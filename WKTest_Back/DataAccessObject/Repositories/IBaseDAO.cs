using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WKTest.DataAccessObject.Repositories
{
    public interface IBaseDAO<T> where T : class
    {
        public ICollection<T> Get();
        public IQueryable<T> Get(Expression<Func<T, bool>> filter);
        public T Add(T entity);
        public T Update(T entity);
        public void Delete(T entity);

    }
}
