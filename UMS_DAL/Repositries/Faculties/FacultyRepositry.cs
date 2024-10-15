using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS_DAL.Models;

namespace UMS_DAL.Repositries.Faculties
{
    public class FacultyRepositry:GenericRepositry<Faculty>, IFacultyRepositry
    {
        public FacultyRepositry(UmsContext dbContext)
        : base(dbContext)
        {
            
        }

        public async Task<IEnumerable<Faculty>> GetFacultyByName(string name)
        {
            return await _entities.Where(x=> x.FacultyName == name).ToListAsync();
        }
    }
}
