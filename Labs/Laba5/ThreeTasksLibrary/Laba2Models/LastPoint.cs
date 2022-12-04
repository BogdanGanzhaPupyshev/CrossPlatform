using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeTasksLibrary.Laba2Models
{
    public class LastPoint : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public LastPoint() { }

        public LastPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
