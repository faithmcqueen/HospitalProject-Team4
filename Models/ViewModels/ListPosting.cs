using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalProject_Team4.Models.ViewModels
{
    public class ListPostings
    {
        //Get all job posting information to display in lists
        public JobPosting JobPosting { get; set; }

        public List<JobPosting> JobPostings { get; set; }

        //We will need the names of the departments so we can access with the department ID in JobPostings table
        public List<Department> Departments { get; set; }
        public Department Department { get; set; }
    }
}