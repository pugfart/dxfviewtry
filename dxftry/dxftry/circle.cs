using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace dxftry
{
    class circle
    {
        public Point bulleye;
        public int radius;


        public circle()
        {
            this.bulleye = new Point();
            this.radius = 0;
        }

        public circle(Point p,int r)
        {
            this.bulleye = p;
            this.radius = r;
        }

        public circle(int px,int py,int r)
        {
            this.bulleye = new Point(px, py);
            this.radius = r;
        }


        public void draw(Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawEllipse(Pens.Black, bulleye.X - radius, bulleye.Y - radius, 2 * radius, 2 * radius);//畫圓
                g.DrawEllipse(Pens.Black, bulleye.X, bulleye.Y, 1, 1);//畫圓心
            }
        }

        public void draw(Image img)
        {
            using (Graphics g = Graphics.FromImage(img))
            {
                g.DrawEllipse(Pens.Black, bulleye.X - radius, bulleye.Y - radius, 2 * radius, 2 * radius);//畫圓
                g.DrawEllipse(Pens.Black, bulleye.X, bulleye.Y, 1, 1);//畫圓心
            }
        }
    }
}
