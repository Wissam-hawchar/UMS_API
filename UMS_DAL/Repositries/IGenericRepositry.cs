using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS_DAL.Repositries
{
    public interface IGenericRepositry<T> where T : class
    {
        Task<T> GetById(int id);
    }
}
