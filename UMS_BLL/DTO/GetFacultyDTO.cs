using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS_BLL.DTO
{
    public class GetFacultyDTO
    {
        public GetFacultyDTO()
        {
        }

        public GetFacultyDTO(int facultyId, string facultyName, string? deanName)
        {
            FacultyId = facultyId;
            FacultyName = facultyName;
            DeanName = deanName;
        }

        public int FacultyId { get; set; }

        public string FacultyName { get; set; } = null!;

        public string? DeanName { get; set; }
    }
}
