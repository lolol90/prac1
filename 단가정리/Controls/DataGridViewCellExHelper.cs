// Decompiled with JetBrains decompiler
// Type: smartMain.Controls.DataGridViewCellExHelper
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace smartMain.Controls
{
    internal static class DataGridViewCellExHelper
    {
        public static Rectangle GetSpannedCellClipBounds<TCell>(
          TCell ownerCell,
          Rectangle cellBounds,
          bool singleVerticalBorderAdded,
          bool singleHorizontalBorderAdded)
          where TCell : DataGridViewCell, ISpannedCell
        {
            DataGridView dataGridView = ownerCell.DataGridView;
            Rectangle rectangle = cellBounds;
            foreach (int index in Enumerable.Range(ownerCell.ColumnIndex, ownerCell.ColumnSpan))
            {
                DataGridViewColumn column = dataGridView.Columns[index];
                if (column.Visible)
                {
                    if (!column.Frozen && index <= dataGridView.FirstDisplayedScrollingColumnIndex)
                    {
                        if (index == dataGridView.FirstDisplayedScrollingColumnIndex)
                        {
                            rectangle.Width -= dataGridView.FirstDisplayedScrollingColumnHiddenWidth;
                            if (dataGridView.RightToLeft != RightToLeft.Yes)
                            {
                                rectangle.X += dataGridView.FirstDisplayedScrollingColumnHiddenWidth;
                                break;
                            }
                            break;
                        }
                        rectangle.Width -= column.Width;
                        if (dataGridView.RightToLeft != RightToLeft.Yes)
                            rectangle.X += column.Width;
                    }
                    else
                        break;
                }
            }
            foreach (int index in Enumerable.Range(ownerCell.RowIndex, ownerCell.RowSpan))
            {
                DataGridViewRow row = dataGridView.Rows[index];
                if (row.Visible)
                {
                    if (!row.Frozen && index < dataGridView.FirstDisplayedScrollingRowIndex)
                    {
                        rectangle.Y += row.Height;
                        rectangle.Height -= row.Height;
                    }
                    else
                        break;
                }
            }
            if (dataGridView.BorderStyle != BorderStyle.None)
            {
                Rectangle clientRectangle = dataGridView.ClientRectangle;
                --clientRectangle.Width;
                --clientRectangle.Height;
                if (dataGridView.RightToLeft == RightToLeft.Yes)
                {
                    ++clientRectangle.X;
                    ++clientRectangle.Y;
                }
                rectangle.Intersect(clientRectangle);
            }
            return rectangle;
        }

        public static Rectangle GetSpannedCellBoundsFromChildCellBounds<TCell>(
          TCell childCell,
          Rectangle childCellBounds,
          bool singleVerticalBorderAdded,
          bool singleHorizontalBorderAdded)
          where TCell : DataGridViewCell, ISpannedCell
        {
            DataGridView dataGridView = childCell.DataGridView;
            if (!(childCell.OwnerCell is TCell cell1))
                cell1 = childCell;
            TCell cell2 = cell1;
            Rectangle rectangle = childCellBounds;
            int num1 = Enumerable.Range(cell2.ColumnIndex, cell2.ColumnSpan).First<int>((Func<int, bool>)(i => dataGridView.Columns[i].Visible));
            if (dataGridView.Columns[num1].Frozen)
            {
                rectangle.X = dataGridView.GetColumnDisplayRectangle(num1, false).X;
            }
            else
            {
                int num2 = Enumerable.Range(num1, childCell.ColumnIndex - num1).Select<int, DataGridViewColumn>((Func<int, DataGridViewColumn>)(i => dataGridView.Columns[i])).Where<DataGridViewColumn>((Func<DataGridViewColumn, bool>)(columnItem => columnItem.Visible)).Sum<DataGridViewColumn>((Func<DataGridViewColumn, int>)(columnItem => columnItem.Width));
                rectangle.X = dataGridView.RightToLeft == RightToLeft.Yes ? rectangle.X + num2 : rectangle.X - num2;
            }
            int num3 = Enumerable.Range(cell2.RowIndex, cell2.RowSpan).First<int>((Func<int, bool>)(i => dataGridView.Rows[i].Visible));
            if (dataGridView.Rows[num3].Frozen)
                rectangle.Y = dataGridView.GetRowDisplayRectangle(num3, false).Y;
            else
                rectangle.Y -= Enumerable.Range(num3, childCell.RowIndex - num3).Select<int, DataGridViewRow>((Func<int, DataGridViewRow>)(i => dataGridView.Rows[i])).Where<DataGridViewRow>((Func<DataGridViewRow, bool>)(rowItem => rowItem.Visible)).Sum<DataGridViewRow>((Func<DataGridViewRow, int>)(rowItem => rowItem.Height));
            int num4 = Enumerable.Range(cell2.ColumnIndex, cell2.ColumnSpan).Select<int, DataGridViewColumn>((Func<int, DataGridViewColumn>)(columnIndex => dataGridView.Columns[columnIndex])).Where<DataGridViewColumn>((Func<DataGridViewColumn, bool>)(column => column.Visible)).Sum<DataGridViewColumn>((Func<DataGridViewColumn, int>)(column => column.Width));
            if (dataGridView.RightToLeft == RightToLeft.Yes)
                rectangle.X = rectangle.Right - num4;
            rectangle.Width = num4;
            rectangle.Height = Enumerable.Range(cell2.RowIndex, cell2.RowSpan).Select<int, DataGridViewRow>((Func<int, DataGridViewRow>)(rowIndex => dataGridView.Rows[rowIndex])).Where<DataGridViewRow>((Func<DataGridViewRow, bool>)(row => row.Visible)).Sum<DataGridViewRow>((Func<DataGridViewRow, int>)(row => row.Height));
            if (singleVerticalBorderAdded && cell2.InFirstDisplayedColumn<TCell>())
            {
                ++rectangle.Width;
                if (dataGridView.RightToLeft != RightToLeft.Yes)
                {
                    if (childCell.ColumnIndex != dataGridView.FirstDisplayedScrollingColumnIndex)
                        --rectangle.X;
                }
                else if (childCell.ColumnIndex == dataGridView.FirstDisplayedScrollingColumnIndex)
                    --rectangle.X;
            }
            if (singleHorizontalBorderAdded && cell2.InFirstDisplayedRow<TCell>())
            {
                ++rectangle.Height;
                if (childCell.RowIndex != dataGridView.FirstDisplayedScrollingRowIndex)
                    --rectangle.Y;
            }
            return rectangle;
        }

        public static DataGridViewAdvancedBorderStyle AdjustCellBorderStyle<TCell>(
          TCell cell)
          where TCell : DataGridViewCell, ISpannedCell
        {
            DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStylePlaceholder = new DataGridViewAdvancedBorderStyle();
            DataGridView dataGridView = cell.DataGridView;
            return cell.AdjustCellBorderStyle(dataGridView.AdvancedCellBorderStyle, dataGridViewAdvancedBorderStylePlaceholder, dataGridView.SingleVerticalBorderAdded(), dataGridView.SingleHorizontalBorderAdded(), cell.InFirstDisplayedColumn<TCell>(), cell.InFirstDisplayedRow<TCell>());
        }

        public static bool InFirstDisplayedColumn<TCell>(this TCell cell) where TCell : DataGridViewCell, ISpannedCell
        {
            DataGridView dataGridView = cell.DataGridView;
            return dataGridView.FirstDisplayedScrollingColumnIndex >= cell.ColumnIndex && dataGridView.FirstDisplayedScrollingColumnIndex < cell.ColumnIndex + cell.ColumnSpan;
        }

        public static bool InFirstDisplayedRow<TCell>(this TCell cell) where TCell : DataGridViewCell, ISpannedCell
        {
            DataGridView dataGridView = cell.DataGridView;
            return dataGridView.FirstDisplayedScrollingRowIndex >= cell.RowIndex && dataGridView.FirstDisplayedScrollingRowIndex < cell.RowIndex + cell.RowSpan;
        }
    }
}
