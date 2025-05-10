namespace StudentNamespace
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public List<int> EnrolledCourseIds { get; set; } = new();

        public Student (int Id, string FullName, int Age, int DepartmentId, List<int> EnrolledCourseIds)
        {
            this.Id = Id;
            this.FullName = FullName;
            this.Age = Age;
            this.DepartmentId = DepartmentId;
            this.EnrolledCourseIds = EnrolledCourseIds;
        }
        public override string ToString()
        {
            return $"{FullName} is studying in this university";
        }
    }
}