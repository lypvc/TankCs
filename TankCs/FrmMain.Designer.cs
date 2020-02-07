namespace TankCs
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnGo = new System.Windows.Forms.Button();
            this.txtNr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlShow = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMini = new System.Windows.Forms.Button();
            this.notifyShow = new System.Windows.Forms.NotifyIcon(this.components);
            this.ovShow = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.pnlShow.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(79, 237);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "确定";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtNr
            // 
            this.txtNr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtNr.ForeColor = System.Drawing.Color.Black;
            this.txtNr.Location = new System.Drawing.Point(12, 110);
            this.txtNr.Multiline = true;
            this.txtNr.Name = "txtNr";
            this.txtNr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNr.Size = new System.Drawing.Size(203, 100);
            this.txtNr.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "测试测试";
            // 
            // pnlShow
            // 
            this.pnlShow.BackColor = System.Drawing.Color.White;
            this.pnlShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlShow.Controls.Add(this.txtNr);
            this.pnlShow.Controls.Add(this.btnGo);
            this.pnlShow.Controls.Add(this.btnClose);
            this.pnlShow.Controls.Add(this.label1);
            this.pnlShow.Controls.Add(this.btnMini);
            this.pnlShow.Location = new System.Drawing.Point(1, 55);
            this.pnlShow.Margin = new System.Windows.Forms.Padding(0);
            this.pnlShow.Name = "pnlShow";
            this.pnlShow.Size = new System.Drawing.Size(227, 373);
            this.pnlShow.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(202, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMini
            // 
            this.btnMini.Location = new System.Drawing.Point(178, 0);
            this.btnMini.Margin = new System.Windows.Forms.Padding(0);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(20, 20);
            this.btnMini.TabIndex = 5;
            this.btnMini.Text = "-";
            this.btnMini.UseVisualStyleBackColor = true;
            this.btnMini.Click += new System.EventHandler(this.btnMini_Click);
            // 
            // notifyShow
            // 
            this.notifyShow.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyShow.Icon")));
            this.notifyShow.Text = "测试透明窗体";
            this.notifyShow.Visible = true;
            this.notifyShow.DoubleClick += new System.EventHandler(this.notifyShow_DoubleClick);
            // 
            // ovShow
            // 
            this.ovShow.BackColor = System.Drawing.Color.Transparent;
            this.ovShow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ovShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ovShow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ovShow.FillGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ovShow.Location = new System.Drawing.Point(92, 437);
            this.ovShow.Name = "ovShow";
            this.ovShow.SelectionColor = System.Drawing.Color.Transparent;
            this.ovShow.Size = new System.Drawing.Size(46, 46);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.ovShow});
            this.shapeContainer1.Size = new System.Drawing.Size(231, 485);
            this.shapeContainer1.TabIndex = 6;
            this.shapeContainer1.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(231, 485);
            this.Controls.Add(this.pnlShow);
            this.Controls.Add(this.shapeContainer1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.ShowInTaskbar = false;
            this.SkinBack = global::TankCs.Properties.Resources.iPhone_5_White2;
            this.SkinPosition = new System.Drawing.Point(15, 15);
            this.SkinSize = new System.Drawing.Size(260, 510);
            this.SkinTrankColor = System.Drawing.Color.Magenta;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测试透明窗体";
            this.pnlShow.ResumeLayout(false);
            this.pnlShow.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtNr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlShow;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMini;
        private System.Windows.Forms.NotifyIcon notifyShow;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ovShow;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;



    }
}

