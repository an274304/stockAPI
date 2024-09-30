using DomainLayer.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.V1.DTOs
{
    public class PurchaseOrderWitItems
	{
		public PurchaseOrder? PurchaseOrder { get; set; }
		public List<PurchaseItem>? PurchaseItems { get; set; }
	}
}
