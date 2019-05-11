using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyEvernote.DataAccessLayer;

namespace MyEvernote.BusinessLayer
{
    public class Repository<T> where T:class
    {

        private readonly DatabaseContext _db = new DatabaseContext();
        private readonly DbSet<T> _objectSet;
        

        public Repository()
        {
            _objectSet = _db.Set<T>();
        }

        public IEnumerable<T> List()
        {
            return _objectSet.ToList();
        }

        public List<T> List(Expression<Func<T,bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }

        public int Insert(T obj)
        {
            //_objectSet.Add(obj);
            _db.Entry(obj).State = EntityState.Added;
            
            return Save();
        }

        public int Update(T obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
           return Save();
        }

        public int Delete(T obj)
        {
            //_objectSet.Remove(obj);
            return Save();
        }

        private int Save()
        {
            return _db.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }
    }
}
