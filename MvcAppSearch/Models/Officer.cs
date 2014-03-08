using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace MvcAppSearch.Models
{
    public class Officer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key] public int OfficerID { get; set; }
        public string LastName { get; set;}
        public string FirstName{ get; set; }
        public string Role{ get; set;}

        public virtual ICollection<Report>Reports {get;set;}
    
    }

   
}