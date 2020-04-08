using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalProject_Team4.Models
{
    public class VolunteerRecruitment
    {
        [Key]
        public int volunteer_id { get; set; }
        public int user_id { get; set; }
        [ForeignKey("user_id")]

        public virtual AspNetUsers AspNetUsers { get; set; }
        public int HasFile { get; set; }
        public string volunteer_FileExtension { get; set; }
        public string volunteer_specialization { get; set; }
        public string volunteer_status { get; set; }


    }
}