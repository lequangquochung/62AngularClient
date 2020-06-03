using System;
using System.Collections.Generic;
using System.Text;
using UserManager.BAL.Interface;
using UserManager.DAL.Interface;
using UserManager.Domain.Reponse;
using UserManager.Domain.Request;

namespace UserManager.BAL
{
    public class JobService : IJobService
    {
        private IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public int CreateNewJob(CreateNewJob request)
        {

            return _jobRepository.CreateNewJob(request);
        }

        public bool DeleteJob(int Id)
        {
            return _jobRepository.DeleteJob(Id);
        }

        public int EditJob(EditJob request)
        {
            return _jobRepository.EditJob(request);
        }

        public Job GetJobById(int Id)
        {
            return _jobRepository.GetJobById(Id);
        }

        public IList<Job> JobList()
        {
            return _jobRepository.JobList();
        }
    }
}
