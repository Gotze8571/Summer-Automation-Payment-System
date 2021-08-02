using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SAP_BusinessLogic.Models.Database.Logs
{
    public class AuditLog
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public string Level { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string Exception { get; set; }
        public string LogEvent { get; set; }
        public string MachineName { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public string ResponseCode { get; set; }
        public string Description { get; set; }
        public string ClientId { get; set; }
        public string CorrelationId { get; set; }
        public string ProductId { get; set; }
    }
}
