﻿using CheapestRouteFinder.Domain.Interfaces;
using CheapestRouteFinder.Infrastructure.EFCoreDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CheapestRouteFinder.Infrastructure.EFCoreDataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public T Add(T entity)
            => _context.Set<T>().Add(entity).Entity;

        public void AddRange(IEnumerable<T> entities)
            => _context.Set<T>().AddRange(entities);

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
            => _context.Set<T>().Where(expression);

        public IEnumerable<T> GetAll()
            => _context.Set<T>().ToList();

        public void Remove(T entity)
            => _context.Set<T>().Remove(entity);

        public void RemoveRange(IEnumerable<T> entities)
            => _context.Set<T>().RemoveRange(entities);

        public void SaveChanges()
            => _context.SaveChanges();
    }
}
