using ApplicationLayer.IServices.Admin.Branch;
using DomainLayer.V1.DTOs;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace StockApproval.Controllers.V1.Admin.Branch
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _BranchService;
        public BranchController(IBranchService BranchService)
        {
            _BranchService = BranchService;
        }

        [HttpPost("save")]
        public IActionResult SaveBranch([FromForm] BranchMaster Branch, [FromForm] IFormFile file)
        {
            try
            {
                var isSave = _BranchService.SaveBranch(Branch, file);

                if (isSave > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Branch Saved",
                        result = true,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Branch Failed To Save",
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
        public IActionResult UpdateBranch([FromForm] BranchMaster Branch, [FromForm] IFormFile file)
        {
            try
            {
                var isUpdate = _BranchService.UpdateBranch(Branch, file);

                if (isUpdate > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Branch Updated",
                        result = true,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Branch Failed To Update",
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

        [HttpDelete("delete/{BranchId}")]
        public IActionResult DeleteBranchById([FromRoute] int BranchId)
        {
            try
            {
                var isDeleted = _BranchService.DeleteBranchById(BranchId);

                if (isDeleted > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Branch Deleted",
                        result = true,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Branch Deletion Fail",
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
        public IActionResult GetAllBranch()
        {
            try
            {
                var categories = _BranchService.GetAllBranch();

                if (categories == null || !categories.Any())
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
                    var response = new ApiResult<BranchMaster>
                    {
                        message = "List Of Branch",
                        result = true,
                        dataList = categories.ToList()
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

        [HttpGet("get/{BranchId}")]
        public IActionResult GetBranchById([FromRoute] int BranchId)
        {
            try
            {
                var Branch = _BranchService.GetBranchById(BranchId);

                if (Branch != null)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Detail Of Branch",
                        result = true,
                        data = Branch
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Fail To Get Branch",
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
