using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.Models
{
    public class FirstPoint : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public FirstPoint() { }

        public FirstPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
