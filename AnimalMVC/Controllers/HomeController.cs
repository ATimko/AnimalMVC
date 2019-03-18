using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnimalMVC.Models;
using Microsoft.AspNetCore.Http;

namespace AnimalMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "About the animal website page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "The contacts page.";

            return View();
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

        [HttpGet]
        public IActionResult CustomerForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CustomerForm(IFormCollection data)
        {
           
            string firstName = data["first_name"];
            string lastName = data["last_Name"];


            Customer cus = new Customer();
            cus.FirstName = firstName;
            cus.LastName = lastName;

            ViewData["Msg"] = "You have added " +
                                firstName + " " + lastName + " customer!";

            return View();
        }
        public IActionResult CustomerBinding()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CustomerBinding(Customer cus)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(cus);
        }

    }
}
