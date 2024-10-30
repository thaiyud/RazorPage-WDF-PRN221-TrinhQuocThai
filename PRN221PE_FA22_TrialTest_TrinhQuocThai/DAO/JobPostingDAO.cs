using Candidate_BuisinessObjects.Models;


namespace Candidate_DAO
{
    public class JobPostingDAO
    {
        private CandidateManagementContext context;
        private static JobPostingDAO instance;

        public JobPostingDAO()
        {
            context = new CandidateManagementContext();
        }

        public static JobPostingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;
            }
        }

        public List<JobPosting> GetJobPostings()
        {
            return context.JobPostings.ToList();
        }
        public JobPosting GetJobPosting(string jobId)
        {
            return context.JobPostings.SingleOrDefault(m => m.PostingId.Equals(jobId));
        }
        public bool AddJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting job = GetJobPosting(jobPosting.PostingId);
            try
            {
                if (job == null)
                {
                    context.JobPostings.Add(jobPosting);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
           
            }
            return result;
        }
        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting job = GetJobPosting(jobPosting.PostingId);
            try
            {
                if (job != null)
                {
                    context.Entry<JobPosting>(jobPosting).State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
       
            }
            return result;
        }
        public bool DeleteJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting job = GetJobPosting(jobPosting.PostingId);
            try
            {
                if (job != null)
                {
                    context.JobPostings.Remove(jobPosting);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
           
            }
            return result;
        }
    }
}
