using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS_BLL.DTO;
using UMS_DAL.Repositries.Faculties;

namespace UMS_BLL.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly IFacultyRepositry _facultyRepositry;
        private readonly IMapper _mapper;
        public FacultyService(IFacultyRepositry facultyRepositry, IMapper mapper)
        {
            _facultyRepositry = facultyRepositry;
            _mapper = mapper;
        }

        public  IEnumerable<GetFacultyDTO> GetFacultyByName(string name)
        {
            var result=_facultyRepositry.GetFacultyByName(name);
            return _mapper.Map<IEnumerable<GetFacultyDTO>>(result);
        }
    }
}
