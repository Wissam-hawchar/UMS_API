using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS_BLL.DTO;

namespace UMS_BLL.Services
{
    public interface IFacultyService
    {
        IEnumerable<GetFacultyDTO> GetFacultyByName(string name);
    }
}
