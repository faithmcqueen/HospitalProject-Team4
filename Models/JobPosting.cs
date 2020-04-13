using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalProject_Team4.Models
{
    public class JobPosting
    {
        [Key]
        public int PostingID { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string Accepter { get; set; }
        public DateTime ApplicationDeadline { get; set; }

        //Representing the Many in (One Department to Many Job Postings)
        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual Department Departments { get; set; }

        //public ICollection<Department> Departments { get; set; }


    }
}