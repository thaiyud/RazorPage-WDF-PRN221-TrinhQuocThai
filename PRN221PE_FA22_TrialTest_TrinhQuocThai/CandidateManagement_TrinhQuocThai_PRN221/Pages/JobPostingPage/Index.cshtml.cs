using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Candidate_BuisinessObjects.Models;
using Candidate_DAO;
using Candidate_Service.IServices;
using Candidate_Service.Services;

namespace CandidateManagement_TrinhQuocThai_PRN221.Pages.JobPostingPage
{
    public class IndexModel : PageModel
    {
        private readonly IJobPostingService jobPostingService;

        public IndexModel(IJobPostingService context)
        {
            jobPostingService = context;
        }
        

        public IList<JobPosting> JobPosting { get;set; } = default!;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public async Task OnGetAsync(int pageNumber = 1, int pageSize = 20)
        {
            var (items, totalItems, totalPages) = jobPostingService.GetJobPostings(pageNumber, pageSize);

            JobPosting = items;
            CurrentPage = pageNumber;
            TotalPages = totalPages;
        }
       
    }
}
