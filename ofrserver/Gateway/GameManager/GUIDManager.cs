using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.GameManager
{
    internal class GUIDManager
    {
        public static ulong GUIDPrefix = 0x22;
        public static ulong curGUID = 1;

        public static ulong createNewGUID()
        {
            return ((++curGUID) << 32) | GUIDPrefix;
        }
    }
}
