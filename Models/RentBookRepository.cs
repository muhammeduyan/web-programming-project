using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Utility;

namespace LibraryManagement.Models
{
    public class RentBookRepository : Repository<RentBook>, IRentBookRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public RentBookRepository(ApplicationDbContext applicationDbContext) :base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    
        public void Update(RentBook rentBook)
        {            
            _applicationDbContext.Update(rentBook);
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
        
    }
}