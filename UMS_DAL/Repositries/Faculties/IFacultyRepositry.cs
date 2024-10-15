using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS_DAL.Models;

namespace UMS_DAL.Repositries.Faculties
{
    public interface IFacultyRepositry:IGenericRepositry<Faculty>
    {
        Task<IEnumerable<Faculty>> GetFacultyByName(string name);
    }
}
