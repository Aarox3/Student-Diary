using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDiary
{
    class ClassHelper
    {
        public static List<Classrooms> GetClasrooms(string defaultClass)
        {
            return new List<Classrooms>
            {
            new Classrooms { ClassId = 0, NameOfClass = defaultClass },
            new Classrooms { ClassId = 1, NameOfClass = "1a" },
            new Classrooms { ClassId = 2, NameOfClass = "1b" },
            new Classrooms { ClassId = 3, NameOfClass = "2a" },
            new Classrooms { ClassId = 4, NameOfClass = "2b" },
            };
        }

    }
}
