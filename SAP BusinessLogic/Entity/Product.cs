using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SAP_BusinessLogic.Entity
{
    public class Product
    {
        [Key]
        public Guid ProductID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Price { get; set; }
        public string Product_Type { get; set; }
        public Customer CustomerID { get; set; }
    }
}
