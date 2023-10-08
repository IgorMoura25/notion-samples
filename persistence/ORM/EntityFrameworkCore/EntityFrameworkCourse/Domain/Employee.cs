namespace EntityFrameworkCourse.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NationalId { get; set; }

        // 1 : 1 (Um funcionário pode ser de apenas um departamento)
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
