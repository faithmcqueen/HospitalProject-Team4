using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalProject_Team4.Models
{
    public class AspNetUserRoles
    {

        [Key]
        public int userrole_id { get; set; }
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual AspNetUsers AspNetUsers { get; set; }

        public int role_id { get; set; }
        [ForeignKey("role_id")]
        public virtual AspNetRoles AspNetRoles { get; set; }
    }
}