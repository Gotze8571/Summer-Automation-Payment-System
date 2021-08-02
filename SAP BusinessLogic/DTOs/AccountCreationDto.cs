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
        public DateTime AccountCreationDate { get; set; }
        public string Status { get; set; }
        public AccountSignatoriesDto AccountSignatoriesName { get; set; }
    }
}
