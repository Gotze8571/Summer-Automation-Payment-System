using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SAP_BusinessLogic.Entity
{
    public class Tracker
    {
        [Key]
        public Guid TrackerID { get; set; }
        public string Tracker_Name { get; set; }
        public string Tracker_Type { get; set; }
        public Order Order_Number { get; set; }
        public Customer Customer_Address { get; set; }
        public Service Service_Type { get; set; }
        public Product Product_Type { get; set; }
        public DateTime Tracker_Date { get; set; }

    }
}
