using System.Collections.Generic;
using JokeApp.Data;
using JokeApp.Data.Models;

namespace JokeApp.Services
{
    public abstract class BaseEntityService<T> : IBaseEntityService<T>
        where T: class, IHaveID
    {
        public BaseEntityService(ApplicationDbContext context)
        {
            this.Entities = context;
        }

        public ApplicationDbContext Entities { get ; set ; }

        public T AddOrUpdate(T value)
        {
            ActionOnAddOrUpdate(value);
            if(value.Id == 0)
            {
                this.Entities.Add(value);
            }
            else
            {
                this.Entities.Update(value);
            }
            this.Entities.SaveChanges();
            return value;
        }
        protected virtual void ActionOnAddOrUpdate(T value)
        {

        }
        public bool Delete(long id)
        {
            T value = this.Entities.Set<T>().Find(id);
            this.Entities.Remove(value);
            try
            {
                this.Entities.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IEnumerable<T> FindAll()
        {
            return this.Entities.Set<T>();
        }

        public T FindById(long id)
        {
            return this.Entities.Set<T>().Find(id);
        }
    }
}