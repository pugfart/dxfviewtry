/*
 * text類別用於儲存dxf檔內string資料 包含文字 數字
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
    class text
    {
        /* 參數說明
         * word 表讀出文字
         * writepoint 表在圖面上何處顯示
         * 
         * s, f 文字顯示樣式 目前沒有特別設定
         */
        public string word;
        public Point writepoint;

        private string s = "";
        private Font f;

        #region build
        /// <summary>
        /// 建構
        /// </summary>
        public text()
        {
            f = new Font(s, 10);//文字字形 文字大小
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
        /// <summary>
        /// 繪製
        /// </summary>
        /// <param name="bmp"></param>
        public void draw(Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawString(word, f, Brushes.Black, writepoint);//分別為 文字 字形 顏色 位置
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

        /// <summary>
        /// 供縮放時改變位置用
        /// </summary>
        /// <param name="sizenumber"></param>
        public void sizechange(double sizenumber)
        {
            writepoint.X = Convert.ToInt32(writepoint.X * sizenumber);
            writepoint.Y = Convert.ToInt32(writepoint.Y * sizenumber);
        }
    }
}
