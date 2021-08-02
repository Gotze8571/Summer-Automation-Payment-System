using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAP_BusinessLogic.Models.Database.Logs
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public virtual DbSet<AuditLog> tbl_auditLog_SAP { get; set; }
        public virtual DbSet<ErrorLog> tbl_errorLog_SAP { get; set; }
    }
}
