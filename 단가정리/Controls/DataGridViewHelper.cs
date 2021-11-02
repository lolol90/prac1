// Decompiled with JetBrains decompiler
// Type: smartMain.Controls.DataGridViewHelper
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using System.Windows.Forms;

namespace smartMain.Controls
{
    internal static class DataGridViewHelper
    {
        public static bool SingleHorizontalBorderAdded(this DataGridView dataGridView) => !dataGridView.ColumnHeadersVisible && (dataGridView.AdvancedCellBorderStyle.All == DataGridViewAdvancedCellBorderStyle.Single || dataGridView.CellBorderStyle == DataGridViewCellBorderStyle.SingleHorizontal);

        public static bool SingleVerticalBorderAdded(this DataGridView dataGridView) => !dataGridView.RowHeadersVisible && (dataGridView.AdvancedCellBorderStyle.All == DataGridViewAdvancedCellBorderStyle.Single || dataGridView.CellBorderStyle == DataGridViewCellBorderStyle.SingleVertical);
    }
}
