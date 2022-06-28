using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    struct Location
    {
        public int RIndex { get; set; }
        public int CIndex { get; set; }


        public Location(int rIndex, int cIndex):this() {
            this.RIndex = rIndex;
            this.CIndex = cIndex;
        
        }

    }
}
