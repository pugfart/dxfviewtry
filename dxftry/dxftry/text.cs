using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace dxftry
{
    class text
    {
        public string word;
        public Point writepoint;

        private string s = "";
        private Font f;

        #region build
        public text()
        {
            f = new Font(s, 10);
        }

        public text(string w,int sx,int sy)
        {
            f = new Font(s, 10);

            this.word = w;
            this.writepoint = new Point(sx, sy);
        }

        public text(string w,Point p)
        {
            f = new Font(s, 10);

            this.word = w;
            this.writepoint = p;
        }
        #endregion

        #region draw
        public void draw(Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawString(word, f, Brushes.Black, writepoint);
            }
        }

        public void draw(Image img)
        {
            using (Graphics g = Graphics.FromImage(img))
            {
                g.DrawString(word, f, Brushes.Black, writepoint);
            }
        }
        #endregion

        public void sizechange(double sizenumber)
        {
            writepoint.X = Convert.ToInt32(writepoint.X * sizenumber);
            writepoint.Y = Convert.ToInt32(writepoint.Y * sizenumber);
        }
    }
}
