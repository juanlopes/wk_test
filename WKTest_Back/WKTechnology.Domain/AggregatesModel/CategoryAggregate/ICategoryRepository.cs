using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WKTechnology.Domain.SeedWork;

namespace WKTechnology.Domain.AggregatesModel.CategoryAggregate
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category Add(Category category);
        void Update(Category category);
        Task<Category> GetAsync(int categoryId);
    }
}
