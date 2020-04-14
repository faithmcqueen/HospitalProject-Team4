using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalProject_Team4.Models
{
    public class Navigation
    {
        /*
        MVP navigation table for all menu options. 
        One-One relationship with page
        Needed data:
        nav id - auto increment, not null
        title - not null, doesn't need to be the same as page title
        url - not null, lower case letters and dashes only

        Must reference page id
         */
        [Key]

        public int nav_id { get; set; }
        public string title { get; set; }
        public string url { get; set; }

        //reference pages table
        public int page_id { get; set; }
        [ForeignKey("page_id")]
        public virtual Page pageid { get; set; }
    }
}