using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace asm._1618
{
    public class Student 
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Email { get; set; }
        public double GPA { get; set; }

        public Student(string name, int id)
        {
            Name = name;
            ID = id;
        }

        public override string ToString()
        {
            return $"{Name} | {ID} | {Email} | {GPA}";
        }
    }
}
