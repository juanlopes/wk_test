using System;
using System.Linq;
using WKTest.Models;
using System.Linq.Expressions;
using System.Collections.Generic;
using WKTest.DataAccessObject.Repositories;

namespace WKTest.DataAccessObject.Services
{
    public class ProdutoDAO : IProdutoDAO
    {
        private readonly IDataContext _dc;
        public ProdutoDAO(IDataContext dc)
        {
            _dc = dc;
        }
        public Produto Add(Produto entity)
        {
            var result = _dc.Produtos.Add(entity).Entity;
            _dc.Commit();
            return result;
        }

        public void Delete(Produto entity)
        {
            try
            {
                _dc.Produtos.Remove(entity);
                _dc.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ICollection<Produto> Get()
        {
            return _dc.Produtos.ToList();
        }

        public IQueryable<Produto> Get(Expression<Func<Produto, bool>> filter)
        {
            return _dc.Produtos.Where(filter);
        }

        public Produto Update(Produto entity)
        {
            var result = _dc.Produtos.Update(entity).Entity;
            _dc.Commit();
            return result;
        }
    }
}
