using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface IRentBookRepository : IRepository<RentBook>
    {
        void Update(RentBook rentBook);
        void Save();
        
    }
}