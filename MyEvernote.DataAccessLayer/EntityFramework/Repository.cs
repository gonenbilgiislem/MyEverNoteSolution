﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MyEvernote.DataAccessLayer.Abstract;

namespace MyEvernote.DataAccessLayer.EntityFramework
{
    public class Repository<T> : RepositoryBase, IRepository<T> where T : class
    {
        private readonly DbSet<T> _objectSet;

        public Repository()
        {
            _objectSet = context.Set<T>();
        }

        public IEnumerable<T> IeEnumerableList()
        {
            return _objectSet.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }

        public int Insert(T obj)
        {
            //_objectSet.Add(obj);
            context.Entry(obj).State = EntityState.Added;

            return Save();
        }

        public int Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            return Save();
        }

        public int Delete(T obj)
        {
            // _objectSet.Remove(obj);
            context.Entry(obj).State = EntityState.Deleted;
            return Save();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }
    }
}