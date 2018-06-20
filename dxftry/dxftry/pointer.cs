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
        public int x_to_zero, y_to_zero;
        public double x_to_zero_dou, y_to_zero_dou;
        public double ori_x, ori_y;

        public pointer()
        {
            location = new Point();
        }

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

        public void sizechange(double sizenumber)
        {
            location.X = Convert.ToInt32(location.X * sizenumber);
            location.Y = Convert.ToInt32(location.Y * sizenumber);

        }
    }
}
