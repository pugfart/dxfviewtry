/* 
 * 主操作頁面 名稱暫定 機械手通教點介面(Common Robot Pointer Interface)
 * 
 * 功能簡介 匯入DXF檔，在其圖面上標記點位，並將其點位資料傳送給手臂
 * 
 * 作者 Andrew Hua, Grace Huang
 * 
 * 最後改動日期 2018.06.27
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace dxftry
{
    public partial class Form1 : Form
    {
        /*參數說明 讀檔與繪圖
         * load 瀏覽,選擇檔案用視窗
         * readdxf 用來讀取dxf檔 讀取法與txt(筆記本)相同
         * line1, line2 讀檔時使用 無其他作用
         * dxfpen 繪圖用 經過多次修改 有時候會出現其他類似功能的宣告
         * blackpen 黑筆 繪圖用 可直接用Pens.black取代
         * startlineX, startlineY, endlineX, endlineY 讀dxf時暫存"線"原始資料 讀到圓只用到前三個變數
         * draw_dxf 繪圖區 大小隨縮放改變 1倍時與顯示的畫面一樣大
         * pre_readthread, readthread 為讀檔執行緒
         * pointx, pointy, radius 圓在圖面上座標,半徑
         * mouse_move_pic 判斷是否在拖拉畫面 對一些功能適時鎖定
         * sizenum 目前bitmap放大倍率
         * s dxf_view(picturebox)在bitmap上的位置
         * old 滑鼠拖拉時用來計算移動亮適用 紀錄滑鼠點下位置
         * dxflines 紀錄"線"資料的list
         * dxfcircles 紀錄"圓"資料的list
         * dxftext 紀錄"文字"資料的list
         */
        private OpenFileDialog load;
        private StreamReader readdxf;
        private string line1, line2;
        private Graphics dxfpen;
        private Pen blackpen;
        private Single startlineX, startlineY, endlineX, endlineY;//直線用
        private Bitmap draw_dxf;//繪圖區
        private ThreadStart pre_readthread;
        private Thread readthread;//讀檔執行緒
        private Int32 pointx, pointy, radius;//圓心 半徑
        private bool mouse_move_pic = false;
        private double sizenum;//底圖縮放倍率
        private Point s;//看圖位置
        private Point old;//滑鼠拖拉移動 紀錄一開始位置
        private List<line> dxflines;//線 資料
        private List<circle> dxfcircles;//圓 資料
        private List<text> dxftext;//文字 數字 資料
        /* 參數說明 標點
         * active_zeropoint 判斷是否正在標註原點 標註時取代普通標點功能
         * zero_exist 原點是否存在 存在才能進行測量
         * startrulerset 判斷是否正在進行other的比例尺設定
         * ruler_exist 比例尺是否存在 存在才能進行測量
         * pointarray 存標點的陣列 目前最多10點
         * count 紀錄標到第幾個點
         * c 設定other比例尺使用
         * zeropoint 原點資料紀錄
         * rulers, rulere 設定other比例尺使用
         * pixellength 單位像素代表的長度
         * ori_lock_x, ori_lock_y 鎖點時暫存該點資料
         */
        private bool active_zeropoint = false, zero_exist = false, startrulerset = false, ruler_exist = false;//可以標零點? 零點存在? 設比例尺? 比例尺存在?
        private pointer[] pointarray;//標點資料
        private Int32 count,c;//標點號碼 比例尺設定用
        private originpoint zeropoint;//原點
        private Point rulers, rulere;//設比例尺用
        private double pixellength, ori_lock_x, ori_lock_y;//單像素代表長度
        /* 參數說明 滑鼠
         * icon1, icon2, rock 游標圖 icon1沒用到
         * mouselock 是否正在鎖點
         */
        private Image icon1, icon2, rock;//游標圖 icon1沒用到
        private bool mouselock = false;

        public Form1()
        {
            InitializeComponent();
            this.dxf_view.MouseWheel += new MouseEventHandler(dxf_view_MouseWheel);//滾輪事件
        }

        /// <summary>
        /// 讀dxf專用
        /// 配合dxf格式
        /// </summary>
        private void GetTwoLines()//讀dxf 每次2行
        {
            line1 = null;
            line2 = null;
            line1 = readdxf.ReadLine();
            line2 = readdxf.ReadLine();         
        }

        /// <summary>
        /// 放大按鈕 在dxf_view右下角
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picturebigger_Click(object sender, EventArgs e)
        {
            if (startrulerset) return;
            sizenum *= 1.5;//放大1.5倍
            zoomsizenum.Text = Math.Round(sizenum, 2).ToString() + "*";//右上角顯示目前倍率
            draw_dxf.Dispose();//關舊圖
            int w = Convert.ToInt32(sizenum * dxf_view.Width);//調整bitmap尺寸
            int h = Convert.ToInt32(sizenum * dxf_view.Height);
            draw_dxf = new Bitmap(w, h);//新bitmap

            using (Graphics g = Graphics.FromImage(draw_dxf))
                g.Clear(Color.White);//白底

            /* 圖面調整
             * 對繪圖,標點資料放大1.5倍並繪製
             */
            foreach (line cc in dxflines)
            {
                cc.sizechange(1.5);
                cc.draw(draw_dxf);
            }

            foreach(circle cc in dxfcircles)
            {
                cc.sizechange(1.5);
                cc.draw(draw_dxf);
            }

            foreach(text cc in dxftext)
            {
                cc.sizechange(1.5);
                cc.draw(draw_dxf);
            }

            for (int i = 1; i <= count; i++)
            {
                pointarray[i].sizechange(1.5);
            }

            number_label.Location = new Point(Convert.ToInt32(number_label.Location.X * 1.5), Convert.ToInt32(number_label.Location.Y * 1.5));

            double x = s.X * 1.5;//放大後顯示位置校準
            double y = s.Y * 1.5;
            s.X = Convert.ToInt32(x);
            s.Y = Convert.ToInt32(y);
            dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);//picturebox顯示的bitmap擷取

            if (ruler_exist)
                pixellength /= 1.5;

            if (zero_exist)
            {
                zeropoint.sizechange(1.5);
            }
        }

        private void picturesmaller_Click(object sender, EventArgs e)
        {
            if (startrulerset) return;
            sizenum /= 1.5;//縮小1.5倍
            zoomsizenum.Text = Math.Round(sizenum, 2).ToString() + "*";//右上角顯示目前倍率
            draw_dxf.Dispose();//關舊圖
            int w = Convert.ToInt32(sizenum * dxf_view.Width);//調整bitmap尺寸
            int h = Convert.ToInt32(sizenum * dxf_view.Height);
            draw_dxf = new Bitmap(w, h);//新bitmap

            using (Graphics g = Graphics.FromImage(draw_dxf))
                g.Clear(Color.White);//白底

            /* 圖面調整
             * 對繪圖,標點資料放大1.5倍並繪製
             */
            foreach (line cc in dxflines)
            {
                cc.sizechange(1/1.5);
                cc.draw(draw_dxf);
            }

            foreach (circle cc in dxfcircles)
            {
                cc.sizechange(1/1.5);
                cc.draw(draw_dxf);
            }

            foreach (text cc in dxftext)
            {
                cc.sizechange(1/1.5);
                cc.draw(draw_dxf);
            }

            for (int i = 1; i <= count; i++)
            {
                pointarray[i].sizechange(1/1.5);
            }

            number_label.Location = new Point(Convert.ToInt32(number_label.Location.X / 1.5), Convert.ToInt32(number_label.Location.Y / 1.5));

            double x = s.X / 1.5;//縮小後位置校準
            double y = s.Y / 1.5;
            s.X = Convert.ToInt32(x);
            s.Y = Convert.ToInt32(y);
            dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);

            if (ruler_exist)
                pixellength *= 1.5;

            if (zero_exist)
            {
                zeropoint.sizechange(1 / 1.5);
            }
        }

        /// <summary>
        /// 工具列file->load功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load = new OpenFileDialog();
            load.InitialDirectory = "c:\\";
            load.Filter = "dxf files (*.dxf)|*.dxf|All files (*.*)|*.*"; //filters the visible files...

            load.FilterIndex = 1;

            if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK)       //open file dialog is shown here...if "cancel" button is clicked then nothing will be done...
            {
                using (Graphics g = Graphics.FromImage(draw_dxf))
                    g.Clear(Color.White);//白底

                dxflines.Clear();//清除舊資料
                dxfcircles.Clear();
                dxftext.Clear();

                dataname.Text = Path.GetFileNameWithoutExtension(load.FileName);
                sizenum = 1;

                string filepath = load.FileName;
                readdxf = new StreamReader(filepath);
                pre_readthread = new ThreadStart(showdxf);
                readthread = new Thread(pre_readthread);
                if (readthread.IsAlive)//如以有執行緒 就先關閉
                    readthread.Abort();

                readthread.Start();
                //System.Threading.Thread.Sleep(500);//等0.5秒讀取 0.5秒後顯示//突然發現不等待不關也沒關係 2018.06.28
                //Refresh();//刷新圖片
                //readthread.Abort();//結束讀檔執行緒
            }

            //各項資料重置
            pointdata.Rows.Clear();
            Array.Clear(pointarray, 1, count);
            
            ruler_exist = false;
            dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);
            count = 0;
            zoomsizenum.Text = sizenum.ToString() + "*";
        }

        /// <summary>
        /// 工具列measure->set zero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setZeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            active_zeropoint = true;//開始標註原點
            zeropoint = new originpoint();
        }

        /// <summary>
        /// 圖面點擊事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dxf_view_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridViewRowCollection pdata = pointdata.Rows;//宣告右邊表格"行"控制項
            if (e.Button == MouseButtons.Right && !active_zeropoint && zero_exist && ruler_exist && !mouse_move_pic)//普通標點 條件:滑鼠右鍵,沒在標原點,原點存在,比例尺存在
            {                                                                                                       
                count++;//計算標到第幾點
                pointarray[count] = new pointer(s.X + e.X, s.Y + e.Y, count);//用dxf_view座標與滑鼠座標算出該像素在bitmap位置
                draw_dxf.SetPixel(s.X + e.X, s.Y + e.Y, Color.Red);//標的位置//如點到bitmap外會崩潰 FIX ME
                pointarray[count].x_to_zero = pointer_x_to_zero(pointarray[count]);//與原點距離 單位:像素
                pointarray[count].y_to_zero = pointer_y_to_zero(pointarray[count]);

                if (mouselock)
                {
                    pointarray[count].ori_x = ori_lock_x;//存鎖點的資料
                    pointarray[count].ori_y = ori_lock_y;
                    if (zeropoint.ori_x >= 0 && zeropoint.ori_y >= 0)
                    {
                        pointarray[count].x_to_zero_dou = (pointarray[count].ori_x - zeropoint.ori_x) * pixellength;//有原始資料便用原始資料算距離
                        pointarray[count].y_to_zero_dou = (pointarray[count].ori_y - zeropoint.ori_y) * pixellength;
                    }
                    else
                    {
                        pointarray[count].x_to_zero_dou = pointarray[count].x_to_zero * pixellength;//用比例尺算與原點距離
                        pointarray[count].y_to_zero_dou = pointarray[count].y_to_zero * pixellength;
                    }
                }
                else
                {
                    pointarray[count].ori_x = -1;//沒鎖點便存-1
                    pointarray[count].ori_y = -1;
                    pointarray[count].x_to_zero_dou = pointarray[count].x_to_zero * pixellength;//用比例尺算與原點距離
                    pointarray[count].y_to_zero_dou = pointarray[count].y_to_zero * pixellength;
                }

                pointarray[count].sizenum = sizenum;//標點時的縮放倍率
                dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);

                pdata.Add(new object[] { pointarray[count].number.ToString(), pointarray[count].x_to_zero_dou.ToString(), pointarray[count].y_to_zero_dou.ToString() });//資料顯示在右邊表格

                label1.Text = label1.Text + "\n" + pointarray[count].x_to_zero_dou.ToString() + "\n" + pointarray[count].y_to_zero_dou.ToString() + "\n" + count.ToString();//測試用 ***完成後應刪除
            }

            else if (active_zeropoint && ruler_exist && e.Button == MouseButtons.Right && !mouse_move_pic)//原點標點
            {
                if (zero_exist)//如有上個原點 將其變回白色
                    draw_dxf.SetPixel(zeropoint.drawpoint.X, zeropoint.drawpoint.Y, Color.White);
                zeropoint = new originpoint(new Point(s.X + e.X, s.Y + e.Y));//用dxf_view座標和滑鼠座標算在bitmap位置
                draw_dxf.SetPixel(s.X + e.X, s.Y + e.Y, Color.Blue);
                dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);
                if (mouselock)
                {
                    zeropoint.ori_x = ori_lock_x;//存鎖點的資料
                    zeropoint.ori_y = ori_lock_y;
                }
                else
                {
                    zeropoint.ori_x = -1;//沒鎖點便存-1
                    zeropoint.ori_y = -1;
                }
                active_zeropoint = false;
                zero_exist = true;
                label1.Text = label1.Text + "\n" + zeropoint.drawpoint.X.ToString() + "\n" + zeropoint.drawpoint.Y.ToString();//測試用 ***完成後應刪除
            }

            if (startrulerset && e.Button == MouseButtons.Right && !mouse_move_pic)//設比例尺 點圖面上兩點手動填入距離算比例尺
            {
                if (c == 1) rulers = new Point(s.X + e.X, s.Y + e.Y);//第一點座標
                if (c == 2) rulere = new Point(s.X + e.X, s.Y + e.Y);//第二點座標
                c++;
                if (c >= 3 && length_refer.Text != "" && length_refer.Text != "在此輸入長度")//三以上且有輸入距離會計算比例尺
                {
                    length_refer.Visible = false;
                    startrulerset = false;
                    ruler_exist = true;
                    rulersetter();//計算方法
                }
            }
        }
        //------------------------------------------------------------------
        /// <summary>
        /// 滑鼠按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dxf_view_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//左鍵按下
            {
                old = new Point(e.X, e.Y);//紀錄按下
                Bitmap a = (Bitmap)Bitmap.FromFile("rock.png");//滑鼠圖 手抓東西圖
                SetCursor(rock, a, new Point(0, 0));
                mouse_move_pic = true;
            }
            else//右鍵按下
            {
                Bitmap a = (Bitmap)Bitmap.FromFile("dot2.png");//滑鼠圖 紅色準心
                SetCursor(icon2, a, new Point(0, 0));
            }
        }

        /// <summary>
        /// 滑鼠進入dxf_view事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dxf_view_MouseEnter(object sender, EventArgs e)
        {
            dxf_view.Focus();//滾輪縮放"可能"用到 目前無功能
        }

        /// <summary>
        /// 滑鼠離開dxf_view事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dxf_view_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;//還原滑鼠樣式
        }

        /// <summary>
        /// 表格行頭雙點事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pointdata_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = Convert.ToInt32(pointdata.Rows[e.RowIndex].Cells[0].Value);//取得標點編號
            number_label.Text = pointarray[rowindex].number.ToString();
            int x, y;
            x = Convert.ToInt32((pointarray[rowindex].location.X) - s.X);//位置換算
            y = Convert.ToInt32((pointarray[rowindex].location.Y) - s.Y);

            if (x >= 0 && y >= 0 && x <= dxf_view.Width && y<=dxf_view.Height)//判斷是否在觀看範圍內 負數表沒有
            {
                number_label.Visible = true;
                number_label.Location = new Point(x + dxf_view.Location.X, y + dxf_view.Location.Y);
            }
            else//在範圍外就讓label消失
                number_label.Visible = false;
        }

        /// <summary>
        /// 滑鼠在dxf_view上移動事件 *鎖點功能*
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dxf_view_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            Form f = new Form();
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Point mousep = new Point();
            foreach (line cc in dxflines)//掃描線上的起點跟終點
            {
                if (Cursor.Position != mousep)
                {
                    Point isthis = cc.start;
                    if ((e.X + s.X - isthis.X < 5 && e.X + s.X - isthis.X > -5) &&
                        (e.Y + s.Y - isthis.Y < 5 && e.Y + s.Y - isthis.Y > -5))//滑鼠靠近start
                    {
                        mouselock = true;
                        mousep = control.PointToScreen(new Point(f.Location.X, f.Location.Y));//form在螢幕上的位置
                        mousep.X = mousep.X + isthis.X - s.X;//form在螢幕位置 + 該點在form的位置 = 滑鼠應該鎖定位置
                        mousep.Y = mousep.Y + isthis.Y - s.Y;
                        Cursor.Position = mousep;//游標位置設定

                        ori_lock_x = cc.ori_sta_x;//暫存鎖點原始資料
                        ori_lock_y = cc.ori_sta_y;
                        //Cursor.Clip = new Rectangle(this.Location, this.Size);
                    }
                    else
                        mouselock = false;
                }

                if (Cursor.Position != mousep)
                {
                    Point isthis = cc.end;
                    if ((e.X + s.X - isthis.X < 5 && e.X + s.X - isthis.X > -5) &&
                        (e.Y + s.Y - isthis.Y < 5 && e.Y + s.Y - isthis.Y > -5))//滑鼠靠近end
                    {
                        mouselock = true;
                        mousep = control.PointToScreen(new Point(f.Location.X, f.Location.Y));
                        mousep.X = mousep.X + isthis.X - s.X;
                        mousep.Y = mousep.Y + isthis.Y - s.Y;
                        Cursor.Position = mousep;

                        ori_lock_x = cc.ori_end_x;
                        ori_lock_y = cc.ori_end_y;
                        //Cursor.Clip = new Rectangle(this.Location, this.Size);
                    }
                    else
                        mouselock = false;
                }
                }

            if (Cursor.Position != mousep)//沒鎖在線上再掃圓心
            { 
                foreach (circle bb in dxfcircles)//掃描圓心
                    {
                        Point isthis = bb.bulleye;
                        if ((e.X + s.X - isthis.X < 5 && e.X + s.X - isthis.X > -5) &&
                            (e.Y + s.Y - isthis.Y < 5 && e.Y + s.Y - isthis.Y > -5))//滑鼠靠近圓心
                        {
                            mouselock = true;
                            mousep = control.PointToScreen(new Point(f.Location.X, f.Location.Y));
                            mousep.X = mousep.X + isthis.X - s.X;
                            mousep.Y = mousep.Y + isthis.Y - s.Y;
                            Cursor.Position = mousep;

                            ori_lock_x = bb.ori_bul_x;
                            ori_lock_y = bb.ori_bul_y;
                            //Cursor.Clip = new Rectangle(this.Location, this.Size);
                        }
                        else mouselock = false;
                    }
            }
        }

        /// <summary>
        /// 工具列measure->square center
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void squareCenterToolStripMenuItem_Click(object sender, EventArgs e)//點方形4角or對角算中心 FIX ME NOT FINISH
        {

        }

        /// <summary>
        /// 工具列measure->set scale->a4 設a4比例尺
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void a4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pixellength = 1/sizenum;
            ruler_exist = true;
        }

        /// <summary>
        /// 工具列measure->set scale->other 沒適合選項時自己設定比例尺
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void otherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("右邊長度請記得輸入", "注意", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (d == DialogResult.OK)
            {
                length_refer.Visible = true;
                startrulerset = true;
                c = 1;
            }
        }

        /// <summary>
        /// 在dxf_view上放開滑鼠事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dxf_view_MouseUp(object sender, MouseEventArgs e)
        {
            if (number_label.Visible)//查找用label是否正在使用
            {
                if (number_label.Location.X - dxf_view.Location.X + (e.X - old.X) >= 0 && 
                    number_label.Location.Y - dxf_view.Location.Y + (e.Y - old.Y) >= 0 &&
                    number_label.Location.X - dxf_view.Location.X + (e.X - old.X) <= dxf_view.Width && 
                    number_label.Location.Y - dxf_view.Location.Y + (e.Y - old.Y) <= dxf_view.Height)//檢查移動後標籤是否還在dxf_view內

                    number_label.Location = new Point(number_label.Location.X + (e.X - old.X), number_label.Location.Y + (e.Y - old.Y));//調整至新位置

                else//沒在圖內就消失

                    number_label.Visible = false;
            }

            if (mouse_move_pic)//移動畫面
            {
                s.X = s.X - e.X + old.X;//用滑鼠點下位置與放開位置計算畫面移動距離
                s.Y = s.Y - e.Y + old.Y;
                dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);
                mouse_move_pic = false;
            }            
        }

        /// <summary>
        /// 載入form事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            number_label.Visible = false;//一開始 查找用label不會顯示
            
            blackpen = new Pen(Color.Black);//用黑線畫dxf ***可被取代
            blackpen.Width = 1;
            draw_dxf = new Bitmap(dxf_view.Width, dxf_view.Height);//先在bitmap畫
            using (dxfpen = Graphics.FromImage(draw_dxf))
            {
                dxfpen.Clear(Color.White);//底色 白
            }
            dxf_view.Image = draw_dxf;//刷新

            count = 0;//標點資料列建立
            pointarray = new pointer[10];
            pointarray[0] = new pointer();

            s = new Point(0, 0);//起始看bitmap的位置(0,0)
            sizenum = 1;

            dxflines = new List<line>();//dxf的list建立
            dxfcircles = new List<circle>();
            dxftext = new List<text>();

            icon1 = Image.FromFile("dot1.png");//黑色準心 沒用到
            icon2 = Image.FromFile("dot2.png");//紅色準心 點滑鼠的圖
            rock = Image.FromFile("rock.png");//拖拉時的手
        }

        /// <summary>
        /// 使用other設定時會出現的textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void length_refer_MouseClick(object sender, MouseEventArgs e)
        {
            length_refer.Text = "";
        }

        /// <summary>
        /// 簡單讀取dxf方法 只有 線 圓 文字
        /// </summary>
        private void showdxf()
        {
            draw_dxf.Dispose();//關舊圖
            int w = Convert.ToInt32(sizenum * dxf_view.Width);//調整bitmap尺寸
            int h = Convert.ToInt32(sizenum * dxf_view.Height);
            
            draw_dxf = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(draw_dxf))//白底
            {
                g.Clear(Color.White);
            }

            do
            {
                GetTwoLines();
                if (line1 == "  0" && line2 == "LINE")//讀直線
                {
                    startlineX = startlineY = endlineX = endlineY = 0;
                    do
                    {
                        GetTwoLines();
                        if (line1 == " 10") startlineX = Convert.ToSingle(line2);//x起點
                        else if (line1 == " 20") startlineY = Convert.ToSingle(line2);//y起點
                        else if (line1 == " 11") endlineX = Convert.ToSingle(line2);//x終點
                        else if (line1 == " 21") endlineY = Convert.ToSingle(line2);//y終點
                    } while (line1 != " 21");
                    startlineX = Convert.ToSingle(startlineX * sizenum);
                    startlineY = Convert.ToSingle((draw_dxf.Height - startlineY * sizenum));
                    endlineX = Convert.ToSingle(endlineX * sizenum);
                    endlineY = Convert.ToSingle((draw_dxf.Height - endlineY * sizenum));

                    dxflines.Add(new line(startlineX, startlineY, endlineX, endlineY));
                    
                    using (dxfpen = Graphics.FromImage(draw_dxf))
                    {
                        dxfpen.DrawLine(blackpen, startlineX, startlineY, endlineX, endlineY);
                    }
                }

                else if (line1 == "  0" && line2 == "CIRCLE")//讀圓
                {
                    pointx = pointy = 0;
                    do
                    {
                        GetTwoLines();
                        if (line1 == " 10") startlineX = Convert.ToSingle(line2);//圓心x
                        else if (line1 == " 20") startlineY = Convert.ToSingle(line2);//圓心y
                        else if (line1 == " 40") endlineX = Convert.ToSingle(line2);//半徑
                    } while (line1 != " 40");

                    startlineX = Convert.ToSingle(startlineX * sizenum);
                    startlineY = Convert.ToSingle(startlineY * sizenum);
                    endlineX = Convert.ToSingle(endlineX * sizenum);

                    startlineY = draw_dxf.Height - startlineY;
                    pointx = Convert.ToInt32(startlineX);
                    pointy = Convert.ToInt32(startlineY);
                    radius = Convert.ToInt32(endlineX);

                    dxfcircles.Add(new circle(startlineX, startlineY, endlineX));
                    Rectangle rec = new Rectangle(pointx - radius, pointy - radius, 2 * radius, 2 * radius);//設定矩形 畫圓用
                    using (dxfpen = Graphics.FromImage(draw_dxf))
                    {
                        dxfpen.DrawEllipse(blackpen, rec);//再矩形內畫與四邊貼齊的圓
                        //dxfpen.DrawEllipse(Pens.DarkBlue, pointx, pointy, 1, 1);//圓心點
                        draw_dxf.SetPixel(pointx, pointy, Color.DarkBlue);//圓心點
                    }
                }

                else if(line1=="  0"&&line2=="MTEXT")//讀文字
                {
                    pointx = pointy = 0;
                    string s="";
                    Font f = new Font(s, 10);
                    do
                    {
                        GetTwoLines();
                        if (line1 == " 10") startlineX = Convert.ToSingle(line2);//寫的位置x
                        else if (line1 == " 20") startlineY = Convert.ToSingle(line2);//寫的位置y
                        else if (line1 == "  1") s = line2;//文字內容
                    } while (line1 != "  1");

                    pointx = Convert.ToInt32(Math.Round(startlineX * sizenum));
                    pointy = Convert.ToInt32(Math.Round(startlineY * sizenum));
                    pointy = draw_dxf.Height - pointy;
                    Point p = new Point(pointx, pointy);
                    dxftext.Add(new text(s, p));
                    using (dxfpen = Graphics.FromImage(draw_dxf))
                    {
                        dxfpen.DrawString(s, f, Brushes.Black, p);
                    }
                }

                else if (line1 == "  0" && line2 == "TEXT")//讀文字
                {
                    pointx = pointy = 0;
                    string s = "";
                    Font f = new Font(s, 10);
                    do
                    {
                        GetTwoLines();
                        if (line1 == " 10") startlineX = Convert.ToSingle(line2);//寫的位置x
                        else if (line1 == " 20") startlineY = Convert.ToSingle(line2);//寫的位置y
                        else if (line1 == "  1") s = line2;//文字內容
                    } while (line1 != "  1");

                    pointx = Convert.ToInt32(Math.Round(startlineX * sizenum));
                    pointy = Convert.ToInt32(Math.Round(startlineY * sizenum));
                    pointy = draw_dxf.Height - pointy;
                    Point p = new Point(pointx, pointy);
                    dxftext.Add(new text(s, p));
                    using (dxfpen = Graphics.FromImage(draw_dxf))
                    {
                        dxfpen.DrawString(s, f, Brushes.Black, p);
                    }
                }
            } while (line1 != "EOF" && line2 != "EOF");//dxf最後一行文字 表結束

            dxf_view.Image = draw_dxf;            
        }
        
        /// <summary>
        /// 畫面擷取方法
        /// </summary>
        /// <param name="s"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private Image cut(Point s, int width, int height)//看部分dxf
        {
            Bitmap cutimage = new Bitmap(width, height);
            Rectangle rec = new Rectangle(0, 0, width, height);
            Graphics draw = Graphics.FromImage(cutimage);
            draw.DrawImage(draw_dxf, rec, s.X, s.Y, width, height, GraphicsUnit.Pixel);
            return cutimage;
        }

        /// <summary>
        /// 游標圖案設定方法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="cursor"></param>
        /// <param name="hotPoint"></param>
        public void SetCursor(Image a, Bitmap cursor, Point hotPoint)//游標
        {
            int hotX = hotPoint.X;
            int hotY = hotPoint.Y;
            Bitmap myNewCursor = new Bitmap(cursor.Width * 3 - hotX, cursor.Height * 3 - hotY);
            Graphics g = Graphics.FromImage(myNewCursor);
            g.Clear(Color.FromArgb(0, 0, 0, 0));
            g.DrawImage(a, cursor.Width - hotX, cursor.Height - hotY, cursor.Width, cursor.Height);
            this.Cursor = new Cursor(myNewCursor.GetHicon());
            g.Dispose();
            myNewCursor.Dispose();
        }

        /// <summary>
        /// 滾輪事件 縮放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dxf_view_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)//滾輪縮放
        {
            if (e.Delta > 0) //放大圖片
            {
                if (startrulerset) return;
                sizenum *= 1.2;
                zoomsizenum.Text = Math.Round(sizenum, 2).ToString() + "*";
                draw_dxf.Dispose();//關舊圖
                int w = Convert.ToInt32(sizenum * dxf_view.Width);//調整bitmap尺寸
                int h = Convert.ToInt32(sizenum * dxf_view.Height);
                draw_dxf = new Bitmap(w, h);

                using (Graphics g = Graphics.FromImage(draw_dxf))
                    g.Clear(Color.White);

                //圖片資料縮放改變
                foreach (line cc in dxflines)
                {
                    cc.sizechange(1.2);
                    cc.draw(draw_dxf);
                }

                foreach (circle cc in dxfcircles)
                {
                    cc.sizechange(1.2);
                    cc.draw(draw_dxf);
                }

                foreach (text cc in dxftext)
                {
                    cc.sizechange(1.2);
                    cc.draw(draw_dxf);
                }

                for (int i = 1; i <= count; i++)
                {
                    pointarray[i].sizechange(sizenum);
                }

                number_label.Location = new Point(Convert.ToInt32(number_label.Location.X * 1.2), Convert.ToInt32(number_label.Location.Y * 1.2));

                double x = s.X * 1.2;//放大後位置校準
                double y = s.Y * 1.2;
                s.X = Convert.ToInt32(x);
                s.Y = Convert.ToInt32(y);
                dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);

                if (ruler_exist)
                    pixellength /= 1.2;

                if (zero_exist)
                {
                    zeropoint.sizechange(1.2);
                }
            }
            else//縮小圖片
            {
                if (startrulerset) return;
                sizenum /= 1.2;
                zoomsizenum.Text = Math.Round(sizenum, 2).ToString() + "*";
                draw_dxf.Dispose();//關舊圖
                int w = Convert.ToInt32(sizenum * dxf_view.Width);//調整bitmap尺寸
                int h = Convert.ToInt32(sizenum * dxf_view.Height);
                draw_dxf = new Bitmap(w, h);

                using (Graphics g = Graphics.FromImage(draw_dxf))
                    g.Clear(Color.White);

                //圖片資料縮放改變
                foreach (line cc in dxflines)
                {
                    cc.sizechange(1 / 1.2);
                    cc.draw(draw_dxf);
                }

                foreach (circle cc in dxfcircles)
                {
                    cc.sizechange(1 / 1.2);
                    cc.draw(draw_dxf);
                }

                foreach (text cc in dxftext)
                {
                    cc.sizechange(1 / 1.2);
                    cc.draw(draw_dxf);
                }

                for (int i = 1; i <= count; i++)
                {
                    pointarray[i].sizechange(1/sizenum);
                }

                number_label.Location = new Point(Convert.ToInt32(number_label.Location.X / 1.2), Convert.ToInt32(number_label.Location.Y / 1.2));

                double x = s.X / 1.2;//縮小後位置校準
                double y = s.Y / 1.2;
                s.X = Convert.ToInt32(x);
                s.Y = Convert.ToInt32(y);
                dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);

                if (ruler_exist)
                    pixellength *= 1.2;

                if (zero_exist)
                {
                    zeropoint.sizechange(1 / 1.2);
                }
            }
        }

        private void rulersetter()//算單個像素距離
        {
            double l = Math.Sqrt((rulere.X - rulers.X) * (rulere.X - rulers.X) + (rulere.Y - rulers.Y) * (rulere.Y - rulers.Y));
            double lengthset = Convert.ToDouble(length_refer.Text);
            pixellength = lengthset / l;
            label1.Text = l.ToString() + "  " + lengthset.ToString() + "  " + pixellength.ToString();
        }

        /// <summary>
        /// 跟原點距離
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private int pointer_x_to_zero(pointer p)
        {
            return p.location.X - zeropoint.drawpoint.X;
        }

        private int pointer_y_to_zero(pointer p)
        {
            return p.location.Y - zeropoint.drawpoint.Y;
        }
    }
}
