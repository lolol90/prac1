// Decompiled with JetBrains decompiler
// Type: smartMain.Controls.conComboBox
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace smartMain.Controls
{
    [ToolboxBitmap(typeof(ComboBox))]
    public class conComboBox : ComboBox
    {
        private Color saveBackColor = Color.White;
        private Color focusedBackColor = Color.White;
        private Color borderColor = Color.White;
        private static int WM_PAINT = 15;

        private void conComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
            SendKeys.SendWait("{tab}");
        }

        private void conComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
                return;
            e.Handled = true;
        }

        [Browsable(true)]
        [Category("con 모양 설정")]
        [Description("입력모드의 배경색을 지정하세요.")]
        public Color _FocusedBackColor
        {
            get => this.focusedBackColor;
            set => this.focusedBackColor = value;
        }

        [Description("테두리 색을 지정하세요.")]
        [Category("con 모양 설정")]
        [Browsable(true)]
        public Color _BorderColor
        {
            get => this.borderColor;
            set => this.borderColor = value;
        }

        public conComboBox()
        {
            this.saveBackColor = this.BackColor;
            this.KeyPress += new KeyPressEventHandler(this.conComboBox_KeyPress);
            this.KeyDown += new KeyEventHandler(this.conComboBox_KeyDown);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg != conComboBox.WM_PAINT)
                return;
            Graphics graphics = Graphics.FromHwnd(this.Handle);
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            ControlPaint.DrawBorder(graphics, bounds, this.borderColor, ButtonBorderStyle.Solid);
            graphics.Dispose();
        }

        protected override void OnEnter(EventArgs e)
        {
            this.saveBackColor = this.BackColor;
            this.BackColor = this.focusedBackColor;
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            this.BackColor = this.saveBackColor;
            base.OnLeave(e);
        }
    }
}
