using BreadOven.core.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BreadOven.core.IRepositories
{
    public interface IGenricRepository<T> where T : BaseEntity
    {

        Task AddAsync(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<T?> GetById (int id);

        Task<decimal> SumAsync(Expression<Func<T, decimal>> selector);

        Task savechangesAsync();


        Task<T?> GetValue(Expression<Func<T,bool>> predicate);

        void Edit(T etity);


    }
}
