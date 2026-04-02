using main.interfaceservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static main.Dto.studentManagementDto;

namespace main.Controllers
{
    [Route("academix/studentmanagement")]
    [ApiController]
    public class studentManagement : ControllerBase
    {
        public readonly studentmanagementserviceInterface _studentmanagementserviceInterface;
        public studentManagement(studentmanagementserviceInterface studentmanagementserviceInterface)
        {
            _studentmanagementserviceInterface = studentmanagementserviceInterface;
        }

        [HttpPost]
        [Route("InsertStudent")]
        public InsertStudentResponseDTO insert_student(InsertStudentRequestDTO _insertStudentRequestDTO)
        {
            InsertStudentResponseDTO result = _studentmanagementserviceInterface.insert_student(_insertStudentRequestDTO);
            return result;

        }
        [HttpGet]
        [Route("GetStudentDetails")]
        public List<InsertStudentRequestDTO> GetStudentDetails()
        {
            List<InsertStudentRequestDTO> result = _studentmanagementserviceInterface.GetStudentDetails();
            return result;
        }


        [HttpGet]
        [Route("GetCourses")]
        public List<CourseResponseDto> getcourses()
        {
            List<CourseResponseDto> CourseResponseDto = _studentmanagementserviceInterface.getcourses();
            //this is tempt
            return CourseResponseDto;
        }
        [HttpGet]
        [Route("GetDepartments")]
        public List<DepartmentResponseDto> getDepartments(int courseid)
        {
            List<DepartmentResponseDto> departments = _studentmanagementserviceInterface.getDepartments(courseid);
            return departments;
        }

        [HttpGet]
        [Route("GetTotalStudentsCount")]
        public int GetTotalStudentsCount()
        {
            int count = _studentmanagementserviceInterface.GetTotalStudentsCount(); ;
            return count;
        }

        [HttpGet]
        [Route("GetTotalActiveStudentsCount")]
        public int GetTotalActiveStudentsCount()
        {
            int count = _studentmanagementserviceInterface.GetTotalActiveStudentsCount();
            return count;
        }

        [HttpGet]
        [Route("GetTotalBoysandGirlscount")]
        public Boysandgirlscount GetTotalBoysandGirlscount()
        {
            Boysandgirlscount result = _studentmanagementserviceInterface.GetTotalBoysandGirlscount();
            return result;
        }

        [HttpGet]
        [Route("getcountnewmonth")]
        public int getcountnewmonth()
        {
            return _studentmanagementserviceInterface.getcountnewmonth();
        }

        [HttpGet]
        [Route("isregnouniqueornot")]
        public bool isregnouniqueornot(string regno)
        {
            return _studentmanagementserviceInterface.isregnouniqueornot( regno);
        }

        [HttpPost]
        [Route("updatestudentrecord")]
        public InsertStudentResponseDTO updatestudentrecord(InsertStudentRequestDTO _insertStudentRequestDTO)
        {
            InsertStudentResponseDTO result = _studentmanagementserviceInterface.updatestudentrecord(_insertStudentRequestDTO);
            return result;

        }

        [HttpDelete]
        [Route("Makestudentinactive")]
        public bool Makestudentinactive(string regno)
        {
            return _studentmanagementserviceInterface.Makestudentinactive(regno);
        }


    }
}
