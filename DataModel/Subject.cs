namespace SubjectNamespace
{
    public class Subject
    {
        public string Name {get;set;}
        public int DepartmentId {get;set;}

        public Subject (string Name, int DepartmentId)
        {
            this.Name = Name;
            this.DepartmentId = DepartmentId;
        }
    }
}