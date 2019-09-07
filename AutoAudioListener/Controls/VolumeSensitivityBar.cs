using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoAudioListener.Controls {
    internal class VolumeSensitivityBar : ProgressBar {
        public VolumeSensitivityBar() {
            // Set ControlStyles flags as instructed by Microsoft docs for overriding OnPaint and reducing flickers
            // http://msdn.microsoft.com/en-us/library/system.windows.forms.controlstyles.aspx
            SetStyle(
                ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer,
                true
            );
        }

        public Color NormalColor { get; set; } = Color.FromArgb(255, 6, 176, 37);
        public Color TriggeredColor { get; set; } = Color.FromArgb(255, 42, 191, 68);

        public Color NormalIndicatorColor { get; set; } = Color.Blue;
        public Color TriggeredIndicatorColor { get; set; } = Color.Red;

        public int Threshold { get; set; } = 500;

        protected override void OnPaint(PaintEventArgs e) {
            var rect = ClientRectangle;
            var g = e.Graphics;
            ProgressBarRenderer.DrawHorizontalBar(g, rect);
            rect.Inflate(-1, -1);
            if (Value > 0) {
                var barRect = new Rectangle(
                    rect.X,
                    rect.Y,
                    (int) Math.Round((float) Value / Maximum * rect.Width),
                    rect.Height
                );
                var barColor = Value >= Threshold ? TriggeredColor : NormalColor;
                var barBrush = new SolidBrush(barColor);
                e.Graphics.FillRectangle(barBrush, barRect);
                var thresholdIndicatorRect = new Rectangle(
                    rect.X + (int) Math.Round((float) Threshold / Maximum * rect.Width),
                    rect.Y,
                    1,
                    rect.Height
                );
                var thresholdIndicatorColor = Value >= Threshold ? TriggeredIndicatorColor : NormalIndicatorColor;
                var thresholdIndicatorBrush = new SolidBrush(thresholdIndicatorColor);
                e.Graphics.FillRectangle(thresholdIndicatorBrush, thresholdIndicatorRect);
            }
        }
    }
}