using System;
using System.Linq;
using JokeApp.Data;
using JokeApp.Data.Models;
using JokeApp.Models.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JokeApp.Controllers
{
    public class CategoryController : BaseEntityViewApiController
    {
        public CategoryController(ApplicationDbContext entities) : base(entities)
        {
        }
        public IActionResult Index()
        {
            CategoriesViewModel model = new CategoriesViewModel();
            model.Categories = this.Entities.Categories.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(long? id)
        {
            Category category = new Category();
            if (id.HasValue)
            {
                category = this.Entities.Categories.Find(id.Value);
            }
            System.Console.WriteLine(category.CreationDate);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            System.Console.WriteLine(category.CreationDate);
            category.LastUpdateDate = DateTime.Now;
            if (category.Id == 0)
            {
                this.Entities.Categories.Add(category);
                category.CreationDate = DateTime.Now;
            }
            else
            {
                this.Entities.Categories.Update(category);
            }
            this.Entities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(long id)
        {
            try
            {
                return View(this.Entities.Categories.Find(id));
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            this.Entities.Categories.Remove(category);
            this.Entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}