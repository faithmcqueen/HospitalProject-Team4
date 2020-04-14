using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalProject_Team4.Models
{
    public class Article
    {
       /*
        Articles are for creating new articles on the website. 
        It has a many-many relationship with the users(authors) table.
        It uses the following parametres:
        article_id int auto-increment not null
        title string not null
        date datetime not null
        image null
        content string not null

        Will reference user_id from aspnetusers table
         */

        [Key]

        public int article_id { get; set; }
        public string title { get; set; }
        public DateTime date { get; set; }
        public string content { get; set; }

        //reference user_id from aspnetusers table
        //getting errors when I try to connect to it though
        //created an authors table
        public ICollection<Author> Authors { get; set; }
    }
}