using System;
using System.Collections.Generic;

namespace JokeApp.Models
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<JokeCategory> JokeCategories { get; set; } = new List<JokeCategory>();
    }
}