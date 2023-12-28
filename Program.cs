using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowSchoolStudent
{
    public class Program
    {
        struct Student
        {
            public string Name;
            public string Class;
        }
        // Load student data from the file.
        static List<Student> LoadStudentsdata(string filePath)
        {
            List<Student> st1 = new List<Student>();
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);
            // Skip the header line (Name, Class)
            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                if (data.Length == 2)
                {
                    string name = data[0].Trim();
                    string Class = data[1].Trim();
                    Student stu = new Student
                    {
                    
                        Name = name,
                        Class = Class,
                    };
                    st1.Add(stu);
                }
            }
            return st1;
        }
        // Bubble Sort to sort students by name
        static void BubbleSort(List<Student> students)
        {
            int n = students.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (string.Compare(students[j].Name, students[j + 1].Name) > 0)
                    {
                        
                        Student temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }
        }
        // Display all students
        static void DisplayStudentsdata(List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.Name} \n Class: {student.Class} ");
            }
        }
        // Search a student by name
        static Student SearchStudentByName(List<Student> students, string searchName)
        {
            Student foundStudent = new Student();
            foreach (Student st in students)
            {
                if (st.Name.Equals(searchName,
               StringComparison.OrdinalIgnoreCase))
                {
                    foundStudent = st;
                    break;
                }
            }
            return foundStudent;
        }
        static void Main(string[] args)
        {
            
            string filePath = @"D:\Project\RetrieveStudentdata\Students.text";
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error: students.text file not found.");
                return;
            }
            List<Student> students = LoadStudentsdata(filePath);
            // Sort students by name using Bubble Sort..
            BubbleSort(students);
            // Display student data
            Console.WriteLine("Sorted Student Data:");
            DisplayStudentsdata(students);
            bool shouldContinue = true;
            while (shouldContinue)
            {
                Console.WriteLine("Enter the name of the student to search or type 'quit' to exit: ");


                string userInput = Console.ReadLine();
                if (userInput.Equals("quit", StringComparison.OrdinalIgnoreCase))
                {
                    shouldContinue = false;
                }
                else
                {
                    Student foundStudent = SearchStudentByName(students, userInput);
                    if (foundStudent.Name != null)
                    {
                        Console.WriteLine($"Found:Name: {foundStudent.Name}\tClass: {foundStudent.Class}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found");
                    }
                    Console.Read();
                }
            }
        }
    }
}
