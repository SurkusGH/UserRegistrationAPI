﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UserRegistrationAPI.Models;
using UserRegistrationAPI.Repositories.IRepository;

namespace UserRegistrationAPI.Repositories.Repository
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        // Dependency injection - instantiate something at Startup.cs procedure and then reference it whenever needed
        //                        meaning whatever we loaded up at statup is awailable application wide
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(DatabaseContext context)
        {
            _context = context; // <- ctor for loacal use when called
            _db = _context.Set<T>(); // <- basically calling Countries or Hotels sets, that are set in DatabaseContext.cs
        }

        public async Task Delete(string id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities); // <- does not have async version, for some reason
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression,
                                 Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _db; // <- query of everything in a db *SET* meaning certain table countries/hotels
            if (include != null) // <- it include property which I indicate it to; but its optional
            {
                query = include(query);
            }


            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
            //^This does not modify database
            //^expression here makes generics extra flexible, based on the context
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null,
                                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _db;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        //public async Task<IPagedList<T>> GetPagedList(RequestParams requestParams,
        //                                              List<string> include = null)
        //{
        //    IQueryable<T> query = _db;

        //    if (include != null)
        //    {
        //        foreach (var includeProperty in include)
        //        {
        //            query = query.Include(includeProperty);
        //        }
        //    }

        //    return await query.AsNoTracking()
        //                      .ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);
        //}

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity); // <- whatever came in as data : add it
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity); // <- starts tracking entity
            _context.Entry(entity).State = EntityState.Modified; // <- when it detects mod, applyes it
        }
    }
}

//db.Courses.Include(x => x.StudentList)
//                         .Include(x => x.LectureList)
//                                                     .Select(x => x.Name).ToList()
//                                                     .ForEach(x => Console.WriteLine($"{index++} - {x}"));