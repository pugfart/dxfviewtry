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
        private OpenFileDialog load;
        private StreamReader readdxf;
        private string line1, line2;
        private Graphics dxfpen;
        private Pen blackpen;
        private float startlineX, startlineY, endlineX, endlineY;
        private Bitmap draw_dxf;
        private ThreadStart pre_readthread;
        private Thread readthread;
        private Int32 pointx, pointy, radius;
        private delegate void delegate_show();

        private bool blIsDrawRectangle = true;
        private Point ptBegin = new Point();
        Thread thDraw;
        delegate void myDrawRectangel();
        myDrawRectangel myDraw;

        public Form1()
        {
            InitializeComponent();
        }

        private void dxf_view_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.X - 25 <= 0)
            if (e.X - 10 <= 0)
            {
                ptBegin.X = 0;
            }
            else if (dxf_view.Size.Width - e.X <= 10)  //25
            {
                ptBegin.X = dxf_view.Size.Width - 20;  //50
                                                          // ptBegin.X = pictureBox1.Size.Width - 1;
            }
            else
            {
                ptBegin.X = e.X - 10; //25
            }
            if (e.Y - 10 <= 0)  //25
            {
                ptBegin.Y = 0;
            }
            else if (dxf_view.Size.Height - e.Y <= 10)  //25
            {
                ptBegin.Y = dxf_view.Size.Height - 20;  //50
                //ptBegin.X = pictureBox1.Size.Width - 10;
            }
            else
            {
                ptBegin.Y = e.Y - 10;  //25
            }
            dxf_view.Refresh();
        }

        private void dxf_view_MouseEnter(object sender, EventArgs e)
        {
            blIsDrawRectangle = true;
        }

        private void dxf_view_MouseLeave(object sender, EventArgs e)
        {
            blIsDrawRectangle = false;
            dxf_view.Refresh();
        }

        private void dxf_view_Paint(object sender, PaintEventArgs e)
        {
            if (blIsDrawRectangle)
            {
                e.Graphics.DrawRectangle(new Pen(Brushes.Black, 1), ptBegin.X, ptBegin.Y, 50, 50);    //黑色移動框大小(ex.50*50)
            }
            //e.Graphics.DrawLine(blackpen, 100, 50, 100, 100);
            //e.Graphics.DrawLine(blackpen, startlineX, startlineY, endlineX, endlineY);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (dxfpen = Graphics.FromImage(dxf_view.Image))
            {
                dxfpen.DrawLine(blackpen, 100,50,100,100);                
            }
            dxf_view.Image = draw_dxf;
        }

        private void load_file_Click(object sender, EventArgs e)
        {            
            load = new OpenFileDialog();
            load.InitialDirectory = "c:\\";
            load.Filter = "dxf files (*.dxf)|*.dxf|All files (*.*)|*.*"; //filters the visible files...

            load.FilterIndex = 1;

            if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK)       //open file dialog is shown here...if "cancel" button is clicked then nothing will be done...
            {
                using (dxfpen = Graphics.FromImage(draw_dxf))
                {
                    dxfpen.Clear(Color.White);
                }
                string filepath=load.FileName;
                button1.Text = filepath;
                readdxf = new StreamReader(filepath);
                pre_readthread = new ThreadStart(showdxf);
                readthread = new Thread(pre_readthread);
                readthread.Start();
                System.Threading.Thread.Sleep(1000);
                Refresh();
                readthread.Abort();
                //readthread = new Thread(new ThreadStart(showdxf));
                //readthread.Start();                
                //readthread.Join();
                //readthread.Abort();
                //showdxf();
            }
        }

        private void GetTwoLines()
        {
            line1 = null;
            line2 = null;
            line1 = readdxf.ReadLine();
            //if(line1!=null) line1.Trim();
            line2 = readdxf.ReadLine();
            //if(line2!=null) line2.Trim();
            //readdxf.DiscardBufferedData();
            //label1.Text += line1 + "\n" + line2 + "\n";            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            blackpen=new Pen(Color.Black);
            blackpen.Width = 1;
            draw_dxf = new Bitmap(dxf_view.Width, dxf_view.Height);
            using (dxfpen = Graphics.FromImage(draw_dxf))
            {
                dxfpen.Clear(Color.White);
            }
            dxf_view.Image = draw_dxf;

            myDraw = new myDrawRectangel(ShowDrawRectangle);
            thDraw = new Thread(Run);
            thDraw.Start();
        }
        
        private void showdxf()
        {
            do
            {
                GetTwoLines();
                if (line1 == "  0" && line2 == "LINE")
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
                    startlineY = draw_dxf.Height - startlineY;
                    endlineY = draw_dxf.Height - endlineY;
                    using (dxfpen = Graphics.FromImage(dxf_view.Image))
                    {
                        dxfpen.DrawLine(blackpen, startlineX, startlineY, endlineX, endlineY);
                    }
                    //dxf_view.Image = draw_dxf;
                }

                else if (line1=="  0"&&line2=="CIRCLE")
                {
                    pointx = pointy = 0;
                    do
                    {
                        GetTwoLines();
                        if (line1 == " 10") startlineX = Convert.ToSingle(line2);
                        else if (line1 == " 20") startlineY = Convert.ToSingle(line2);
                        else if (line1 == " 40") endlineX = Convert.ToSingle(line2);
                    } while (line1 != " 40");

                    pointx = Convert.ToInt32(Math.Floor(startlineX));
                    pointy = Convert.ToInt32(Math.Floor(startlineY));
                    pointy = dxf_view.Height - pointy;
                    radius = Convert.ToInt32(Math.Floor(endlineX));
                    Rectangle rec = new Rectangle(pointx - radius, pointy - radius, 2*radius,2*radius);
                    using (dxfpen = Graphics.FromImage(dxf_view.Image))
                    {
                        dxfpen.DrawEllipse(blackpen, rec);
                    }
                }
            } while (line1 != "EOF"||line2 !="EOF");

            dxf_view.Image = draw_dxf;
        }

        private void ShowDrawRectangle() // 底圖
        {
            int high = getHeight(dxf_view.Image);
            int wide = getWidth(dxf_view.Image);
            label1.Text = high.ToString() + "\n" + wide.ToString();
            Rectangle rec = new Rectangle(ptBegin.X * dxf_view.Image.Size.Width / wide, ptBegin.Y * dxf_view.Image.Size.Height / high,    //圖片大小(ex.1280*760)
                50 * dxf_view.Image.Size.Width / wide, 50 * dxf_view.Image.Size.Height / high);
            Graphics g = zoombox.CreateGraphics();
            g.DrawImage(dxf_view.Image, zoombox.ClientRectangle, rec, GraphicsUnit.Pixel);
            g.Flush();
        }

        private int getHeight(Image img)
        {
            return img.Size.Height;
        }
        private int getWidth(Image img)
        {
            return img.Size.Width;
        }

        private void Run()
        {
            while (true)
            {
                if (dxf_view.Image != null)
                {
                    this.BeginInvoke(myDraw);
                }
                Thread.Sleep(50);
            }
        } // init
    }
}
