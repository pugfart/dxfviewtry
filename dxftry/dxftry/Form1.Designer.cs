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
            this.dxf_view = new System.Windows.Forms.PictureBox();
            this.load_file = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.zoombox = new System.Windows.Forms.PictureBox();
            this.zoomplus = new System.Windows.Forms.Button();
            this.zoomminus = new System.Windows.Forms.Button();
            this.activepoint = new System.Windows.Forms.Button();
            this.dot_place = new System.Windows.Forms.PictureBox();
            this.pointlight = new System.Windows.Forms.Label();
            this.picturebigger = new System.Windows.Forms.Button();
            this.picturesmaller = new System.Windows.Forms.Button();
            this.setsize = new System.Windows.Forms.Button();
            this.moveup = new System.Windows.Forms.Button();
            this.movedown = new System.Windows.Forms.Button();
            this.moveleft = new System.Windows.Forms.Button();
            this.moveright = new System.Windows.Forms.Button();
            this.zeropointer = new System.Windows.Forms.Button();
            this.dataname = new System.Windows.Forms.Label();
            this.length_refer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dxf_view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoombox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dot_place)).BeginInit();
            this.SuspendLayout();
            // 
            // dxf_view
            // 
            this.dxf_view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dxf_view.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dxf_view.Cursor = System.Windows.Forms.Cursors.Cross;
            this.dxf_view.Location = new System.Drawing.Point(12, 12);
            this.dxf_view.Name = "dxf_view";
            this.dxf_view.Size = new System.Drawing.Size(1081, 670);
            this.dxf_view.TabIndex = 0;
            this.dxf_view.TabStop = false;
            // 
            // load_file
            // 
            this.load_file.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.load_file.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.load_file.Location = new System.Drawing.Point(1121, 12);
            this.load_file.Name = "load_file";
            this.load_file.Size = new System.Drawing.Size(200, 50);
            this.load_file.TabIndex = 1;
            this.load_file.Text = "讀檔";
            this.load_file.UseVisualStyleBackColor = true;
            this.load_file.Click += new System.EventHandler(this.load_file_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1117, 620);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "測試用";
            // 
            // zoombox
            // 
            this.zoombox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoombox.Location = new System.Drawing.Point(1121, 249);
            this.zoombox.Name = "zoombox";
            this.zoombox.Size = new System.Drawing.Size(200, 200);
            this.zoombox.TabIndex = 4;
            this.zoombox.TabStop = false;
            // 
            // zoomplus
            // 
            this.zoomplus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomplus.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.zoomplus.Location = new System.Drawing.Point(1225, 455);
            this.zoomplus.Name = "zoomplus";
            this.zoomplus.Size = new System.Drawing.Size(95, 50);
            this.zoomplus.TabIndex = 5;
            this.zoomplus.Text = "+";
            this.zoomplus.UseVisualStyleBackColor = true;
            this.zoomplus.Click += new System.EventHandler(this.zoomplus_Click);
            // 
            // zoomminus
            // 
            this.zoomminus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomminus.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.zoomminus.Location = new System.Drawing.Point(1120, 455);
            this.zoomminus.Name = "zoomminus";
            this.zoomminus.Size = new System.Drawing.Size(95, 50);
            this.zoomminus.TabIndex = 6;
            this.zoomminus.Text = "-";
            this.zoomminus.UseVisualStyleBackColor = true;
            this.zoomminus.Click += new System.EventHandler(this.zoomminus_Click);
            // 
            // activepoint
            // 
            this.activepoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.activepoint.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.activepoint.Location = new System.Drawing.Point(1120, 514);
            this.activepoint.Name = "activepoint";
            this.activepoint.Size = new System.Drawing.Size(200, 50);
            this.activepoint.TabIndex = 7;
            this.activepoint.Text = "標點";
            this.activepoint.UseVisualStyleBackColor = true;
            this.activepoint.Click += new System.EventHandler(this.activepoint_Click);
            // 
            // dot_place
            // 
            this.dot_place.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dot_place.Location = new System.Drawing.Point(0, 0);
            this.dot_place.Name = "dot_place";
            this.dot_place.Size = new System.Drawing.Size(1081, 670);
            this.dot_place.TabIndex = 8;
            this.dot_place.TabStop = false;
            this.dot_place.Paint += new System.Windows.Forms.PaintEventHandler(this.dot_place_Paint);
            this.dot_place.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dot_place_MouseClick);
            this.dot_place.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dot_place_MouseDown);
            this.dot_place.MouseEnter += new System.EventHandler(this.dot_place_MouseEnter);
            this.dot_place.MouseLeave += new System.EventHandler(this.dot_place_MouseLeave);
            this.dot_place.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dot_place_MouseMove);
            // 
            // pointlight
            // 
            this.pointlight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pointlight.BackColor = System.Drawing.Color.Red;
            this.pointlight.Location = new System.Drawing.Point(1120, 559);
            this.pointlight.Name = "pointlight";
            this.pointlight.Size = new System.Drawing.Size(200, 3);
            this.pointlight.TabIndex = 9;
            // 
            // picturebigger
            // 
            this.picturebigger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picturebigger.Location = new System.Drawing.Point(1226, 69);
            this.picturebigger.Name = "picturebigger";
            this.picturebigger.Size = new System.Drawing.Size(95, 30);
            this.picturebigger.TabIndex = 10;
            this.picturebigger.Text = "+";
            this.picturebigger.UseVisualStyleBackColor = true;
            this.picturebigger.Click += new System.EventHandler(this.picturebigger_Click);
            // 
            // picturesmaller
            // 
            this.picturesmaller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picturesmaller.Location = new System.Drawing.Point(1121, 69);
            this.picturesmaller.Name = "picturesmaller";
            this.picturesmaller.Size = new System.Drawing.Size(95, 30);
            this.picturesmaller.TabIndex = 11;
            this.picturesmaller.Text = "-";
            this.picturesmaller.UseVisualStyleBackColor = true;
            this.picturesmaller.Click += new System.EventHandler(this.picturesmaller_Click);
            // 
            // setsize
            // 
            this.setsize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setsize.Location = new System.Drawing.Point(1120, 179);
            this.setsize.Name = "setsize";
            this.setsize.Size = new System.Drawing.Size(200, 30);
            this.setsize.TabIndex = 12;
            this.setsize.Text = "設定比例尺";
            this.setsize.UseVisualStyleBackColor = true;
            this.setsize.Click += new System.EventHandler(this.setsize_Click);
            // 
            // moveup
            // 
            this.moveup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveup.Location = new System.Drawing.Point(1120, 107);
            this.moveup.Name = "moveup";
            this.moveup.Size = new System.Drawing.Size(95, 30);
            this.moveup.TabIndex = 13;
            this.moveup.Text = "上移";
            this.moveup.UseVisualStyleBackColor = true;
            this.moveup.Click += new System.EventHandler(this.moveup_Click);
            // 
            // movedown
            // 
            this.movedown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.movedown.Location = new System.Drawing.Point(1225, 107);
            this.movedown.Name = "movedown";
            this.movedown.Size = new System.Drawing.Size(95, 30);
            this.movedown.TabIndex = 14;
            this.movedown.Text = "下移";
            this.movedown.UseVisualStyleBackColor = true;
            this.movedown.Click += new System.EventHandler(this.movedown_Click);
            // 
            // moveleft
            // 
            this.moveleft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveleft.Location = new System.Drawing.Point(1120, 143);
            this.moveleft.Name = "moveleft";
            this.moveleft.Size = new System.Drawing.Size(95, 30);
            this.moveleft.TabIndex = 15;
            this.moveleft.Text = "左移";
            this.moveleft.UseVisualStyleBackColor = true;
            this.moveleft.Click += new System.EventHandler(this.moveleft_Click);
            // 
            // moveright
            // 
            this.moveright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveright.Location = new System.Drawing.Point(1225, 143);
            this.moveright.Name = "moveright";
            this.moveright.Size = new System.Drawing.Size(95, 30);
            this.moveright.TabIndex = 16;
            this.moveright.Text = "右移";
            this.moveright.UseVisualStyleBackColor = true;
            this.moveright.Click += new System.EventHandler(this.moveright_Click);
            // 
            // zeropointer
            // 
            this.zeropointer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zeropointer.Location = new System.Drawing.Point(1120, 565);
            this.zeropointer.Name = "zeropointer";
            this.zeropointer.Size = new System.Drawing.Size(200, 30);
            this.zeropointer.TabIndex = 17;
            this.zeropointer.Text = "零點";
            this.zeropointer.UseVisualStyleBackColor = true;
            this.zeropointer.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataname
            // 
            this.dataname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataname.AutoSize = true;
            this.dataname.Location = new System.Drawing.Point(13, 689);
            this.dataname.Name = "dataname";
            this.dataname.Size = new System.Drawing.Size(67, 15);
            this.dataname.TabIndex = 18;
            this.dataname.Text = "顯示檔名";
            // 
            // length_refer
            // 
            this.length_refer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.length_refer.Location = new System.Drawing.Point(1120, 215);
            this.length_refer.Name = "length_refer";
            this.length_refer.Size = new System.Drawing.Size(200, 25);
            this.length_refer.TabIndex = 19;
            this.length_refer.Text = "在此輸入長度";
            this.length_refer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.length_refer.Visible = false;
            this.length_refer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.length_refer_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 711);
            this.Controls.Add(this.length_refer);
            this.Controls.Add(this.dataname);
            this.Controls.Add(this.zeropointer);
            this.Controls.Add(this.moveright);
            this.Controls.Add(this.moveleft);
            this.Controls.Add(this.movedown);
            this.Controls.Add(this.moveup);
            this.Controls.Add(this.setsize);
            this.Controls.Add(this.picturesmaller);
            this.Controls.Add(this.picturebigger);
            this.Controls.Add(this.pointlight);
            this.Controls.Add(this.dot_place);
            this.Controls.Add(this.activepoint);
            this.Controls.Add(this.zoomminus);
            this.Controls.Add(this.zoomplus);
            this.Controls.Add(this.zoombox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.load_file);
            this.Controls.Add(this.dxf_view);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxf_view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoombox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dot_place)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox dxf_view;
        private System.Windows.Forms.Button load_file;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox zoombox;
        private System.Windows.Forms.Button zoomplus;
        private System.Windows.Forms.Button zoomminus;
        private System.Windows.Forms.Button activepoint;
        private System.Windows.Forms.PictureBox dot_place;
        private System.Windows.Forms.Label pointlight;
        private System.Windows.Forms.Button picturebigger;
        private System.Windows.Forms.Button picturesmaller;
        private System.Windows.Forms.Button setsize;
        private System.Windows.Forms.Button moveup;
        private System.Windows.Forms.Button movedown;
        private System.Windows.Forms.Button moveleft;
        private System.Windows.Forms.Button moveright;
        private System.Windows.Forms.Button zeropointer;
        private System.Windows.Forms.Label dataname;
        private System.Windows.Forms.TextBox length_refer;
    }
}

