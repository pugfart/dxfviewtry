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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.zoombox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dxf_view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoombox)).BeginInit();
            this.SuspendLayout();
            // 
            // dxf_view
            // 
            this.dxf_view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dxf_view.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dxf_view.Location = new System.Drawing.Point(12, 12);
            this.dxf_view.Name = "dxf_view";
            this.dxf_view.Size = new System.Drawing.Size(1404, 854);
            this.dxf_view.TabIndex = 0;
            this.dxf_view.TabStop = false;
            this.dxf_view.Paint += new System.Windows.Forms.PaintEventHandler(this.dxf_view_Paint);
            this.dxf_view.MouseEnter += new System.EventHandler(this.dxf_view_MouseEnter);
            this.dxf_view.MouseLeave += new System.EventHandler(this.dxf_view_MouseLeave);
            this.dxf_view.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dxf_view_MouseMove);
            // 
            // load_file
            // 
            this.load_file.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.load_file.Location = new System.Drawing.Point(1445, 12);
            this.load_file.Name = "load_file";
            this.load_file.Size = new System.Drawing.Size(75, 23);
            this.load_file.TabIndex = 1;
            this.load_file.Text = "讀檔";
            this.load_file.UseVisualStyleBackColor = true;
            this.load_file.Click += new System.EventHandler(this.load_file_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1405, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1402, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // zoombox
            // 
            this.zoombox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoombox.Location = new System.Drawing.Point(1435, 144);
            this.zoombox.Name = "zoombox";
            this.zoombox.Size = new System.Drawing.Size(100, 100);
            this.zoombox.TabIndex = 4;
            this.zoombox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1547, 878);
            this.Controls.Add(this.zoombox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.load_file);
            this.Controls.Add(this.dxf_view);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxf_view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoombox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox dxf_view;
        private System.Windows.Forms.Button load_file;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox zoombox;
    }
}

