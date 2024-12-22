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
    public class RentBookController : Controller
    {
        private readonly IRentBookRepository _rentBookRepo;
        private readonly IBookRepository _bookRepo;


        public RentBookController(IRentBookRepository rentBookRepository, IBookRepository bookRepo)
        {
            _rentBookRepo = rentBookRepository;
            _bookRepo = bookRepo;
        }

        public IActionResult Index()
        {
            List<RentBook> rentBookList = _rentBookRepo.GetAll(includeProps:"Book").ToList();
            return View(rentBookList);
        }

        public IActionResult AddRentBook()
        {
            IEnumerable<SelectListItem> BookList = _bookRepo.GetAll().Select(
                k => new SelectListItem
                {
                    Text = k.Name,
                    Value = k.Id.ToString(),
                }
            );
            ViewBag.BookList = BookList;
            return View();
        }

        [HttpPost]
        public IActionResult AddRentBook(RentBook rentBook)
        {
            if (ModelState.IsValid)
            {
                _rentBookRepo.Add(rentBook);
                _rentBookRepo.Save(); // Veritabanına bilgileri ekler.
                TempData["succesful"] = "Yeni kiralama başarıyla oluşturuldu!";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult UpdateRentBook(int? id)
        {
            IEnumerable<SelectListItem> BookList = _bookRepo.GetAll().Select(
                k => new SelectListItem
                {
                    Text = k.Name,
                    Value = k.Id.ToString(),
                }
            );
            ViewBag.BookList = BookList;
            if(id == null || id==0)
            {
                return NotFound();
            }
            RentBook? rentBookVt = _rentBookRepo.Get(u=>u.Id == id);
            if(rentBookVt == null)
            {
                return NotFound();
            }
            return View(rentBookVt);
        }

        [HttpPost]
        public IActionResult UpdateRentBook(RentBook rentBook)
        {
            if (ModelState.IsValid)
            {
                _rentBookRepo.Update(rentBook);
                _rentBookRepo.Save();
                TempData["succesful"] = "Kitap kiralama başarıyla güncellendi!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult DeleteRentBook(int? id)
        {
            IEnumerable<SelectListItem> BookList = _bookRepo.GetAll().Select(
                k => new SelectListItem
                {
                    Text = k.Name,
                    Value = k.Id.ToString(),
                }
            );
            ViewBag.BookList = BookList;

            if(id == null || id==0)
            {
                return NotFound();
            }
            RentBook? rentBookVt = _rentBookRepo.Get(u=>u.Id == id);
            if(rentBookVt == null)
            {
                return NotFound();
            }
            return View(rentBookVt);
        }

        [HttpPost, ActionName("DeleteRentBook")]
        public IActionResult DeleteRentBookPost(int? id)
        {
            RentBook? rentBook = _rentBookRepo.Get(u=>u.Id == id);
            if (rentBook == null)
            {
                return NotFound();
            }
            _rentBookRepo.Delete(rentBook);
            _rentBookRepo.Save();
            TempData["succesful"] = "Kayıt silme işlemi başarılı!";
            return RedirectToAction("Index");
        }
        
    }
}