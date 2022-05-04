using CSharpColorPicker.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpColorPicker
{
    [DefaultEvent("ColorChanged")]
    public partial class ColorPicker : UserControl
    {
        public ColorPicker()
        {
            InitializeComponent();
        }

        public delegate void colorChanged(object sender, ColorChangedEventArgs e);
        public event colorChanged ColorChanged;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap bitmap = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(bitmap);
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
               Color.White,
               MainColor,
               LinearGradientMode.Horizontal))
            {
                g.FillRectangle(brush, this.ClientRectangle);
            }

            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
   Color.Transparent,
   Color.Black,
   LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, this.ClientRectangle);
            }
            e.Graphics.DrawImage(bitmap, 0, 0);
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
        }

        private Color mainColor = Color.Red;
        public Color MainColor
        {
            get
            {
                return mainColor;
            }
            set
            {
                mainColor = value;
                this.Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    Bitmap b = new Bitmap(this.Width, this.Height);
                    this.DrawToBitmap(b, new Rectangle(0, 0, b.Width, b.Height));
                    Graphics g = Graphics.FromImage(b);
                    Color color = b.GetPixel(e.Location.X, e.Location.Y);

                    Color penColor = (color.R * 0.2126 + color.G * 0.7152 + color.B * 0.0722 < 255 / 2) ? Color.White : Color.Black;
                    if (color.R != 0 && color.G != 0 && color.B != 0)
                    {
                        g.FillEllipse(new SolidBrush(color), new RectangleF(e.Location.X - (10 / 2), e.Location.Y - (10 / 2), 10, 10));
                        g.DrawEllipse(new Pen(penColor), new Rectangle(e.Location.X - (10 / 2), e.Location.Y - (10 / 2), 10, 10));
                        g.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
                        Graphics control = Graphics.FromHwnd(this.Handle);
                        control.DrawImage(b, 0, 0);
                        if (ColorChanged != null)
                        {
                            ColorChanged(this, new ColorChangedEventArgs() { Color = color });
                        }
                        this.Cursor = Cursors.Hand;
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    this.Invalidate();
                }
            } catch { }
        }

        public class ColorChangedEventArgs : EventArgs
        {
            public Color Color { get; set; }
        }
    }
}
