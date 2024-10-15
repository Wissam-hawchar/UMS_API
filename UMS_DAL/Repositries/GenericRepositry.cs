using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS_DAL.Models;

namespace UMS_DAL.Repositries
{
    public class GenericRepositry<T> : IGenericRepositry<T> where T : class
    {
        protected readonly DbSet<T> _entities;

        public GenericRepositry(UmsContext context)
        {
            _entities=context.Set<T>();
        }


        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }
    }
}
