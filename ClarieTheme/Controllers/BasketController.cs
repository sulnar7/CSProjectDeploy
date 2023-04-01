using ClarieTheme.DAL;
using ClarieTheme.Models;
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
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            string basket = HttpContext.Request.Cookies["basket"];
            List<BasketVM> basketVMs = null;
            if (!string.IsNullOrWhiteSpace(basket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }

            return View( /*await _GetBasketContent(basketVMs)*/);
        }
        public async Task<IActionResult> AddToBasket(int? id)
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

            if (basketVMs.Exists(b => b.ProductId == id))
            {
                basketVMs.Find(b => b.ProductId == id).Count++;
            }
            else
            {
                BasketVM basketVM = new BasketVM
                {
                    ProductId = product.Id,
                    Count = 1,
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
        public async Task<IActionResult> DeleteFromBasket(int? id)
        {
            if (id == null)
            {
                return BadRequest();

            }
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.IsDeleted == false && p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            string basket = HttpContext.Request.Cookies["basket"];
            List<BasketVM> products = null;
            if (!string.IsNullOrWhiteSpace(basket))
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                BasketVM basketVM = products.Find(p => p.ProductId == id);
                if (basketVM != null)
                {
                    products.Remove(basketVM);
                }
                else
                {
                    return NotFound();
                }
            }
            string basket1 = JsonConvert.SerializeObject(products);
            HttpContext.Response.Cookies.Append("basket", basket1);

            foreach (BasketVM basketVM in products)
            {
                Product product1 = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.ProductId);
                basketVM.Image = product1.Image;
                basketVM.Price = product1.Price;
                basketVM.Title = product1.Title;
            }

            return PartialView("_BasketPartial", products);

        }

        public async Task<IActionResult> UpdateCount(int? id, int count)
        {
            if (id == null) return BadRequest();

            if (!await _context.Products.AnyAsync(p => p.Id == id)) return NotFound();

            string basket = HttpContext.Request.Cookies["basket"];
            List<BasketVM> basketVMs = null;
            if (!string.IsNullOrWhiteSpace(basket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

                BasketVM basketVM = basketVMs.FirstOrDefault(b => b.ProductId == id);

                if (basketVM == null) return NotFound();

                basketVM.Count = count <= 0 ? 1 : count;

                basket = JsonConvert.SerializeObject(basketVMs);

                HttpContext.Response.Cookies.Append("basket", basket);
               
            }
            else
            {
                return BadRequest();
            }

            return PartialView("_BasketPartial");
        }

        public async Task<IActionResult> GetBasketContent()
        {
            string pro = HttpContext.Request.Cookies["basket"];
            List<BasketVM> products = JsonConvert.DeserializeObject<List<BasketVM>>(pro);
            return Json(products);

        }
    }
}
