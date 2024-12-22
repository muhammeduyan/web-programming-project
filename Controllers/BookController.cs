using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;

using LibraryManagement.Utility;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepo;
        private readonly IBookTypeRepository _bookTypeRepo;


        public BookController(IBookRepository bookRepository, IBookTypeRepository bookTypeRepo)
        {
            _bookRepo = bookRepository;
            _bookTypeRepo = bookTypeRepo;
        }

        public IActionResult Index()
        {
            List<Book> books = _bookRepo.GetAll(includeProps:"BookType").ToList();
            return View(books);
        }

        public IActionResult AddBook()
        {
            IEnumerable<SelectListItem> BookTypeList = _bookTypeRepo.GetAll().Select(
                k => new SelectListItem
                {
                    Text = k.Name,
                    Value = k.Id.ToString(),
                }
            );
            ViewBag.BookTypeList = BookTypeList;
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepo.Add(book);
                _bookRepo.Save(); // Veritabanına bilgileri ekler.
                TempData["succesful"] = "Yeni kitap başarıyla oluşturuldu!";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult UpdateBook(int? id)
        {
            IEnumerable<SelectListItem> BookTypeList = _bookTypeRepo.GetAll().Select(
                k => new SelectListItem
                {
                    Text = k.Name,
                    Value = k.Id.ToString(),
                }
            );
            ViewBag.BookTypeList = BookTypeList;
            if(id == null || id==0)
            {
                return NotFound();
            }
            Book? bookVt = _bookRepo.Get(u=>u.Id == id);
            if(bookVt == null)
            {
                return NotFound();
            }
            return View(bookVt);
        }

        [HttpPost]
        public IActionResult UpdateBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepo.Update(book);
                _bookRepo.Save();
                TempData["succesful"] = "Kitap başarıyla güncellendi!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult DeleteBook(int? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }
            Book? bookVt = _bookRepo.Get(u=>u.Id == id);
            if(bookVt == null)
            {
                return NotFound();
            }
            return View(bookVt);
        }

        [HttpPost, ActionName("DeleteBook")]
        public IActionResult DeleteBookPost(int? id)
        {
            Book? book = _bookRepo.Get(u=>u.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            _bookRepo.Delete(book);
            _bookRepo.Save();
            TempData["succesful"] = "Kayıt silme işlemi başarılı!";
            return RedirectToAction("Index");
        }
        
    }
}