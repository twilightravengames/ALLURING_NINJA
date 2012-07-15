using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlluringNinja
{
    public class UtilityTimer
    {

        //utility class - all public static methods

        public static int getTime()
        {
            return System.Environment.TickCount;
        }
    }
}
