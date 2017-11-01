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
                // things to make:
                //  meta
                Meta newMeta = new Meta();
                newMeta.note = incoming.meta;
                _context.meta.Add(newMeta);
                _context.SaveChanges();
                newMeta = _context.meta.Last();
                //  quote
                Quote newQuote = new Quote();
                newQuote.authorId = incoming.authorId;
                newQuote.author = _context.author.FirstOrDefault(author => author.id == incoming.authorId);
                newQuote.text = incoming.text;
                newQuote.metaId = newMeta.id;
                newQuote.meta = newMeta;
                _context.quote.Add(newQuote);
                _context.SaveChanges();
                //  categoryJoin
                categoryJoin newJoin = new categoryJoin();
                newJoin.categoryId = incoming.categoryId;
                newJoin.category = _context.category.SingleOrDefault(category => category.id == incoming.categoryId);
                newJoin.quoteId = _context.quote.Last().id;
                newJoin.quote = _context.quote.Last();
                _context.category_has_quote.Add(newJoin);
                //Update quotecategories
                newQuote.categoryJoin.Add(newJoin);
                _context.SaveChanges();

                System.Console.WriteLine("quoteform seems to work");
            } else {
                System.Console.WriteLine("quoteform broke");
            }
            return RedirectToAction("Index");
        }
    }
}
