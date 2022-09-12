using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WKTest.DataAccessObject.Repositories;
using WKTest.Models;

namespace WKTest.DataAccessObject.Services
{
    public class CategoriaDAO : ICategoriaDAO
    {
        private readonly IDataContext _dc;
        public CategoriaDAO(IDataContext dc)
        {
            _dc = dc;
        }

        public Categoria Add(Categoria entity)
        {
            var result = _dc.Categorias.Add(entity).Entity;
            _dc.Commit();
            return result;
        }

        public void Delete(Categoria entity)
        {
            try
            {
                _dc.Categorias.Remove(entity);
                _dc.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ICollection<Categoria> Get()
        {
            return _dc.Categorias.ToList();
        }

        public IQueryable<Categoria> Get(Expression<Func<Categoria, bool>> filter)
        {
            return _dc.Categorias.Where(filter);
        }

        public Categoria Update(Categoria entity)
        {
            var result = _dc.Categorias.Update(entity).Entity;
            _dc.Commit();
            return result;
        }

    }
}
