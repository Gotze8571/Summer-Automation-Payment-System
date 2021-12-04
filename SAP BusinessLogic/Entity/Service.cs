using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SAP_BusinessLogic.Entity
{
    public class Service
    {
        [Key]
        public Guid ServiceID { get; set; }
        public string Service_Name { get; set; }
        public string Service_Type { get; set; }
        public string Service_Rate { get; set; }
        public DateTime Service_TimeStamp { get; set; }
        public Order Service_Order { get; set; }

    }
}
