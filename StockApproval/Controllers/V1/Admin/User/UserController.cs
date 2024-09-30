using ApplicationLayer.IServices.Admin.User;
using DomainLayer.V1.DTOs;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockApproval.Controllers.V1.Admin.User
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        [HttpPost("save")]
        public IActionResult SaveUser([FromForm] UserMaster User, [FromForm] IFormFile file)
        {
            try
            {
                var isSave = _UserService.SaveUser(User, file);

                if (isSave > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "User Saved",
                        result = true,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "User Failed To Save",
                        result = false,
                        data = null
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResult<object>
                {
                    message = ex.Message.ToString(),
                    result = false,
                    data = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateUser([FromForm] UserMaster User, [FromForm] IFormFile file)
        {
            try
            {
                var isUpdate = _UserService.UpdateUser(User, file);

                if (isUpdate > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "User Updated",
                        result = true,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "User Failed To Update",
                        result = false,
                        data = null
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResult<object>
                {
                    message = ex.Message.ToString(),
                    result = false,
                    data = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpDelete("delete/{UserId}")]
        public IActionResult DeleteUserById([FromRoute] int UserId)
        {
            try
            {
                var isDeleted = _UserService.DeleteUserById(UserId);

                if (isDeleted > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "User Deleted",
                        result = true,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "User Deletion Fail",
                        result = false,
                        data = null
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResult<object>
                {
                    message = ex.Message.ToString(),
                    result = false,
                    data = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet("all")]
        public IActionResult GetAllUser()
        {
            try
            {
                var Users = _UserService.GetAllUser();

                if (Users == null || !Users.Any())
                {
                    var response = new ApiResult<object>
                    {
                        message = "No categories found.",
                        result = false,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<UserMaster>
                    {
                        message = "List Of User",
                        result = true,
                        dataList = Users.ToList()
                    };

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResult<object>
                {
                    message = ex.Message.ToString(),
                    result = false,
                    data = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet("get/{UserId}")]
        public IActionResult GetUserById([FromRoute] int UserId)
        {
            try
            {
                var User = _UserService.GetUserById(UserId);

                if (User != null)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Detail Of User",
                        result = true,
                        data = User
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Fail To Get User",
                        result = false,
                        data = null
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResult<object>
                {
                    message = ex.Message.ToString(),
                    result = false,
                    data = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
