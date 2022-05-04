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
    public partial class ColorPickerVertical : UserControl
    {
        public ColorPickerVertical()
        {
            InitializeComponent();
        }
        public delegate void colorChanged(object sender, ColorChangedEventArgs e);
        public event colorChanged ColorChanged;

        int MarkerY = 1;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            LinearGradientBrush linearGradientBrush =
   new LinearGradientBrush(this.ClientRectangle, Color.Red, Color.Red, 90);

            ColorBlend cblend = new ColorBlend(7);
            cblend.Colors = new Color[7] { Color.Red, Color.Yellow, Color.Lime, Color.Aqua, Color.Blue, Color.DeepPink, Color.Red };
            cblend.Positions = new float[7] { 0f, 0.16f, 0.32f, 0.48f,  0.64f, 0.8f, 1f};

            linearGradientBrush.InterpolationColors = cblend;

            e.Graphics.FillRectangle(linearGradientBrush, this.ClientRectangle);
            if(MarkerY <= 1)
            {
                MarkerY = 1;
            }
            e.Graphics.DrawLine(new Pen(Color.White, 2f), 0, MarkerY, this.Width, MarkerY);
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
                    Graphics g = Graphics.FromImage(b);
                    LinearGradientBrush linearGradientBrush =
   new LinearGradientBrush(this.ClientRectangle, Color.Red, Color.Red, 90);

                    ColorBlend cblend = new ColorBlend(7);
                    cblend.Colors = new Color[7] { Color.Red, Color.Yellow, Color.Lime, Color.Aqua, Color.Blue, Color.DeepPink, Color.Red };
                    cblend.Positions = new float[7] { 0f, 0.16f, 0.32f, 0.48f, 0.64f, 0.8f, 1f }; // -> basic math 1f / 6 * index

                    linearGradientBrush.InterpolationColors = cblend;

                    g.FillRectangle(linearGradientBrush, this.ClientRectangle);
                    Color color = b.GetPixel(2, e.Y);
                    MarkerY = e.Y;
                    this.Cursor = Cursors.Hand;
                    if (ColorChanged != null)
                    {
                        ColorChanged(this, new ColorChangedEventArgs() { Color = color });
                    }
                    this.Invalidate();
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
            catch { }
        }

        public class ColorChangedEventArgs : EventArgs
        {
            public Color Color { get; set; }
        }
    }
}
