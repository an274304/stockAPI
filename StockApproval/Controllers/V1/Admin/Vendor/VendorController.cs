using ApplicationLayer.IServices.Admin.Vendor;
using DomainLayer.V1.DTOs;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockApproval.Controllers.V1.Admin.Vendor
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _VendorService;
        public VendorController(IVendorService VendorService)
        {
            _VendorService = VendorService;
        }

        [HttpPost("save")]
        public IActionResult SaveVendor([FromForm] VendorMaster Vendor, [FromForm] IFormFile file)
        {
            try
            {
                var isSave = _VendorService.SaveVendor(Vendor, file);

                if (isSave > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Vendor Saved",
                        result = true,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Vendor Failed To Save",
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
        public IActionResult UpdateVendor([FromForm] VendorMaster Vendor, [FromForm] IFormFile file)
        {
            try
            {
                var isUpdate = _VendorService.UpdateVendor(Vendor, file);

                if (isUpdate > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Vendor Updated",
                        result = true,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Vendor Failed To Update",
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

        [HttpDelete("delete/{VendorId}")]
        public IActionResult DeleteVendorById([FromRoute] int VendorId)
        {
            try
            {
                var isDeleted = _VendorService.DeleteVendorById(VendorId);

                if (isDeleted > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Vendor Deleted",
                        result = true,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Vendor Deletion Fail",
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
        public IActionResult GetAllVendor()
        {
            try
            {
                var vendors = _VendorService.GetAllVendor();

                if (vendors == null || !vendors.Any())
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
                    var response = new ApiResult<VendorMaster>
                    {
                        message = "List Of Vendor",
                        result = true,
                        dataList = vendors.ToList()
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

        [HttpGet("get/{VendorId}")]
        public IActionResult GetVendorById([FromRoute] int VendorId)
        {
            try
            {
                var Vendor = _VendorService.GetVendorById(VendorId);

                if (Vendor != null)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Detail Of Vendor",
                        result = true,
                        data = Vendor
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Fail To Get Vendor",
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
