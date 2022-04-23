using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_hub_backend.DTO;
using student_hub_backend.Models;
using student_hub_backend.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        IJobService _jobService;
        public JobController(IJobService service)
        {
            _jobService = service;
        }

        /*Get List Of All Job Method*/
        /// <summary>
        /// get all employess
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllJob()
        {
            try
            {
                var jobs = _jobService.GetJobList();
                if (jobs == null)
                {
                    return NotFound();
                }

                var getJobDto = jobs.Select(e => new JobDto
                {
                    College = e.College,
                    JobTitle = e.JobTitle,
                    JobLevel = e.JobLevel,
                    Vacancy = e.Vacancy,
                    Type = e.Type,
                    Salary = e.Salary,
                    Deadline = e.Deadline,
                    Education = e.Education,
                    Experience = e.Experience,
                    JobDescription = e.JobDescription,
                    ApplyingProcedure = e.ApplyingProcedure,
                    OtherSpecification = e.OtherSpecification,
                    UserID = e.UserID,
                    /*UserName = e.Users.UserName*/
                });
                return Ok(jobs);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /*Get Job Details By Id Method*/
        /// <summary>
        /// get job details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetJobById(int id)
        {
            try
            {
                var jobs = _jobService.GetJobDetailsById(id);
                if (jobs == null)
                {
                    return NotFound();
                }
                var getJobDto = new JobDto
                {
                    College = jobs.College,
                    JobTitle = jobs.JobTitle,
                    JobLevel = jobs.JobLevel,
                    Vacancy = jobs.Vacancy,
                    Type = jobs.Type,
                    Salary = jobs.Salary,
                    Deadline = jobs.Deadline,
                    Education = jobs.Education,
                    Experience = jobs.Experience,
                    JobDescription = jobs.JobDescription,
                    ApplyingProcedure = jobs.ApplyingProcedure,
                    OtherSpecification = jobs.OtherSpecification,
                    UserID = jobs.UserID

                };
                return Ok(getJobDto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /*Save Job Method*/
        /// <summary>
        /// save Job
        /// </summary>
        /// <param name="jobModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveJob([FromForm] JobDto jobDto)
        {
            try
            {
                string path = Path.Combine("F:\\student-hub-fyp\\public\\Images\\JobImages", jobDto.FileName);

                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    jobDto.FormFile.CopyTo(stream);
                }

                var jobModel = new Job
                {
                    College = jobDto.College,
                    JobTitle = jobDto.JobTitle,
                    JobBanner = "\\Images\\JobImages\\" + jobDto.FileName,
                    JobLevel = jobDto.JobLevel,
                    Vacancy = jobDto.Vacancy,
                    Type = jobDto.Type,
                    Salary = jobDto.Salary,
                    Deadline = jobDto.Deadline,
                    Education = jobDto.Education,
                    Experience = jobDto.Experience,
                    JobDescription = jobDto.JobDescription,
                    ApplyingProcedure = jobDto.ApplyingProcedure,
                    OtherSpecification = jobDto.OtherSpecification,
                    UserID = jobDto.UserID

                };

                var model = _jobService.SaveJob(jobModel);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /*Delete job Method*/
        /// <summary>
        /// delete job
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteJob(int id)
        {
            try
            {
                var model = _jobService.DeleteJob(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
