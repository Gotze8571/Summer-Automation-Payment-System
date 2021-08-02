using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SAP_BusinessLogic.Models.Database.Logs
{
    public class ErrorLog
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public string Level { get; set; }
        [MaxLength(128)]
        public DateTime TimeStamp { get; set; }
        public string Exception { get; set; }
        [MaxLength(40)]
        public string ClientId { get; set; }
        [MaxLength(40)]
        public string CorrelationId { get; set; }
    }
}
