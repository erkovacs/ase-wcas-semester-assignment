using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BikeStore.Models;
using BikeStore.Data;

namespace BikeStore.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryProductRepository repository;
        public CategoryController(ICategoryProductRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(repository.GetCategories());
        }

        public IActionResult Products(int id) {
            // id = category id
            var products = repository.GetProductsInCategory(id);
            return View("Views/Product/List.cshtml", products);
        }
    }
}