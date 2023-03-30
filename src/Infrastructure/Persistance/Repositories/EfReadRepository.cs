using Application.Abstractions.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public  class EfReadRepository<T>:IEfReadRepository<T> where T : BaseEntity
    {
        readonly ApplicationDbContext _appContext;
        public EfReadRepository(ApplicationDbContext appContext)
        {
            _appContext = appContext;
        }
        public DbSet<T> Table => _appContext.Set<T>();
        public virtual IQueryable<T> GetAll(bool tracking = true)
        {

            if (!tracking)
                return Table.AsNoTracking();
            else
                return Table.AsQueryable();
        }
        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> expression, bool tracking = true)
        {

            if (!tracking)
                return Table.Where(expression).AsNoTracking();
            else
                return Table.Where(expression).AsQueryable();

        }
        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query.AsNoTracking();

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query.AsNoTracking();

            return await query.FirstOrDefaultAsync(expression);
        }
    }
}
