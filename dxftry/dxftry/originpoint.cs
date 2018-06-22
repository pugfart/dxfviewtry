using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace dxftry
{
    class originpoint
    {
        public Point drawpoint;
        public double ori_x, ori_y;

        #region build
        public originpoint()
        {
            ori_x = -1;
            ori_y = -1;

            drawpoint = new Point();
        }

        public originpoint(Point p)
        {
            ori_x = -1;
            ori_y = -1;

            drawpoint = p;
        }

        public originpoint(double x,double y)
        {
            ori_x = x;
            ori_y = y;

            drawpoint = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
        }
        #endregion

        public void sizechange(double changenum)
        {
            if (ori_x >= 0 && ori_y >= 0)
            {
                this.ori_x *= changenum;
                this.ori_y *= changenum;

                drawpoint.X = Convert.ToInt32(this.ori_x);
                drawpoint.Y = Convert.ToInt32(this.ori_y);
            }
        }
    }
}
