using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalProject_Team4.Models.ViewModels
{
    public class UpdatePosting
    {
        //Get information about job posting that we will be updating
        public JobPosting JobPostings { get; set; }

        //We also need a list of the departments to make our dropdown work
        public List<Department> Departments { get; set; }
    }
}