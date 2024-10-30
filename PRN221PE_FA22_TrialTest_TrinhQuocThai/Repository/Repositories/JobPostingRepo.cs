using Candidate_BuisinessObjects.Models;
using Candidate_DAO;
using Candidate_Repository.IRepositories;

namespace Candidate_Repository.Repositories
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public List<JobPosting> GetJobPostings() => JobPostingDAO.Instance.GetJobPostings();

        public JobPosting GetJobPosting(string jobId) => JobPostingDAO.Instance.GetJobPosting(jobId);

        public bool AddJobPosting(JobPosting jobPosting) => JobPostingDAO.Instance.AddJobPosting(jobPosting);

        public bool UpdateJobPosting(JobPosting jobPosting) => JobPostingDAO.Instance.UpdateJobPosting(jobPosting);

        public bool DeleteJobPosting(JobPosting jobPosting) => JobPostingDAO.Instance.DeleteJobPosting(jobPosting);
    }
}
