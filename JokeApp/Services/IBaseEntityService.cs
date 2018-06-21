using System.Collections.Generic;
using JokeApp.Data;
using JokeApp.Data.Models;

namespace JokeApp.Services
{
    public interface IBaseEntityService<T> : IBaseService
        where T : IHaveID
    {
        T AddOrUpdate(T value);
        bool Delete(long id);
        ApplicationDbContext Entities { get; set; }
        T FindById(long id);
        IEnumerable<T> FindAll();
    }
}