using System;
using System.Collections.Generic;
using System.Text;

namespace SAP_BusinessLogic.DTOs
{
    public class AccountCreationDto
    {
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public decimal AccountBalance { get; set; }
        // Account Status: Active or Freeze
        public string AccountStatus { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public decimal ChargesAmt { get; set; }
        public AccountSignatoriesDto AccountSignatoriesName { get; set; }
    }
}
