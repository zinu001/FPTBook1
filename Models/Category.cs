using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FPTLibrary.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "This field cannot be empty!")]
        [MinLength(2, ErrorMessage = "Category name must have at least 2 characters!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field cannot be empty!")]
        [Url]
        [Display(Name = "Image")]
        public string Image { get; set; }
        public ICollection<Book> Books { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
