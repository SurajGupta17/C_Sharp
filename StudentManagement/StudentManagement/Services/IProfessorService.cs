using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services
{
    internal interface IProfessorService
    {
        void AddProfessor();
        void DisplayProfessor();
        void DeleteProfessor();

        void Run();
    }
}
