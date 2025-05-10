namespace EnrollmentNamespace
{
    public class Enrollment
    {
        public int StudentId;
        public int CourseId;

        public Enrollment (int StudentId, int CourseId)
        {
            this.StudentId = StudentId;
            this.CourseId = CourseId;
        }
    }
}