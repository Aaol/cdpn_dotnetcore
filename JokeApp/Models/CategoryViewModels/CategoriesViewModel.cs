using System.Collections.Generic;
using JokeApp.Data.Models;
namespace JokeApp.Models.CategoryViewModels
{
    public class CategoriesViewModel 
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}