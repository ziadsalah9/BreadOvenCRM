using BreadOven.core.IRepositories;
using BreadOven.core.Models;
using BreadOven.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BreadOven.Repository
{
    public class GenericRepository<T> : IGenricRepository<T> where T : BaseEntity
    {

        private readonly StoreContext _context;
        public GenericRepository(StoreContext context)
        {

            _context = context;
        }
        public async Task AddAsync(T entity)
        {

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }


        public void Edit( T entity)
        {


            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();

        }

        public async Task<T?> GetById(int id)
        {

           //return await _context.Set<T>().FindAsync(id);
           return await _context.Set<T>().FirstOrDefaultAsync(p=>p.Id==id);
        }


        //    var costofunitproduction = _context.CostsAndDistrubutionfromitems.Where(c => c.Id == undto.idofCosts && c.ItemId==sa3ateltash8el.Id).FirstOrDefault();


        //public async Task<T?> GetValue(Expression<Func<int, int, T>> predicate)
        //{
        //  return  await _context.Set<T>().FirstOrDefaultAsync(predicate);
        //}


        public async Task<T?> GetValue(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }


        public async Task savechangesAsync()
        {
            await _context.SaveChangesAsync();
        }

      

        public async Task <decimal> SumAsync(Expression< Func<T,decimal>> Selector)
        {
            return await _context.Set<T>().SumAsync(Selector);
        }

      
    }
}
