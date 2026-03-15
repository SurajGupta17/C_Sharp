using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CsharpBasics.Services;
using CsharpBasics.Models;

namespace CsharpBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("HelloWorld");
            StudentServices service = new StudentServices();
            service.Run();

            bool running = true;


            while (running)
            {
                Console.WriteLine("\n---- MENU ----");
                Console.WriteLine("1. Enter Student Info");
                Console.WriteLine("2. ODD or EVEN");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                int option = Convert.ToInt32(Console.ReadLine());

                if(option == 1)
                {
                    EnterStudentInfo();
                }
                else if(option == 2)
                {
                    OddEvenNum();
                }
                else if(option == 3)
                {
                    running = false;
                    Console.WriteLine("Program Ended");
                }
            }

        }

        static void EnterStudentInfo()
        {
            Console.Write("Enter Student Name:");
            string name = Console.ReadLine();

            Console.Write("Enter Student Age:");
            int age = Convert.ToInt32(Console.ReadLine());

            Student st = new Student(name, age);
            st.DisplayInfo();

            if(age > 18)
            {
                Console.WriteLine(name + " is an adult");
            }
            else if(age<0 && age>110)
            {
                Console.WriteLine("Enter valid age");
            }
            else
            {
                Console.WriteLine(name + " is a child");
            }
        }

        static void OddEvenNum()
        {
            Console.Write("Enter Number to check:");
            int num = Convert.ToInt32(Console.ReadLine());

            if(num < 0)
            {
                Console.WriteLine("Please Enter Positive Number");
            }
            else if(num%2 == 0)
            {
                Console.WriteLine(num + " is Even Number");
            }
            else
            {
                Console.WriteLine(num + " is Odd Number");
            }
        }

    }
}
