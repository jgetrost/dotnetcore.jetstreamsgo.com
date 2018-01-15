using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jetstreamsgo.Data;
using Microsoft.AspNetCore.Mvc;
using static jetstreamsgo.Models.LibraryModel;

namespace jetstreamsgo.Controllers
{
    public class PublisherController : Controller
    {
        private LibraryContext dbc = new LibraryContext();

        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(string name)
        {
            Publisher newPublisher = new Publisher
            {
                Name = name
            };
            dbc.Publisher.Add(newPublisher);
            dbc.SaveChanges();

            return RedirectToAction("Publishers", "Home");
        }
    }
}