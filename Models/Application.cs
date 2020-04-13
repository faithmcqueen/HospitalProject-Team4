using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalProject_Team4.Models
{
    public class Application
    {
        [Key]
        public int ApplicationID { get; set; }
        public Boolean Resume { get; set; }
        public string FormerEmployer { get; set; }
        public string Reference1_Name { get; set; }
        public string Reference1_Email { get; set; }
        public string Reference2_Name { get; set; }
        public string Reference2_Email { get; set; }
        public string Reference3_Name { get; set; }
        public string Reference3_Email { get; set; }

    }
}