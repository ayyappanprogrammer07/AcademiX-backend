using main.Dto;
using main.interfacerepo;
using System.Data;
using static main.Dto.studentManagementDto;
using Microsoft.Data.SqlClient;

namespace main.repoS
{
    public class studentManagementRepo : studentmanagementrepoInterface
    {
        string connectionString = "";
        public studentManagementRepo(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public InsertStudentResponseDTO insert_student(InsertStudentRequestDTO _insertStudentRequestDTO)
        {
            InsertStudentResponseDTO result = new InsertStudentResponseDTO();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("studentmanagement.insertstudentrecord", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Personal Details
                        cmd.Parameters.AddWithValue("@regno", _insertStudentRequestDTO.PersonalInfo.RegNo);
                        cmd.Parameters.AddWithValue("@firstname", _insertStudentRequestDTO.PersonalInfo.FirstName);
                        cmd.Parameters.AddWithValue("@MiddleName", _insertStudentRequestDTO.PersonalInfo.MiddleName);
                        cmd.Parameters.AddWithValue("@lastname", _insertStudentRequestDTO.PersonalInfo.LastName);
                        cmd.Parameters.AddWithValue("@gender", _insertStudentRequestDTO.PersonalInfo.Gender);
                        cmd.Parameters.AddWithValue("@dateofbirth", _insertStudentRequestDTO.PersonalInfo.DateOfBirth);
                        cmd.Parameters.AddWithValue("@age", _insertStudentRequestDTO.PersonalInfo.Age);
                        cmd.Parameters.AddWithValue("@bloodgroup", _insertStudentRequestDTO.PersonalInfo.BloodGroup);
                        cmd.Parameters.AddWithValue("@nationality", _insertStudentRequestDTO.PersonalInfo.Nationality);
                        cmd.Parameters.AddWithValue("@categoryorcommunity", _insertStudentRequestDTO.PersonalInfo.CategoryOrCommunity);

                        //Contact details
                        cmd.Parameters.AddWithValue("@mobileno", _insertStudentRequestDTO.ContactInfo.MobileNo);
                        cmd.Parameters.AddWithValue("@AlternateMobile", _insertStudentRequestDTO.ContactInfo.AlternateMobile);
                        cmd.Parameters.AddWithValue("@Emailaddress", _insertStudentRequestDTO.ContactInfo.EmailAddress);
                        cmd.Parameters.AddWithValue("@AddressLine1", _insertStudentRequestDTO.ContactInfo.AddressLine1);
                        cmd.Parameters.AddWithValue("@AddressLine2", _insertStudentRequestDTO.ContactInfo.AddressLine2);
                        cmd.Parameters.AddWithValue("@City", _insertStudentRequestDTO.ContactInfo.City);
                        cmd.Parameters.AddWithValue("@State", _insertStudentRequestDTO.ContactInfo.State);
                        cmd.Parameters.AddWithValue("@Country", _insertStudentRequestDTO.ContactInfo.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", _insertStudentRequestDTO.ContactInfo.PostalCode);

                        //Parants Details
                        cmd.Parameters.AddWithValue("@FatherName", _insertStudentRequestDTO.ParentDetails.FatherName);
                        cmd.Parameters.AddWithValue("@FathersMobilenumber", _insertStudentRequestDTO.ParentDetails.FathersMobileNumber);
                        cmd.Parameters.AddWithValue("@MothersName", _insertStudentRequestDTO.ParentDetails.MothersName);
                        cmd.Parameters.AddWithValue("@MothersMobile", _insertStudentRequestDTO.ParentDetails.MothersMobile);
                        cmd.Parameters.AddWithValue("@GuardianName", _insertStudentRequestDTO.ParentDetails.GuardianName);
                        cmd.Parameters.AddWithValue("@GuardianPhone", _insertStudentRequestDTO.ParentDetails.GuardianPhone);
                        cmd.Parameters.AddWithValue("@Relationship", _insertStudentRequestDTO.ParentDetails.Relationship);

                        //Academic Details
                        cmd.Parameters.AddWithValue("@courseorprogram", _insertStudentRequestDTO.AcademicDetails.CourseOrProgram);
                        cmd.Parameters.AddWithValue("@Department", _insertStudentRequestDTO.AcademicDetails.Department);
                        cmd.Parameters.AddWithValue("@Year", _insertStudentRequestDTO.AcademicDetails.Year);
                        cmd.Parameters.AddWithValue("@Semester", _insertStudentRequestDTO.AcademicDetails.Semester);
                        cmd.Parameters.AddWithValue("@Section", _insertStudentRequestDTO.AcademicDetails.Section);
                        cmd.Parameters.AddWithValue("@RollNo", _insertStudentRequestDTO.AcademicDetails.RollNo);
                        cmd.Parameters.AddWithValue("@AdmissionDate", _insertStudentRequestDTO.AcademicDetails.AdmissionDate);
                        cmd.Parameters.AddWithValue("@AdmissionType", _insertStudentRequestDTO.AcademicDetails.AdmissionType);

                        //Identification Details
                        cmd.Parameters.AddWithValue("@AadhaarNumber", _insertStudentRequestDTO.IdentificationDetails.AadhaarNumber);
                        cmd.Parameters.AddWithValue("@PassportNumber", _insertStudentRequestDTO.IdentificationDetails.PassportNumber);
                        cmd.Parameters.AddWithValue("@GovtIDType", _insertStudentRequestDTO.IdentificationDetails.GovtIDType);
                        cmd.Parameters.AddWithValue("@GovtIDNumber", _insertStudentRequestDTO.IdentificationDetails.GovtIDNumber);
                        cmd.Parameters.AddWithValue("@sslcSchool", _insertStudentRequestDTO.IdentificationDetails.SslcSchool);
                        cmd.Parameters.AddWithValue("@sslcBoard", _insertStudentRequestDTO.IdentificationDetails.SslcBoard);
                        cmd.Parameters.AddWithValue("@sslcYearofPassing", _insertStudentRequestDTO.IdentificationDetails.SslcYearOfPassing);
                        cmd.Parameters.AddWithValue("@sslcPercentageporCGPA", _insertStudentRequestDTO.IdentificationDetails.SslcPercentageOrCGPA);
                        cmd.Parameters.AddWithValue("@hscSchool", _insertStudentRequestDTO.IdentificationDetails.HscSchool);
                        cmd.Parameters.AddWithValue("@hscBoard", _insertStudentRequestDTO.IdentificationDetails.HscBoard);
                        cmd.Parameters.AddWithValue("@hscYearofPassing", _insertStudentRequestDTO.IdentificationDetails.HscYearOfPassing);
                        cmd.Parameters.AddWithValue("@hscPercentageporCGPA", _insertStudentRequestDTO.IdentificationDetails.HscPercentageOrCGPA);
                        cmd.Parameters.AddWithValue("@PreviousDegree", _insertStudentRequestDTO.IdentificationDetails.PreviousDegree);
                        cmd.Parameters.AddWithValue("@PreviousDepartment", _insertStudentRequestDTO.IdentificationDetails.PreviousDepartment);
                        cmd.Parameters.AddWithValue("@PreviousInstitution", _insertStudentRequestDTO.IdentificationDetails.PreviousInstitution);
                        cmd.Parameters.AddWithValue("@PreviousUniversity", _insertStudentRequestDTO.IdentificationDetails.PreviousUniversity);
                        cmd.Parameters.AddWithValue("@PreviousYearofPassing", _insertStudentRequestDTO.IdentificationDetails.PreviousYearOfPassing);
                        cmd.Parameters.AddWithValue("@PreviousPercentageorCGPA", _insertStudentRequestDTO.IdentificationDetails.PreviousPercentageOrCGPA);

                        SqlParameter resultparameter = new SqlParameter("@result", SqlDbType.Int);
                        resultparameter.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(resultparameter);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        if (Convert.ToInt32(resultparameter.Value) == 1)
                        {
                            result.isadded = true;
                            result.msg = "Student added";
                        }
                        else
                        {
                            result.isadded = false;
                            result.msg = "Student failed to add";
                        }

                    }
                }
                return result;

            }
            catch
            {
                result.isadded = false;

                return result;
            }


        }


        public List<CourseResponseDto> getcourses()
        {
            List<CourseResponseDto> courses = new List<CourseResponseDto>();

            CourseResponseDto coursesd = new CourseResponseDto();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("lookup.studentmanagement_getcourses", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while(reader.Read())
                        {
                            CourseResponseDto course = new CourseResponseDto
                            {
                                courseid = Convert.ToInt32(reader["courseid"]),
                                coursename = Convert.ToString(reader["coursename"])
                                
                            };
                            courses.Add(course);
                        }
                    }
                }
            }
            catch
            {

            }
            return courses;

            
        }

        public List<DepartmentResponseDto> getDepartments(int courseid) {

            List<DepartmentResponseDto> departments = new List<DepartmentResponseDto>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("lookup.studentmanagement_getDepartmentds", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@courseid", courseid);

                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            DepartmentResponseDto department = new DepartmentResponseDto
                            {
                                departmentid = Convert.ToInt32(reader["departmentid"]),
                                departmentname = Convert.ToString(reader["departmentname"])

                            };
                            departments.Add(department);
                        }
                    }
                }
            }
            catch
            {

            }

            return departments;

        }

    }
}
