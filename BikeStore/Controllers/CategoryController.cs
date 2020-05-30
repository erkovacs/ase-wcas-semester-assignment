using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BikeStore.Models;

namespace BikeStore.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository repository;
        public CategoryController(ICategoryRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(repository.Categories);
        }

        public IActionResult Products(int id) {
            // id = category id
            var products = repository.GetProductsInCategory(id);
            return View("Views/Product/List.cshtml", products);
        }
    }
}