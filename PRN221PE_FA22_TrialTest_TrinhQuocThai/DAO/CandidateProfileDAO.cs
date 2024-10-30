using Candidate_BuisinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace Candidate_DAO
{
    public class CandidateProfileDAO
    {
        private CandidateManagementContext context;
        private static CandidateProfileDAO instance;

        public CandidateProfileDAO()
        {
            context = new CandidateManagementContext();
        }

        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            return context.CandidateProfiles.Include(cp => cp.Posting).ToList();
        }

        public CandidateProfile GetCandidate(string id)
        {

            var entity = context.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(id));
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfileNew)
        {
            bool result = false;
            CandidateProfile candidateProfile = GetCandidate(candidateProfileNew.CandidateId);
            try
            {
                if (candidateProfile == null)
                {
                    context.CandidateProfiles.Add(candidateProfileNew);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
            
            }
            return result;
        }
        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            bool result = false;
            CandidateProfile candidate = GetCandidate(candidateProfile.CandidateId);
            try
            {
                if (candidate != null)
                {
                    context.Entry<CandidateProfile>(candidateProfile).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                  
                    result = true;
                }
            } 
            catch (Exception ex)
            {
              
            }
            return result;
        }
        public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
        {
            bool result = false;
            CandidateProfile candidate = GetCandidate(candidateProfile.CandidateId);
            try
            {
                if (candidate != null)
                {
                    context.CandidateProfiles.Remove(candidateProfile);
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
