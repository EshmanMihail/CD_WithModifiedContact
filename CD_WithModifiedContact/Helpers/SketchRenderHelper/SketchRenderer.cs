using CD_WithModifiedContact.Helpers.SketchRenderHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace CD_WithModifiedContact.Helpers
{
    public class SketchRenderer
    {
        public void RenderSketch(int index, string savePath, List<TextItem> textItems)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Недопустимый индекс эскиза.");

            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sketches", $"Page{index}.jpg");

            using (Bitmap bitmap = new Bitmap(inputPath))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    foreach (var item in textItems)
                    {
                        if (item == null) continue;

                        string text = item.Text;
                        if (string.IsNullOrEmpty(text) && item.TextResolver != null) text = item.TextResolver();

                        var font = item.Font ?? SystemFonts.DefaultFont;
                        var brush = item.Brush ?? Brushes.Black;
                        var format = item.Format; // может быть null

                        if (format != null)
                            graphics.DrawString(text, font, brush, item.Position, format);
                        else
                            graphics.DrawString(text, font, brush, item.Position);
                    }
                }

                bitmap.Save(savePath);
            }
        }
    }
}
