using Candidate_BuisinessObjects.Models;
using Candidate_Service.IServices;
using Candidate_Repository.IRepositories;
using Candidate_Repository.Repositories;

namespace Candidate_Service.Services
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private ICandidateProfileRepo iCandidateProfileRepo;
        public CandidateProfileService()
        {
            iCandidateProfileRepo = new CandidateProfileRepo();
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            return iCandidateProfileRepo.GetCandidateProfiles();
        }

        public (List<CandidateProfile> Items, int TotalItems, int TotalPages) GetCandidateProfiles(int pageNumber, int pageSize)
        {
            var allProfiles = iCandidateProfileRepo.GetCandidateProfiles();
            var totalItems = allProfiles.Count();

            var pagedProfiles = allProfiles
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            return (pagedProfiles, totalItems, totalPages);
        }


        public CandidateProfile GetCandidateProfileById(string id)
        {
            return iCandidateProfileRepo.GetCandidateProfileById(id);
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            return iCandidateProfileRepo.AddCandidateProfile(candidateProfile);
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {

            return iCandidateProfileRepo.UpdateCandidateProfile(candidateProfile);
        }

        public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
        {
            return iCandidateProfileRepo.DeleteCandidateProfile(candidateProfile);
        }
    }
}
