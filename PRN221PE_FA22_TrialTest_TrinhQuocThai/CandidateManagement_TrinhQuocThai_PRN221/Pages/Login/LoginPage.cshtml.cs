using Candidate_BuisinessObjects.Models;
using Candidate_Service.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagement_TrinhQuocThai_PRN221.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly IHRAccountService _hrAccountService;
        public IndexModel(IHRAccountService hrAccountService)
        {
            _hrAccountService = hrAccountService;
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            string email = Request.Form["txtEmail"];
            string password = Request.Form["txtPassword"];

            Hraccount account = _hrAccountService.GetHraccountByEmail(email);
            if (account != null && account.Password.Equals(password))
            {
                string RoleID = account.MemberRole.ToString();
               HttpContext.Session.SetString("RoleID", RoleID);
                Response.Redirect("/CandidateProfilePage/index");
            }
            else
                Response.Redirect("/Error");
        }
    }
}
