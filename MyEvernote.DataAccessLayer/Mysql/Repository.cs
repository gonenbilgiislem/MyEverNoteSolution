using MyEvernote.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyEvernote.DataAccessLayer.Mysql
{
    public class Repository<T> : RepositoryBase, IRepository<T> where T : class
    {
        IEnumerable<T> IRepository<T>.IeEnumerableList()
        {
            throw new NotImplementedException();
        }

        public List<T> List(Expression<Func<T, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public int Insert(T obj)
        {
            throw new NotImplementedException();
        }

        public int Update(T obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(T obj)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public T Find(Expression<Func<T, bool>> @where)
        {
            throw new NotImplementedException();
        }
    }
}