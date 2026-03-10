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
        [Route("GetCourses")]
        public List<CourseResponseDto> getcourses()
        {
            List<CourseResponseDto> CourseResponseDto = _studentmanagementserviceInterface.getcourses();
            //this is tempt
            return CourseResponseDto;
        }
        [HttpGet]
        [Route("GetDepartments")]
        public List<DepartmentResponseDto>getDepartments(int courseid)
        {
            List<DepartmentResponseDto> departments = _studentmanagementserviceInterface.getDepartments(courseid);
            return departments;
        }

    }
}
