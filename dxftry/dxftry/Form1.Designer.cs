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
            this.picturebigger = new System.Windows.Forms.Button();
            this.picturesmaller = new System.Windows.Forms.Button();
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
            this.pointdata = new System.Windows.Forms.DataGridView();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dxf_view)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointdata)).BeginInit();
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
            this.length_refer.Location = new System.Drawing.Point(699, 609);
            this.length_refer.Name = "length_refer";
            this.length_refer.Size = new System.Drawing.Size(111, 25);
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
            this.a4ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.a4ToolStripMenuItem.Text = "A4";
            this.a4ToolStripMenuItem.Click += new System.EventHandler(this.a4ToolStripMenuItem_Click);
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
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
            // pointdata
            // 
            this.pointdata.AllowUserToOrderColumns = true;
            this.pointdata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pointdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pointdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NO,
            this.X,
            this.Y});
            this.pointdata.Location = new System.Drawing.Point(822, 31);
            this.pointdata.Name = "pointdata";
            this.pointdata.RowTemplate.Height = 27;
            this.pointdata.Size = new System.Drawing.Size(228, 292);
            this.pointdata.TabIndex = 22;
            this.pointdata.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.pointdata_RowHeaderMouseDoubleClick);
            // 
            // NO
            // 
            this.NO.HeaderText = "NO";
            this.NO.Name = "NO";
            this.NO.Width = 25;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.Width = 50;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.Width = 50;
            // 
            // number_label
            // 
            this.number_label.AutoSize = true;
            this.number_label.BackColor = System.Drawing.Color.White;
            this.number_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.number_label.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.number_label.ForeColor = System.Drawing.Color.Red;
            this.number_label.Location = new System.Drawing.Point(849, 344);
            this.number_label.Name = "number_label";
            this.number_label.Size = new System.Drawing.Size(91, 21);
            this.number_label.TabIndex = 23;
            this.number_label.Text = "查找用label";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.number_label);
            this.Controls.Add(this.pointdata);
            this.Controls.Add(this.zoomsizenum);
            this.Controls.Add(this.length_refer);
            this.Controls.Add(this.dataname);
            this.Controls.Add(this.picturesmaller);
            this.Controls.Add(this.picturebigger);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dxf_view);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CommonRobotPointerInterface";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxf_view)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox dxf_view;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button picturebigger;
        private System.Windows.Forms.Button picturesmaller;
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
        private System.Windows.Forms.DataGridView pointdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.Label number_label;
    }
}

