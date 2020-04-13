using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalProject_Team4.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string Name { get; set; }
    }
}