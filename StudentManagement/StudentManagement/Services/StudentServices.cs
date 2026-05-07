using System;
using System.Collections.Generic;
using System.Linq;
using StudentManagement.Model;

namespace StudentManagement.Services
{
    internal class StudentServices : IStudentService,IProfessorService
    {
        List<Person> Person = new List<Person>();

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
                    Console.WriteLine("6. Add Professor");
                    Console.WriteLine("7. View Professor");
                    Console.WriteLine("8. Delete Professor");
                    Console.WriteLine("9. Exit");
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
                        AddProfessor();
                    }
                    else if (option == 7)
                    {
                        DisplayProfessor();
                    }
                    else if (option == 8)
                    {
                        DeleteProfessor();
                    }
                    else if (option == 9)
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

        public void AddStudent()
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

                Person.Add(student);

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

        public void displayStudent()
        {
            if(Person.Count == 0)
            {
                Console.WriteLine("No Record Found");
                return;
            }
            else
            {
                Console.WriteLine("\n---List of Student---");

                foreach (Student p in Person.OfType<Student>())
                {
                    p.displayInfo();
                    Console.WriteLine("----------");
                }
            }

        }

        public void DeleteStudent()
        {
            Console.Write("Enter Student name: ");
            string name = Console.ReadLine();

            if (Person.Count == 0)
            {
                Console.WriteLine("No records to delete");
                return;
            }

            Person studentToRemove = Person.OfType<Student>()
                                           .FirstOrDefault(s => s.Name.Equals(name));

            if (studentToRemove != null)
            {
                Person.Remove(studentToRemove);
                Console.WriteLine("Student removed successfully");
            }
            else
            {
                Console.WriteLine("Student not found");
            }
        }

        public void checkAdult()
        {
            Console.Write("Enter Name whose age you have to check:");
            string name = Console.ReadLine();

            Person nameToCheck = Person.OfType<Student>()
                                       .FirstOrDefault(s => s.Name.Equals(name));

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

        public void FilterBasedOnMarks()
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

        public void StudentWithMaxMarks()
        {
            var topStudent = Person.OfType<Student>()
                                   .OrderByDescending(s=>s.Marks).FirstOrDefault();

            topStudent.displayInfo();
        }

        public void AboveMarksFilter()
        {
            try
            {
                Console.Write("Enter Minimum Marks for student");
                int min = Convert.ToInt32(Console.ReadLine());

                var filteredStudents = Person.OfType<Student>()
                                             .Where(s => s.Marks > min);

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

        public void BelowMarksFilter()
        {
            try
            {
                Console.Write("Enter Minimum Marks for student");
                int max = Convert.ToInt32(Console.ReadLine());

                var filteredStudents = Person.OfType<Student>().Where(s => s.Marks < max);

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

        public void MinimumMarks()
        {
            var bottomStudent = Person.OfType<Student>().OrderBy(s => s.Marks).FirstOrDefault();

            bottomStudent.displayInfo();
        }

        public void AddProfessor()
        {
            try
            {
                Console.Write("Enter Name:");
                string name = Console.ReadLine();

                Console.Write("Enter Age:");
                int age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Employee ID:");
                int EmpId = Convert.ToInt32(Console.ReadLine());

                Professor professor = new Professor(name, age, EmpId);

                Person.Add(professor);

                Console.WriteLine("Student Added Successfully");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Age or Marks. Enter Correct Age or Marks");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }

        }
       
        public void DisplayProfessor()
        {
            if(Person.Count == 0)
            {
                Console.WriteLine("No Records Found");
            }
            else
            {
                Console.WriteLine("-----List Of Professor------");

                foreach(Professor p in Person.OfType<Professor>())
                {
                    p.displayInfo();
                }
            }
        }

        public void DeleteProfessor()
        {
            Console.Write("Enter Professor name: ");
            string name = Console.ReadLine();

            if (Person.Count == 0)
            {
                Console.WriteLine("No records to delete");
                return;
            }

            Person ProfessorToRemove = Person.OfType<Professor>()
                                           .FirstOrDefault(s => s.Name.Equals(name));

            if (ProfessorToRemove != null)
            {
                Person.Remove(ProfessorToRemove);
                Console.WriteLine("Professor removed successfully");
            }
            else
            {
                Console.WriteLine("Professor not found");
            }
        }
    }
}
