﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyEvernote.DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        IEnumerable<T> IeEnumerableList();

        List<T> List(Expression<Func<T, bool>> where);

        int Insert(T obj);

        int Update(T obj);

        int Delete(T obj);

        int Save();

        T Find(Expression<Func<T, bool>> where);
    }
}