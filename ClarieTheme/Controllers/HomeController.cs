using ClarieTheme.DAL;
using ClarieTheme.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {

                Sliders = await _context.Sliders.Where(s => s.IsDeleted == false).ToListAsync(),
                Products = await _context.Products.Where(p => p.IsDeleted == false).ToListAsync(),
                Blogs = await _context.Blogs.Where(b => b.IsDeleted == false).ToListAsync()
            };
            return View(homeVM);
        }
    }
}
