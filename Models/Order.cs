using FPTLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FPTLibrary.Models
{
    public enum Payment
    {
        Visa, Mastercard, Napa, Cash
    }
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }   
        public Payment Payment { get; set; }
        public DateTime Order_Date { get; set; }
        [Required]
        public int Quantity { get; set; }
        public AspNetUser AspNetUsers { get; set; }
        public Book Book { get; set; }
    }
}
