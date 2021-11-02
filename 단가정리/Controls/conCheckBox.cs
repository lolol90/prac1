// Decompiled with JetBrains decompiler
// Type: smartMain.Controls.conCheckBox
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using System.Drawing;
using System.Windows.Forms;

namespace smartMain.Controls
{
    [ToolboxBitmap(typeof(ComboBox))]
    public class conCheckBox : CheckBox
    {
        private void conComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
            SendKeys.SendWait("{tab}");
        }

        public conCheckBox() => this.KeyDown += new KeyEventHandler(this.conComboBox_KeyDown);
    }
}
