using main.interfacerepo;
using main.interfaceservice;
using static main.Dto.studentManagementDto;

namespace main.Services
{
    public class studentManagementService : studentmanagementserviceInterface
    {
        public readonly studentmanagementrepoInterface _studentmanagementrepoInterface;

        public studentManagementService(studentmanagementrepoInterface studentmanagementrepoInterface)
        {
            _studentmanagementrepoInterface = studentmanagementrepoInterface;
        }
        public InsertStudentResponseDTO insert_student(InsertStudentRequestDTO _insertStudentRequestDTO)
        {
            InsertStudentResponseDTO result = _studentmanagementrepoInterface.insert_student(_insertStudentRequestDTO);
            return result;
        }
        public List<CourseResponseDto> getcourses()
        {
            List<CourseResponseDto> courses = _studentmanagementrepoInterface.getcourses();
            return courses;
        }
        public List<DepartmentResponseDto> getDepartments(int courseid)
        {

            List<DepartmentResponseDto> departments = _studentmanagementrepoInterface.getDepartments(courseid);
            return departments;
        }
    }
}

