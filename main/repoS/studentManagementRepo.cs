using main.Dto;
using main.interfacerepo;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics.Metrics;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using static main.Dto.studentManagementDto;
using static System.Collections.Specialized.BitVector32;

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
                        cmd.Parameters.AddWithValue("@createdon", _insertStudentRequestDTO.PersonalInfo.createdon);

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


        //THIS RESPONSIBLE FOR FETCHING THE STUDENT DETAILS
        public List<InsertStudentRequestDTO> GetStudentDetails()
        {
            List<InsertStudentRequestDTO> result = new List<InsertStudentRequestDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("studentmanagement.getStudentDetails", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            InsertStudentRequestDTO data = new InsertStudentRequestDTO
                            {
                                PersonalInfo = new PersonalInfoDTO
                                {
                                    RegNo = Convert.ToString(reader["regno"]),
                                    FirstName = Convert.ToString(reader["FirstName"]),       
                                    MiddleName = Convert.ToString(reader["MiddleName"]),
                                    LastName = Convert.ToString(reader["LastName"]),
                                    Gender = Convert.ToString(reader["Gender"]),
                                    DateOfBirth = Convert.ToString(reader["DateofBirth"]),
                                    Age = Convert.ToInt32(reader["Age"]),
                                    BloodGroup = Convert.ToString(reader["BloodGroup"]),
                                    Nationality = Convert.ToString(reader["Nationality"]),
                                    CategoryOrCommunity = Convert.ToString(reader["CategoryorCommunity"]),
                                },
                                ContactInfo =new ContactInfoDTO
                                {
                                    MobileNo = Convert.ToString(reader["mobileno"]),
                                    AlternateMobile = Convert.ToString(reader["AlternateMobile"]),
                                    EmailAddress = Convert.ToString(reader["Emailaddress"]),
                                    AddressLine1 = Convert.ToString(reader["AddressLine1"]),
                                    AddressLine2 = Convert.ToString(reader["AddressLine2"]),
                                    City = Convert.ToString(reader["City"]),
                                    State = Convert.ToString(reader["State"]),
                                    Country = Convert.ToString(reader["Country"]),
                                    PostalCode = Convert.ToString(reader["PostalCode"])
                                },
                                ParentDetails =new ParentDetailsDTO
                                {
                                    FatherName = Convert.ToString(reader["FatherName"]),
                                    FathersMobileNumber = Convert.ToString(reader["FathersMobilenumber"]),
                                    MothersName = Convert.ToString(reader["MothersName"]),
                                    MothersMobile = Convert.ToString(reader["MothersMobile"]),
                                    GuardianName = Convert.ToString(reader["GuardianName"]),
                                    GuardianPhone = Convert.ToString(reader["GuardianPhone"]),
                                    Relationship = Convert.ToString(reader["Relationship"])
                                },
                                AcademicDetails = new AcademicDetailsDTO
                                {
                                    CourseOrProgram = Convert.ToString(reader["courseorprogram"]),
                                    Department = Convert.ToString(reader["Department"]),
                                    Year = Convert.ToString(reader["Year"]),
                                    Semester = Convert.ToString(reader["Semester"]),
                                    Section = Convert.ToString(reader["Section"]),
                                    RollNo = Convert.ToString(reader["RollNo"]),
                                    AdmissionDate = Convert.ToString(reader["AdmissionDate"]),
                                    AdmissionType = Convert.ToString(reader["AdmissionType"])
                                },
                                IdentificationDetails = new IdentificationDetailsDTO
                                {
                                    AadhaarNumber = Convert.ToString(reader["AadhaarNumber"]),
                                    PassportNumber = Convert.ToString(reader["PassportNumber"]),
                                    GovtIDType = Convert.ToString(reader["GovtIDType"]),
                                    GovtIDNumber = Convert.ToString(reader["GovtIDNumber"]),

                                    SslcSchool = Convert.ToString(reader["sslcSchool"]),
                                    SslcBoard = Convert.ToString(reader["sslcBoard"]),
                                    SslcYearOfPassing = Convert.ToString(reader["sslcYearofPassing"]),
                                    SslcPercentageOrCGPA = Convert.ToString(reader["sslcPercentageporCGPA"]),

                                    HscSchool = Convert.ToString(reader["hscSchool"]),
                                    HscBoard = Convert.ToString(reader["hscBoard"]),
                                    HscYearOfPassing = Convert.ToString(reader["hscYearofPassing"]),
                                    HscPercentageOrCGPA = Convert.ToString(reader["hscPercentageporCGPA"]),

                                    PreviousDegree = Convert.ToString(reader["PreviousDegree"]),
                                    PreviousDepartment = Convert.ToString(reader["PreviousDepartment"]),
                                    PreviousInstitution = Convert.ToString(reader["PreviousInstitution"]),
                                    PreviousUniversity = Convert.ToString(reader["PreviousUniversity"]),
                                    PreviousYearOfPassing = Convert.ToString(reader["PreviousYearofPassing"]),
                                    PreviousPercentageOrCGPA = Convert.ToString(reader["PreviousPercentageorCGPA"])
                                }
                            };
                            result.Add(data);
                        }
                    }
                }
            }
            catch
            {

            }
            return result;
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

        public List<DepartmentResponseDto> getDepartments(int courseid)
        {

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

        public int GetTotalStudentsCount()
        {
            int count = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("studentmanagement.getTotalStudents", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        count = Convert.ToInt32(cmd.ExecuteScalar());         
                    }
                }
            }
            catch
            {
                count = 0;
            }
            return count;
        }
        public int GetTotalActiveStudentsCount()
        {
            int count = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("studentmanagement.getTotalActiveStudents", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch
            {
                count = 0;
            }
            return count;
        }
        public Boysandgirlscount GetTotalBoysandGirlscount()
        {
            Boysandgirlscount result = new Boysandgirlscount();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("studentmanagement.getTotalBoysorGirlsCount", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int boyIndex = reader.GetOrdinal("Boyscount");
                            int girlIndex = reader.GetOrdinal("Girlscount");

                            result.boyscount = reader.IsDBNull(boyIndex) ? 0 : reader.GetInt32(boyIndex);
                            result.girlscount = reader.IsDBNull(girlIndex) ? 0 : reader.GetInt32(girlIndex);
                        }
                    }
                }
            }
            catch
            {
                result.boyscount = 0;
                result.girlscount = 0;
            }
            return result;
        }

        public int getcountnewmonth()
        {
            int count = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("studentmanagement.getcountnewmonth", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@")
                        connection.Open();
                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch
            {
                count = 0;
            }
            return count;
        }

        public bool isregnouniqueornot(string regno)
        {
            bool result;
            int count = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("studentmanagement.isregnouniqueornot", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@regno", regno);
                        connection.Open();
                        count = Convert.ToInt32(cmd.ExecuteScalar());
                        if(count==0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }


        public InsertStudentResponseDTO updatestudentrecord(InsertStudentRequestDTO _insertStudentRequestDTO)
        {
            InsertStudentResponseDTO result = new InsertStudentResponseDTO();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("studentmanagement.updatestudentrecord", connection))
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
                        //cmd.Parameters.AddWithValue("@createdon", _insertStudentRequestDTO.PersonalInfo.createdon);

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

        public bool Makestudentinactive(string regno)
        {
            bool result;
            int count = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("studentmanagement.makestudentinactive", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@regno", regno);
                        connection.Open();
                        count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
