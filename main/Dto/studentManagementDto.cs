namespace main.Dto
{
    public class studentManagementDto
    {
        // PERSONAL INFO
        public class PersonalInfoDTO
        {
            public string? RegNo { get; set; }
            public string? FirstName { get; set; }
            public string? MiddleName { get; set; }
            public string? LastName { get; set; }
            public string? Gender { get; set; }
            public string? DateOfBirth { get; set; }
            public int? Age { get; set; }
            public string? BloodGroup { get; set; }
            public string? Nationality { get; set; }
            public string? CategoryOrCommunity { get; set; }
        }

        // CONTACT INFO
        public class ContactInfoDTO
        {
            public string? MobileNo { get; set; }
            public string? AlternateMobile { get; set; }
            public string? EmailAddress { get; set; }
            public string? AddressLine1 { get; set; }
            public string? AddressLine2 { get; set; }
            public string? City { get; set; }
            public string? State { get; set; }
            public string? Country { get; set; }
            public string? PostalCode { get; set; }
        }

        // PARENT DETAILS
        public class ParentDetailsDTO
        {
            public string? FatherName { get; set; }
            public string? FathersMobileNumber { get; set; }
            public string? MothersName { get; set; }
            public string? MothersMobile { get; set; }
            public string? GuardianName { get; set; }
            public string? GuardianPhone { get; set; }
            public string? Relationship { get; set; }
        }

        // ACADEMIC DETAILS
        public class AcademicDetailsDTO
        {
            public string? CourseOrProgram { get; set; }
            public string? Department { get; set; }
            public string? Year { get; set; }
            public string? Semester { get; set; }
            public string? Section { get; set; }
            public string? RollNo { get; set; }
            public string? AdmissionDate { get; set; }
            public string? AdmissionType { get; set; }
        }

        // IDENTIFICATION DETAILS
        public class IdentificationDetailsDTO
        {
            public string? RegNo { get; set; }
            public string? AadhaarNumber { get; set; }
            public string? PassportNumber { get; set; }
            public string? GovtIDType { get; set; }
            public string? GovtIDNumber { get; set; }

            // SSLC
            public string? SslcSchool { get; set; }
            public string? SslcBoard { get; set; }
            public string? SslcYearOfPassing { get; set; }
            public string? SslcPercentageOrCGPA { get; set; }

            // HSC
            public string? HscSchool { get; set; }
            public string? HscBoard { get; set; }
            public string? HscYearOfPassing { get; set; }
            public string? HscPercentageOrCGPA { get; set; }

            // PREVIOUS DEGREE
            public string? PreviousDegree { get; set; }
            public string? PreviousDepartment { get; set; }
            public string? PreviousInstitution { get; set; }
            public string? PreviousUniversity { get; set; }
            public string? PreviousYearOfPassing { get; set; }
            public string? PreviousPercentageOrCGPA { get; set; }
        }

        // MASTER DTO — combines all sections into one object for the SP call
        public class InsertStudentRequestDTO
        {
            public PersonalInfoDTO PersonalInfo { get; set; }
            public ContactInfoDTO ContactInfo { get; set; }
            public ParentDetailsDTO ParentDetails { get; set; }
            public AcademicDetailsDTO AcademicDetails { get; set; }
            public IdentificationDetailsDTO IdentificationDetails { get; set; }
        }
        public class InsertStudentResponseDTO
        {
            public string msg { get; set; }
            public bool isadded { get; set; }
        }
        public class CourseResponseDto
        {


            public int courseid { get; set; }
            public string? coursename { get; set; }
        }

        public class DepartmentResponseDto
        {
            public int departmentid { get; set; }
            public string? departmentname { get; set; }
        }

        public class Boysandgirlscount
        {
            public int boyscount { get; set; }

            public int girlscount { get; set; }
        }

    }
}
