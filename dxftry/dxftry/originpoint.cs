/*
 * originpoint類別用於儲存標註原點的資料
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
    class originpoint
    {
        /* 參數說明
         * drawpoint 圖面上原點資料
         * ori_x, ori_y 鎖點原始資料
         */
        public Point drawpoint;
        public double ori_x, ori_y;

        #region build
        /// <summary>
        /// 建構
        /// </summary>
        public originpoint()
        {
            ori_x = -1;//小於0表示沒有原始資料
            ori_y = -1;

            drawpoint = new Point();
        }

        public originpoint(Point p)
        {
            ori_x = -1;//小於0表示沒有原始資料
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

        /* 供縮放使用
         * 用有無原始資料決定算法
         */
        public void sizechange(double changenum)
        {
            if (ori_x >= 0 && ori_y >= 0)
            {
                this.ori_x *= changenum;
                this.ori_y *= changenum;

                drawpoint.X = Convert.ToInt32(this.ori_x);
                drawpoint.Y = Convert.ToInt32(this.ori_y);
            }
            else
            {
                drawpoint.X = Convert.ToInt32(drawpoint.X * changenum);
                drawpoint.Y = Convert.ToInt32(drawpoint.Y * changenum);
            }
        }
    }
}
