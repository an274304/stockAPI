using ApplicationLayer.IServices.Admin.Auth;
using DomainLayer.AuthDTOs;
using DomainLayer.V1.DTOs;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StockApproval.Controllers.Auth
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtOption _jwtOptions;
        private readonly IAuthService _authService;

        public AuthController(IOptions<JwtOption> jwtOptions, IAuthService authService)
        {
            _jwtOptions = jwtOptions.Value;
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LogInDTO logIn)
        {
            // Authenticate user with the provided credentials
            UserMaster user = _authService.Login(logIn);

            if (user != null)
            {
                // Generate JWT token upon successful login
                var token = GenerateJwtToken(user);
                return Ok(new
                {
                    token = token,
                    userName = user.UsName,
                    userId = user.Id,
                    userRole = user.UsTypeName
                });
            }

            return BadRequest(new { message = "Invalid username or password" });
        }

        private string GenerateJwtToken(UserMaster user)
        {
            // Retrieve the JWT key and signing credentials
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Define claims for the token (email, name, and custom userId claim)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.UsEmail),
                new Claim(ClaimTypes.Name, user.UsName),
                new Claim("userId", user.Id.ToString())
            };

            // Set token expiration (1 hour) and issuer/audience settings
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Set token expiration
                signingCredentials: credentials
            );

            // Generate and return the token
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        [HttpGet("GetAllUserType")]
        public IActionResult GetAllUserType()
        {
            try
            {
                // Fetch all user types from the service
                var userTypes = _authService.GetAllUserType();

                if (userTypes == null || !userTypes.Any())
                {
                    return Ok(new ApiResult<object>
                    {
                        message = "No user types found.",
                        result = false,
                        data = null
                    });
                }

                return Ok(new ApiResult<UserTypeMaster>
                {
                    message = "List of User Types",
                    result = true,
                    dataList = userTypes.ToList()
                });
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return a 500 error
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResult<object>
                {
                    message = ex.Message,
                    result = false,
                    data = null
                });
            }
        }
    }
}
