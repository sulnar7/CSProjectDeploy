using ClarieTheme.DAL;
using ClarieTheme.Models;
using ClarieTheme.ViewModels;
using ClarieTheme.ViewModels.Basket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Product> model = _context.Products.Where(a => !a.IsDeleted).ToList();
            return View(model);
        }
        public IActionResult Search(string search)
        {
            List<Product> products = _context.Products.Where(p => !p.IsDeleted && p.Title.ToLower().Contains(search.ToLower())).ToList();
            return PartialView("_SearchPartial", products);
        }
        public IActionResult Detail(int id)
        {
            Product product = _context.Products
                .Where(p => !p.IsDeleted && p.Id == id).FirstOrDefault();
            ProductDetailVM productDetailVM = new ProductDetailVM()
            {
                Product = product
            };
            return View(product);
        }
        public async Task<IActionResult> AsAddToBasket(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            string basket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (basket != null)
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }

            if (basketVMs.Exists(b =>b.ProductId == id))
            {
                basketVMs.Find(b => b.ProductId == id).Count++;
            }
            else
            {
                BasketVM basketVM = new BasketVM
                {
                    ProductId = product.Id,
                    Count = 0,
                    Image = product.Image,
                    Title = product.Title,
                    Price = product.Price
                };

                basketVMs.Add(basketVM);
            }


            basket = JsonConvert.SerializeObject(basketVMs);

            HttpContext.Response.Cookies.Append("basket", basket);

            return PartialView("_BasketPartial", basketVMs);

        }
    }
}
