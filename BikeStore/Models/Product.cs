﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }
        [ForeignKey("Category")]
        [Required(ErrorMessage = "Please specify a category")]
        public int CategoryFK { get; set; }
    }
}
