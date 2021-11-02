// Decompiled with JetBrains decompiler
// Type: smartMain.Controls.conLabel
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace smartMain.Controls
{
    [ToolboxBitmap(typeof(Label))]
    public class conLabel : Label
    {
        private Color borderColor = Color.Black;
        private static int WM_PAINT = 15;

        [Category("con 모양 설정")]
        [Browsable(true)]
        [Description("테두리 색을 지정하세요.")]
        public Color _BorderColor
        {
            get => this.borderColor;
            set => this.borderColor = value;
        }

        public conLabel()
        {
            this.AutoSize = false;
            this.BorderStyle = BorderStyle.None;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg != conLabel.WM_PAINT)
                return;
            Graphics graphics = Graphics.FromHwnd(this.Handle);
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            ControlPaint.DrawBorder(graphics, bounds, this.borderColor, ButtonBorderStyle.Solid);
            graphics.Dispose();
        }

        protected override void OnEnter(EventArgs e) => base.OnEnter(e);

        protected override void OnLeave(EventArgs e) => base.OnLeave(e);
    }
}
