namespace dxftry
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dxf_view = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.zoombox = new System.Windows.Forms.PictureBox();
            this.activepoint = new System.Windows.Forms.Button();
            this.pointlight = new System.Windows.Forms.Label();
            this.picturebigger = new System.Windows.Forms.Button();
            this.picturesmaller = new System.Windows.Forms.Button();
            this.moveup = new System.Windows.Forms.Button();
            this.movedown = new System.Windows.Forms.Button();
            this.moveleft = new System.Windows.Forms.Button();
            this.moveright = new System.Windows.Forms.Button();
            this.dataname = new System.Windows.Forms.Label();
            this.length_refer = new System.Windows.Forms.TextBox();
            this.zoomsizenum = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.measureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.a4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setZeroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareCenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomminusbtn = new System.Windows.Forms.Button();
            this.zoomplusbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dxf_view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoombox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dxf_view
            // 
            this.dxf_view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dxf_view.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dxf_view.Cursor = System.Windows.Forms.Cursors.Cross;
            this.dxf_view.Location = new System.Drawing.Point(12, 31);
            this.dxf_view.Name = "dxf_view";
            this.dxf_view.Size = new System.Drawing.Size(798, 603);
            this.dxf_view.TabIndex = 0;
            this.dxf_view.TabStop = false;
            this.dxf_view.Paint += new System.Windows.Forms.PaintEventHandler(this.dxf_view_Paint);
            this.dxf_view.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dxf_view_MouseClick);
            this.dxf_view.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dxf_view_MouseDown);
            this.dxf_view.MouseEnter += new System.EventHandler(this.dxf_view_MouseEnter);
            this.dxf_view.MouseLeave += new System.EventHandler(this.dxf_view_MouseLeave);
            this.dxf_view.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dxf_view_MouseMove);
            this.dxf_view.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dxf_view_MouseUp);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(834, 565);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "測試用";
            // 
            // zoombox
            // 
            this.zoombox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoombox.Location = new System.Drawing.Point(838, 123);
            this.zoombox.Name = "zoombox";
            this.zoombox.Size = new System.Drawing.Size(200, 200);
            this.zoombox.TabIndex = 4;
            this.zoombox.TabStop = false;
            // 
            // activepoint
            // 
            this.activepoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.activepoint.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.activepoint.Location = new System.Drawing.Point(837, 365);
            this.activepoint.Name = "activepoint";
            this.activepoint.Size = new System.Drawing.Size(200, 50);
            this.activepoint.TabIndex = 7;
            this.activepoint.Text = "標點";
            this.activepoint.UseVisualStyleBackColor = true;
            this.activepoint.Click += new System.EventHandler(this.activepoint_Click);
            // 
            // pointlight
            // 
            this.pointlight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pointlight.BackColor = System.Drawing.Color.Red;
            this.pointlight.Location = new System.Drawing.Point(837, 411);
            this.pointlight.Name = "pointlight";
            this.pointlight.Size = new System.Drawing.Size(200, 3);
            this.pointlight.TabIndex = 9;
            // 
            // picturebigger
            // 
            this.picturebigger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picturebigger.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.picturebigger.Location = new System.Drawing.Point(760, 584);
            this.picturebigger.Name = "picturebigger";
            this.picturebigger.Size = new System.Drawing.Size(50, 50);
            this.picturebigger.TabIndex = 10;
            this.picturebigger.Text = "+";
            this.picturebigger.UseVisualStyleBackColor = true;
            this.picturebigger.Click += new System.EventHandler(this.picturebigger_Click);
            // 
            // picturesmaller
            // 
            this.picturesmaller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picturesmaller.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.picturesmaller.Location = new System.Drawing.Point(709, 584);
            this.picturesmaller.Name = "picturesmaller";
            this.picturesmaller.Size = new System.Drawing.Size(50, 50);
            this.picturesmaller.TabIndex = 11;
            this.picturesmaller.Text = "-";
            this.picturesmaller.UseVisualStyleBackColor = true;
            this.picturesmaller.Click += new System.EventHandler(this.picturesmaller_Click);
            // 
            // moveup
            // 
            this.moveup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveup.Image = ((System.Drawing.Image)(resources.GetObject("moveup.Image")));
            this.moveup.Location = new System.Drawing.Point(907, 36);
            this.moveup.Name = "moveup";
            this.moveup.Size = new System.Drawing.Size(65, 40);
            this.moveup.TabIndex = 13;
            this.moveup.UseVisualStyleBackColor = true;
            this.moveup.Click += new System.EventHandler(this.moveup_Click);
            // 
            // movedown
            // 
            this.movedown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.movedown.Image = ((System.Drawing.Image)(resources.GetObject("movedown.Image")));
            this.movedown.Location = new System.Drawing.Point(907, 77);
            this.movedown.Name = "movedown";
            this.movedown.Size = new System.Drawing.Size(65, 40);
            this.movedown.TabIndex = 14;
            this.movedown.UseVisualStyleBackColor = true;
            this.movedown.Click += new System.EventHandler(this.movedown_Click);
            // 
            // moveleft
            // 
            this.moveleft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveleft.Image = ((System.Drawing.Image)(resources.GetObject("moveleft.Image")));
            this.moveleft.Location = new System.Drawing.Point(840, 55);
            this.moveleft.Name = "moveleft";
            this.moveleft.Size = new System.Drawing.Size(65, 40);
            this.moveleft.TabIndex = 15;
            this.moveleft.UseVisualStyleBackColor = true;
            this.moveleft.Click += new System.EventHandler(this.moveleft_Click);
            // 
            // moveright
            // 
            this.moveright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveright.Image = ((System.Drawing.Image)(resources.GetObject("moveright.Image")));
            this.moveright.Location = new System.Drawing.Point(974, 55);
            this.moveright.Name = "moveright";
            this.moveright.Size = new System.Drawing.Size(65, 40);
            this.moveright.TabIndex = 16;
            this.moveright.UseVisualStyleBackColor = true;
            this.moveright.Click += new System.EventHandler(this.moveright_Click);
            // 
            // dataname
            // 
            this.dataname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataname.AutoSize = true;
            this.dataname.Location = new System.Drawing.Point(12, 649);
            this.dataname.Name = "dataname";
            this.dataname.Size = new System.Drawing.Size(67, 15);
            this.dataname.TabIndex = 18;
            this.dataname.Text = "顯示檔名";
            // 
            // length_refer
            // 
            this.length_refer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.length_refer.Location = new System.Drawing.Point(688, 609);
            this.length_refer.Name = "length_refer";
            this.length_refer.Size = new System.Drawing.Size(122, 25);
            this.length_refer.TabIndex = 19;
            this.length_refer.Text = "在此輸入長度";
            this.length_refer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.length_refer.Visible = false;
            this.length_refer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.length_refer_MouseClick);
            // 
            // zoomsizenum
            // 
            this.zoomsizenum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomsizenum.BackColor = System.Drawing.Color.White;
            this.zoomsizenum.Location = new System.Drawing.Point(754, 31);
            this.zoomsizenum.Name = "zoomsizenum";
            this.zoomsizenum.Size = new System.Drawing.Size(56, 16);
            this.zoomsizenum.TabIndex = 20;
            this.zoomsizenum.Text = "1*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.measureToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1062, 27);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(45, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.loadToolStripMenuItem.Text = "Open dxf";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // measureToolStripMenuItem
            // 
            this.measureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setScaleToolStripMenuItem,
            this.setZeroToolStripMenuItem,
            this.squareCenterToolStripMenuItem});
            this.measureToolStripMenuItem.Name = "measureToolStripMenuItem";
            this.measureToolStripMenuItem.Size = new System.Drawing.Size(81, 23);
            this.measureToolStripMenuItem.Text = "Measure";
            // 
            // setScaleToolStripMenuItem
            // 
            this.setScaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.a4ToolStripMenuItem,
            this.otherToolStripMenuItem});
            this.setScaleToolStripMenuItem.Name = "setScaleToolStripMenuItem";
            this.setScaleToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.setScaleToolStripMenuItem.Text = "Set scale";
            // 
            // a4ToolStripMenuItem
            // 
            this.a4ToolStripMenuItem.Name = "a4ToolStripMenuItem";
            this.a4ToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this.a4ToolStripMenuItem.Text = "A4";
            this.a4ToolStripMenuItem.Click += new System.EventHandler(this.a4ToolStripMenuItem_Click);
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this.otherToolStripMenuItem.Text = "Other";
            this.otherToolStripMenuItem.Click += new System.EventHandler(this.otherToolStripMenuItem_Click);
            // 
            // setZeroToolStripMenuItem
            // 
            this.setZeroToolStripMenuItem.Name = "setZeroToolStripMenuItem";
            this.setZeroToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.setZeroToolStripMenuItem.Text = "Set Zero";
            this.setZeroToolStripMenuItem.Click += new System.EventHandler(this.setZeroToolStripMenuItem_Click);
            // 
            // squareCenterToolStripMenuItem
            // 
            this.squareCenterToolStripMenuItem.Name = "squareCenterToolStripMenuItem";
            this.squareCenterToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.squareCenterToolStripMenuItem.Text = "Square Center";
            this.squareCenterToolStripMenuItem.Click += new System.EventHandler(this.squareCenterToolStripMenuItem_Click);
            // 
            // zoomminusbtn
            // 
            this.zoomminusbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomminusbtn.Location = new System.Drawing.Point(837, 330);
            this.zoomminusbtn.Name = "zoomminusbtn";
            this.zoomminusbtn.Size = new System.Drawing.Size(95, 30);
            this.zoomminusbtn.TabIndex = 23;
            this.zoomminusbtn.Text = "-";
            this.zoomminusbtn.UseVisualStyleBackColor = true;
            this.zoomminusbtn.Click += new System.EventHandler(this.zoomminusbtn_Click);
            // 
            // zoomplusbtn
            // 
            this.zoomplusbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomplusbtn.Location = new System.Drawing.Point(942, 330);
            this.zoomplusbtn.Name = "zoomplusbtn";
            this.zoomplusbtn.Size = new System.Drawing.Size(95, 30);
            this.zoomplusbtn.TabIndex = 24;
            this.zoomplusbtn.Text = "+";
            this.zoomplusbtn.UseVisualStyleBackColor = true;
            this.zoomplusbtn.Click += new System.EventHandler(this.zoomplusbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.zoomplusbtn);
            this.Controls.Add(this.zoomminusbtn);
            this.Controls.Add(this.zoomsizenum);
            this.Controls.Add(this.length_refer);
            this.Controls.Add(this.dataname);
            this.Controls.Add(this.moveright);
            this.Controls.Add(this.moveleft);
            this.Controls.Add(this.movedown);
            this.Controls.Add(this.moveup);
            this.Controls.Add(this.picturesmaller);
            this.Controls.Add(this.picturebigger);
            this.Controls.Add(this.pointlight);
            this.Controls.Add(this.activepoint);
            this.Controls.Add(this.zoombox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dxf_view);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CommonRobotPointerInterface";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxf_view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoombox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox dxf_view;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox zoombox;
        private System.Windows.Forms.Button activepoint;
        private System.Windows.Forms.Label pointlight;
        private System.Windows.Forms.Button picturebigger;
        private System.Windows.Forms.Button picturesmaller;
        private System.Windows.Forms.Button moveup;
        private System.Windows.Forms.Button movedown;
        private System.Windows.Forms.Button moveleft;
        private System.Windows.Forms.Button moveright;
        private System.Windows.Forms.Label dataname;
        private System.Windows.Forms.TextBox length_refer;
        private System.Windows.Forms.Label zoomsizenum;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem measureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setZeroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareCenterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem a4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.Button zoomminusbtn;
        private System.Windows.Forms.Button zoomplusbtn;
    }
}

