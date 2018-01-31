using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class Utilities
    {
        public static string GetCaller([CallerMemberName] string caller = null)
        {
            return caller;
        }
    }
}
