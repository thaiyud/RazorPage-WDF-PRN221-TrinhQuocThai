using Candidate_BuisinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository.IRepositories
{
    public interface IHRAccountRepo
    {
        public Hraccount GetHraccountByEmail(string email);

        public List<Hraccount> GetHraccounts();

    }
}
