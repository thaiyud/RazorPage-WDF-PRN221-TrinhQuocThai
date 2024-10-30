using BuisinessObjects.Models;
using Repository.IRepositories;
using Repository.Repositories;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class HRAccountService : IHRAccountService
    {
        private readonly IHRAccountRepo iHRAccountRepo;
        public HRAccountService()
        {
            iHRAccountRepo = new HRAccountRepo();
        }
        public Hraccount GetHraccountByEmail(string email)
        {
           return iHRAccountRepo.GetHraccountByEmail(email);
        }

        public List<Hraccount> GetHraccountByEmail()
        {
            return iHRAccountRepo.GetHraccounts();
        }
    }
}
