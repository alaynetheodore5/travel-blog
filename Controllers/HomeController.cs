using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Travel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Travel.Controllers
{
    public class HomeController : Controller
    {

        private MyContext _context { get; set; }
        private PasswordHasher<User> regHasher = new PasswordHasher<User>();
        private PasswordHasher<LoginUser> logHasher = new PasswordHasher<LoginUser>();

        public  User GetUser()
        {
            return _context.Users.FirstOrDefault( u =>  u.UserId == HttpContext.Session.GetInt32("userId"));
        }

        public HomeController(MyContext context)
        {
            _context = context; 
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("loginindex")]
        public IActionResult LoginIndex()
        {
            return View("_Login");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser lu)
        {
            if(ModelState.IsValid)
            {
                User userInDB = _context.Users.FirstOrDefault(u => u.Email == lu.LoginEmail);
                if(userInDB == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Email or Password");
                    return View("_Login");
                }
                var result = logHasher.VerifyHashedPassword(lu, userInDB.Password, lu.LoginPassword);
                if(result == 0)
                {
                    ModelState.AddModelError("LoginPassword", "Invalid Email or Password");
                    return View("_Login");
                }
                HttpContext.Session.SetInt32("userId", userInDB.UserId);
                return Redirect("/home");
            }
            return View("_Login");
        }

        [HttpGet("registerindex")]
        public IActionResult RegisterIndex()
        {
            return View("_Register");
        }

                [HttpPost("register")]
        public IActionResult Register(User u)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.FirstOrDefault(usr => usr.Email == u.Email) !=null)
                {
                    ModelState.AddModelError("Email", "Email is already in use, try logging in!");
                    return View("_Register");
                }
                string hash = regHasher.HashPassword(u, u.Password);
                u.Password = hash;
                _context.Users.Add(u);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("userId", u.UserId);
                return Redirect("/home");
            }
            return View("_Register");
        }

        [HttpGet("home")]
        public IActionResult Home()
        {
            User current = GetUser();
            if (current == null)
            {
                return Redirect ("/");
            }
            return View("Home");
        }

        [HttpGet("about-me")]
        public IActionResult AboutMe()
        {
            return View("AboutMe");
        }

        [HttpGet("travel-blog")]
        public IActionResult Blog()
        {
            return View("Blog");
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View("Contact");
        }

        [HttpGet("start-here")]
        public IActionResult StartHere()
        {
            return View("StartHere");
        }

        [HttpGet("destinations")]
        public IActionResult Destinations()
        {
            return View("Destinations");
        }

        [HttpGet("travel-shop")]
        public IActionResult TravelShop()
        {
            return View("TravelShop");
        }

        [HttpGet("resources")]
        public IActionResult Resources()
        {
            return View("Resources");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
