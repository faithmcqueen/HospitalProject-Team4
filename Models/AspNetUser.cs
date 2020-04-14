using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalProject_Team4.Models
{
    public class AspNetUser
    {
        [Key]
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public string home_phone { get; set; }
        public string dob { get; set; }
        public string cell_phone { get; set; }
        public string gender { get; set; }
        public string username { get; set; }
        public string password { get; set; }


    }
}