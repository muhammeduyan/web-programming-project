using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface IBookRepository : IRepository<Book>
    {
        void Update(Book book);
        void Save();
        
    }
}