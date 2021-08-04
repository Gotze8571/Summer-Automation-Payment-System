using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SAP_BusinessLogic.Entity
{
    public class Tracker
    {
        [Key]
        public int TrackerID { get; set; }
        public string Tracker_Name { get; set; }
        public string Tracker_Type { get; set; }
        public DateTime Tracker_Created_Date { get; set; }

    }
}
