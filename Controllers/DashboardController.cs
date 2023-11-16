using Azure;
using Hotels.Data;
using Hotels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimeKit;
using System.Net;
using MimeKit;
using MailKit.Net.Smtp;

namespace Hotels.Controllers
{

	public class DashboardController : Controller
    {
		private readonly AppDbContext _context;
		public DashboardController(AppDbContext context) {

			_context = context;	
			
		}
		[HttpPost]
		public IActionResult Index(string city)
		{
			var hotel = _context.hotel.ToList();
			var findhotels = hotel.Where(x => x.City.Contains(city));
			ViewBag.hotel = findhotels;

			return View(findhotels);
		}
		//siugqmyrauddzw
		[Authorize]
		public IActionResult Index()
        {
			var currentuser = HttpContext.User.Identity.Name;
			ViewBag.currentuser = currentuser;

			//CookieOptions option=new CookieOptions();   //create
			//option.Expires = DateTime.Now.AddMinutes(20);    //time
			//Response.Cookies.Append("UserName", currentuser, option); //stor data

			HttpContext.Session.SetString("UserName", currentuser);
			var hotel = _context.hotel.ToList();
            return View(hotel);
        }
		public IActionResult Rooms()
		{
			var hotel = _context.hotel.ToList();
			ViewBag.hotel = hotel;

			var room = _context.rooms.ToList();
			ViewBag.rooms = room;

			ViewBag.currentuser = HttpContext.Session.GetString("UserName");
			//ViewBag.currentuser = Request.Cookies["UserName"];
			return View(room);
		}
		public IActionResult RoomDetails()
		{
			var hotel = _context.hotel.ToList();
			ViewBag.hotel = hotel;

			var rooms = _context.rooms.ToList();
			ViewBag.rooms = rooms;

			var roomDetails = _context.roomDetails.ToList();
			ViewBag.roomDetails = roomDetails;
			return View(roomDetails);
		}

		public IActionResult CreateNewHotel(Hotel hotels)
		{
			if (ModelState.IsValid)
			{
				_context.hotel.Add(hotels);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
			var hotel=_context.hotel.ToList();
			return View("Index", hotel);

		}
		public IActionResult CreateNewRooms(Rooms rooms) { 
			_context.rooms.Add(rooms);
			_context.SaveChanges();
			return RedirectToAction("Rooms");

		}
		public IActionResult CreateNewRoomDetails(RoomDetails roomDetails)
		{
			_context.roomDetails.Add(roomDetails);
			_context.SaveChanges();
			return RedirectToAction("RoomDetails");

		}
		public async Task<string> SendEmail()
		{
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("test message", "lafnaaly@gmail.com"));
			message.To.Add(MailboxAddress.Parse("anfal11439@gmail.com"));
			message.Subject="test Email from my project ";
			message.Body = new TextPart("plain")
			{
				Text = "wecome to my project"
			};

			using (var client = new SmtpClient())
			{
				try
				{
					client.Connect("smtp.gmail.com", 587);
					client.Authenticate("lafnaaly@gmail.com", "siugqmyrauddzw");
					await client.SendAsync(message);
					client.Disconnect(true);
				}
				catch { }
			}

			return "OK";
		}
		public IActionResult Delete(int Id)
		{
			var hoteldelete = _context.hotel.SingleOrDefault(x => x.Id == Id);//search
			if (hoteldelete != null)
			{
				_context.hotel.Remove(hoteldelete);//delete
				_context.SaveChanges();
				TempData["Del"] = "Ok";
			}
			return RedirectToAction("Index");
		}

		public IActionResult DeleteRooms(int Id)
		{
			var roomdelete = _context.rooms.SingleOrDefault(x => x.Id == Id);//search
			if (roomdelete != null)
			{
				_context.rooms.Remove(roomdelete);//delete
				_context.SaveChanges();
				TempData["Del"] = "Ok";
			}
			return RedirectToAction("Rooms");
		}
		public IActionResult DeleteRoomDetails(int Id)
		{
			var roomDdelete = _context.roomDetails.SingleOrDefault(x => x.Id == Id);//search
			if (roomDdelete != null)
			{
				_context.roomDetails.Remove(roomDdelete);//delete
				_context.SaveChanges();
				TempData["Del"] = "Ok";
			}
			return RedirectToAction("RoomDetails");
		}

		public IActionResult Update(Hotel hotel)
		{
			if(ModelState.IsValid)
			{
                _context.hotel.Update(hotel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
			return View("Edit");
		}

		public IActionResult Edit(int Id)
		{
			var hotelEdit = _context.hotel.SingleOrDefault(x => x.Id == Id);//search

			return View("EditHotel");
		}
		public IActionResult UpdateRoom(Rooms rooms)
		{
			_context.rooms.Update(rooms);
			_context.SaveChanges();
			return RedirectToAction("Rooms");
		}
		public IActionResult EditRoom(int Id)
		{
			var EditRoom = _context.rooms.SingleOrDefault(x => x.Id == Id);//search

			return View("EditRoom");
		}

	}
}
