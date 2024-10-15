using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS_DAL.Models;
using UMS_DAL.Repositries;

namespace UMS_DAL
{
    public class FacultyDAL
    {
        private readonly UmsContext _context;
        public FacultyDAL(UmsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Faculty>> getAllFaculties()
        {
            return await _context.Faculties.ToListAsync();
        }

        public async Task<Faculty> getFacultyById(int id)
        {
            return await _context.Faculties.Where(x => x.FacultyId == id).FirstOrDefaultAsync();
        }

        public async Task<Faculty> getFacultyByName(string name)
        {
            return await _context.Faculties.Where(x => x.FacultyName == name).FirstOrDefaultAsync();
        }

        public  Faculty addFaculty(Faculty faculty)
        {
            try
            {
                var result = _context.Faculties.Add(faculty);
                _context.SaveChangesAsync();
                return result.Entity;
                
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
