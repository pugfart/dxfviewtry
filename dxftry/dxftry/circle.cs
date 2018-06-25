/*
 * circle類別用於儲存dxf檔案內"圓"的資料
 * 
 * 作者 Andrew Hua, Grace Huang
 * 
 * 最後改動日期 2018.06.25
 */
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
        /* 參數說明
         * bulleye 代表圖面上圓心的位置
         * radius 代表圖面上圓的半徑
         * ori_bul_x, ori_bul_y, ori_rad 分別儲存從dxf檔讀出的資料
         */
        public Point bulleye;
        public int radius;
        public double ori_bul_x, ori_bul_y, ori_rad;

        #region build
        /// <summary>
        /// 建構
        /// </summary>
        public circle()
        {
            this.bulleye = new Point();
            this.radius = 0;

            ori_bul_x = -1;//小於0表示沒有原始資料
            ori_bul_y = -1;
            ori_rad = -1;
        }

        public circle(Point p,int r)
        {
            this.bulleye = p;
            this.radius = r;

            ori_bul_x = -1;//小於0表示沒有原始資料
            ori_bul_y = -1;
            ori_rad = -1;
        }

        public circle(int px,int py,int r)
        {
            this.bulleye = new Point(px, py);
            this.radius = r;

            ori_bul_x = -1;//小於0表示沒有原始資料
            ori_bul_y = -1;
            ori_rad = -1;
        }

        public circle(Single px,Single py,Single r)
        {
            this.ori_bul_x = px;
            this.ori_bul_y = py;
            this.ori_rad = r;

            this.bulleye = new Point(Convert.ToInt32(px), Convert.ToInt32(py));
            this.radius = Convert.ToInt32(r);
        }

        public circle(double px, double py, double r)
        {
            this.ori_bul_x = px;
            this.ori_bul_y = py;
            this.ori_rad = r;

            this.bulleye = new Point(Convert.ToInt32(px), Convert.ToInt32(py));
            this.radius = Convert.ToInt32(r);
        }
        #endregion

        #region draw
        /* 繪圖
         */
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
        #endregion

        /* sizechange用途
         * 進行縮放時使用
         * 以有無原始資料決定如何運算
         */
        public void sizechange(double sizenumber)
        {
            
            if (ori_bul_x >= 0 && ori_bul_y >= 0 && ori_rad >= 0)
            {
                ori_bul_x *= sizenumber;
                ori_bul_y *= sizenumber;
                ori_rad *= sizenumber;

                bulleye.X = Convert.ToInt32(ori_bul_x);
                bulleye.Y = Convert.ToInt32(ori_bul_y);
                radius = Convert.ToInt32(ori_rad);
            }
            else
            {
                bulleye.X = Convert.ToInt32(bulleye.X * sizenumber);
                bulleye.Y = Convert.ToInt32(bulleye.Y * sizenumber);
                radius = Convert.ToInt32(radius * sizenumber);
            }
        }
    }
}
