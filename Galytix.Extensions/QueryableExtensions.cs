﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace Galytix.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> whereClause)
            => condition ? query.Where(whereClause) : query;
    }
}
