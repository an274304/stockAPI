using ApplicationLayer.IServices.Account.VendorBill;
using ApplicationLayer.IServices.Director.VendorBill;
using DomainLayer.V1.DTOs;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockApproval.Controllers.V1.Account.VendorBill
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
   // [Authorize]
    public class VendorBillTableAccountController : ControllerBase
    {
        private readonly IVendorBillTableAccountService _vendorBillTableAccount;
        public VendorBillTableAccountController(IVendorBillTableAccountService vendorBillTableAccount)
        {
            _vendorBillTableAccount = vendorBillTableAccount;
        }

        [HttpGet("GetPendingBillAtAccount")]
        public IActionResult GetPendingBillAtAccount()
        {
            try
            {
                var PurchaseOrders = _vendorBillTableAccount.GetPendingBillAtAccount();

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


        [HttpGet("GetPayedBillAtAccount")]
        public IActionResult GetPayedBillAtAccount()
        {
            try
            {
                var PurchaseOrders = _vendorBillTableAccount.GetPayedBillAtAccount();

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
