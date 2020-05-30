using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Please enter a category name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a category description")]
        public string Description { get; set; }
    }
}
