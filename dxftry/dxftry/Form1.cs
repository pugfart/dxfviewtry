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
        private float startlineX, startlineY, endlineX, endlineY;//直線用
        private Bitmap draw_dxf;
        private ThreadStart pre_readthread;
        private Thread readthread;
        private Int32 pointx, pointy, radius;//圓心 半徑
        private delegate void delegate_show();
        private bool set_size=false;
        private double sizenum;
        private Int32 movex,movey;
        private Point s;
        //放大鏡
        private bool blIsDrawRectangle = true;
        private Point ptBegin = new Point();
        private Thread thDraw;
        private delegate void myDrawRectangel();
        private myDrawRectangel myDraw;
        private Int32 zoomsize;
        //標點
        private bool active_point;
        private pointer[] pointarray;
        private Int32 count;
        private Bitmap dotbmp;

        public Form1()
        {
            InitializeComponent();
        }
                
        private void load_file_Click(object sender, EventArgs e)//讀檔
        {            
            load = new OpenFileDialog();
            load.InitialDirectory = "c:\\";
            load.Filter = "dxf files (*.dxf)|*.dxf|All files (*.*)|*.*"; //filters the visible files...

            load.FilterIndex = 1;

            if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK)       //open file dialog is shown here...if "cancel" button is clicked then nothing will be done...
            {
                sizenum = 1;
                movex = movey = 0;
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
                Refresh();//刷新圖片
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
        }

        private void dot_place_MouseLeave(object sender, EventArgs e)
        {
            blIsDrawRectangle = false;
            dot_place.Refresh();
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

        private void dot_place_MouseClick(object sender, MouseEventArgs e)
        {
            if (active_point&&e.Button==MouseButtons.Left)
            {
                pointarray[count] = new pointer(e.X,e.Y,count);
                draw_dxf.SetPixel(e.X, e.Y, Color.Red);
                dxf_view.Image = draw_dxf;
                Refresh();
                label1.Text = label1.Text + "\n" + e.X.ToString() + "\n" + e.Y.ToString() + "\n" + count.ToString();

                count++;
                active_point = false;
                pointlight.BackColor = Color.Red;
            }
        }

        private void picturebigger_Click(object sender, EventArgs e)
        {
            if (!set_size)
            {
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
                Refresh();//刷新圖片
                readthread.Abort();//結束讀檔執行緒
                dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);
            }
            /*sizenum *= 1.1;
            draw_dxf= Resize(draw_dxf, sizenum);
            dxf_view.Image = draw_dxf;*/
        }

        private void picturesmaller_Click(object sender, EventArgs e)
        {
            if (!set_size)
            {
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
                Refresh();//刷新圖片
                readthread.Abort();//結束讀檔執行緒
                dxf_view.Image = cut(s, dxf_view.Width, dxf_view.Height);
            }
            /*sizenum /= 1.1;
            draw_dxf = Resize(draw_dxf, sizenum);
            dxf_view.Image = draw_dxf;*/
        }

        private void moveup_Click(object sender, EventArgs e)
        {
            /*if (!set_size)
            {
                movey -= 30;
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
                Refresh();//刷新圖片
                readthread.Abort();//結束讀檔執行緒
                //image.location = new point(image.location.x + 10, 100);
            }*/
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

        private void setsize_Click(object sender, EventArgs e)
        {
            set_size = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            set_size = false;
            movex = movey = 0;
            zoomsize = 50;//大小初值
            blackpen=new Pen(Color.Black);//用黑線畫dxf
            blackpen.Width = 1;
            draw_dxf = new Bitmap(dxf_view.Width*2, dxf_view.Height*2);//先在bitmap畫
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
            dotbmp = new Bitmap(dot_place.Width, dot_place.Height);

            s = new Point(dxf_view.Width/2, dxf_view.Height/2);
            sizenum = 1;
        }
        
        private void showdxf()
        {
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
                    startlineX = Convert.ToSingle(startlineX * sizenum + s.X);
                    startlineY = Convert.ToSingle((draw_dxf.Height - startlineY * sizenum) + movey) - draw_dxf.Height / 4;
                    endlineX = Convert.ToSingle(endlineX * sizenum + s.X);
                    endlineY = Convert.ToSingle((draw_dxf.Height - endlineY * sizenum) + movey) - draw_dxf.Height / 4;
                    using (dxfpen = Graphics.FromImage(draw_dxf))
                    {
                        dxfpen.DrawLine(blackpen, startlineX, startlineY, endlineX, endlineY);
                    }
                }

                else if (line1=="  0"&&line2=="CIRCLE")//讀圓
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
                    pointx = Convert.ToInt32(Math.Floor(startlineX) + s.X);
                    pointy = Convert.ToInt32(Math.Floor(startlineY));
                    pointy = draw_dxf.Height/4*3 - pointy + movey;
                    radius = Convert.ToInt32(Math.Floor(endlineX));
                    
                    Rectangle rec = new Rectangle(pointx - radius, pointy - radius, 2*radius,2*radius);
                    using (dxfpen = Graphics.FromImage(draw_dxf))
                    {
                        dxfpen.DrawEllipse(blackpen, rec);
                    }
                }
            } while (line1 != "EOF"||line2 !="EOF");

            dxf_view.Image = draw_dxf;
        }

        private void ShowDrawRectangle() // 底圖
        {
            //int high = getHeight(dot_place.Image);
            //int wide = getWidth(dot_place.Image);
            //label1.Text = dxf_view.Height.ToString() + "\n" + dxf_view.Width.ToString() + "\n" + dot_place.Height.ToString() + "\n" + dot_place.Width.ToString();
            Rectangle rec = new Rectangle(ptBegin.X , ptBegin.Y , zoomsize , zoomsize );//圖片大小(ex.1280*760) 
            Graphics g = zoombox.CreateGraphics();
            g.DrawImage(dxf_view.Image, zoombox.ClientRectangle, rec, GraphicsUnit.Pixel);
            g.DrawLine(Pens.SteelBlue, zoombox.Width/2, 0, zoombox.Width/2, zoombox.Height);
            g.DrawLine(Pens.SteelBlue, 0, zoombox.Height/2, zoombox.Width, zoombox.Height/2);
            g.Flush();
        }

        private int getHeight(Image img)//目前picturebox高
        {
            return img.Height;
        }

        private int getWidth(Image img)//目前picturebox寬
        {
            return img.Width;
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

        /*public static new Bitmap Resize(Bitmap originImage, Double times)//放大縮小 效果不佳
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
        }*/

        private Image cut(Point s, int width, int height)
        {
            Bitmap cutimage = new Bitmap(width, height);
            Rectangle rec = new Rectangle(0, 0, width, height);
            Graphics draw = Graphics.FromImage(cutimage);
            draw.DrawImage(draw_dxf, rec, s.X, s.Y, width, height, GraphicsUnit.Pixel);
            return cutimage;
        }
    }
}
