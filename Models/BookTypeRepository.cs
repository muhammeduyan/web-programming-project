using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Utility;

namespace LibraryManagement.Models
{
    public class BookTypeRepository : Repository<BookType>, IBookTypeRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public BookTypeRepository(ApplicationDbContext applicationDbContext) :base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    
        public void Update(BookType bookType)
        {            
            _applicationDbContext.Update(bookType);
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
        
    }
}