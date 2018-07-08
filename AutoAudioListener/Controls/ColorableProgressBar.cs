using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAudioListener.Controls {
    class ColorableProgressBar : ProgressBar {

        public Color FillColor { get; set; } = Color.FromArgb(255, 6, 176, 37);

        public ColorableProgressBar() {
            // Set ControlStyles flags as instructed by Microsoft docs for overriding OnPaint and reducing flickers
            // http://msdn.microsoft.com/en-us/library/system.windows.forms.controlstyles.aspx
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e) {
            Rectangle rect = ClientRectangle;
            Graphics g = e.Graphics;
            ProgressBarRenderer.DrawHorizontalBar(g, rect);
            rect.Inflate(-1, -1);
            if (Value > 0) {
                var barRect = new Rectangle(rect.X, rect.Y, (int)Math.Round(((float)Value / Maximum) * rect.Width), rect.Height);
                var brush = new SolidBrush(FillColor);
                e.Graphics.FillRectangle(brush, barRect);
            }
        }
    }
}
