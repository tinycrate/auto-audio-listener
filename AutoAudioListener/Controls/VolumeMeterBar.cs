using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AutoAudioListener.Controls {
    public class VolumeMeterBar : ProgressBar {
        private readonly Color[] volumeMeterGradientColors = {
            Color.FromArgb(255, 6, 176, 37),
            Color.FromArgb(255, 6, 176, 37),
            Color.FromArgb(255, 245, 209, 70),
            Color.FromArgb(255, 245, 70, 70)
        };

        private readonly float[] volumeMeterGradientPositions = {0, 0.7f, 0.9f, 1};

        public VolumeMeterBar() {
            // Set ControlStyles flags as instructed by Microsoft docs for overriding OnPaint and reducing flickers
            // http://msdn.microsoft.com/en-us/library/system.windows.forms.controlstyles.aspx
            SetStyle(
                ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer,
                true
            );
        }

        public VolumeMeterFillStyle FillStyle { get; set; } = VolumeMeterFillStyle.Horiztonal;

        protected override void OnPaint(PaintEventArgs e) {
            var rect = ClientRectangle;
            var g = e.Graphics;
            ProgressBarRenderer.DrawHorizontalBar(g, rect);
            rect.Inflate(-1, -1);
            if (Value > 0) {
                var width = FillStyle == VolumeMeterFillStyle.Horiztonal
                    ? (int) Math.Round((float) Value / Maximum * rect.Width)
                    : rect.Width;
                var height = FillStyle == VolumeMeterFillStyle.Vertical
                    ? (int) Math.Round((float) Value / Maximum * rect.Height)
                    : rect.Height;
                var xPos = rect.X;
                var yPos = FillStyle == VolumeMeterFillStyle.Vertical ? rect.Y + (rect.Height - height) : rect.Y;
                var barRect = new Rectangle(xPos, yPos, width, height);
                var colors = new ColorBlend();
                colors.Positions = volumeMeterGradientPositions;
                colors.Colors = volumeMeterGradientColors;
                var gradentBrush = new LinearGradientBrush(
                    rect,
                    Color.Black,
                    Color.Black,
                    FillStyle == VolumeMeterFillStyle.Vertical ? 270f : 0f
                );
                gradentBrush.InterpolationColors = colors;
                e.Graphics.FillRectangle(gradentBrush, barRect);
            }
        }

        public enum VolumeMeterFillStyle {
            Horiztonal,
            Vertical
        }
    }
}