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
            var categoriesToReturn = this.repo.All().Where(x => x.IsDeleted != true);
            return categoriesToReturn;
        }

    }
}
