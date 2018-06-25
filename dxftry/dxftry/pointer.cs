/*
 * pointer類別用於儲存標點資料
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
    class pointer
    {
        /* 參數說明
         * location 表圖面上該點位置
         * number 表此點編號
         * x_to_zero, y_to_zero 表圖面上 此點與原點相隔多少像素
         * x_to_zero_dou, y_to_zero_dou 表經過比例尺換算與原點相隔多少距離
         * ori_x, ori_y 如果標點時有鎖點 便會在此紀錄該點原始資料
         * sizenum 表標點時縮放的幅度 在圖面縮放時使用
         */
        public Point location;
        public Int32 number;
        public int x_to_zero, y_to_zero;
        public double x_to_zero_dou, y_to_zero_dou;
        public double ori_x, ori_y;
        public double sizenum;

        #region build
        /// <summary>
        /// 建構
        /// </summary>
        public pointer()
        {
            location = new Point(0, 0);
            number = 0;
            sizenum = 1;//小於0表示沒有原始資料
            ori_x = -1;
            ori_y = -1;
        }

        public pointer(Int32 x,Int32 y,Int32 No)
        {
            location = new Point(x, y);
            number = No;

            ori_x = -1;//小於0表示沒有原始資料
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

        /// <summary>
        /// 如果座標有改變使用 目前沒用到
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void movepoint(Int32 x,Int32 y)
        {
            location.X = x;
            location.Y = y;
        }

        /// <summary>
        /// 縮放時使用 主要供查找用label使用
        /// </summary>
        /// <param name="sizenumber"></param>
        public void sizechange(double sizenumber)
        {
            if (ori_x >= 0 && ori_y >= 0)
            {
                double drawx = ori_x * sizenumber / sizenum;
                double drawy = ori_y * sizenumber / sizenum;

                location.X = Convert.ToInt32(drawx);
                location.Y = Convert.ToInt32(drawy);
            }
            else
            {
                location.X = Convert.ToInt32(location.X * sizenumber / sizenum);
                location.Y = Convert.ToInt32(location.Y * sizenumber / sizenum);
            }
        }
    }
}
