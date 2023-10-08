namespace EntityFrameworkCourse.Domain
{
    public class Department
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        // 1 : N (Um departamento pode ter vários funcionários)
        public List<Employee>? Employees { get; set; }
    }
}
