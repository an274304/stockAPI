using ApplicationLayer.IServices.Admin.Currency;
using DomainLayer.V1.DTOs;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockApproval.Controllers.V1.Admin.Currency
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _CurrencyService;
        public CurrencyController(ICurrencyService CurrencyService)
        {
            _CurrencyService = CurrencyService;
        }

        [HttpPost("save")]
        public IActionResult SaveCurrency([FromForm] CurrencyMaster Currency, [FromForm] IFormFile file)
        {
            try
            {
                var isSave = _CurrencyService.SaveCurrency(Currency, file);

                if (isSave > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Currency Saved",
                        result = true,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Currency Failed To Save",
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
        public IActionResult UpdateCurrency([FromForm] CurrencyMaster Currency, [FromForm] IFormFile file)
        {
            try
            {
                var isUpdate = _CurrencyService.UpdateCurrency(Currency, file);

                if (isUpdate > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Currency Updated",
                        result = true,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Currency Failed To Update",
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

        [HttpDelete("delete/{CurrencyId}")]
        public IActionResult DeleteCurrencyById([FromRoute] int CurrencyId)
        {
            try
            {
                var isDeleted = _CurrencyService.DeleteCurrencyById(CurrencyId);

                if (isDeleted > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Currency Deleted",
                        result = true,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Currency Deletion Fail",
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
        public IActionResult GetAllCurrency()
        {
            try
            {
                var Currencys = _CurrencyService.GetAllCurrency();

                if (Currencys == null || !Currencys.Any())
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
                    var response = new ApiResult<CurrencyMaster>
                    {
                        message = "List Of Currency",
                        result = true,
                        dataList = Currencys.ToList()
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

        [HttpGet("get/{CurrencyId}")]
        public IActionResult GetCurrencyById([FromRoute] int CurrencyId)
        {
            try
            {
                var Currency = _CurrencyService.GetCurrencyById(CurrencyId);

                if (Currency != null)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Detail Of Currency",
                        result = true,
                        data = Currency
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Fail To Get Currency",
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
