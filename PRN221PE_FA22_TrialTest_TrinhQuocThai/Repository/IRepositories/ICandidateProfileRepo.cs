﻿using Candidate_BuisinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository.IRepositories
{
    public interface ICandidateProfileRepo
    {
        public List<CandidateProfile> GetCandidateProfiles();
        public CandidateProfile GetCandidateProfileById(string id);
        public bool AddCandidateProfile(CandidateProfile candidateProfile);
        public bool UpdateCandidateProfile(CandidateProfile candidateProfile);
        public bool DeleteCandidateProfile(CandidateProfile candidateProfile);
    }
}
