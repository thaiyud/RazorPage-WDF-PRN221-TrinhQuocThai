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
    public class DeleteModel : PageModel
    {
        private readonly IJobPostingService jobPostingService;

        public DeleteModel(IJobPostingService context)
        {
            jobPostingService = context;
        }


        [BindProperty]
      public JobPosting JobPosting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || jobPostingService.GetJobPostings() == null)
            {
                return NotFound();
            }

            var jobposting = jobPostingService.GetJobPosting(id);

            if (jobposting == null)
            {
                return NotFound();
            }
            else 
            {
                JobPosting = jobposting;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || jobPostingService.GetJobPostings() == null)
            {
                return NotFound();
            }
            var jobPosting = jobPostingService.GetJobPosting(id);

            if (jobPosting != null)
            {
               JobPosting = jobPosting;
                jobPostingService.DeleteJobPosting(jobPosting);
            }
            

            return RedirectToPage("./Index");
        }
    }
}
