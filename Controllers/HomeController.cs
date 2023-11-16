using Hotels.Data;
using Hotels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace Hotels.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult CreateNewRecord(Hotel hotels)
        {
            if (ModelState.IsValid)
            {
                _context.hotel.Add(hotels);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
            var hotel = _context.hotel.ToList();
            return View("Index", hotel);
        }
        [HttpPost]
        public IActionResult Index(string city)
        {
            var hotel = _context.hotel.ToList();
            var findhotels = hotel.Where(x => x.City.Contains(city));
            ViewBag.hotel = findhotels;

            return View(findhotels);
        }
        public IActionResult Index()
        {
            var hotel=_context.hotel.ToList();

            return View(hotel);
        }
        public IActionResult Delete(int Id)
        {
            var hoteldelete = _context.hotel.SingleOrDefault(x=>x.Id==Id);//search

            _context.hotel.Remove(hoteldelete);//delete
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int Id)
        {
            var hotelEdit = _context.hotel.SingleOrDefault(x => x.Id == Id);//search

            return View("hotelEdit");
        }
        public IActionResult Update(Hotel hotels)
        {
            if (ModelState.IsValid)
            {
                _context.hotel.Update(hotels);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit");
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}