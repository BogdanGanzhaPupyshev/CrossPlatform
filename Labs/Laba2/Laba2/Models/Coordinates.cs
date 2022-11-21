using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.Models
{
    public class Coordinates
    {
        public FirstPoint FirstPoint { get; set; }

        public LastPoint LastPoint { get; set; }

        public Coordinates() { }

        public Coordinates(FirstPoint firstPoint, LastPoint lastPoint)
        {
            FirstPoint = firstPoint;
            LastPoint = lastPoint;
        }
    }
}
