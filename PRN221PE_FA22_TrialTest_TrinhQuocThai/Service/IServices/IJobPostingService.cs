using Candidate_BuisinessObjects.Models;

namespace Candidate_Service.IServices
{
    public interface IJobPostingService
    {
        public List<JobPosting> GetJobPostings();
        public JobPosting GetJobPosting(string jobId);
        public bool AddJobPosting(JobPosting jobPosting);
        public bool UpdateJobPosting(JobPosting jobPosting);
        public bool DeleteJobPosting(JobPosting jobPosting);
    }
}
