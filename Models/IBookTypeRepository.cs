using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface IBookTypeRepository : IRepository<BookType>
    {
        void Update(BookType bookType);
        void Save();
        
    }
}