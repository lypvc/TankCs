using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace CCWin
{
    //绘图层
    public partial class SkinForm : Form
    {
        //控件层
        private SkinMain Main;
        //带参构造
        public SkinForm(SkinMain main)
        {
            InitializeComponent();
            //将控制层传值过来
            this.Main = main;
            //减少闪烁
            SetStyles();
            //初始化
            Init();
        }
        #region 变量
        //绘图层透明属性
        private int _skinopacity = 255;
        [Description("设置或获取绘图层窗口透明度(0-255)")]
        [DefaultValue(255)]
        public int SkinOpacity
        {
            get { return _skinopacity; }
            set
            {
                if (_skinopacity != value)
                {
                    Main.Opacity = _skinopacity = value > 255 ? 255 : value;
                    SetBits();
                }
            }
        }

        //绘图层需要透明的颜色
        private Color _skintrankcolor = Color.Transparent;
        [DefaultValue(typeof(Color), "Color.Transparent")]
        [Description("绘图层需要透明的颜色")]
        public Color SkinTrankColor
        {
            get { return _skintrankcolor; }
            set
            {
                if (_skintrankcolor != value)
                {
                    Main.SkinTrankColor = _skintrankcolor = value;
                    SetBits();
                }
            }
        }

        //设置或获取窗口在控件层位置
        private Point _skinposition;
        [Description("设置或获取窗口在控件层位置")]
        public Point SkinPosition
        {
            get { return _skinposition; }
            set
            {
                if (_skinposition != value)
                {
                    Main.SkinPosition = _skinposition = value;
                }
            }
        }

        //绘图层是否开启位图仿透明
        private bool _skinwhethertank;
        [Description("绘图层是否开启位图仿透明\r\n注意(SkinOpacity < 255时，此属性为False可达到背景透明，控件不透明的效果。)")]
        public bool SkinWhetherTank
        {
            get { return _skinwhethertank; }
            set
            {
                if (_skinwhethertank != value)
                {
                    Main.SkinWhetherTank = _skinwhethertank = value;
                    SetBits();
                }
            }
        }

        //窗体是否可以移动
        private bool _skinmobile = true;
        [Description("窗体是否可以移动")]
        [DefaultValue(typeof(bool), "true")]
        public bool SkinMobile
        {
            get { return _skinmobile; }
            set
            {
                if (_skinmobile != value)
                {
                    Main.SkinMobile = _skinmobile = value;
                }
            }
        }
        #endregion

        #region 初始化
        private void Init()
        {
            //设置绘图层需要透明的颜色
            SkinTrankColor = Main.SkinTrankColor;
            //最顶层
            TopMost = true;
            //没有最小化按钮
            MinimizeBox = false;
            //没有最大化按钮
            MaximizeBox = false;
            //控制菜单框是否显示
            ControlBox = false;
            //是否在任务栏显示
            ShowInTaskbar = Main.ShowInTaskbar;
            Main.ShowInTaskbar = false;
            //初始化显示在屏幕中间
            StartPosition = FormStartPosition.CenterScreen;
            //无边框模式
            FormBorderStyle = FormBorderStyle.None;
            //自动拉伸背景图以适应窗口
            BackgroundImageLayout = ImageLayout.Stretch;
            //还原任务栏右键菜单
            CommonClass.SetTaskMenu(this);
            //设置绘图层显示位置
            this.Location = new Point(Main.Location.X - Main.SkinPosition.X, Main.Location.Y - Main.SkinPosition.Y);
            //设置ICO
            Icon = Main.Icon;
            //是否显示ICO
            ShowIcon = Main.ShowIcon;
            //设置大小
            Size = Main.SkinSize;
            //设置透明度
            SkinOpacity = Main.SkinOpacity;
            //设置标题名
            Text = Main.Text;
            //设置控件层位置
            SkinPosition = Main.SkinPosition;
            //窗口是否可以移动
            SkinMobile = Main.SkinMobile;
            //是否开启位图仿透明
            SkinWhetherTank = Main.SkinWhetherTank;
            //设置背景
            Bitmap bitmaps = new Bitmap(Main.SkinBack, Size);
            bitmaps.MakeTransparent(SkinTrankColor);
            BackgroundImage = bitmaps;
            //控制层与绘图层合为一体
            Main.Visible = false;
            Main.TopMost = true;
            Main.TransparencyKey = Main.BackColor;
            Main.Location = new Point(this.Location.X + Main.SkinPosition.X, this.Location.Y + Main.SkinPosition.Y);
            Main.Show(this);
            Main.Opacity = Main.opacitys;
            //绘制层窗体移动
            this.MouseDown += new MouseEventHandler(Frm_MouseDown);
            this.MouseMove += new MouseEventHandler(Frm_MouseMove);
            this.MouseUp += new MouseEventHandler(Frm_MouseUp);
            //控制层层窗体移动
            Main.MouseDown += new MouseEventHandler(Frm_MouseDown);
            Main.MouseMove += new MouseEventHandler(Frm_MouseMove);
            Main.MouseUp += new MouseEventHandler(Frm_MouseUp);
        }
        #endregion

        #region 减少闪烁
        private void SetStyles()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw|
                ControlStyles.DoubleBuffer, true);
            //强制分配样式重新应用到控件上
            UpdateStyles();
        }
        #endregion

        #region 无标题栏的窗口移动
        private Point mouseOffset; //记录鼠标指针的坐标
        private bool isMouseDown = false; //记录鼠标按键是否按下
        private void Frm_MouseDown(object sender, MouseEventArgs e)
        {
            if (SkinMobile)
            {
                int xOffset;
                int yOffset;
                //点击窗体时，记录鼠标位置，启动移动
                if (e.Button == MouseButtons.Left)
                {
                    xOffset = -e.X;
                    yOffset = -e.Y;
                    mouseOffset = new Point(xOffset, yOffset);
                    isMouseDown = true;
                }
            }
        }

        private void Frm_MouseMove(object sender, MouseEventArgs e)
        {
            if (SkinMobile)
            {
                //将调用此事件的窗口保存下
                Form frm = (Form)sender;
                //确定开启了移动模式后
                if (isMouseDown)
                {
                    //移动的位置计算
                    Point mousePos = Control.MousePosition;
                    mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                    //判断是绘图层还是控件层调用了移动事件,并作出相应回馈
                    if (frm.Name == "SkinForm")
                    {
                        Location = mousePos;
                        Main.Location = new Point(mousePos.X + SkinPosition.X, mousePos.Y + SkinPosition.Y);
                    }
                    else
                    {
                        Main.Location = mousePos;
                        Location = new Point(mousePos.X - SkinPosition.X, mousePos.Y - SkinPosition.Y);
                    }
                }
            }
        }

        private void Frm_MouseUp(object sender, MouseEventArgs e)
        {
            if (SkinMobile)
            {
                // 修改鼠标状态isMouseDown的值
                // 确保只有鼠标左键按下并移动时，才移动窗体
                if (e.Button == MouseButtons.Left)
                {
                    //松开鼠标时，停止移动
                    isMouseDown = false;
                    //Top高度小于0的时候，等于0
                    if (this.Top < 0)
                    {
                        this.Top = 0;
                        Main.Top = 0 + Main.SkinPosition.Y;
                    }
                }
            }
        }
        #endregion

        #region 还原任务栏右键菜单
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cParms = base.CreateParams;
                cParms.ExStyle |= 0x00080000; // WS_EX_LAYERED
                return cParms;
            }
        }
        public class CommonClass
        {
            [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
            static extern int GetWindowLong(HandleRef hWnd, int nIndex);
            [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
            static extern IntPtr SetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong);
            public const int WS_SYSMENU = 0x00080000;
            public const int WS_MINIMIZEBOX = 0x20000;
            public static void SetTaskMenu(Form form)
            {
                int windowLong = (GetWindowLong(new HandleRef(form, form.Handle), -16));
                SetWindowLong(new HandleRef(form, form.Handle), -16, windowLong | WS_SYSMENU | WS_MINIMIZEBOX);
            }
        }
        #endregion

        #region 不规则无毛边方法
        public void SetBits()
        {
            if (BackgroundImage != null)
            {
                //设置控件层背景
                Main.BindBack();
                //绘制绘图层背景
                Bitmap bitmap = new Bitmap(BackgroundImage, base.Width, base.Height);
                if (!Bitmap.IsCanonicalPixelFormat(bitmap.PixelFormat) || !Bitmap.IsAlphaPixelFormat(bitmap.PixelFormat))
                    throw new ApplicationException("图片必须是32位带Alhpa通道的图片。");
                IntPtr oldBits = IntPtr.Zero;
                IntPtr screenDC = Win32.GetDC(IntPtr.Zero);
                IntPtr hBitmap = IntPtr.Zero;
                IntPtr memDc = Win32.CreateCompatibleDC(screenDC);

                try
                {
                    Win32.Point topLoc = new Win32.Point(Left, Top);
                    Win32.Size bitMapSize = new Win32.Size(Width, Height);
                    Win32.BLENDFUNCTION blendFunc = new Win32.BLENDFUNCTION();
                    Win32.Point srcLoc = new Win32.Point(0, 0);

                    hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                    oldBits = Win32.SelectObject(memDc, hBitmap);

                    blendFunc.BlendOp = Win32.AC_SRC_OVER;
                    blendFunc.SourceConstantAlpha = Byte.Parse(SkinOpacity.ToString());
                    blendFunc.AlphaFormat = Win32.AC_SRC_ALPHA;
                    blendFunc.BlendFlags = 0;

                    Win32.UpdateLayeredWindow(Handle, screenDC, ref topLoc, ref bitMapSize, memDc, ref srcLoc, 0, ref blendFunc, Win32.ULW_ALPHA);
                }
                finally
                {
                    if (hBitmap != IntPtr.Zero)
                    {
                        Win32.SelectObject(memDc, oldBits);
                        Win32.DeleteObject(hBitmap);
                    }
                    Win32.ReleaseDC(IntPtr.Zero, screenDC);
                    Win32.DeleteDC(memDc);
                }
            }
        }
        #endregion

        #region 重载背景更改时事件
        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);
            SetBits();
        }
        #endregion
    }
}
