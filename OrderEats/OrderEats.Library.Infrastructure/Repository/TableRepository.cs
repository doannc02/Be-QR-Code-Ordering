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
    public class TableRepository : ITableRepository
    {
        private readonly OrderEatsDbContext _context;

        public TableRepository(OrderEatsDbContext context)
        {
           _context =  context;
        }
        public async Task<int> Add(Table entity)
        {
            await _context.Tables.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> AddMultiTable(List<Table> tableList)
        {
            try
            {
                await _context.Tables.AddRangeAsync(tableList);
                await _context.SaveChangesAsync();
                return true;
            }catch
            {
                return false;
            } 
        }

        public async Task<bool> Delete(int id)
        {
            var isSuccess = true;
            var table = await _context.Tables.FindAsync(id);
            if (table == null) isSuccess = false;
            if(table != null)
            {
                _context.Tables.Remove(table);
                await _context.SaveChangesAsync();
            }
            return isSuccess;
        }

        public async Task<Table> Get(int id)
        {
            return await _context.Tables.FindAsync(id);
        }

        public async Task<IEnumerable<Table>> GetAll()
        {
            return await _context.Tables.ToListAsync();
        }

        public string GetListTableIsOccupied()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(int id, Table entity)
        {
            try
            {
                _context.Tables.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
