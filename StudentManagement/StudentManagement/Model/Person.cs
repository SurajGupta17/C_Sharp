using System;

namespace StudentManagement.Model
{
    internal class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Name can't be empty");
                    name = "Unknown";
                }
                else
                {
                    name = value;
                }
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Age Can't be less than 0");
                    age = 0;
                }
                else if(value > 120)
                {
                    Console.WriteLine("Age Cant be more than 120");
                    age = 120;
                }
                else
                {
                    age = value;
                }
            }
        }

        public Person(string name,int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void displayInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
        }


    }
}
