using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalProject_Team4.Models
{
    public class Feedback
    {
        [Key]
        public int feedback_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string feedback_subject { get; set; }
        public string feedback_message { get; set; }
        public DateTime feedback_date { get; set; }
    }
}
