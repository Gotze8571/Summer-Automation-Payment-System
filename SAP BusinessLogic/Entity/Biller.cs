using System;
using System.Collections.Generic;
using System.Text;

namespace SAP_BusinessLogic.Entity
{
    public class Biller : GeneralEntity
    {
        public string Quantity { get; set; }
        public decimal BillRate { get; set; }
        public string VendorName { get; set; }


    }
}
