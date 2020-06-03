using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManager.BAL.Interface;
using UserManager.Domain.Reponse;
using UserManager.Domain.Request;

namespace UserManager.API.Controllers
{
    [ApiController]
   
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        //GET API: get all customer
        [HttpGet]
        [Route("api/customer/AllCustomer")]
        public IEnumerable<Customer> AllCustomer()
        {
            return _customerService.AllCustomer();
        }

        //GET API: Get customer by job_id
        [HttpGet]
        [Route("api/customer/customerlist/{id}")]
        public IEnumerable<Customer> CustomerList(int id)
        {
            return _customerService.CustomerList(id);
        }

        //GET API BY ID
        [HttpGet]
        [Route("api/customer/customerbyid/{id}")]
        public Customer CustomerById (int id)
        {
            return _customerService.CustomerById(id);
        }

        //POST API : Create New Customer
        [HttpPost]
        [Route("api/customer/createnewcustomer")]
        public int CreateNewCustomer([FromBody] CreateNewCustomer request)
        {
            return _customerService.CreateNewCustomer(request);
        }

        //PUT API : Edit customer
        [HttpPut]
        [Route("api/customer/editcustomer")]
        public int EditCustomer([FromBody] EditCustomer request)
        {
            return _customerService.EditCustomer(request);
        }

        //DELETE API : Delete customer
        [HttpDelete]
        [Route("api/customer/deletecustomer/{id}")]
        public bool DelelteCustomer (int id)
        {
            return _customerService.DeleteCustomer(id);
        }
        
    }
}