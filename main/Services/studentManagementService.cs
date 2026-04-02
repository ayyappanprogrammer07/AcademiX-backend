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
        public List<InsertStudentRequestDTO> GetStudentDetails()
        {
            List<InsertStudentRequestDTO> resut = _studentmanagementrepoInterface.GetStudentDetails();
            return resut;
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

        public int GetTotalStudentsCount()
        {
            int count = _studentmanagementrepoInterface.GetTotalStudentsCount();
            return count;
        }
        public int GetTotalActiveStudentsCount()
        {
            int count = _studentmanagementrepoInterface.GetTotalActiveStudentsCount();
            return count;
        }
        public Boysandgirlscount GetTotalBoysandGirlscount()
        {
            Boysandgirlscount result = _studentmanagementrepoInterface.GetTotalBoysandGirlscount();
            return result;
        }
        public int getcountnewmonth()
        {
            return _studentmanagementrepoInterface.getcountnewmonth();
        }
        public bool isregnouniqueornot(string regno)
        {
            return _studentmanagementrepoInterface.isregnouniqueornot(regno);
        }

        public InsertStudentResponseDTO updatestudentrecord(InsertStudentRequestDTO _insertStudentRequestDTO)
        {
            InsertStudentResponseDTO _InsertStudentResponseDTO = _studentmanagementrepoInterface.updatestudentrecord(_insertStudentRequestDTO);
            return _InsertStudentResponseDTO;
        }

        public bool Makestudentinactive(string regno)
        {
            return _studentmanagementrepoInterface.Makestudentinactive(regno);
        }

    }
}

