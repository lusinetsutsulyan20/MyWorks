// Ստեղծել List<Student>, List<Department>, և List<Course>
// իրականացնել հետևյալ հարցումները LINQ-ով
// Գտնել Computer Science դեպարտամենտի ուսանողներին
// Գտնել այն կուրսերը, որտեղ ոչ մի ուսանող չկա
// Computer Science -ի բաժնում դասավանդվող առարկաների ցուցակը
// Գտնել այն դեպարտամենտները, որտեղ 5-ից ավել ուսանող կա
// Գտնել տարիքով ամենափոքր ուսանողի դեպարտմանետի անունը
// Ո՞ր դեպարտամենտում են ամենաշատ առարկաները դասավանդվում

using System;
using System.Linq;
using SubjectNamespace;
using StudentNamespace;
using CourseNamespace;
using DepartmentNamespace;
using EnrollmentNamespace;
using System.ComponentModel.Design;

namespace MyProgNamespace
{
    public class Program 
    {
        public static void Main()
        {

            List<Subject> subjects = new()
            {
                new Subject("Data Structures", 1),
                new Subject("Algorithms", 1),
                new Subject("Calculus I", 2),
                new Subject("Linear Algebra", 2),
                new Subject("Classical Mechanics", 3),
                new Subject("Quantum Physics", 3)
            };  
            var departments = new List<Department>
            {
                new Department(1, "Computer Science"),
                new Department(2, "Mathematics"),
                new Department(3, "Physics")
            };
            var courses = new  List<Course>
            {
                new Course(101, "Data Structures", 4, 1),
                new Course(102, "Algorithms", 4, 1),
                new Course(201, "Calculus I", 3, 2),
                new Course(202, "Linear Algebra", 3, 2),
                new Course(301, "Classical Mechanics", 4, 3),
                new Course(302, "Quantum Physics", 4, 3)
            };
            var students = new List<Student>
            {
                new Student(1, "Alice Johnson", 21, 1, new List<int> { 101, 102 }),
                new Student(2, "Bob Smith", 25, 2, new List<int> { 201, 202 }),
                new Student(3, "Charlie Lee", 20, 3, new List<int> { 301 }),
                new Student(4, "Diana Adams", 22, 1, new List<int> { 101, 202 }),
                new Student(5, "Evan Torres", 23, 2, new List<int> { 201 })
            };
            var enrollments = new List<Enrollment>
            {
                new Enrollment(1, 101), // Alice -> Data Structures
                new Enrollment(1, 102), // Alice -> Algorithms
                new Enrollment(2, 201), // Bob -> Calculus I
                new Enrollment(2, 202), // Bob -> Linear Algebra
                new Enrollment(3, 301), // Charlie -> Classical Mechanics
                new Enrollment(4, 101), // Diana -> Data Structures
                new Enrollment(4, 202), // Diana -> Linear Algebra
                new Enrollment(5, 201)  // Evan -> Calculus I
            };

        
// Գտնել Computer Science դեպարտամենտի ուսանողներին
            var CompScienceStudents =   from student in students
                                        where student.DepartmentId == 
                                            (from department in departments
                                            where department.Name == "Computer Science"
                                            select department.Id
                                            ).FirstOrDefault()
                                        select student;
            foreach (var item in CompScienceStudents)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

// Գտնել այն կուրսերը, որտեղ ոչ մի ուսանող չկա

            var EmptyCourses = from c in courses
                            where !enrollments.Any(e => e.CourseId == c.Id)
                            select c.Title;

            foreach(var item in EmptyCourses)
            {
                Console.WriteLine(item);
            }



                                
// Computer Science -ի բաժնում դասավանդվող առարկաների ցուցակը
            var CompScienceSubject =    from subject in subjects
                                        where subject.DepartmentId == 
                                            (from department in departments
                                            select department.Id
                                            ).First()        
                                        select subject.Name;
            
            foreach(var item in CompScienceSubject)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


// Գտնել այն դեպարտամենտները, որտեղ 5-ից ավել ուսանող կա

            var BigDepartments =    from s in students
                                    group s by s.DepartmentId into g 
                                    where g.Count() > 1
                                    join d in departments on g.Key equals d.Id
                                    select new 
                                    {
                                        Department = d.Name,
                                        Count = g.Count()
                                    };
            foreach(var item in BigDepartments)
            {
                Console.WriteLine(item);
            }


// Գտնել տարիքով ամենափոքր ուսանողի դեպարտմանետի անունը
            var minAge =    (from s in students
                            select s.Age).Min();
            
            var DepartmentMinAge =  (from s in students
                                    where s.Age == minAge
                                    join d in departments on s.DepartmentId equals d.Id
                                    select d.Name).FirstOrDefault();
            Console.WriteLine(DepartmentMinAge);


// Ո՞ր դեպարտամենտում են ամենաշատ առարկաները դասավանդվում

            var MostSubjects =  (from sub in subjects
                                group sub by sub.DepartmentId into gr
                                where gr.Count() == 
                                    (from s in subjects
                                    group s by s.DepartmentId into g
                                    select g.Count()
                                    ).Max()
                                join d in departments on gr.Key equals d.Id
                                select d.Name).FirstOrDefault();

            Console.WriteLine(MostSubjects);

        }

    }
}