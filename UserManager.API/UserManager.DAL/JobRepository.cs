using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UserManager.DAL.Interface;
using UserManager.Domain.Reponse;
using UserManager.Domain.Request;
using static Dapper.SqlMapper;

namespace UserManager.DAL
{
    public class JobRepository : BaseRepository, IJobRepository
    {
        public int CreateNewJob(CreateNewJob request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();              
                parameters.Add("@job_code", request.job_code);
                parameters.Add("@job_name", request.job_name);
                parameters.Add("@job_description", request.job_description);
                int id = SqlMapper.ExecuteScalar<int>(con, "CreateNewJob", param: parameters, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public bool DeleteJob(int Id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@job_id", Id);               
                var result = SqlMapper.ExecuteScalar<bool>(con, "DeleteJob", param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public int EditJob(EditJob request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@job_id", request.job_id);
                parameters.Add("@job_code", request.job_code);
                parameters.Add("@job_name", request.job_name);
                parameters.Add("@job_description", request.job_description);
                int id = SqlMapper.ExecuteScalar<int>(con, "EditJob", param: parameters, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }

        public Job GetJobById(int Id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@job_id", Id);
                Job JobbyId = SqlMapper.Query<Job>(con, "GetJobById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return JobbyId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Job> JobList()
        {
            IList<Job> JobList = SqlMapper.Query<Job>(con, "JobList", commandType: CommandType.StoredProcedure).ToList();
            return JobList;
        }
    }
}
