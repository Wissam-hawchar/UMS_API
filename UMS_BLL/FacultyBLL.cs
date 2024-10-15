using AutoMapper;
using UMS_BLL.DTO;
using UMS_DAL;
using UMS_DAL.Models;
using UMS_DAL.Repositries.Faculties;

namespace UMS_BLL
{
    public class FacultyBLL
    {
        public readonly FacultyDAL _facultyDAL;
        private readonly IMapper _mapper;
        public FacultyBLL(IMapper mapper)
        {
            _facultyDAL = new FacultyDAL(new UmsContext());
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetFacultyDTO>> getAllFacultiesBLL()
        {
            var result= await _facultyDAL.getAllFaculties();//list of faculties
            return _mapper.Map<List<GetFacultyDTO>>(result);
        }
        public async Task<GetFacultyDTO> getFacultyById(int id)
        {
            var result = await _facultyDAL.getFacultyById(id);
            return _mapper.Map<GetFacultyDTO>(result);
        }

        public async Task<GetFacultyDTO> getFacultyByName(string name)
        {
            var result = await _facultyDAL.getFacultyByName(name);
            GetFacultyDTO fcDTO = new GetFacultyDTO(result.FacultyId, result.FacultyName, result.DeanName);
            return fcDTO;
        }

        public  GetFacultyDTO addFaculty(AddFacultyDTO facultyDTO)
        {
            try
            {
                Faculty fcRequest=_mapper.Map<Faculty>(facultyDTO);
                Faculty fcResponse = _facultyDAL.addFaculty(fcRequest);
                GetFacultyDTO fcResponseDTO= _mapper.Map<GetFacultyDTO>(fcResponse);
                return fcResponseDTO;
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }
    }
}
