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
        //讀 顯示
        private OpenFileDialog load;
        private StreamReader readdxf;
        private string line1, line2;
        private Graphics dxfpen;
        private Pen blackpen;
        private Single startlineX, startlineY, endlineX, endlineY;//直線用
        private Bitmap draw_dxf;
        private ThreadStart pre_readthread;
        private Thread readthread;
        private Int32 pointx, pointy, radius;//圓心 半徑
        private bool set_size=false;
        private double sizenum;//底圖縮放倍率
        private Point s;//看圖位置
        private double wheelzoom;
        private List<line> dxflines;
        private List<circle> dxfcircles;
        //放大鏡
        private bool blIsDrawRectangle = true;
        private Point ptBegin = new Point();
        private Thread thDraw;
        private delegate void myDrawRectangel();
        private myDrawRectangel myDraw;
        private Int32 zoomsize;
        //標點
        private bool active_point = false, active_zeropoint = false, zero_exist = false, startrulerset = false;
        private pointer[] pointarray;
        private Int32 count,c;
        private Point zeropoint;
        private Point rulers, rulere;
        private double pixellength;
        //滑鼠
        private Image icon1, icon2;

        public Form1()
        {
            InitializeComponent();
            this.dot_place.MouseWheel += new MouseEventHandler(dot_place_MouseWheel);
        }
                
        private void load_file_Click(object sender, EventArgs e)//讀檔
        {            
            load = new OpenFileDialog();
            load.InitialDirectory = "c:\\";
            load.Filter = "dxf files (*.dxf)|*.dxf|All files (*.*)|*.*"; //filters the visible files...

            load.FilterIndex = 1;

            if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK)       //open file dialog is shown here...if "cancel" button is clicked then nothing will be done...
            {
                dataname.Text = Path.GetFileNameWithoutExtension(load.FileName);
                sizenum = 1;
                zoomsize = 1;
                using (dxfpen = Graphics.FromImage(draw_dxf))
                {
                    dxfpen.Clear(Color.White);
                }
                string filepath=load.FileName;                
                readdxf = new StreamReader(filepath);
                pre_readthread = new ThreadStart(showdxf);
                readthread = new Thread(pre_readthread);
                readthread.Start();
                System.Threading.Thread.Sleep(500);//等1秒讀取 1秒後顯示
                //Refresh();//刷新圖片
                readthread.Abort();//結束讀檔執行緒
            }
            dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);
            count = 1;
            set_size = false;
        }

        private void GetTwoLines()//讀dxf 每次2行
        {
            line1 = null;
            line2 = null;
            line1 = readdxf.ReadLine();
            line2 = readdxf.ReadLine();         
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)//關視窗時 關放大鏡執行緒
        {
            thDraw.Abort();
        }

        private void zoomplus_Click(object sender, EventArgs e)//放更大 框框變小
        {
            zoomsize -= 15;
            if (zoomsize <= 0) zoomsize = 5;
        }

        private void zoomminus_Click(object sender, EventArgs e)//放比較小 框框變大
        {
            zoomsize += 15;
            if (zoomsize >= 110) zoomsize = 95;
        }

        private void activepoint_Click(object sender, EventArgs e)
        {
            if (active_point)
            {
                active_point = false;
                pointlight.BackColor = Color.Red;
            }
            else
            {
                active_point = true;
                pointlight.BackColor = Color.Green;
            }
        }

        private void dot_place_Paint(object sender, PaintEventArgs e)
        {
            if (blIsDrawRectangle)
            {
                e.Graphics.DrawRectangle(new Pen(Brushes.Black, 1), ptBegin.X, ptBegin.Y, zoomsize, zoomsize);    //黑色移動框大小(初始50*50) 隨放大率改變
            }
        }

        private void dot_place_MouseEnter(object sender, EventArgs e)
        {
            blIsDrawRectangle = true;
            dot_place.Focus();
        }

        private void dot_place_MouseLeave(object sender, EventArgs e)
        {
            blIsDrawRectangle = false;
            dot_place.Refresh();

            this.Cursor = Cursors.Default;            
        }

        private void dot_place_MouseMove(object sender, MouseEventArgs e)//放大鏡資料
        {
            //if (e.X - 25 <= 0)
            if (e.X - zoomsize/2 <= 0)
            {
                ptBegin.X = 0;
            }
            else if (dot_place.Width - e.X <= zoomsize/2)  //25
            {
                ptBegin.X = dot_place.Width - zoomsize;  //50
                                                       // ptBegin.X = pictureBox1.Size.Width - 1;
            }
            else
            {
                ptBegin.X = e.X - zoomsize/2; //25
            }
            if (e.Y - zoomsize/2 <= 0)  //25
            {
                ptBegin.Y = 0;
            }
            else if (dot_place.Height - e.Y <= zoomsize/2)  //25
            {
                ptBegin.Y = dot_place.Height - zoomsize;  //50
                //ptBegin.X = pictureBox1.Size.Width - 10;
            }
            else
            {
                ptBegin.Y = e.Y - zoomsize/2;  //25
            }
            dot_place.Refresh();
        }

        private void dot_place_MouseClick(object sender, MouseEventArgs e)//標點
        {
            if (active_point&&e.Button==MouseButtons.Left&&!active_zeropoint&&zero_exist)//普通標點
            {
                pointarray[count] = new pointer(s.X + e.X, s.Y + e.Y, count);
                draw_dxf.SetPixel(s.X + e.X, s.Y + e.Y, Color.Red);
                pointarray[count].x_to_zero = pointer_x_to_zero(pointarray[count]);
                pointarray[count].y_to_zero = pointer_y_to_zero(pointarray[count]);
                pointarray[count].x_to_zero_dou = pointarray[count].x_to_zero * pixellength;
                pointarray[count].y_to_zero_dou = pointarray[count].y_to_zero * pixellength;
                dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);
                label1.Text = label1.Text + "\n" + pointarray[count].x_to_zero_dou.ToString() + "\n" + pointarray[count].y_to_zero_dou.ToString() + "\n" + count.ToString();
                count++;
                active_point = false;
                pointlight.BackColor = Color.Red;
            }

            else if(active_zeropoint)//零點標點
            {
                draw_dxf.SetPixel(zeropoint.X, zeropoint.Y, Color.White);
                zeropoint = new Point(s.X + e.X, s.Y + e.Y);
                draw_dxf.SetPixel(s.X + e.X, s.Y + e.Y, Color.Blue);
                dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);
                active_zeropoint = false;
                zero_exist = true;
                label1.Text = label1.Text + "\n" + (s.X + e.X).ToString() + "\n" + (s.Y + e.Y).ToString();
            }

            if (startrulerset)
            {
                if (c == 1) rulers = new Point(s.X + e.X, s.Y + e.Y);
                if (c == 2) rulere = new Point(s.X + e.X, s.Y + e.Y);
                c++;
                if (c == 3)
                {
                    length_refer.Visible = false;
                    startrulerset = false;
                    rulersetter();
                }
            }
        }

        private void picturebigger_Click(object sender, EventArgs e)
        {
            if (!set_size)
            {
                dxflines.Clear();
                dxfcircles.Clear();
                sizenum *= 1.5;
                using (dxfpen = Graphics.FromImage(draw_dxf))
                {
                    dxfpen.Clear(Color.White);
                }
                string filepath = load.FileName;
                readdxf = new StreamReader(filepath);
                pre_readthread = new ThreadStart(showdxf);
                readthread = new Thread(pre_readthread);
                readthread.Start();
                System.Threading.Thread.Sleep(500);//等1秒讀取 1秒後顯示
                //Refresh();//刷新圖片
                readthread.Abort();//結束讀檔執行緒                
            }
            double x = s.X * 1.5;//放大後位置校準
            double y = s.Y * 1.5;
            s.X = Convert.ToInt32(x);
            s.Y = Convert.ToInt32(y);
            dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);
            /*sizenum *= 1.1;//放大
            draw_dxf= Resize(draw_dxf, sizenum);
            dxf_view.Image = draw_dxf;*/
        }

        private void picturesmaller_Click(object sender, EventArgs e)
        {
            if (!set_size)
            {
                dxflines.Clear();
                dxfcircles.Clear();
                sizenum /= 1.5;
                using (dxfpen = Graphics.FromImage(draw_dxf))
                {
                    dxfpen.Clear(Color.White);
                }
                string filepath = load.FileName;
                readdxf = new StreamReader(filepath);
                pre_readthread = new ThreadStart(showdxf);
                readthread = new Thread(pre_readthread);
                readthread.Start();
                System.Threading.Thread.Sleep(500);//等1秒讀取 1秒後顯示
                //Refresh();//刷新圖片
                readthread.Abort();//結束讀檔執行緒                
            }
            double x = s.X / 1.5;//縮小後位置校準
            double y = s.Y / 1.5;
            s.X = Convert.ToInt32(x);
            s.Y = Convert.ToInt32(y);
            dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);
            /*sizenum /= 1.1;//縮小
            draw_dxf = Resize(draw_dxf, sizenum);
            dxf_view.Image = draw_dxf;*/
        }

        private void moveup_Click(object sender, EventArgs e)
        {
            s.Y += 50;
            dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);
        }

        private void movedown_Click(object sender, EventArgs e)
        {
            s.Y -= 50;
            dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);
        }

        private void moveleft_Click(object sender, EventArgs e)
        {
            s.X += 50;
            dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);
        }

        private void moveright_Click(object sender, EventArgs e)
        {
            s.X -= 50;
            dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);
        }

        private void dot_place_MouseDown(object sender, MouseEventArgs e)
        {
            Bitmap a = (Bitmap)Bitmap.FromFile("dot2.png");
            SetCursor(icon2, a, new Point(0, 0));
        }

        private void setsize_Click(object sender, EventArgs e)
        {
            if (!set_size)
            {
                DialogResult d= MessageBox.Show("確定後按鍵將不能縮放", "注意", MessageBoxButtons.OKCancel);
                if (d == DialogResult.OK)
                {
                    length_refer.Visible = true;
                    startrulerset = true;
                    set_size = true;
                    c = 1;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            active_zeropoint = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            set_size = false;
            zoomsize = 50;//大小初值
            blackpen = new Pen(Color.Black);//用黑線畫dxf
            blackpen.Width = 1;
            draw_dxf = new Bitmap(dxf_view.Width, dxf_view.Height);//先在bitmap畫
            using (dxfpen = Graphics.FromImage(draw_dxf))
            {
                dxfpen.Clear(Color.White);//底色 白
            }
            dxf_view.Image = draw_dxf;//刷新
            //開始放大鏡執行續
            myDraw = new myDrawRectangel(ShowDrawRectangle);
            thDraw = new Thread(Run);
            thDraw.Start();

            active_point = false;
            count = 1;
            pointarray = new pointer[10];
            this.dxf_view.BackColor = Color.Transparent;
            this.dot_place.Parent = this.dxf_view;

            s = new Point(0, draw_dxf.Height - dxf_view.Height);//起始看bitmap的位置(0,0)
            sizenum = 1;
            wheelzoom = 1;

            dxflines = new List<line>();
            dxfcircles = new List<circle>();

            icon1 = Image.FromFile("dot1.png");
            icon2 = Image.FromFile("dot2.png");//點滑鼠的圖
        }
        
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
                        if (line1 == " 10") startlineX = Convert.ToSingle(line2);
                        else if (line1 == " 20") startlineY = Convert.ToSingle(line2);
                        else if (line1 == " 11") endlineX = Convert.ToSingle(line2);
                        else if (line1 == " 21") endlineY = Convert.ToSingle(line2);
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
                        if (line1 == " 10") startlineX = Convert.ToSingle(line2);
                        else if (line1 == " 20") startlineY = Convert.ToSingle(line2);
                        else if (line1 == " 40") endlineX = Convert.ToSingle(line2);
                    } while (line1 != " 40");

                    startlineX = Convert.ToSingle(startlineX * sizenum);
                    startlineY = Convert.ToSingle(startlineY * sizenum);
                    endlineX = Convert.ToSingle(endlineX * sizenum);
                    pointx = Convert.ToInt32(startlineX);
                    pointy = Convert.ToInt32(startlineY);
                    pointy = draw_dxf.Height - pointy;
                    radius = Convert.ToInt32(endlineX);

                    dxfcircles.Add(new circle(pointx, pointy, radius));
                    Rectangle rec = new Rectangle(pointx - radius, pointy - radius, 2 * radius, 2 * radius);
                    using (dxfpen = Graphics.FromImage(draw_dxf))
                    {
                        dxfpen.DrawEllipse(blackpen, rec);
                        //dxfpen.DrawEllipse(Pens.DarkBlue, pointx, pointy, 1, 1);//圓心點
                        draw_dxf.SetPixel(pointx, pointy, Color.DarkBlue);//圓心點
                    }
                }

                else if(line1=="  0"&&line2=="MTEXT")
                {
                    pointx = pointy = 0;
                    string s="";
                    Font f = new Font(s, 10);
                    do
                    {
                        GetTwoLines();
                        if (line1 == " 10") startlineX = Convert.ToSingle(line2);
                        else if (line1 == " 20") startlineY = Convert.ToSingle(line2);
                        else if (line1 == "  1") s = line2;
                    } while (line1 != "  1");

                    pointx = Convert.ToInt32(Math.Round(startlineX * sizenum));
                    pointy = Convert.ToInt32(Math.Round(startlineY * sizenum));
                    pointy = draw_dxf.Height - pointy;
                    Point p = new Point(pointx, pointy);
                    using (dxfpen = Graphics.FromImage(draw_dxf))
                    {
                        dxfpen.DrawString(s, f, Brushes.Black, p);
                    }
                }
            } while (line1 != "EOF" || line2 != "EOF");

            dxf_view.Image = draw_dxf;            
        }

        private void ShowDrawRectangle() // 底圖
        {
            Rectangle rec = new Rectangle(ptBegin.X, ptBegin.Y, zoomsize, zoomsize);
            Graphics g = zoombox.CreateGraphics();
            g.DrawImage(dxf_view.Image, zoombox.ClientRectangle, rec, GraphicsUnit.Pixel);
            g.DrawLine(Pens.SteelBlue, zoombox.Width/2, 0, zoombox.Width/2, zoombox.Height);
            g.DrawLine(Pens.SteelBlue, 0, zoombox.Height/2, zoombox.Width, zoombox.Height/2);
            g.Flush();
        }

        private void Run()
        {
            while (true)
            {
                if (dxf_view.Image != null)
                {
                    this.BeginInvoke(myDraw);
                }
                Thread.Sleep(10);
            }
        } // init

        public static new Bitmap Resize(Bitmap originImage, Double times)//放大縮小 效果不佳 
        {
            int width = Convert.ToInt32(originImage.Width * times);
            int height = Convert.ToInt32(originImage.Height * times);

            return Process(originImage, originImage.Width, originImage.Height, width, height);
        }

        private static Bitmap Process(Bitmap originImage, int oriwidth, int oriheight, int width, int height)
        {
            Bitmap resizedbitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(resizedbitmap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.Transparent);
            g.DrawImage(originImage, new Rectangle(0, 0, width, height), new Rectangle(0, 0, oriwidth, oriheight), GraphicsUnit.Pixel);
            return resizedbitmap;
        }

        private Image cut(Point s, int width, int height)//看部分dxf
        {
            Bitmap cutimage = new Bitmap(width, height);
            Rectangle rec = new Rectangle(0, 0, width, height);
            Graphics draw = Graphics.FromImage(cutimage);
            draw.DrawImage(draw_dxf, rec, s.X, s.Y, width, height, GraphicsUnit.Pixel);
            return cutimage;
        }

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

        private void dot_place_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)//滾輪縮放
        {
            if (e.Delta > 0) //放大圖片
            {
                //pictureBox1.Size = new Size(pictureBox1.Width + 50, pictureBox1.Height + 50);
                wheelzoom = 1.1;
                draw_dxf = Resize(draw_dxf, wheelzoom);
                dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);
            }
            else
            {  //缩小图片
                //pictureBox1.Size = new Size(pictureBox1.Width - 50, pictureBox1.Height - 50);
                wheelzoom = 0.9;
                draw_dxf = Resize(draw_dxf, wheelzoom);
                dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);
            }
            //设置图片在窗体居中
            //pictureBox1.Location = new Point((this.Width - pictureBox1.Width) / 2, (this.Height - pictureBox1.Height) / 2);
        }

        private void rulersetter()
        {
            double l = Math.Sqrt((rulere.X - rulers.X) * (rulere.X - rulers.X) + (rulere.Y - rulers.Y) * (rulere.Y - rulers.Y));
            double lengthset = Convert.ToDouble(length_refer.Text);
            pixellength = lengthset / l;
            label1.Text = l.ToString() + "  " + lengthset.ToString() + "  " + pixellength.ToString();
        }

        private double distance_calculator(pointer p)
        {
            double result;
            result = pixellength * Math.Sqrt(p.x_to_zero * p.x_to_zero + p.y_to_zero * p.y_to_zero);
            return result;
        }

        private int pointer_x_to_zero(pointer p)
        {
            return p.location.X - zeropoint.X;
        }

        private int pointer_y_to_zero(pointer p)
        {
            return p.location.Y - zeropoint.Y;
        }
    }
}
