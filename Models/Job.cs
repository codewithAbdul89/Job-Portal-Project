using System;


namespace JobPortalSystemProject.Models
{
    public class Job
    {
        public int JobId { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Location { get; set; }

        public string Salary { get; set; }

        public string Description { get; set; }


        public Job()
        {
            Title = string.Empty;
            Company = string.Empty;
            Location = string.Empty;
            Salary = string.Empty;
            Description = string.Empty;
        }
    }
}
