using Application.Abstractions.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class EfWriteRepository<T> : IEfWriteRepository<T> where T : BaseEntity
    {
        readonly ApplicationDbContext _appContext;
        public EfWriteRepository(ApplicationDbContext appContext)
        {
            _appContext = appContext;
        }
        public DbSet<T> Table => _appContext.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                if (entity == null)
                    return null;
                {
                    entity.CreatedDate = DateTime.UtcNow;
                    await Table.AddAsync(entity);
                    await _appContext.SaveChangesAsync();
                    return entity;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<bool> AddRangeAsync(List<T> entites)
        {
            if (entites.Count == 0)
                return false;
            else
            {
                await Table.AddRangeAsync(entites);
                await _appContext.SaveChangesAsync();
                return true;
            }

        }

        public async Task<T> RemoveAsync(T entity)
        {
            if (entity == null)
                return null;
            else
            {
                entity.IsDeleted = true;
                //Table.Remove(entity);
                await _appContext.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<T> RemoveAsync(int id)
        {
            var entity = await Table.FindAsync(id);

            if (entity == null)
                return null;
            else
            {
                Table.Remove(entity);
                await _appContext.SaveChangesAsync();
                return entity;

            }

        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
                return null;
            else
            {
                entity.UpdatedDate = DateTime.UtcNow;
                Table.Update(entity);
                await _appContext.SaveChangesAsync();
                return entity;

            }
        }

        public async Task<bool> RemoveRangeAsync(List<T> entites)
        {
            if (entites.Count == 0)
                return false;
            else
            {
                Table.RemoveRange(entites);
                await _appContext.SaveChangesAsync();
                return true;
            }

        }
    }
}
