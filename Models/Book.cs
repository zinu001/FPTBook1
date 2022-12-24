using System;
using System.ComponentModel.DataAnnotations;

namespace FPTLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field cannot be empty!")]
        [Display(Name = "Book Name")]
        [MinLength(3, ErrorMessage = "Book name must contain at least 3 characters!")]
        [MaxLength(100, ErrorMessage = "Book name is too long! Please shorten the name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The book must have its author!")]
        [MinLength(2, ErrorMessage = "Book author must have at least 2 characters!")]
        [MaxLength(100, ErrorMessage = "There are no author name last that long! Please shorten the name!")]
        [Display(Name = "Author")]
        public string Author { get; set; }
        [Required(ErrorMessage = "This field cannot be empty!")]
        [Display(Name = "Image")]
        [Url]
        public string Image { get; set; }
        [Required(ErrorMessage = "This field cannot be empty!")]
        [DataType(DataType.Date)]
        [Display(Name = "Published Date")]
        public DateTime Published_Date { get; set; }
        [Required(ErrorMessage = "This field cannot be empty!")]
        [Range(1, 10000, ErrorMessage = "Book price must be between 1 and 10000!")]
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Required(ErrorMessage = "This field cannot be empty!")]
        [Range(0, 1000, ErrorMessage = "Book quantity must be between 0 and 1000!")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "This field cannot be empty!")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "This field cannot be empty!")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
