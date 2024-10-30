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
    public class DetailsModel : PageModel
    {
        private readonly IJobPostingService jobPostingService;

        public DetailsModel(IJobPostingService context)
        {
            jobPostingService = context;
        }

        public JobPosting JobPosting { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || jobPostingService.GetJobPostings() == null)
            {
                return NotFound();
            }
            var jobPosting = jobPostingService.GetJobPosting(id);
            if (jobPosting == null)
            {
                return NotFound();
            }
            else
            {
                JobPosting = jobPosting;
            }
            return Page();
        }
    }
}
