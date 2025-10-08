using System;
using System.Drawing;

namespace TestingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputPath = @"D:\testImage\kot.jpg";

            string outputPath = @"D:\testImage\output_kot.jpg";

            using (Bitmap bitmap = new Bitmap(inputPath))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    Font font = new Font("Arial", 14, FontStyle.Bold);
                    Brush brush = Brushes.Black;

                    graphics.DrawString("300 мм", font, brush, new PointF(355, 250));
                    graphics.DrawString("planetDestroer", font, brush, new PointF(35, 45));

                }
                bitmap.Save(outputPath);
            }

            Console.WriteLine("Изображение успешно сохранено с добавленными размерами!");
        }
    }
}
