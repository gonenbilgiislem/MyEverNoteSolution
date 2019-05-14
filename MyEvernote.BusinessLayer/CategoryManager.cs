using MyEvernote.DataAccessLayer.EntityFramework;
using MyEvernote.Entities;
using System.Collections.Generic;

namespace MyEvernote.BusinessLayer
{
    public class CategoryManager
    {
        private readonly Repository<Category> _repository = new Repository<Category>();

        public IEnumerable<Category> GetCategories()
        {
            return _repository.List();
        }

        public Category GetCategoryById(int id)
        {
            return _repository.Find(x => x.Id == id);
        }  
    }
}