using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main1(string[] args)
        {
            StudentList studentList = new StudentList();

            studentList.AddStudent(new Student("Иван", "Петров", 4.0));
            studentList.AddStudent(new Student("Мария", "Иванова", 3.5));
            studentList.AddStudent(new Student("Петр", "Сидоров", 3.2));

            StudentActionDelegate printInfoDelegate = PrintStudentInfo;

            studentList.ProcessStudents(printInfoDelegate);

            Console.ReadLine();
        }

        static void PrintStudentInfo(Student student)
        {
            Console.WriteLine($"Student: {student.FirstName} {student.LastName}, Average Grade: {student.AverageGrade}");
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double AverageGrade { get; set; }

        public Student(string firstName, string lastName, double averageGrade)
        {
            FirstName = firstName;
            LastName = lastName;
            AverageGrade = averageGrade;
        }
    }

    class StudentList
    {
        private List<Student> students;

        public StudentList()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void ProcessStudents(StudentActionDelegate action)
        {
            foreach (var student in students)
            {
                action(student);
            }
        }
    }

    delegate void StudentActionDelegate(Student student);

}
