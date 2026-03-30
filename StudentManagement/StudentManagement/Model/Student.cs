using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    internal class Student : Person
    {
        private int marks;


        //public string Name
        //{
        //    get { return name; }
        //    set
        //    {
        //        if (string.IsNullOrWhiteSpace(value))
        //        {
        //            Console.WriteLine("Name Cannot be Empty");
        //            name = "Unknown";
        //        }
        //        else
        //        {
        //            name = value;
        //        }
        //    }
        //}
        //public int Age
        //{
        //    get { return age; }
        //    set
        //    {
        //        if(value < 0)
        //        {
        //            age = 0;
        //        }
        //        else if (value > 120)
        //        {
        //            Console.WriteLine("Age cant be more than 120");
        //            age = 120;
        //        }
        //        else
        //        {
        //            age = value;
        //        }
        //    }
        //}
        public int Marks
        {

            get { return marks; }
            set
            {
                if(value < 0)
                {
                    marks = 0;
                }
                else if(value > 100)
                {
                    marks = 100;
                }
                else
                {
                    marks = value;
                }
            }
        }



        public Student(string name,int age,int marks) : base(name,age)
        {
            Marks = marks;
        }

        public override void displayInfo()
        {
            Console.WriteLine($"Name :{ Name}");
            Console.WriteLine($"Age : { Age}");
            Console.WriteLine($"Marks :{Marks}");
        }
    }
}
