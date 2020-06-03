using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManager.BAL.Interface;
using UserManager.Domain.Reponse;
using UserManager.Domain.Request;

namespace UserManager.API.Controllers
{    
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }
        // GET: api/Jobs
        [HttpGet]
        [Route("api/Jobs/JobList")]
        public IEnumerable<Job> JobList()
        {
            return _jobService.JobList();   
        }

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        [Route("api/Jobs/GetJobById/{id}")]
        public Job GetJobById(int id)
        {
            return _jobService.GetJobById(id);
        }

        // POST: api/Jobs
        [HttpPost]
        [Route("api/Jobs/CreateNewJob")]
        public int CreateNewJob([FromBody] CreateNewJob request)
        {
            return _jobService.CreateNewJob(request);
        }

        // PUT: api/Jobs/5
        [HttpPut]
        [Route("api/Jobs/EditJob")]
        public int EditJob([FromBody] EditJob request)
        {
            return _jobService.EditJob(request);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Route("api/Jobs/DeleteJob/{id}")]
        public bool DeleteJob(int id)
        {
            return _jobService.DeleteJob(id);
        }
    }
}
