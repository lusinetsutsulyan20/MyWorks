namespace CourseNamespace
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        public Course (int Id, string Title, int Credits, int DepartmentId)
        {
            this.Id = Id;
            this.Title = Title;
            this.Credits = Credits;
            this.DepartmentId = DepartmentId;
        }
    }
}