using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SAP_BusinessLogic.Entity
{
    public class AccountSignatories
    {
        [Key]
        public int AccountSignatoriesID { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string AccountSignatories1 { get; set; }
        public string AccountSignatories2 { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
