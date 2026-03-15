using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    internal class Student
    {
        public string Name;
        public int Age;
        public int Marks;

        public Student(string name,int age,int marks)
        {
            Name = name;
            Age = age;
            Marks = marks;
        }

        public void displayInfo()
        {
            Console.WriteLine($"Name :{ Name}");
            Console.WriteLine($"Age : { Age}");
            Console.WriteLine($"Marks :{Marks}");
        }
    }
}
