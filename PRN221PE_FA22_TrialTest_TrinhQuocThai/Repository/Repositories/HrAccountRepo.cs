using BuisinessObjects.Models;
using DAO;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class HRAccountRepo : IHRAccountRepo
    {

        public Hraccount GetHraccountByEmail(string email) => HRAccountDAO.Instance.GetHraccount(email);
        public List<Hraccount> GetHraccounts() => HRAccountDAO.Instance.GetHraccounts();
    }
}
