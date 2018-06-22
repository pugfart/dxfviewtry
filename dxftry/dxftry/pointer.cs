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
        public double sizenum;

        #region build
        public pointer()
        {
            location = new Point();

            ori_x = -1;
            ori_y = -1;
        }

        public pointer(Int32 x,Int32 y,Int32 No)
        {
            location = new Point(x, y);
            number = No;

            ori_x = -1;
            ori_y = -1;
        }

        public pointer(double x,double y,int no)
        {
            ori_x = x;
            ori_y = y;
            number = no;
            location = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
        }
        #endregion

        public void movepoint(Int32 x,Int32 y)
        {
            location.X = x;
            location.Y = y;
        }

        public void sizechange(double sizenumber)
        {
            if (ori_x >= 0 && ori_y >= 0)
            {
                ori_x *= sizenumber / sizenum;
                ori_y *= sizenumber / sizenum;

                location.X = Convert.ToInt32(ori_x);
                location.Y = Convert.ToInt32(ori_x);
            }
            else
            {
                location.X = Convert.ToInt32(location.X * sizenumber / sizenum);
                location.Y = Convert.ToInt32(location.Y * sizenumber / sizenum);
            }
        }
    }
}
