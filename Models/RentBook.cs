using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;



namespace LibraryManagement.Models
{
    public class RentBook
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OgrenciId { get; set; }

        public int BookId { get; set;}   
        [ForeignKey("BookId")]

        [ValidateNever]
        public Book Book { get; set; }
        
        
    }
}