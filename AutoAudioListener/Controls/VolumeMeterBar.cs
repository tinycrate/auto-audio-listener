using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAudioListener.Controls {
    public class VolumeMeterBar : ProgressBar {

        public enum VolumeMeterFillStyle {
            Horiztonal,
            Vertical
        }

        public VolumeMeterFillStyle FillStyle { get; set; } = VolumeMeterFillStyle.Horiztonal;

        private readonly float[] volumeMeterGradientPositions = { 0, 0.7f, 0.9f, 1 };
        private readonly Color[] volumeMeterGradientColors = {
            Color.FromArgb(255, 6, 176, 37),
            Color.FromArgb(255, 6, 176, 37),
            Color.FromArgb(255, 245, 209, 70),
            Color.FromArgb(255, 245, 70, 70),
        };

        public VolumeMeterBar() {
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
                int width = (FillStyle == VolumeMeterFillStyle.Horiztonal) ? (int)Math.Round(((float)Value / Maximum) * rect.Width) : rect.Width;
                int height = (FillStyle == VolumeMeterFillStyle.Vertical) ? (int)Math.Round(((float)Value / Maximum) * rect.Height) : rect.Height;
                int xPos = rect.X;
                int yPos = (FillStyle == VolumeMeterFillStyle.Vertical) ? rect.Y + (rect.Height - height) : rect.Y;
                var barRect = new Rectangle(xPos, yPos, width, height);
                var colors = new ColorBlend();
                colors.Positions = volumeMeterGradientPositions;
                colors.Colors = volumeMeterGradientColors;
                var gradentBrush = new LinearGradientBrush(rect, Color.Black, Color.Black, (FillStyle == VolumeMeterFillStyle.Vertical) ? 270f : 0f);
                gradentBrush.InterpolationColors = colors;
                e.Graphics.FillRectangle(gradentBrush, barRect);
            }
        }
    }
}
