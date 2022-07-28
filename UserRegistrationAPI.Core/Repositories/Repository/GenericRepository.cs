using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UserRegistrationAPI.Core.Repositories.IRepository;
using UserRegistrationAPI.Data;

namespace UserRegistrationAPI.Core.Repositories.Repository
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task Delete(string id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"> Allows for Lambda Query</param>
        /// <param name="include"> Allows for Secondary Lambda Query</param>
        /// <returns></returns>
        public async Task<T> Get(Expression<Func<T, bool>> expression,
                                 Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
                                 )
        {
            IQueryable<T> query = _db;
            if (include != null)
            {
                query = include(query);
            }


            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"> Allows for Lambda Query</param>
        /// <param name="orderBy">Orders result by parameter</param>
        /// <param name="include"> Allows for Secondary Lambda Query</param>
        /// <returns></returns>
        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null,
                                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
                                           )
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


        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}