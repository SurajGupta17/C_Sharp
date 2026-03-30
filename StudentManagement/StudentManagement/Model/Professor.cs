using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    internal class Professor : Person
    {
        private int EmployeeId;

        public int EmpId
        {
            get { return EmployeeId; }
            set
            {
                if (value < 100)
                {
                    Console.WriteLine("EmployeeID cannot be less than 101");
                }
                else
                {
                    EmployeeId = value;
                }
            }
        }
        public Professor(string name,int age,int empId) : base(name, age)
        {
            EmpId = empId;
        }

        public override void displayInfo()
        {
            Console.WriteLine($"Name :{Name}");
            Console.WriteLine($"Age : {Age}");
            Console.WriteLine($"EmpId :{EmpId}");
        }
        
    }
}
