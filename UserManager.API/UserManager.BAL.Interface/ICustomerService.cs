using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Domain.Reponse;
using UserManager.Domain.Request;

namespace UserManager.BAL.Interface
{
    public interface ICustomerService
    {
        IList<Customer> CustomerList(int job_id);
        IList<Customer> AllCustomer();
        Customer CustomerById(int customer_id);
        int CreateNewCustomer(CreateNewCustomer request);
        int EditCustomer(EditCustomer request);
        bool DeleteCustomer(int customer_id);
    }
}
