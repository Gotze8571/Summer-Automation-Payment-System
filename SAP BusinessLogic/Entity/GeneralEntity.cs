using System;
using System.Collections.Generic;
using System.Text;

namespace SAP_BusinessLogic.Entity
{
    public class GeneralEntity
    {
        public int Id { get; set; }
        public DateTime LogDate { get; set; }
        public string ItemName { get; set; }
        public string TransactionId { get; set; }
        public DateTime Trans_Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Commission { get; set; }
       
    }
}
