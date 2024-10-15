using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UMS_BLL;
using UMS_BLL.DTO;
using UMS_DAL;
using UMS_DAL.Models;


namespace UMS_WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController] 
    public class FacultiesController : Controller
    {
        
        private readonly FacultyBLL _faucltyBLL;
        public FacultiesController(IMapper mapper)
        {
            _faucltyBLL=new FacultyBLL(mapper);
        }

        [HttpGet("Get")]
        public async Task<IEnumerable<GetFacultyDTO>> GetFacluty()
        {
            return await _faucltyBLL.getAllFacultiesBLL();
        }

        [HttpGet("GetById")]
        public async Task<GetFacultyDTO> GetById(int id)
        {
            return await _faucltyBLL.getFacultyById(id);
        }
        [HttpGet("GetByName")]
        public async Task<ActionResult<GetFacultyDTO>> GetByName(string name)
        {
            return await _faucltyBLL.getFacultyByName(name);
        }

        [HttpPost("Add")]
        public GetFacultyDTO AddFaculty(AddFacultyDTO fcDto)
        {
            return _faucltyBLL.addFaculty(fcDto);

         
        }
    }
}
