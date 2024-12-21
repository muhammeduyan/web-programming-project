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
{    public class BookTypeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BookTypeController(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public IActionResult Index()
        {
            List<BookType> bookTypes = _applicationDbContext.BookTypes.ToList();
            return View(); 
        }
    }
}