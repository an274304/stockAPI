using ApplicationLayer.IServices.Admin.Stock;
using DomainLayer.V1.DTOs;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StockApproval.Controllers.V1.Admin.Stock
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class StockController : ControllerBase
    {
        private readonly IStockService _StockService;
        public StockController(IStockService stockService)
        {
            _StockService = stockService;
        }

        [HttpGet("GetNewStockAtAdmin")]
        public IActionResult GetNewStockAtAdmin()
        {
            try
            {
                List<PurchaseOrder> result = _StockService.GetNewStockAtAdmin();

                if (result != null)
                {
                    var response = new ApiResult<PurchaseOrder>
                    {
                        message = "New Stocks",
                        result = true,
                        dataList = result
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Failed To Fetch",
                        result = false
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

        [HttpGet("GetNewStockItemsAtAdmin")]
        public IActionResult GetNewStockItemsAtAdmin([FromQuery] string purchaseOrderNo)
        {
            try
            {
                PurchaseOrderWitItems result = _StockService.GetNewStockItemsAtAdmin(purchaseOrderNo);

                if (result != null)
                {
                    var response = new ApiResult<object>
                    {
                        message = "All Received Items For Stock",
                        result = true,
                        data = result
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Failed To Fetch",
                        result = false
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

        [HttpPut("UpdateNewStockItem")]
        public IActionResult UpdateNewStockItem(IEnumerable<UpdateNewStockItem> newStockItems)
        {
            try
            {
                int result = _StockService.UpdateNewStockItem(newStockItems);

                if (result > 0)
                {
                    var response = new ApiResult<PurchaseOrder>
                    {
                        message = "Succesfully Updated Stocks",
                        result = true,
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Failed To Fetch",
                        result = false
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

        [HttpGet("loadUpdatedStockMasterItems")]
        public IActionResult loadUpdatedStockMasterItems([FromQuery] string purchaseOrderNo)
        {
            try
            {
                List<StockItemMaster> result = _StockService.loadUpdatedStockMasterItems(purchaseOrderNo);

                if (result.Any())
                {
                    var response = new ApiResult<StockItemMaster>
                    {
                        message = "All Updated Items In Stock",
                        result = true,
                        dataList = result
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "No Items Found",
                        result = false
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
