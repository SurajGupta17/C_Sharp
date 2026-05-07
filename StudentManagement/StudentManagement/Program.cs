using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Services;

namespace StudentManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStudentService ser = new StudentServices();
            ser.Run();

            IProfessorService pser = new StudentServices();
            pser.Run();
        }


    }
}
