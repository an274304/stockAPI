using ApplicationLayer.IServices.Admin.Purchase;
using DomainLayer.V1.DTOs;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockApproval.Controllers.V1.Admin.Purchase
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class PurchaseTableController : ControllerBase
    {
        private readonly IPurchaseTableService _PurchaseTableService;
        public PurchaseTableController(IPurchaseTableService purchaseTableService)
        {
            _PurchaseTableService = purchaseTableService;
        }

        [HttpGet("GetApprovalPendingOrderAtAdmin")]
        public IActionResult GetApprovalPendingOrderAtAdmin()
        {
            try
            {
                var PurchaseOrders = _PurchaseTableService.GetApprovalPendingOrderAtAdmin();

                if (PurchaseOrders.Any())
                {
                    var response = new ApiResult<PurchaseOrder>
                    {
                        message = "List Of Purchase Order",
                        result = true,
                        dataList = PurchaseOrders
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<PurchaseOrder>
                    {
                        message = "No Purchase Order Are Found",
                        result = false,
                        dataList = null
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResult<PurchaseOrder>
                {
                    message = ex.Message.ToString(),
                    result = false,
                    data = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet("GetRejectedOrderAtAdmin")]
        public IActionResult GetRejectedOrderAtAdmin()
        {
            try
            {
                var PurchaseOrders = _PurchaseTableService.GetRejectedOrderAtAdmin();

                if (PurchaseOrders.Any())
                {
                    var response = new ApiResult<PurchaseOrder>
                    {
                        message = "List Of Purchase Order",
                        result = true,
                        dataList = PurchaseOrders
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<PurchaseOrder>
                    {
                        message = "No Purchase Order Are Found",
                        result = false,
                        dataList = null
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResult<PurchaseOrder>
                {
                    message = ex.Message.ToString(),
                    result = false,
                    data = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet("GetApprovedOrderAtAdmin")]
        public IActionResult GetApprovedOrderAtAdmin()
        {
            try
            {
                var PurchaseOrders = _PurchaseTableService.GetApprovedOrderAtAdmin();

                if (PurchaseOrders.Any())
                {
                    var response = new ApiResult<PurchaseOrder>
                    {
                        message = "List Of Purchase Order",
                        result = true,
                        dataList = PurchaseOrders
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<PurchaseOrder>
                    {
                        message = "No Purchase Order Are Found",
                        result = false,
                        dataList = null
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResult<PurchaseOrder>
                {
                    message = ex.Message.ToString(),
                    result = false,
                    data = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet("GetWaitingOrderAtAdmin")]
        public IActionResult GetWaitingOrderAtAdmin()
        {
            try
            {
                var PurchaseOrders = _PurchaseTableService.GetWaitingOrderAtAdmin();

                if (PurchaseOrders.Any())
                {
                    var response = new ApiResult<PurchaseOrder>
                    {
                        message = "List Of Purchase Order",
                        result = true,
                        dataList = PurchaseOrders
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<PurchaseOrder>
                    {
                        message = "No Purchase Order Are Found",
                        result = false,
                        dataList = null
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResult<PurchaseOrder>
                {
                    message = ex.Message.ToString(),
                    result = false,
                    data = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet("GetOrderToApproveAtDirector")]
        public IActionResult GetOrderToApproveAtDirector()
        {
            try
            {
                var PurchaseOrders = _PurchaseTableService.GetOrderToApproveAtDirector();

                if (PurchaseOrders.Any())
                {
                    var response = new ApiResult<PurchaseOrder>
                    {
                        message = "List Of Purchase Order",
                        result = true,
                        dataList = PurchaseOrders
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<PurchaseOrder>
                    {
                        message = "No Purchase Order Are Found",
                        result = false,
                        dataList = null
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResult<PurchaseOrder>
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
