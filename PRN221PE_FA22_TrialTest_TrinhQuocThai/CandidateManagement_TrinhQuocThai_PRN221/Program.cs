using Candidate_Repository.IRepositories;
using Candidate_Repository.Repositories;
using Candidate_Service.IServices;
using Candidate_Service.Services;

namespace CandidateManagement_TrinhQuocThai_PRN221
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddScoped<ICandidateProfileService, CandidateProfileService>();
            builder.Services.AddScoped<ICandidateProfileRepo, CandidateProfileRepo>();
            builder.Services.AddScoped<IJobPostingRepo, JobPostingRepo>();
            builder.Services.AddScoped<IJobPostingService, JobPostingService>();
            builder.Services.AddScoped<IHRAccountRepo, HRAccountRepo>();
            builder.Services.AddScoped<IHRAccountService, HRAccountService>();
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();


            app.UseAuthorization();
            app.MapGet("/", context =>
            {
                context.Response.Redirect("/Login/LoginPage");
                return Task.CompletedTask;
            });
            app.MapRazorPages();

            app.Run();
        }
    }
}