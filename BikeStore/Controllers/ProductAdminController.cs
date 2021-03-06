﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BikeStore.Models;

namespace BikeStore.Controllers
{
    [Authorize]
    public class ProductAdminController : Controller
    {
        private ICategoryProductRepository repository;
        private IQueryable<Category> categories;

        public ProductAdminController(ICategoryProductRepository repo)
        {
            repository = repo;
            categories = repository.GetCategories();
        }
        
        public IActionResult Index()
        {
            return View(repository.GetProducts());
        }

        [Authorize(Roles = "ProductManagement")]
        public IActionResult Edit(int productId)
        {
            ViewBag.Categories = categories;
            return View(repository.GetProducts().FirstOrDefault(p => p.ProductID == productId));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ViewBag.Categories = categories;
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values 
                return View(product);
            }
        }

        public IActionResult Create()
        {
            ViewBag.Categories = categories;
            return View("Edit", new Product());
        }

        [Authorize(Roles = "ProductManagement")]
        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}