using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager.Domain.Request
{
    public class EditCustomer
    {
        public int customer_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string description { get; set; }
        public int job_id { get; set; }
        public string imgUrl { get; set; }
    }
}
