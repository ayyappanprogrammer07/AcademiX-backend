using static main.Dto.studentManagementDto;

namespace main.interfacerepo
{
    public interface studentmanagementrepoInterface
    {
        public InsertStudentResponseDTO insert_student(InsertStudentRequestDTO _insertStudentRequestDTO);

        public List<CourseResponseDto> getcourses();
        public List<DepartmentResponseDto> getDepartments(int courseid);

    }
}
