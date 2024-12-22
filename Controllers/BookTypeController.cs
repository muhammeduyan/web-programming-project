using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LibraryManagement.Utility;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class BookTypeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BookTypeController(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public IActionResult Index()
        {
            List<BookType> bookTypes = _applicationDbContext.BookTypes.ToList();
            return View(bookTypes);
        }

        public IActionResult AddBookType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBookType(BookType bookType)
        {
            if (ModelState.IsValid)
            {
                _applicationDbContext.BookTypes.Add(bookType);
                _applicationDbContext.SaveChanges(); // Veritabanına bilgileri ekler.
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult UpdateBookType(int? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }
            BookType? bookTypeVt = _applicationDbContext.BookTypes.Find(id);
            if(bookTypeVt == null)
            {
                return NotFound();
            }
            return View(bookTypeVt);
        }

        [HttpPost]
        public IActionResult UpdateBookType(BookType bookType)
        {
            if (ModelState.IsValid)
            {
                _applicationDbContext.BookTypes.Update(bookType);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult DeleteBookType(int? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }
            BookType? bookTypeVt = _applicationDbContext.BookTypes.Find(id);
            if(bookTypeVt == null)
            {
                return NotFound();
            }
            return View(bookTypeVt);
        }

        [HttpPost, ActionName("DeleteBookType")]
        public IActionResult DeleteBookTypePost(int? id)
        {
            BookType? bookType = _applicationDbContext.BookTypes.Find(id);
            if (bookType == null)
            {
                return NotFound();
            }
            _applicationDbContext.BookTypes.Remove(bookType);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}