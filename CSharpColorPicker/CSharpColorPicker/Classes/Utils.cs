using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpColorPicker.Classes
{
    internal class Utils
    {
        public List<PointF> getCorners(RectangleF r)
        {
            return new List<PointF>() { r.Location, new PointF(r.Right, r.Top),
        new PointF(r.Right, r.Bottom), new PointF(r.Left, r.Bottom)};
        }

        public static Color medianColor(List<Color> cols)
        {
            int c = cols.Count;
            return Color.FromArgb(cols.Sum(x => x.A) / c, cols.Sum(x => x.R) / c,
                cols.Sum(x => x.G) / c, cols.Sum(x => x.B) / c);
        }

        Bitmap Gradient2D(Rectangle r, Color c1, Color c2, Color c3, Color c4)
        {
            List<Color> colors = new List<Color> { c1, c3, c4, c2 };
            Bitmap bmp = new Bitmap(r.Width, r.Height);
            using (Graphics g = Graphics.FromImage(bmp))
                for (int y = 0; y < r.Height; y++)
                {

                    using (PathGradientBrush pgb = new PathGradientBrush(getCorners(r).ToArray()))
                    {
                        pgb.CenterColor = medianColor(colors);
                        pgb.SurroundColors = colors.ToArray();
                        g.FillRectangle(pgb, 0, y, r.Width, 1);
                    }
                }
            return bmp;
        }
    }
}
