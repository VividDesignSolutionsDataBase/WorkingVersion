using System;
using System.ComponentModel.DataAnnotations;

namespace MvcAppSearch.Models
{

    public enum Status
    {
        A, B, C
    }

    public class Report
    {
        [Key] public int ReportNo { get; set; }
        public int InmateID { get; set; }
        public int OfficerID { get; set; }
        public Status? Status { get; set; }

        public virtual Officer Officer { get; set; }
        public virtual Inmate Inmate { get; set; }

        
    }
}