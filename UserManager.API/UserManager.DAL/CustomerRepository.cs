using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UserManager.DAL.Interface;
using UserManager.Domain.Reponse;
using UserManager.Domain.Request;

namespace UserManager.DAL
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public IList<Customer> AllCustomer()
        {
            IList<Customer> CustomerList = SqlMapper.Query<Customer>(con, "Cus_GetAllCustomer", commandType: CommandType.StoredProcedure).ToList();
            return CustomerList;
        }

        public int CreateNewCustomer(CreateNewCustomer request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();                
                parameters.Add("@first_name", request.first_name);
                parameters.Add("@last_name", request.last_name);
                parameters.Add("@gender", request.gender);
                parameters.Add("@address", request.address);
                parameters.Add("@city", request.city);
                parameters.Add("@email", request.email);
                parameters.Add("@phone_number", request.phone_number);
                parameters.Add("@description", request.description);
                parameters.Add("@job_id", request.job_id);
                parameters.Add("@imgUrl", request.imgUrl);
                int id = SqlMapper.ExecuteScalar<int>(con, "Cus_CreateNewCustomer", param: parameters, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public Customer CustomerbById(int customer_id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@customer_id", customer_id);
                Customer CustomerById = SqlMapper.Query<Customer>(con, "Cus_CustomerById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return CustomerById;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public IList<Customer> CustomerList()
        //{
        //    IList<Customer> CustomerList = SqlMapper.Query<Customer>(con, "Cus_CustomerByJob", commandType: CommandType.StoredProcedure).ToList();
        //    return CustomerList;
        //}

        public IList<Customer> CustomerList(int job_id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@job_id", job_id);
            IList<Customer> CustomerList = SqlMapper.Query<Customer>(con, "Cus_CustomerByJob", parameters, commandType: CommandType.StoredProcedure).ToList();
            return CustomerList;
        }

        public bool DeleteCustomer(int customer_id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@customer_id", customer_id);
                var result = SqlMapper.ExecuteScalar<bool>(con, "DeleteCustomer", param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }     

        public int EditCustomer(EditCustomer request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@customer_id", request.customer_id);
                parameters.Add("@first_name", request.first_name);
                parameters.Add("@last_name", request.last_name);
                parameters.Add("@gender", request.gender);
                parameters.Add("@address", request.address);
                parameters.Add("@city", request.city);
                parameters.Add("@email", request.email);
                parameters.Add("@phone_number", request.phone_number);
                parameters.Add("@description", request.description);
                parameters.Add("@job_id", request.job_id);
                parameters.Add("@imgUrl", request.imgUrl);
                int id = SqlMapper.ExecuteScalar<int>(con, "Cus_EditCustomer", param: parameters, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
