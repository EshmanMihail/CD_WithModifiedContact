using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;

public static class ImageSigner
{
    public static void SignImage(string inputPath, string outputPath, IEnumerable<(PointF pos, string text)> labels, float dpi = 300f)
    {
        using (var src = new Bitmap(inputPath))
        {
            var bmp = new Bitmap(src.Width, src.Height);
            bmp.SetResolution(dpi, dpi);

            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                g.Clear(Color.White);
                g.DrawImageUnscaled(src, 0, 0);

                using (var font = new Font("Arial", Math.Max(10, bmp.Width / 120f), FontStyle.Bold))
                using (var pen = new Pen(Color.Black, Math.Max(1f, bmp.Width / 600f)))
                using (var brush = new SolidBrush(Color.Black))
                {
                    foreach (var label in labels)
                    {
                        var text = label.text;
                        var pos = label.pos;
                        var size = g.MeasureString(text, font);

                        var bgRect = new RectangleF(pos.X - 2, pos.Y - 2, size.Width + 4, size.Height + 4);
                        using (var bgBrush = new SolidBrush(Color.FromArgb(200, Color.White)))
                            g.FillRectangle(bgBrush, bgRect);

                        g.DrawString(text, font, brush, pos);
                    }
                }
            }

            var ext = Path.GetExtension(outputPath).ToLowerInvariant();
            if (ext == ".png")
                bmp.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
            else
                bmp.Save(outputPath, System.Drawing.Imaging.ImageFormat.Jpeg);

            bmp.Dispose();
        }
    }
}
