using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace dxftry
{
    class line
    {
        public Point start;
        public Point end;
        public double ori_sta_x, ori_sta_y, ori_end_x, ori_end_y;

        #region build
        public line()
        {
            this.start = new Point();
            this.end = new Point();

            ori_end_x = -1;
            ori_end_y = -1;
            ori_sta_x = -1;
            ori_sta_y = -1;
        }

        public line(Point s,Point e)
        {
            this.start = s;
            this.end = e;

            ori_end_x = -1;
            ori_end_y = -1;
            ori_sta_x = -1;
            ori_sta_y = -1;
        }

        public line(int sx,int sy,int ex,int ey)
        {
            this.start = new Point(sx, sy);
            this.end = new Point(ex, ey);

            ori_end_x = -1;
            ori_end_y = -1;
            ori_sta_x = -1;
            ori_sta_y = -1;
        }

        public line (Single sx,Single sy,Single ex, Single ey)
        {
            this.ori_sta_x = sx;
            this.ori_sta_y = sy;
            this.ori_end_x = ex;
            this.ori_end_y = ey;

            int isx = Convert.ToInt32(sx);
            int isy = Convert.ToInt32(sy);
            int iex = Convert.ToInt32(ex);
            int iey = Convert.ToInt32(ey);

            this.start = new Point(isx, isy);
            this.end = new Point(iex, iey);
        }

        public line(double sx, double sy, double ex, double ey)
        {
            this.ori_sta_x = sx;
            this.ori_sta_y = sy;
            this.ori_end_x = ex;
            this.ori_end_y = ey;

            int isx = Convert.ToInt32(sx);
            int isy = Convert.ToInt32(sy);
            int iex = Convert.ToInt32(ex);
            int iey = Convert.ToInt32(ey);

            this.start = new Point(isx, isy);
            this.end = new Point(iex, iey);
        }
        #endregion

        #region draw
        public void draw(Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawLine(Pens.Black, start, end);//畫線
            }
        }

        public void draw(Image img)
        {
            using (Graphics g = Graphics.FromImage(img))
            {
                g.DrawLine(Pens.Black, start, end);//畫線
            }
        }
        #endregion

        public void sizechange(double sizenumber)
        {
            if (ori_end_x >= 0 && ori_end_y >= 0 && ori_sta_x >= 0 && ori_sta_y >= 0)
            {
                ori_end_x *= sizenumber;
                ori_end_y *= sizenumber;
                ori_sta_x *= sizenumber;
                ori_sta_y *= sizenumber;

                start.X = Convert.ToInt32(ori_sta_x);
                start.Y = Convert.ToInt32(ori_sta_y);
                end.X = Convert.ToInt32(ori_end_x);
                end.Y = Convert.ToInt32(ori_end_y);
            }
            else
            {
                start.X = Convert.ToInt32(start.X * sizenumber);
                start.Y = Convert.ToInt32(start.Y * sizenumber);
                end.X = Convert.ToInt32(end.X * sizenumber);
                end.Y = Convert.ToInt32(end.Y * sizenumber);
            }
        }
    }
}
