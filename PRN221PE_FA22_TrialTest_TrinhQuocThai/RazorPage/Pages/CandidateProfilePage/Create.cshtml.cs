﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuisinessObjects.Models;
using DAO;

namespace RazorPage.Pages.CandidateProfilePage
{
    public class CreateModel : PageModel
    {
        private readonly DAO.CandidateManagementContext _context;

        public CreateModel(DAO.CandidateManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PostingId"] = new SelectList(_context.JobPostings, "PostingId", "PostingId");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CandidateProfiles == null || CandidateProfile == null)
            {
                return Page();
            }

            _context.CandidateProfiles.Add(CandidateProfile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
