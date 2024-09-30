using ApplicationLayer.Implementations.Admin.Purchase;
using ApplicationLayer.IServices.Admin.Purchase;
using ApplicationLayer.IServices.Director.VendorBill;
using DomainLayer.V1.DTOs;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StockApproval.Controllers.V1.Director.VendorBill
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class VendorBillTableController : ControllerBase
    {
        private readonly IVendorBillTableService _vendorBillTable;
        public VendorBillTableController(IVendorBillTableService vendorBillTable)
        {
            _vendorBillTable = vendorBillTable;
        }

        [HttpGet("GetPendingBillAtDirector")]
        public IActionResult GetPendingBillAtDirector()
        {
            try
            {
                var PurchaseOrders = _vendorBillTable.GetPendingBillAtDirector();

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

        [HttpGet("GetApprovedBillAtDirector")]
        public IActionResult GetApprovedBillAtDirector()
        {
            try
            {
                var PurchaseOrders = _vendorBillTable.GetApprovedBillAtDirector();

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

        [HttpGet("GetRejectedBillAtDirector")]
        public IActionResult GetRejectedBillAtDirector()
        {
            try
            {
                var PurchaseOrders = _vendorBillTable.GetRejectedBillAtDirector();

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
