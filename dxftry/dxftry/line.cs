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


        public line()
        {
            this.start = new Point();
            this.end = new Point();
        }

        public line(Point s,Point e)
        {
            this.start = s;
            this.end = e;
        }

        public line(int sx,int sy,int ex,int ey)
        {
            this.start = new Point(sx, sy);
            this.end = new Point(ex, ey);
        }

        public line (Single sx,Single sy,Single ex, Single ey)
        {
            int isx = Convert.ToInt32(sx);
            int isy = Convert.ToInt32(sy);
            int iex = Convert.ToInt32(ex);
            int iey = Convert.ToInt32(ey);

            this.start = new Point(isx, isy);
            this.end = new Point(iex, iey);
        }


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
    }
}
