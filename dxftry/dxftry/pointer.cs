using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace dxftry
{
    class pointer
    {
        public Point location;
        public Int32 number;

        public pointer(Int32 x,Int32 y,Int32 No)
        {
            location = new Point(x, y);
            number = No;
        }

        public void movepoint(Int32 x,Int32 y)
        {
            location.X = x;
            location.Y = y;
        }
    }
}
