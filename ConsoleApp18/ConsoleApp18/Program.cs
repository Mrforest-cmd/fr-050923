using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Linq;

public class Academy
{
    public List<Group> Groups { get; set; }

    public Academy()
    {
        Groups = new List<Group>();
    }

    public void AddGroup(Group group)
    {
        Groups.Add(group);
    }

    public void RemoveGroup(Group group)
    {
        Groups.Remove(group);
    }

    public void UpdateGroup(Group oldGroup, Group newGroup)
    {
        int index = Groups.IndexOf(oldGroup);
        if (index != -1)
        {
            Groups[index] = newGroup;
        }
    }

    public void SaveToXml(string filePath)
    {
        XDocument xdoc = new XDocument(
            new XElement("Academy",
                new XElement("Groups",
                    Groups.Select(group =>
                        new XElement("Group",
                            new XElement("Name", group.Name),
                            new XElement("Teacher",
                                new XElement("FullName", group.Teacher.FullName)),
                            new XElement("Students",
                                group.Students.Select(student =>
                                    new XElement("Student",
                                        new XElement("FullName", student.FullName),
                                        new XElement("Phone", student.Phone),
                                        new XElement("BirthYear", student.BirthYear),
                                        new XElement("ProgrammingGrade", student.ProgrammingGrade),
                                        new XElement("ThreeDModelingGrade", student.ThreeDModelingGrade),
                                        new XElement("RoboticsGrade", student.RoboticsGrade)))))))));

        xdoc.Save(filePath);
    }



    public static Academy LoadFromXml(string filePath)
    {
        Academy academy = new Academy();
        XDocument xdoc = XDocument.Load(filePath);
        foreach (XElement groupElement in xdoc.Root.Element("Groups").Elements("Group"))
        {
            Group group = new Group
            {
                Name = groupElement.Element("Name").Value,
                Teacher = new Teacher
                {
                    FullName = groupElement.Element("Teacher").Element("FullName").Value
                }
            };
            foreach (XElement studentElement in groupElement.Element("Students").Elements("Student"))
            {
                Student student = new Student
                {
                    FullName = studentElement.Element("FullName").Value,
                    Phone = studentElement.Element("Phone").Value,
                    BirthYear = int.Parse(studentElement.Element("BirthYear").Value),
                    ProgrammingGrade = int.Parse(studentElement.Element("ProgrammingGrade").Value),
                    ThreeDModelingGrade = int.Parse(studentElement.Element("ThreeDModelingGrade").Value),
                    RoboticsGrade = int.Parse(studentElement.Element("RoboticsGrade").Value)
                };
                group.Students.Add(student);
            }
            academy.Groups.Add(group);
        }
        return academy;
    }
}

public class Group
{
    public string Name { get; set; }
    public List<Student> Students { get; set; }
    public Teacher Teacher { get; set; }

    public Group()
    {
        Students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        Students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        Students.Remove(student);
    }

    public void UpdateStudent(Student oldStudent, Student newStudent)
    {
        int index = Students.IndexOf(oldStudent);
        if (index != -1)
        {
            Students[index] = newStudent;
        }
    }
}

public class Student
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public int BirthYear { get; set; }
    public int ProgrammingGrade { get; set; }
    public int ThreeDModelingGrade { get; set; }
    public int RoboticsGrade { get; set; }
}

public class Teacher
{
    public string FullName { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Academy academy = new Academy();

        Group group1 = new Group { Name = "Group 1" };
        group1.AddStudent(new Student { FullName = "John Doe", Phone = "1234567890", BirthYear = 2000, ProgrammingGrade = 90, ThreeDModelingGrade = 85, RoboticsGrade = 92 });
        group1.AddStudent(new Student { FullName = "Jane Smith", Phone = "0987654321", BirthYear = 2001, ProgrammingGrade = 88, ThreeDModelingGrade = 91, RoboticsGrade = 87 });
        group1.Teacher = new Teacher { FullName = "Mike Johnson" };
        academy.AddGroup(group1);

        Group group2 = new Group { Name = "Group 2" };
        group2.AddStudent(new Student { FullName = "Bob Williams", Phone = "5551234567", BirthYear = 1999, ProgrammingGrade = 92, ThreeDModelingGrade = 89, RoboticsGrade = 90 });
        group2.Teacher = new Teacher { FullName = "Sarah Davis" };
        academy.AddGroup(group2);

        academy.SaveToXml("academy.xml");

        academy = Academy.LoadFromXml("academy.xml");

        foreach (Group group in academy.Groups)
        {
            Console.WriteLine($"Group: {group.Name}");
            Console.WriteLine("Teacher: " + group.Teacher.FullName);
            Console.WriteLine("Students:");
            foreach (Student student in group.Students)
            {
                Console.WriteLine($"{student.FullName}, {student.Phone}, {student.BirthYear}, Programming: {student.ProgrammingGrade}, 3D Modeling: {student.ThreeDModelingGrade}, Robotics: {student.RoboticsGrade}");
            }
            Console.WriteLine();
        }
    }
}