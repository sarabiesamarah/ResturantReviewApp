using Microsoft.AspNetCore.Mvc;
using System.Linq;

using ResturantReviewApp.Models;


namespace ResturantReviewApp.Controllers
{
    public class ResturantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResturantController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Resturant
        public IActionResult Index()
        {
            var restaurants = _context.Restaurants.ToList();
            return View(restaurants);
        }

        // GET: Resturant/Details/5
        public IActionResult Details(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // GET: Resturant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resturant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Restaurants.Add(restaurant);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // GET: Resturant/Edit/5
        public IActionResult Edit(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // POST: Resturant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(restaurant);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // GET: Resturant/Delete/5
        public IActionResult Delete(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // POST: Resturant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
