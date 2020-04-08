using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalProject_Team4.Models
{
    public class Donation
    {
        [Key]
        public int DonationID { get; set; }

        /*----------foreign key to users table -----------------*/
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual AspNetUsers AspNetUsers { get; set; }



        public string donor_mail { get; set; }
        public int donation_amount { get; set; }
        public DateTime donated_on { get; set; }
    }
}