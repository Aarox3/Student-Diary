using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDiary
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Comments { get; set; }
        public string Math { get; set; }
        public string Technology { get; set; }
        public string Physics { get; set; }
        public string Polish { get; set; }
        public string Foreign { get; set; }
        public bool AddLessons { get; set; }
        public string ClassOfStudent { get; set; }
        public int ClassId { get; set; }
    }

  }