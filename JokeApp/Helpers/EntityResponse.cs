using System.Collections.Generic;

namespace JokeApp.Helpers
{
    public class EntityResponse<T>
    {
        public T Entity { get; set; }
        public ICollection<string> Errors { get; set; }
        public ICollection<string> Warnings { get; set; }
        public string Success { get; set; }
        public EntityResponse()
        {
            this.Errors = new List<string>();
            this.Warnings = new List<string>();
        }
        public bool HasErrors()
        {
            return this.Errors.Count > 0;
        }
    }
}