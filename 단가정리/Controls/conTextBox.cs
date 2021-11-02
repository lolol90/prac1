// Decompiled with JetBrains decompiler
// Type: smartMain.Controls.conTextBox
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace smartMain.Controls
{
    [ToolboxBitmap(typeof(TextBox))]
    public class conTextBox : TextBox
    {
        private Color saveBackColor = Color.White;
        private Color focusedBackColor = Color.White;
        private Color borderColor = Color.White;
        private bool autoTab = true;
        private string waterMarkText = string.Empty;
        private Color waterMarkColor = Color.Gray;
        private static int WM_PAINT = 15;

        private void conTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return || !this._AutoTab)
                return;
            e.Handled = true;
            SendKeys.SendWait("{tab}");
        }

        private void conTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
                return;
            e.Handled = true;
        }

        [Description("입력모드의 배경색을 지정하세요.")]
        [Category("con 모양 설정")]
        [Browsable(true)]
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

        [Description("엔터키 입력시 자동 탭여부 설정하세요.")]
        [Category("con 모양 설정")]
        [Browsable(true)]
        public bool _AutoTab
        {
            get => this.autoTab;
            set => this.autoTab = value;
        }

        [Description("배경글을 입력하세요.")]
        [Browsable(true)]
        [Category("con 모양 설정")]
        public string _WaterMarkText
        {
            get => this.waterMarkText;
            set => this.waterMarkText = value;
        }

        public Color _WaterMarkColor
        {
            get => this.waterMarkColor;
            set => this.waterMarkColor = value;
        }

        public conTextBox()
        {
            this.saveBackColor = this.BackColor;
            this.AutoSize = false;
            this.KeyPress += new KeyPressEventHandler(this.conTextBox_KeyPress);
            this.KeyDown += new KeyEventHandler(this.conTextBox_KeyDown);
        }

        protected override void WndProc(ref Message m)
        {
            bool flag = false;
            if (m.Msg == 15)
            {
                base.WndProc(ref m);
                flag = true;
                if (m.Msg == conTextBox.WM_PAINT)
                {
                    Graphics graphics = Graphics.FromHwnd(this.Handle);
                    Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
                    ControlPaint.DrawBorder(graphics, bounds, this.borderColor, ButtonBorderStyle.Solid);
                    graphics.Dispose();
                }
                this.DrawWaterMarkText();
            }
            else if (m.Msg == 8 && this.Multiline)
                this.DrawWaterMarkText();
            if (flag)
                return;
            base.WndProc(ref m);
        }

        private void DrawWaterMarkText()
        {
            if (!string.IsNullOrEmpty(this.Text) || string.IsNullOrEmpty(this._WaterMarkText) || !this.IsHandleCreated || this.Focused || !this.Visible)
                return;
            using (Graphics graphics = Graphics.FromHwnd(this.Handle))
            {
                StringFormat format = new StringFormat();
                float y = (float)(((double)this.Height - (double)graphics.MeasureString(this._WaterMarkText, this.Font, this.Width, format).Height) / 2.0);
                RectangleF layoutRectangle = new RectangleF(0.0f, y, (float)this.Width, (float)this.Height - y * 2f);
                graphics.DrawString(this._WaterMarkText, this.Font, (Brush)new SolidBrush(this._WaterMarkColor), layoutRectangle, format);
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            this.ImeMode = ImeMode.Inherit;
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
