using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class BookType
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Kitap tür adı boş bırakılamaz!")]
        [MaxLength(25)]
        public string? Name { get; set; }
    }
}