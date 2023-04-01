using ClarieTheme.DAL;
using ClarieTheme.Models;
using ClarieTheme.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Blog> model = _context.Blogs.Where(a => !a.IsDeleted).ToList();
            return View(model);
        }
        public IActionResult Detail(int id)
        {
            Blog blog = _context.Blogs
               .Where(p => !p.IsDeleted && p.Id == id).FirstOrDefault();
            BlogDetailVM blogDetailVM = new BlogDetailVM()
            {
                Blog = blog
            };
            return View(blogDetailVM);
        }
    }
}