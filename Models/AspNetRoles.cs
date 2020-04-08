using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalProject_Team4.Models
{
    public class AspNetRoles
    {
        [Key, ForeignKey("ApplicationUser")]
        public int role_id { get; set; }

        public string role { get; set; }
    }
}