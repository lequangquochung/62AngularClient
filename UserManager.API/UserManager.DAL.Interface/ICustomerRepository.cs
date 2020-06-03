using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Domain.Reponse;
using UserManager.Domain.Request;

namespace UserManager.DAL.Interface
{
    public interface ICustomerRepository
    {
        IList<Customer> CustomerList(int job_id);
        IList<Customer> AllCustomer();
        Customer CustomerbById(int customer_id);
        int CreateNewCustomer(CreateNewCustomer request);
        int EditCustomer(EditCustomer request);
        bool DeleteCustomer(int customer_id);
    }
}
