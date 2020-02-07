using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using CCWin;

namespace TankCs
{
    public partial class FrmMain : SkinMain
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        int i = 1;
        private void btnGo_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                this.SkinBack = Properties.Resources.iPhone_5_Black2;
                i = 2;
            }
            else
            {
                this.SkinBack = Properties.Resources.iPhone_5_White2;
                i = 1;
            }
        }

        //最小化
        private void btnMini_Click(object sender, EventArgs e)
        {
            this.AllHide();
        }

        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //双击显示
        private void notifyShow_DoubleClick(object sender, EventArgs e)
        {
            this.AllShow();
        }
    }
}
