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
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Product> products = _context.Products.Where(b => !b.IsDeleted).ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            if (!product.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Sekil Formati secin");
            }

            if (product.Photo.CheckSize(20000))
            {
                ModelState.AddModelError("Photo", "Sekil 20 mb-dan boyuk ola bilmez");
            }

            string filename = await product.Photo.SaveFile(_env, "assets/images/product");
            product.Image = filename;


            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = _context.Products.FirstOrDefault(b => b.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult> Update(int? id, Product product)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product db = _context.Products.FirstOrDefault(b => b.Id == id);
            if (db == null)
            {
                return NotFound();
            }
            if (product.Photo != null)
            {

                if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    return View();
                }

                if (!product.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Sekil Formati secin");
                }

                if (product.Photo.CheckSize(20000))
                {
                    ModelState.AddModelError("Photo", "Sekil 20 mb-dan boyuk ola bilmez");
                }
                Helper.DeleteFile(_env, "assets/images/blog", db.Image);
                string filename = await product.Photo.SaveFile(_env, "assets/images/product");
                db.Image = filename;
            }
            else
            {
                db.Image = db.Image;
            }

            Product existName = _context.Products.FirstOrDefault(x => x.Title.ToLower() == product.Title.ToLower());

            if (existName != null)
            {
                if (db != existName)
                {
                    ModelState.AddModelError("Title", "Name Already Exist");
                    return View();
                }
            }

            Product existPrice = _context.Products.FirstOrDefault(x => x.OldPrice == product.OldPrice);

            if (existPrice != null)
            {
                if (db != existPrice)
                {
                    ModelState.AddModelError("OldPrice", "Price Already Exist");
                    return View();
                }
            }

            Product existNewPrice = _context.Products.FirstOrDefault(x => x.Price == product.Price);

            if (existNewPrice != null)
            {
                if (db != existNewPrice)
                {
                    ModelState.AddModelError("Price", "Discount Price Already Exist");
                    return View();
                }
            }


            db.Title = product.Title;
            db.OldPrice = product.OldPrice;
            db.Price = product.Price;
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

            Product db = _context.Products.Find(id);
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
            Product product = _context.Products.Where(b => !b.IsDeleted).FirstOrDefault(b => b.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

    }
}
