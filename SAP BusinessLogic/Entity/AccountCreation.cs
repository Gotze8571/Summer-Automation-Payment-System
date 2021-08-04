using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SAP_BusinessLogic.Entity
{
    public class AccountCreation
    {
        [Key]
        public int AccountID { get; set; }
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public string Status { get; set; }
        public string AccountSignatoriesName { get; set; }
    }
}
