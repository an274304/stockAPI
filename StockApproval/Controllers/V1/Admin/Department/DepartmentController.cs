using ApplicationLayer.IServices.Admin.Department;
using DomainLayer.V1.DTOs;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockApproval.Controllers.V1.Admin.Department
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _DepartmentService;
        public DepartmentController(IDepartmentService DepartmentService)
        {
            _DepartmentService = DepartmentService;
        }

        [HttpPost("save")]
        public IActionResult SaveDepartment([FromForm] DepartmentMaster Department, [FromForm] IFormFile file)
        {
            try
            {
                var isSave = _DepartmentService.SaveDepartment(Department, file);

                if (isSave > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Department Saved",
                        result = true,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Department Failed To Save",
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
        public IActionResult UpdateDepartment([FromForm] DepartmentMaster Department, [FromForm] IFormFile file)
        {
            try
            {
                var isUpdate = _DepartmentService.UpdateDepartment(Department, file);

                if (isUpdate > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Department Updated",
                        result = true,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Department Failed To Update",
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

        [HttpDelete("delete/{DepartmentId}")]
        public IActionResult DeleteDepartmentById([FromRoute] int DepartmentId)
        {
            try
            {
                var isDeleted = _DepartmentService.DeleteDepartmentById(DepartmentId);

                if (isDeleted > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Department Deleted",
                        result = true,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Department Deletion Fail",
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
        public IActionResult GetAllDepartment()
        {
            try
            {
                var categories = _DepartmentService.GetAllDepartment();

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
                    var response = new ApiResult<DepartmentMaster>
                    {
                        message = "List Of Department",
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

        [HttpGet("get/{DepartmentId}")]
        public IActionResult GetDepartmentById([FromRoute] int DepartmentId)
        {
            try
            {
                var Department = _DepartmentService.GetDepartmentById(DepartmentId);

                if (Department != null)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Detail Of Department",
                        result = true,
                        data = Department
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Fail To Get Department",
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
