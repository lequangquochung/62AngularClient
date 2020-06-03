using System;
using System.Collections.Generic;
using System.Text;
using UserManager.BAL.Interface;
using UserManager.DAL.Interface;
using UserManager.Domain.Reponse;
using UserManager.Domain.Request;

namespace UserManager.BAL
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        public CustomerService (ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public int CreateNewCustomer(CreateNewCustomer request)
        {
            return _customerRepository.CreateNewCustomer(request);
        }

        public Customer CustomerById(int customer_id)
        {
            return _customerRepository.CustomerbById(customer_id);
        }

        public bool DeleteCustomer(int customer_id)
        {
            return _customerRepository.DeleteCustomer(customer_id);
        }

        public int EditCustomer(EditCustomer request)
        {
            return _customerRepository.EditCustomer(request);
        }

        public IList<Customer> CustomerList(int job_id)
        {
            return _customerRepository.CustomerList(job_id);
        }

        public IList<Customer> AllCustomer()
        {
            return _customerRepository.AllCustomer();
        }
    }
}
