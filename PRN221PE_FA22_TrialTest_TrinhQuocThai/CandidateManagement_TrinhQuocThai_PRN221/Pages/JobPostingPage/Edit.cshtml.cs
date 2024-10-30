using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Candidate_BuisinessObjects.Models;
using Candidate_Service.IServices;

namespace CandidateManagement_TrinhQuocThai_PRN221.Pages.JobPostingPage
{
    public class EditModel : PageModel
    {
        private readonly ICandidateProfileService candidateProfileService;
        private readonly IJobPostingService jobPostingService;

        public EditModel(ICandidateProfileService candidateProfileService, IJobPostingService jobPostingService)
        {
            this.candidateProfileService = candidateProfileService;
            this.jobPostingService = jobPostingService;
        }

        [BindProperty]
        public JobPosting JobPosting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            JobPosting = jobPostingService.GetJobPosting(id);
            if (JobPosting == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                
                bool updateSuccess = jobPostingService.UpdateJobPosting(JobPosting);
                if (!updateSuccess)
                {
                    return NotFound(); // Or handle as needed
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError(string.Empty, "The job posting was modified by another user.");
                JobPosting = jobPostingService.GetJobPosting(JobPosting.PostingId);
                return Page();
            }

            return RedirectToPage("./Index");
        }

        private bool JobPostingExists(string id)
        {
            return jobPostingService.GetJobPosting(id) != null;
        }
    }
}
