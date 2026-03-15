using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsharpBasics.Models;

namespace CsharpBasics.Services
{
    internal class StudentServices
    {
        public void Run()
        {
            Student s1 = new Student("Suraj", 16);

            s1.DisplayInfo();
        }
    }
}
