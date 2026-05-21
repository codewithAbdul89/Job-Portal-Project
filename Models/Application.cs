using System;

namespace JobPortalSystemProject.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }

        public int UserId { get; set; }

        public int JobId { get; set; }

        public DateTime ApplyDate { get; set; }

        public string Status { get; set; }

        public Application()
        {
            ApplyDate = DateTime.Now;

            Status = "Pending";
        }
    }
}