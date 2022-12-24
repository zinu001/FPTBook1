using FPTLibrary.Data;
using FPTLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FPTLibrary.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;
        public OrderController(ApplicationDbContext _context)
        {
            context = _context;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var order = context.Orders.ToList();
            return View(order);
        }
        public IActionResult Detail(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var order = context.Orders
                .Include(b => b.Book)
                .Include(c => c.AspNetUsers)
                .FirstOrDefault(o => o.Id == id);
            return View(order);
        }

        public IActionResult Create(int? id)
        {
            var book = context.Books.Where(b => b.Id == id);
            ViewBag.Books = book;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Order order)
        {
                order.Order_Date = System.DateTime.Today;
                context.Orders.Add(order);
                context.SaveChanges();
                return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var order = context.Orders.Find(id);
            context.Orders.Remove(order);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
