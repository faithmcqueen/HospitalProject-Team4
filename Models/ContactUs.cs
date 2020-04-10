using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalProject_Team4.Models
{
    public class ContactUs
    {
        [Key]
        public int message_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string cell_phone { get; set; }
        public string question { get; set; }
        public DateTime date { get; set; }
        public int category_id { get; set; }
        public string reply { get; set; }

        [ForeignKey("category_id")]
        public virtual MessageCategory MessageCategories { get; set; }
    }
}
