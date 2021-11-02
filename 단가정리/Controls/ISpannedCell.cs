// Decompiled with JetBrains decompiler
// Type: smartMain.Controls.ISpannedCell
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using System.Windows.Forms;

namespace smartMain.Controls
{
    internal interface ISpannedCell
    {
        int ColumnSpan { get; }

        int RowSpan { get; }

        DataGridViewCell OwnerCell { get; }
    }
}
