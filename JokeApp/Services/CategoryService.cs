using JokeApp.Data;
using JokeApp.Data.Models;

namespace JokeApp.Services
{
    public class CategoryService : BaseEntityService<Category>
    {
        public CategoryService(ApplicationDbContext context) : base(context)
        {
        }
    }
}