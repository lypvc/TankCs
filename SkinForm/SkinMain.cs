using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace CCWin
{
    //控件层
    public partial class SkinMain : Form
    {
        //绘制层
        public SkinForm skin;
        public double opacitys;
        public SkinMain()
        {
            InitializeComponent();
            opacitys = this.Opacity;
            this.Opacity = 0;
        }
        #region 全部显示
        public void AllShow()
        {
            this.Show();
            if(skin != null)
            {
                skin.Show();
            }
        }
        #endregion

        #region 全部隐藏
        public void AllHide() 
        {
            skin.Hide();
            this.Hide();
        }
        #endregion

        #region 变量属性
        private Size _skinsize;
        [Description("设置或获取绘图层窗口大小")]
        public Size SkinSize
        {
            get { return _skinsize; }
            set
            {
                if (_skinsize != value)
                {
                    _skinsize = value;
                    if(skin != null)
                    {
                        skin.Size = _skinsize;
                    }
                    //验证下宽高
                    BindSize();
                    //重新应用下绘图层背景
                    BindBack();
                }
            }
        }

        private Bitmap _skinback;
        [Description("设置或获取绘图层窗口背景")]
        public Bitmap SkinBack
        {
            get { return _skinback; }
            set
            {
                if (_skinback != value)
                {
                    _skinback = value;
                    if (skin != null)
                    {
                        Bitmap bitmap = new Bitmap(SkinBack, SkinSize);
                        bitmap.MakeTransparent(SkinTrankColor);
                        skin.BackgroundImage = bitmap;
                    }
                    else
                    {
                        //重新应用下绘图层背景
                        BindBack();
                    }
                }
            }
        }

        private int _skinopacity = 255;
        [Browsable​(true)​]​
        [Description("设置或获取绘图层窗口透明度")]//(0-255)
        [DefaultValue(255)]
        public int SkinOpacity
        {
            get { return _skinopacity; }
            set
            {
                if (_skinopacity != value)
                {
                    //如果赋值大与255，就等于255
                    _skinopacity = value > 255 ? 255 : value;
                    if (skin != null)
                    {
                        skin.SkinOpacity = _skinopacity;
                    }
                }
            }
        }


        private Point _skinposition;
        [Description("设置或获取窗口在控件层位置")]
        public Point SkinPosition
        {
            get { return _skinposition; }
            set
            {
                if (_skinposition != value)
                {
                    _skinposition = value;
                    //验证下宽高
                    BindSize();
                    //重新应用下绘图层背景
                    BindBack();
                    if (skin != null)
                    {
                        Location = new Point(skin.Left + SkinPosition.X, skin.Top + SkinPosition.Y);
                        skin.SkinPosition = _skinposition;
                    }
                }
            }
        }

        private Color _skintrankcolor = Color.Transparent;
        [Description("绘图层需要透明的颜色")]
        [DefaultValue(typeof(Color), "Color.Transparent")]
        public Color SkinTrankColor
        {
            get { return _skintrankcolor; }
            set
            {
                if (_skintrankcolor != value)
                {
                    _skintrankcolor = value;
                    if (BackgroundImage != null)
                    {
                        backs();
                    }
                    if(skin != null)
                    {
                        skin.SkinTrankColor = _skintrankcolor;
                        Bitmap bitmap = new Bitmap(SkinBack, SkinSize);
                        bitmap.MakeTransparent(SkinTrankColor);
                        skin.BackgroundImage = bitmap;
                    }
                }
            }
        }

        private bool _skinwhethertank = true;
        [Description("绘图层是否开启位图仿透明.注意(SkinOpacity < 255时，此属性为False可达到背景透明，控件不透明的效果。)")]
        [DefaultValue(typeof(bool),"true")]
        public bool SkinWhetherTank
        {
            get { return _skinwhethertank; }
            set
            {
                if (_skinwhethertank != value)
                {
                    _skinwhethertank = value;
                    if (skin != null)
                    {
                        skin.SkinWhetherTank = _skinwhethertank;
                    }
                }
            }
        }

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
                    _skinmobile = value;
                    if (skin != null)
                    {
                        skin.SkinMobile = _skinmobile;
                    }
                }
            }
        }
        #endregion

        #region 绑定背景
        public void BindBack()
        {
            //绘图层背景属性不等于空，绘图层宽高不等于0，控件层宽高不等于0时才绑定背景
            if (_skinback != null && SkinSize != new Size(0, 0) && Width != 0 && Height != 0 && SkinSize != new Size(0, 0))
            {
                //在设计器时，始终显示裁剪背景
                if (!TopLevel)
                {
                    backs();
                }
                else 
                {
                    if (SkinWhetherTank)
                    {
                        backs();
                    }
                    else 
                    {
                        BackgroundImage = null;
                    }
                }
            }
        }

        //裁剪透明做背景
        public void backs() 
        {
            //裁剪下图片
            Bitmap back = new Bitmap(_skinback, _skinsize);
            Rectangle cloneRect = new Rectangle(_skinposition.X, _skinposition.Y, Width, Height);
            PixelFormat format = back.PixelFormat;
            Bitmap cloneBitmap = back.Clone(cloneRect, format);
            cloneBitmap.MakeTransparent(_skintrankcolor);
            //将裁剪好的图片给控件层赋值
            this.BackgroundImage = cloneBitmap;
        }
        #endregion

        #region 重载大小改变事件
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            //控制层宽高 大于或等于 （绘制层宽高 - 控制层在绘图层的位置XY）时重新绑定背景 
            if (Width <= (SkinSize.Width - SkinPosition.X) && Height <= (SkinSize.Height - SkinPosition.Y))
            {
                BindBack();
            }
            else
            {
                //否则重新验证宽高大小，并给出回馈
                BindSize();
            }
        }
        #endregion

        #region 验证大小
        private void BindSize()
        {
            //判断控件层和绘图层宽高都不等于0时
            if (Width != 0 && Height != 0 && SkinSize != new Size(0,0))
            {
                //控件层宽度 大于 (绘图层宽度 - 控件层所在绘图层X值)时
                if (Width > SkinSize.Width - SkinPosition.X)
                {
                    //等于最大限制的宽度
                    Width = SkinSize.Width - SkinPosition.X;
                }
                //控件层宽度 大于 (绘图层宽度 - 控件层所在绘图层Y值)时
                if (Height > SkinSize.Height - SkinPosition.Y)
                {
                    //等于最大限制的高度
                    Height = SkinSize.Height - SkinPosition.Y;
                }
            }
        }
        #endregion

        #region 窗口加载时
        protected override void OnLoad(EventArgs e)
        {
            //判断是否是顶级窗口,不是则执行在设计器中的事件
            if(this.TopLevel == true)
            {
                skin = new SkinForm(this);
                skin.Show();
            }
            base.OnLoad(e);
        }
        #endregion
    }
}
