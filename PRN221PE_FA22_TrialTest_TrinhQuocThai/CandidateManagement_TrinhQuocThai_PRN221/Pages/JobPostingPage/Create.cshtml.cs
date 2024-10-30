using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Candidate_BuisinessObjects.Models;
using Candidate_DAO;
using Candidate_Service.IServices;
using Candidate_Service.Services;

namespace CandidateManagement_TrinhQuocThai_PRN221.Pages.JobPostingPage
{
    public class CreateModel : PageModel
    {
        private readonly IJobPostingService jobPostingService;

        public CreateModel(IJobPostingService context)
        {
            jobPostingService = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JobPosting JobPosting { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || jobPostingService.GetJobPostings() == null || JobPosting == null)
            {
                return Page();
            }

            jobPostingService.AddJobPosting(JobPosting);

            return RedirectToPage("./Index");
        }
    }
}
