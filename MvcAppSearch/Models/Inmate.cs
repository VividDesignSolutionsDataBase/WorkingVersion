using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcAppSearch.Models
{
    public class Inmate
    {
        
        [Key] public int InmateID { get; set;}
        public string LastName {get; set;}
        public string FirstName { get; set;}
        public string Location { get; set; }
        public int FloorNo { get; set; }
        public DateTime ReportDate { get; set; }

        public virtual ICollection<Report> Reports { get; set; }

        

        
    }
}