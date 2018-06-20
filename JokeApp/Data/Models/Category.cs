using System;
using System.Collections.Generic;

namespace JokeApp.Data.Models
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual DateTime LastUpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<JokeCategory> JokeCategories { get; set; } = new List<JokeCategory>();
    }
}