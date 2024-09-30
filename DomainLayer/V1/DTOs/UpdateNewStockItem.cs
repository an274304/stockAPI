using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.V1.DTOs
{
	public class UpdateNewStockItem
	{
		public string? PurchaseOrderNo { get; set; }
		public int? PurchaseItemId { get; set; }
		public DateTime? ItemExpiryDt { get; set; }
	}
}
