using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quoteCodeAlong.Models;

namespace quoteCodeAlong.Controllers
{
    public class quoteCodeAlongController : Controller
    {
        private quoteCodeAlongContext _context;
        public quoteCodeAlongController(quoteCodeAlongContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index ()
        {
            ViewBag.authors = _context.author.ToList();
            ViewBag.category = _context.category.ToList();
            return View();
        }
        [HttpPost]
        [Route("author/create")]
        public IActionResult AddAuthor(AuthorViewModel incoming)
        {
            TryValidateModel(incoming);
            if(ModelState.IsValid)
            {
                System.Console.WriteLine("so far so good");
                Author addAuthor = new Author();
                addAuthor.name = incoming.name;
                _context.author.Add(addAuthor);
                _context.SaveChanges();
            } else {
                System.Console.WriteLine("not working yet");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("quote/create")]
        public IActionResult AddQuote(QuoteViewModel incoming)
        {
            TryValidateModel(incoming);
            if(ModelState.IsValid)
            {
                System.Console.WriteLine("quoteform seems to work");
            } else {
                System.Console.WriteLine("quoteform broke");
            }
            return RedirectToAction("Index");
        }
    }
}
