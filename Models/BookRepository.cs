using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Utility;

namespace LibraryManagement.Models
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public BookRepository(ApplicationDbContext applicationDbContext) :base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    
        public void Update(Book book)
        {            
            _applicationDbContext.Update(book);
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
        
    }
}