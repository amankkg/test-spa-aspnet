using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCrud.Model
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category Find(int id);
        void Add(Category c);
        void Edit(Category c);
        void Remove(int id);
    }

    public class CategoryListRepository : ICategoryRepository
    {
        private int index = 0;
        List<Category> categories = new List<Category>();

        public IEnumerable<Category> GetAll() => categories;

        public Category Find(int id) => categories.FirstOrDefault(c => c.Id == id);

        public void Add(Category c)
        {
            c.Id = ++index;
            categories.Add(c);
        }

        public void Edit(Category c)
        {
            categories = categories.Where(cc => cc.Id == c.Id).ToList();
            categories.Add(c);
        }

        public void Remove(int id)
        {
            categories = categories.Where(c => c.Id != id).ToList();
        }
    }
}
