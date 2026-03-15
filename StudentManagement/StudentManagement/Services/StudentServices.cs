using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Model;

namespace StudentManagement.Services
{
    internal class StudentServices
    {
        List<Student> students = new List<Student>();

        public void Run()
        {
            bool running = true;

            while (running)
            {
                try
                {
                    Console.WriteLine("\n---- STUDENT MENU ----");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. View Students");
                    Console.WriteLine("3. Delete Student");
                    Console.WriteLine("4. Check Adult");
                    Console.WriteLine("5. Filter Bases On Marks");
                    Console.WriteLine("6. Exit");
                    Console.Write("Choose option: ");

                    int option = Convert.ToInt32(Console.ReadLine());

                    if (option == 1)
                    {
                        AddStudent();
                    }
                    else if (option == 2)
                    {
                        displayStudent();
                    }
                    else if (option == 3)
                    {
                        DeleteStudent();
                    }
                    else if (option == 4)
                    {
                        checkAdult();
                    }
                    else if (option == 5)
                    {
                        FilterBasedOnMarks();
                    }
                    else if (option == 6)
                    {
                        running = false;
                        Console.WriteLine("Program Ended");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Marks. Enter Correct Marks");
 }
                catch (Exception ex)
                {
                    Console.WriteLine("Something Went Wrong: " + ex.Message);
                }

                
            }
        }

        void AddStudent()
        {
            try
            {
                Console.Write("Enter Name:");
                string name = Console.ReadLine();

                Console.Write("Enter Age:");
                int age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Marks:");
                int marks = Convert.ToInt32(Console.ReadLine());

                Student student = new Student(name, age, marks);

                students.Add(student);

                Console.WriteLine("Student Added Successfully");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Age or Marks. Enter Correct Age or Marks");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }            
        }

        void displayStudent()
        {
            if(students.Count == 0)
            {
                Console.WriteLine("No Record Found");
                return;
            }
            else
            {
                Console.WriteLine("\n---List of Student---");

                foreach (Student s in students)
                {
                    s.displayInfo();
                    Console.WriteLine("----------");
                }
            }

        }

        void DeleteStudent()
        {
            Console.Write("Enter Student name: ");
            string name = Console.ReadLine();

            if (students.Count == 0)
            {
                Console.WriteLine("No records to delete");
                return;
            }

            Student studentToRemove = students.Find(s => s.Name.Equals(name));

            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
                Console.WriteLine("Student removed successfully");
            }
            else
            {
                Console.WriteLine("Student not found");
            }
        }

        void checkAdult()
        {
            Console.Write("Enter Name whose age you have to check:");
            string name = Console.ReadLine();

            Student nameToCheck = students.Find(s => s.Name.Equals(name));

            if (nameToCheck != null)
            {
                //Console.WriteLine(nameToCheck.Age);
                if(nameToCheck.Age > 18)
                {
                    Console.WriteLine($"{nameToCheck.Name} is an adult");
                }
                else
                {
                    Console.WriteLine($"{nameToCheck.Name} is an child");
                }
            }
        }

        void FilterBasedOnMarks()
        {
           bool running = true;

            while (running)
            {

                Console.WriteLine("-------------");
                Console.WriteLine("A.Student With Maximum Marks");
                Console.WriteLine("B.Students Above Specific Marks");
                Console.WriteLine("C.Students Below SPecific Marks");
                Console.WriteLine("D.Student with Minimum Marks");
                Console.WriteLine("E. Exit");

                string opt = Console.ReadLine();

                if (opt == "A")
                {
                    StudentWithMaxMarks();
                }
                else if (opt == "B")
                {
                    AboveMarksFilter();                    
                }
                else if(opt == "C")
                {
                    BelowMarksFilter();
                }
                else if(opt == "D")
                {
                    MinimumMarks();
                }
                else if(opt == "E")
                {
                    running = false;
                    Console.WriteLine("Exited to the Main menu.");
                }
            }
        }

        void StudentWithMaxMarks()
        {
            var topStudent = students.OrderByDescending(s=>s.Marks).FirstOrDefault();

            topStudent.displayInfo();
        }

        void AboveMarksFilter()
        {
            try
            {
                Console.Write("Enter Minimum Marks for student");
                int min = Convert.ToInt32(Console.ReadLine());

                var filteredStudents = students.Where(s => s.Marks > min);

                foreach (Student s in filteredStudents)
                {
                    s.displayInfo();
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid Marks. Enter Correct Marks");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something Went Wrong: " + ex.Message);
            }
        }

        void BelowMarksFilter()
        {
            try
            {
                Console.Write("Enter Minimum Marks for student");
                int max = Convert.ToInt32(Console.ReadLine());

                var filteredStudents = students.Where(s => s.Marks < max);

                foreach (Student s in filteredStudents)
                {
                    s.displayInfo();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Marks. Enter Correct Marks");
 }
            catch (Exception ex)
            {
                Console.WriteLine("Something Went Wrong: " + ex.Message);
            }
        }

        void MinimumMarks()
        {
            var bottomStudent = students.OrderBy(s => s.Marks).FirstOrDefault();

            bottomStudent.displayInfo();
        }
    }
}
