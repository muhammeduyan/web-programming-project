using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;



namespace LibraryManagement.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [Range(10, 5000)]
        public double Price { get; set; }

        public int BookTypeId { get; set; }
        [ForeignKey("BookTypeId")]

        [ValidateNever]
        public BookType BookType { get; set; }
    }
}