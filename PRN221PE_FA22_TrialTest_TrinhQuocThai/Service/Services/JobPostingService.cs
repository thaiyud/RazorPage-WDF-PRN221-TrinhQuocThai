﻿using Candidate_BuisinessObjects.Models;
using Candidate_Repository.IRepositories;
using Candidate_Repository.Repositories;
using Candidate_Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service.Services
{
    public class JobPostingService : IJobPostingService
    {
        private IJobPostingRepo iJobPostingRepo;
        public JobPostingService()
        {
            iJobPostingRepo = new JobPostingRepo();
        }

        public List<JobPosting> GetJobPostings()
        {
            return iJobPostingRepo.GetJobPostings();
        }

        public JobPosting GetJobPosting(string jobId)
        {
            return iJobPostingRepo.GetJobPosting(jobId);
        }

        public bool AddJobPosting(JobPosting jobPosting)
        {
            return iJobPostingRepo.AddJobPosting(jobPosting);
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            return iJobPostingRepo.UpdateJobPosting(jobPosting);
        }

        public bool DeleteJobPosting(JobPosting jobPosting)
        {
            return iJobPostingRepo.DeleteJobPosting(jobPosting);
        }
    }
}
