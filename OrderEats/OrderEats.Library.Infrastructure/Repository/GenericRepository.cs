using Microsoft.EntityFrameworkCore;
using OrderEats.Library.Application.Interfaces;
using OrderEats.Library.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenercRepository<T> where T : class
    {
        private readonly OrderEatsDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(OrderEatsDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<int> Add(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                var idProperty = typeof(T).GetProperty("Id");

                if (idProperty == null)
                {
                    throw new InvalidOperationException("Entity does not have an 'Id' property.");
                }

                return (int)idProperty.GetValue(entity);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return -1; 
            }
        }


        public async Task<bool> Delete(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    return false;
                }

                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true; 
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<T> Get(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return null; 
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return new List<T>(); 
            }
        }

        public async Task<bool> Update(int id, T entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return false;
            }
        }
    }
}
