using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WKTechnology.Domain.AggregatesModel.CategoryAggregate;
using WKTechnology.Domain.SeedWork;

namespace WKTechnology.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public IUnitOfWork UnitOfWork {
            get
            {
                return _context;
            }
        }

        public CategoryRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Category Add(Category category)
        {
            return _context.Category.Add(category).Entitty;
        }

        public async Task<Category> GetAsync(int categoryId)
        {
            return await _context.Categories.Where(category => category.Id == categoryId).SingleOrDefaultAsync();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
