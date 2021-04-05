using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    class Person : IPerson
    {
        public Person(int personId, string name, string classAttendance)
        {
            Id = personId;
            Name = name;
            ClassAttendance = classAttendance;
        }

        public int Id { get; }

        public string Name { get; set; }

        public string ClassAttendance { get; set; }

    }
}
