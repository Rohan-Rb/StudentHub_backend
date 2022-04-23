using Microsoft.EntityFrameworkCore;
using student_hub_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.Services
{
    public class JobService : IJobService
    {
        private MyDBContext _context;
        public JobService(MyDBContext context)
        {
            _context = context;
        }

        public List<Job> GetJobList()
        {
            List<Job> jobList;
            try
            {
                jobList = _context.Job.Include(x => x.Users).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return jobList;
        }

        public Job GetJobDetailsById(int jobId)
        {
            Job jobs;
            try
            {
                jobs = _context.Find<Job>(jobId);
                jobs = _context.Job.Include(x => x.Users).Where(jobs => jobs.JobId == jobId).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return jobs;
        }
        public ResponseModel SaveJob(Job jobModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Job _temp = GetJobDetailsById(jobModel.JobId);
                if (_temp != null)
                {
                    _temp.College = jobModel.College;
                    _temp.JobTitle = jobModel.JobTitle;
                    _temp.JobLevel = jobModel.JobLevel;
                    _temp.Vacancy = jobModel.Vacancy;
                    _temp.Type = jobModel.Type;
                    _temp.Salary = jobModel.Salary;
                    _temp.Deadline = jobModel.Deadline;
                    _temp.Education = jobModel.Education;
                    _temp.Experience = jobModel.Experience;
                    _temp.JobDescription = jobModel.JobDescription;
                    _temp.ApplyingProcedure = jobModel.ApplyingProcedure;
                    _temp.OtherSpecification = jobModel.OtherSpecification;
                    _temp.UserID = jobModel.UserID;

                    _context.Update<Job>(_temp);
                    model.Messsage = "job Update Successfully";
                }
                else
                {
                    _context.Add<Job>(jobModel);
                    model.Messsage = "Job Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
        public ResponseModel DeleteJob(int jobId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Job _temp = GetJobDetailsById(jobId);
                if (_temp != null)
                {
                    _context.Remove<Job>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "job Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "job Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        
    }
}
