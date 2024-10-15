using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS_BLL.DTO
{
    public class AddFacultyDTO
    {
        public AddFacultyDTO()
        {
        }

        public AddFacultyDTO(string facultyName, string? deanName)
        {
            FacultyName = facultyName;
            DeanName = deanName;
        }

        public string FacultyName { get; set; } = null!;

        public string? DeanName { get; set; }
    }
}
