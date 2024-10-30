using Microsoft.AspNetCore.Mvc.RazorPages;
using Candidate_Service.IServices;
using Candidate_BuisinessObjects.Models;

namespace CandidateManagement_TrinhQuocThai_PRN221.Pages.CandidateProfilePage
{
    public class IndexModel : PageModel
    {
        private readonly ICandidateProfileService candidateProfileService;

        public IndexModel(ICandidateProfileService context)
        {
            candidateProfileService = context;
        }

        public IList<CandidateProfile> CandidateProfiles { get; set; } = default!;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public async Task OnGetAsync(int pageNumber = 1, int pageSize = 20)
        {
            var (items, totalItems, totalPages) = candidateProfileService.GetCandidateProfiles(pageNumber, pageSize);

            CandidateProfiles = items;
            CurrentPage = pageNumber;
            TotalPages = totalPages;
        }
    }
}
