using Candidate_BuisinessObjects.Models;

namespace Candidate_Service.IServices
{
    public interface IJobPostingService
    {
        public List<JobPosting> GetJobPostings();
        (List<JobPosting> Items, int TotalItems, int TotalPages) GetJobPostings(int pageNumber, int pageSize);
        public JobPosting GetJobPosting(string jobId);
        public bool AddJobPosting(JobPosting jobPosting);
        public bool UpdateJobPosting(JobPosting jobPosting);
        public bool DeleteJobPosting(JobPosting jobPosting);
    }
}
