using ClarieTheme.DAL;
using ClarieTheme.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Team> model = _context.Teams.Where(a => !a.IsDeleted).ToList();
            return View(model);
        }
    }
}
