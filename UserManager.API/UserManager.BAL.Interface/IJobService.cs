using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Domain.Reponse;
using UserManager.Domain.Request;

namespace UserManager.BAL.Interface
{
    public interface IJobService
    {
        IList<Job> JobList();
        Job GetJobById(int Id);
        int CreateNewJob(CreateNewJob request);
        int EditJob(EditJob request);
        bool DeleteJob(int Id);
    }
}
