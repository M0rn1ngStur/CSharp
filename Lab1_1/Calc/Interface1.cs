using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    interface IPerson
    {
        int Id
        {
            get;
        }
        string Name
        {
            get;
            set;
        }
        string ClassAttendance
        {
            get;
            set;
        }

    }
}
