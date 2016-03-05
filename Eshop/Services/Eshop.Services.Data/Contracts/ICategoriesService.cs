﻿namespace Eshop.Services.Data.Contracts
{
    using Eshop.Data.Models;
    using System.Linq;

    public interface ICategoriesService
    {
        IQueryable<Category> GetAllCategories();
    }
}
