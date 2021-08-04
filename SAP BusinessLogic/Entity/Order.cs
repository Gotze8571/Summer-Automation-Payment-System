using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SAP_BusinessLogic.Entity
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string Order_Name { get; set; }
        public string Order_Type { get; set; }
        public string Order_Status { get; set; }
        public int TrackerID { get; set; }
        public DateTime Order_Date { get; set; }
    }
}
