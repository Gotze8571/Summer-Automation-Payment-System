using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SAP_BusinessLogic.Entity
{
    public class Customer
    {
        [Key]
        public Guid CustomerID { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Address { get; set; }
        public string Customer_PhoneNo { get; set; }
        public string Customer_Status { get; set; }
        public Product Customer_Product { get; set; }
        public Order Customer_Order { get; set; }
        public DateTime Created_Date { get; set; }
    }
}
