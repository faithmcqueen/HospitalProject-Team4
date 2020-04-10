using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalProject_Team4.Models
{
    public class MessageCategory
    {
        [Key]
        public int category_id { get; set; }
        public string category_name { get; set; }


        //Representing "Many to One" relation (One Brand to many Products)   
        public ICollection<ContactUs> ContactUs { get; set; }
    }
}

