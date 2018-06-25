/*
 * line類別用於儲存dxf檔案內"線"的資料
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
    class line
    {
        /* 參數說明
         * start, end 表圖面上線段的起點與終點
         * ori_sta_x, ori_sta_y, ori_end_x, ori_end_y 表線段起點與終點座標的原始資料
         */
        public Point start;
        public Point end;
        public double ori_sta_x, ori_sta_y, ori_end_x, ori_end_y;

        #region build
        /// <summary>
        /// 建構
        /// </summary>
        public line()
        {
            this.start = new Point();
            this.end = new Point();

            ori_end_x = -1;//小於0表示沒有原始資料
            ori_end_y = -1;
            ori_sta_x = -1;
            ori_sta_y = -1;
        }

        public line(Point s,Point e)
        {
            this.start = s;
            this.end = e;

            ori_end_x = -1;//小於0表示沒有原始資料
            ori_end_y = -1;
            ori_sta_x = -1;
            ori_sta_y = -1;
        }

        public line(int sx,int sy,int ex,int ey)
        {
            this.start = new Point(sx, sy);
            this.end = new Point(ex, ey);

            ori_end_x = -1;//小於0表示沒有原始資料
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
        /// <summary>
        /// 繪製
        /// </summary>
        /// <param name="bmp"></param>
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

        /* 供縮放時使用
         * 用有無原始資料決定運算法
         */
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
