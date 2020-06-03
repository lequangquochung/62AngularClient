using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UserManager.Domain.Reponse
{
    public class Customer
    {
       
        public int customer_id { get; set; }
        [DisplayName("First Name")]
        public string first_name { get; set; }
        [DisplayName("Last Name")]
        public string last_name { get; set; }
        [DisplayName("Gender")]
        public string gender { get; set; }
        [DisplayName("Address")]
        public string address { get; set; }
        [DisplayName("City")]
        public string city { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("Phone Number")]
        public string phone_number { get; set; }
        [DisplayName("Description")]
        public string description { get; set; }
        [DisplayName("Job")]
        public string job_name { get; set; }
        public string imgUrl { get; set; }

    }
}
