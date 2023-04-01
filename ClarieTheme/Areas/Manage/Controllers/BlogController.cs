using ClarieTheme.DAL;
using ClarieTheme.Extensions;
using ClarieTheme.Helpers;
using ClarieTheme.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public BlogController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Blog> blogs = _context.Blogs.Where(b => !b.IsDeleted).ToList();
            return View(blogs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            if (!blog.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Sekil Formati secin");
            }

            if (blog.Photo.CheckSize(20000))
            {
                ModelState.AddModelError("Photo", "Sekil 20 mb-dan boyuk ola bilmez");
            }

            string filename = await blog.Photo.SaveFile(_env, "assets/images/blog");
            blog.Image = filename;


            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Blog blog = _context.Blogs.FirstOrDefault(b => b.Id == id);

            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }


        [HttpPost]
        public async Task<IActionResult> Update(int? id, Blog blog)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog db = _context.Blogs.FirstOrDefault(b => b.Id == id);
            if (db == null)
            {
                return NotFound();
            }
            if (blog.Photo != null)
            {

                if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    return View();
                }

                if (!blog.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Sekil Formati secin");
                }

                if (blog.Photo.CheckSize(20000))
                {
                    ModelState.AddModelError("Photo", "Sekil 20 mb-dan boyuk ola bilmez");
                }
                Helper.DeleteFile(_env, "assets/images/blog", db.Image);
                string filename = await blog.Photo.SaveFile(_env, "assets/images/blog");
                db.Image = filename;
            }
            else
            {
                db.Image = db.Image;
            }

            Blog existName = _context.Blogs.FirstOrDefault(x => x.Title.ToLower() == blog.Title.ToLower());

            if (existName != null)
            {
                if (db != existName)
                {
                    ModelState.AddModelError("Title", "Name Already Exist");
                    return View();
                }
            }

            db.Title = blog.Title;
            db.Description = blog.Description;
            db.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog db = _context.Blogs.Find(id);
            if (db == null) return NotFound();
            db.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Blog blog = _context.Blogs.Where(b => !b.IsDeleted).FirstOrDefault(b => b.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

    }
}
