using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jetstreamsgo.Data;
using Microsoft.AspNetCore.Mvc;
using static jetstreamsgo.Models.LibraryModel;

namespace jetstreamsgo.Controllers
{
    public class BookController : Controller
    {
        private LibraryContext dbc = new LibraryContext();

        public IActionResult Add()
        {
            IEnumerable<Publisher> _viewModel;
            _viewModel = dbc.Publisher.AsEnumerable().OrderBy(p => p.Name);
            return View(_viewModel);
        }


        [HttpPost]
        public IActionResult Add(string isbn, string title, string author, int pages, int publisher)
        {
            Publisher newBookPublisher = dbc.Publisher.SingleOrDefault(p => p.ID == publisher); 
            Book newBook = new Book
            {
                ISBN = isbn,
                Title = title,
                Author = author,
                Pages = pages,
                Language = "English",
                Publisher = newBookPublisher,
            };
            dbc.Book.Add(newBook);
            dbc.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}