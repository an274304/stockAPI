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
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _PurchaseService;
        public PurchaseController(IPurchaseService PurchaseService)
        {
            _PurchaseService = PurchaseService;
        }


        [HttpPost("PurchaseOrder")]
        public IActionResult PurchaseOrder([FromBody] PurchaseOrderWitItems purchaseOrderWitItems)
        {
            try
            {
                var PurchaseOrder = _PurchaseService.PurchaseOrder(purchaseOrderWitItems);

                if (PurchaseOrder.Id > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Purchase Order Saved",
                        result = true,
                        data = PurchaseOrder
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Purchase Order Failed To Save",
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

        [HttpPut("ItemsApproveByDirector")]
        public IActionResult ItemsApproveByDirector([FromQuery] string purchaseOrderNo)
        {
            try
            {
                var result = _PurchaseService.ItemsApproveByDirector(purchaseOrderNo);

                if (result > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Items Approve By Director Success",
                        result = true
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Items Not Approve By Director",
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

        [HttpPut("ItemsRejectByDirector")]
        public IActionResult ItemsRejectByDirector([FromQuery] string purchaseOrderNo)
        {
            try
            {
                var result = _PurchaseService.ItemsRejectByDirector(purchaseOrderNo);

                if (result > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Items Rejected By Director",
                        result = true
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Items Rejection Failed By Director",
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

        [HttpPut("RemoveItemByDirector")]
        public IActionResult RemoveItemByDirector([FromQuery] int purchaseItemId)
        {
            try
            {
                var result = _PurchaseService.RemoveItemByDirector(purchaseItemId);

                if (result > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Items Removed By Director",
                        result = true
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Items Removed Failed By Director",
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

        [HttpPut("ItemsSendToVendor")]
        public IActionResult ItemsSendToVendor([FromQuery] string purchaseOrderNo)
        {
            try
            {
                var result = _PurchaseService.ItemsSendToVendor(purchaseOrderNo);

                if (result > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Successfully Sent To Vendor",
                        result = true
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Failed Sent To Vendor",
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

        [HttpPut("ReceivedItemsUpdate")]
        public IActionResult ReceivedItemsUpdate([FromBody] PurchaseOrderWitItems updateOrder)
        {
            try
            {
                var result = _PurchaseService.ReceivedItemsUpdate(updateOrder);

                if (result > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Items Updated Successfully",
                        result = true
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Failed To Update",
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

        [HttpGet("GetReceivedItemsForUpdate")]
        public IActionResult GetReceivedItemsForUpdate([FromQuery] string purchaseOrderNo)
        {
            try
            {
                PurchaseOrderWitItems result = _PurchaseService.GetReceivedItemsForUpdate(purchaseOrderNo);

                if (result != null)
                {
                    var response = new ApiResult<object>
                    {
                        message = "All Received Items For Update",
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

        [HttpPut("BillSendTOAcctsAndStock")]
        public IActionResult BillSendTOAcctsAndStock([FromForm] string purchaseOrderNo, [FromForm] IFormFile file)
        {
            try
            {
                var result = _PurchaseService.BillSendTOAcctsAndStock(purchaseOrderNo, file);

                if (result > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Items Successfully Send To Accts & Stock",
                        result = true
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Failed To Send To Accts & Stock",
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

        [HttpPatch("UploadPayedReceiptForBill")]
        public IActionResult UploadPayedReceiptForBill([FromForm] string purchaseOrderNo, [FromForm] IFormFile file)
        {
            try
            {
                var result = _PurchaseService.UploadPayedReceiptForBill(purchaseOrderNo, file);

                if (result > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Receipt Upload Successfully",
                        result = true
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Receipt Failed To Upload",
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
