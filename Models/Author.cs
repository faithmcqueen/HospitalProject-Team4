using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalProject_Team4.Models
{
    public class Author
    {
        /*
         Authors are people who can write, update, and delete articles. 
         This is meant to be a role in the users table but I couldn't 
         get it to connect properly so I chose to create a new table 
         instead.
         Has the following coloumns:
         author_id int, auto increment
         first_name string
         last_name string

         It will reference the Articles table for a many to many relationship.
         */
        [Key]

        public int author_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

        //Representing the Many to Many relationship with the articles
        public ICollection<Article> Articles { get; set; }
    }
}