using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager.Domain.Reponse
{
    public class Job
    {
        public int job_id { get; set; }
        public string job_code { get; set; }
        public string job_name { get; set; }
        public string job_description { get; set; }
        public int totalCustomer { get; set; }
    }
}
