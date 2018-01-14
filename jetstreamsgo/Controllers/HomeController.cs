using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using jetstreamsgo.Models;
using static jetstreamsgo.Models.LibraryModel;
using jetstreamsgo.Data;
using Microsoft.EntityFrameworkCore;

namespace jetstreamsgo.Controllers
{
    public class HomeController : Controller
    {
        private LibraryContext dbc = new LibraryContext();

        public IActionResult Index()
        {
            IEnumerable<Book> _viewModel;
            _viewModel = dbc.Book.Include(b => b.Publisher).AsEnumerable();
            return View(_viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Publishers()
        {
            IEnumerable<Publisher> _viewModel;
            _viewModel = dbc.Publisher.Include(p => p.Books).AsEnumerable();
            return View(_viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
