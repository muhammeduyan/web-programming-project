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
        private readonly IBookTypeRepository _bookTypeRepo;

        public BookTypeController(IBookTypeRepository context)
        {
            _bookTypeRepo = context;
        }

        public IActionResult Index()
        {
            List<BookType> bookTypes = _bookTypeRepo.GetAll().ToList();
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
                _bookTypeRepo.Add(bookType);
                _bookTypeRepo.Save(); // Veritabanına bilgileri ekler.
                TempData["succesful"] = "Yeni kitap türü başarıyla oluşturuldu!";
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
            BookType? bookTypeVt = _bookTypeRepo.Get(u=>u.Id == id);
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
                _bookTypeRepo.Update(bookType);
                _bookTypeRepo.Save();
                TempData["succesful"] = "Kitap türü başarıyla güncellendi!";
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
            BookType? bookTypeVt = _bookTypeRepo.Get(u=>u.Id == id);
            if(bookTypeVt == null)
            {
                return NotFound();
            }
            return View(bookTypeVt);
        }

        [HttpPost, ActionName("DeleteBookType")]
        public IActionResult DeleteBookTypePost(int? id)
        {
            BookType? bookType = _bookTypeRepo.Get(u=>u.Id == id);
            if (bookType == null)
            {
                return NotFound();
            }
            _bookTypeRepo.Delete(bookType);
            _bookTypeRepo.Save();
            TempData["succesful"] = "Kayıt silme işlemi başarılı!";
            return RedirectToAction("Index");
        }
        
    }
}