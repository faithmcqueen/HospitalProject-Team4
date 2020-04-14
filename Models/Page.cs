using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalProject_Team4.Models
{
    public class Page
    {
        /*
           MVP Page class is for creating new page on the website. 
           One to One relationship with navigation class
           Needed data:
           page id - auto increment, not null
           title - null, can be the same/different as nav title
           image - can be null
           content - large text area, not null
         */
        [Key]

        public int page_id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
    }
}