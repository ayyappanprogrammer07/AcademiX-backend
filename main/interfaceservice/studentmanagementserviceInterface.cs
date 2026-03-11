using static main.Dto.studentManagementDto;

namespace main.interfaceservice
{
    public interface studentmanagementserviceInterface
    {
        public InsertStudentResponseDTO insert_student(InsertStudentRequestDTO _insertStudentRequestDTO);

        public List<InsertStudentRequestDTO> GetStudentDetails();
        public List<CourseResponseDto> getcourses();
        public List<DepartmentResponseDto> getDepartments(int courseid);

        public int GetTotalStudentsCount();
        public int GetTotalActiveStudentsCount();

        public Boysandgirlscount GetTotalBoysandGirlscount();


    }
}
