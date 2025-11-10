using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_WithModifiedContact.Helpers.SketchRenderHelper
{
    public class TextItem
    {
        public string Text { get; set; }
        public Func<string> TextResolver { get; set; }
        public PointF Position { get; set; }
        public Font Font { get; set; } = new Font("Arial", 12);
        public Brush Brush { get; set; } = Brushes.Black;
        public StringFormat Format { get; set; }
    }
}
