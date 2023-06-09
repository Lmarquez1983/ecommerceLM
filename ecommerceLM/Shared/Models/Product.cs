﻿using System.ComponentModel.DataAnnotations;

namespace ecommerceLM.Shared.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required, StringLength(50,MinimumLength =5)]
        public string ? Name { get; set; }
        [Required, StringLength (500,MinimumLength =10)]
        public string ? Description { get; set; }
        [Required, DataType(DataType.Currency)]
        public double? OriginalPrice { get; set; } = 1.00;
        [DataType(DataType.Currency)]
        public double? NewPrice { get; set; } = 0.00;
        [Required]
        public int Quantity { get; set; } = 1;
        [Required]
        public string ? Image { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime UploadDate { get; set; } = DateTime.Now;
    }
}
