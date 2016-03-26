using Eshop.Data.Repositories;

namespace Eshop.Services.Data
{
    using Contracts;
    using Eshop.Data.Models;
    using System.Linq;

    public class CategoriesService : ICategoriesService
    {
        private IRepository<Category> repo;

        public CategoriesService(IRepository<Category> repo)
        {
            this.repo = repo;
        }

        public IQueryable<Category> GetAllCategories()
        {
            return this.repo.All();
        }

        public IQueryable<Category> GetMainCategories()
        {
            return this.repo.All().Where(x => x.ParentId == null);
        }

        public Category AddCategory(Category model)
        {
            this.repo.Add(model);
            this.repo.SaveChanges();
            return model;
        }

        public bool DeleteCategory(int Id)
        {
            var category = this.repo.GetById(Id);
            if(category == null)
            {
                return false;
            }
            this.repo.HardDelete(category);
            this.repo.SaveChanges();
            return true;
        }

    }
}
