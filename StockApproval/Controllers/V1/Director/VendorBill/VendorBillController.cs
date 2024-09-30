using ApplicationLayer.IServices.Director.VendorBill;
using DomainLayer.V1.DTOs;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockApproval.Controllers.V1.Director.VendorBill
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class VendorBillController : ControllerBase
    {
        private readonly IVendorBillService _VendorBill;
        public VendorBillController(IVendorBillService VendorBill)
        {
            _VendorBill = VendorBill;
        }

        [HttpGet("GetPendingItemsForApprovalAtDirector")]
        public IActionResult GetPendingItemsForApprovalAtDirector([FromQuery] string purchaseOrderNo)
        {
            try
            {
                var PurchaseOrdersWithItems = _VendorBill.GetPendingItemsForApprovalAtDirector(purchaseOrderNo);

                if (PurchaseOrdersWithItems != null)
                {
                    var response = new ApiResult<PurchaseOrderWitItems>
                    {
                        message = "List Of Purchase Order",
                        result = true,
                        data = PurchaseOrdersWithItems
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
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
