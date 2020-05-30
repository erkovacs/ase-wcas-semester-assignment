using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BikeStore.Models;

namespace BikeStore.Controllers
{
    [Authorize]
    public class CategoryAdminController : Controller
    {
        private ICategoryRepository repository;

        public CategoryAdminController(ICategoryRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View(repository.Categories);
        }

        [Authorize(Roles = "ProductManagement")]
        public IActionResult Edit(int categoryId)
        {
            return View(repository.Categories.FirstOrDefault(p => p.CategoryID == categoryId));
        }


        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCategory(category);
                TempData["message"] = $"{category.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values 
                return View(category);
            }
        }

        public IActionResult Create()
        {
            return View("Edit", new Category());
        }

        [Authorize(Roles = "ProductManagement")]
        [HttpPost]
        public IActionResult Delete(int categoryId)
        {
            Category deletedCategory = repository.DeleteCategory(categoryId);
            if (deletedCategory != null)
            {
                TempData["message"] = $"{deletedCategory.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}