using Microsoft.AspNetCore.Mvc;
using FLORES_Midterm_Store.Data;

namespace FLORES_Midterm_Store.Controllers

{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CartController(ApplicationDbContext db) { _db = db; }

        public IActionResult Index(string searchString)
        {
            var cartItems = _db.Items.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                cartItems = cartItems.Where(p => p.ProductName.ToLower().Contains(searchString.ToLower()));
            }

            ViewData["searchString"] = searchString;
            return View(cartItems.ToList());
        }

        public IActionResult Update(int id, int quantity)
        {
            var cartItem = _db.Items.Find(id);

            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                _db.Items.Update(cartItem);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var cartItem = _db.Items.Find(id);

            if (cartItem != null)
            {
                _db.Items.Remove(cartItem);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}