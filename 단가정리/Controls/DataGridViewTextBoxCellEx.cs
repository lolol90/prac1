// Decompiled with JetBrains decompiler
// Type: smartMain.Controls.DataGridViewTextBoxCellEx
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace smartMain.Controls
{
    public class DataGridViewTextBoxCellEx : DataGridViewTextBoxCell, ISpannedCell
    {
        private int m_ColumnSpan = 1;
        private int m_RowSpan = 1;
        private DataGridViewTextBoxCellEx m_OwnerCell;

        public int ColumnSpan
        {
            get => this.m_ColumnSpan;
            set
            {
                if (this.DataGridView == null || this.m_OwnerCell != null)
                    return;
                if (value < 1 || this.ColumnIndex + value - 1 >= this.DataGridView.ColumnCount)
                    throw new ArgumentOutOfRangeException(nameof(value));
                if (this.m_ColumnSpan == value)
                    return;
                this.SetSpan(value, this.m_RowSpan);
            }
        }

        public int RowSpan
        {
            get => this.m_RowSpan;
            set
            {
                if (this.DataGridView == null || this.m_OwnerCell != null)
                    return;
                if (value < 1 || this.RowIndex + value - 1 >= this.DataGridView.RowCount)
                    throw new ArgumentOutOfRangeException(nameof(value));
                if (this.m_RowSpan == value)
                    return;
                this.SetSpan(this.m_ColumnSpan, value);
            }
        }

        public DataGridViewCell OwnerCell
        {
            get => (DataGridViewCell)this.m_OwnerCell;
            private set => this.m_OwnerCell = value as DataGridViewTextBoxCellEx;
        }

        public override bool ReadOnly
        {
            get => base.ReadOnly;
            set
            {
                base.ReadOnly = value;
                if (this.m_OwnerCell != null || this.m_ColumnSpan <= 1 && this.m_RowSpan <= 1 || this.DataGridView == null)
                    return;
                foreach (int columnIndex in Enumerable.Range(this.ColumnIndex, this.m_ColumnSpan))
                {
                    foreach (int rowIndex in Enumerable.Range(this.RowIndex, this.m_RowSpan))
                    {
                        if (columnIndex != this.ColumnIndex || rowIndex != this.RowIndex)
                            this.DataGridView[columnIndex, rowIndex].ReadOnly = value;
                    }
                }
            }
        }

        protected override void Paint(
          Graphics graphics,
          Rectangle clipBounds,
          Rectangle cellBounds,
          int rowIndex,
          DataGridViewElementStates cellState,
          object value,
          object formattedValue,
          string errorText,
          DataGridViewCellStyle cellStyle,
          DataGridViewAdvancedBorderStyle advancedBorderStyle,
          DataGridViewPaintParts paintParts)
        {
            if (this.m_OwnerCell != null && this.m_OwnerCell.DataGridView == null)
                this.m_OwnerCell = (DataGridViewTextBoxCellEx)null;
            if (this.DataGridView == null || this.m_OwnerCell == null && this.m_ColumnSpan == 1 && this.m_RowSpan == 1)
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            }
            else
            {
                DataGridViewTextBoxCellEx viewTextBoxCellEx1 = this;
                int columnIndex = this.ColumnIndex;
                int columnSpan = this.m_ColumnSpan;
                int rowSpan = this.m_RowSpan;
                if (this.m_OwnerCell != null)
                {
                    viewTextBoxCellEx1 = this.m_OwnerCell;
                    columnIndex = this.m_OwnerCell.ColumnIndex;
                    rowIndex = this.m_OwnerCell.RowIndex;
                    columnSpan = this.m_OwnerCell.ColumnSpan;
                    rowSpan = this.m_OwnerCell.RowSpan;
                    value = this.m_OwnerCell.GetValue(rowIndex);
                    errorText = this.m_OwnerCell.GetErrorText(rowIndex);
                    cellState = this.m_OwnerCell.State;
                    cellStyle = this.m_OwnerCell.GetInheritedStyle((DataGridViewCellStyle)null, rowIndex, true);
                    formattedValue = this.m_OwnerCell.GetFormattedValue(value, rowIndex, ref cellStyle, (TypeConverter)null, (TypeConverter)null, DataGridViewDataErrorContexts.Display);
                }
                if (this.CellsRegionContainsSelectedCell(columnIndex, rowIndex, columnSpan, rowSpan))
                    cellState |= DataGridViewElementStates.Selected;
                Rectangle fromChildCellBounds = DataGridViewCellExHelper.GetSpannedCellBoundsFromChildCellBounds<DataGridViewTextBoxCellEx>(this, cellBounds, this.DataGridView.SingleVerticalBorderAdded(), this.DataGridView.SingleHorizontalBorderAdded());
                clipBounds = DataGridViewCellExHelper.GetSpannedCellClipBounds<DataGridViewTextBoxCellEx>(viewTextBoxCellEx1, fromChildCellBounds, this.DataGridView.SingleVerticalBorderAdded(), this.DataGridView.SingleHorizontalBorderAdded());
                using (Graphics graphics1 = this.DataGridView.CreateGraphics())
                {
                    graphics1.SetClip(clipBounds);
                    advancedBorderStyle = DataGridViewCellExHelper.AdjustCellBorderStyle<DataGridViewTextBoxCellEx>(viewTextBoxCellEx1);
                    viewTextBoxCellEx1.NativePaint(graphics1, clipBounds, fromChildCellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts & ~DataGridViewPaintParts.Border);
                    if ((paintParts & DataGridViewPaintParts.Border) != DataGridViewPaintParts.None)
                    {
                        DataGridViewTextBoxCellEx viewTextBoxCellEx2 = viewTextBoxCellEx1;
                        DataGridViewAdvancedBorderStyle advancedBorderStyle1 = new DataGridViewAdvancedBorderStyle()
                        {
                            Left = advancedBorderStyle.Left,
                            Top = advancedBorderStyle.Top,
                            Right = DataGridViewAdvancedCellBorderStyle.None,
                            Bottom = DataGridViewAdvancedCellBorderStyle.None
                        };
                        viewTextBoxCellEx2.PaintBorder(graphics1, clipBounds, fromChildCellBounds, cellStyle, advancedBorderStyle1);
                        if (!(this.DataGridView[columnIndex + columnSpan - 1, rowIndex + rowSpan - 1] is DataGridViewTextBoxCellEx viewTextBoxCellEx10))
                            viewTextBoxCellEx10 = this;
                        DataGridViewTextBoxCellEx viewTextBoxCellEx4 = viewTextBoxCellEx10;
                        DataGridViewAdvancedBorderStyle advancedBorderStyle2 = new DataGridViewAdvancedBorderStyle()
                        {
                            Left = DataGridViewAdvancedCellBorderStyle.None,
                            Top = DataGridViewAdvancedCellBorderStyle.None,
                            Right = advancedBorderStyle.Right,
                            Bottom = advancedBorderStyle.Bottom
                        };
                        viewTextBoxCellEx4.PaintBorder(graphics1, clipBounds, fromChildCellBounds, cellStyle, advancedBorderStyle2);
                    }
                }
            }
        }

        private void NativePaint(
          Graphics graphics,
          Rectangle clipBounds,
          Rectangle cellBounds,
          int rowIndex,
          DataGridViewElementStates cellState,
          object value,
          object formattedValue,
          string errorText,
          DataGridViewCellStyle cellStyle,
          DataGridViewAdvancedBorderStyle advancedBorderStyle,
          DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }

        private void SetSpan(int columnSpan, int rowSpan)
        {
            int columnSpan1 = this.m_ColumnSpan;
            int rowSpan1 = this.m_RowSpan;
            this.m_ColumnSpan = columnSpan;
            this.m_RowSpan = rowSpan;
            if (this.DataGridView == null)
                return;
            foreach (int rowIndex in Enumerable.Range(this.RowIndex, rowSpan1))
            {
                foreach (int columnIndex in Enumerable.Range(this.ColumnIndex, columnSpan1))
                {
                    if (this.DataGridView[columnIndex, rowIndex] is DataGridViewTextBoxCellEx viewTextBoxCellEx2)
                        viewTextBoxCellEx2.OwnerCell = (DataGridViewCell)null;
                }
            }
            foreach (int rowIndex in Enumerable.Range(this.RowIndex, this.m_RowSpan))
            {
                foreach (int columnIndex in Enumerable.Range(this.ColumnIndex, this.m_ColumnSpan))
                {
                    if (this.DataGridView[columnIndex, rowIndex] is DataGridViewTextBoxCellEx viewTextBoxCellEx5 && viewTextBoxCellEx5 != this)
                    {
                        if (viewTextBoxCellEx5.ColumnSpan > 1)
                            viewTextBoxCellEx5.ColumnSpan = 1;
                        if (viewTextBoxCellEx5.RowSpan > 1)
                            viewTextBoxCellEx5.RowSpan = 1;
                        viewTextBoxCellEx5.OwnerCell = (DataGridViewCell)this;
                    }
                }
            }
            this.OwnerCell = (DataGridViewCell)null;
            this.DataGridView.Invalidate();
        }

        public override Rectangle PositionEditingPanel(
          Rectangle cellBounds,
          Rectangle cellClip,
          DataGridViewCellStyle cellStyle,
          bool singleVerticalBorderAdded,
          bool singleHorizontalBorderAdded,
          bool isFirstDisplayedColumn,
          bool isFirstDisplayedRow)
        {
            if (this.m_OwnerCell == null && this.m_ColumnSpan == 1 && this.m_RowSpan == 1)
                return base.PositionEditingPanel(cellBounds, cellClip, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, isFirstDisplayedColumn, isFirstDisplayedRow);
            DataGridViewTextBoxCellEx viewTextBoxCellEx = this;
            if (this.m_OwnerCell != null)
            {
                int rowIndex = this.m_OwnerCell.RowIndex;
                cellStyle = this.m_OwnerCell.GetInheritedStyle((DataGridViewCellStyle)null, rowIndex, true);
                this.m_OwnerCell.GetFormattedValue(this.m_OwnerCell.Value, rowIndex, ref cellStyle, (TypeConverter)null, (TypeConverter)null, DataGridViewDataErrorContexts.Formatting);
                if (this.DataGridView.EditingControl is IDataGridViewEditingControl editingControl2)
                {
                    editingControl2.ApplyCellStyleToEditingControl(cellStyle);
                    Control parent = this.DataGridView.EditingControl.Parent;
                    if (parent != null)
                        parent.BackColor = cellStyle.BackColor;
                }
                viewTextBoxCellEx = this.m_OwnerCell;
            }
            cellBounds = DataGridViewCellExHelper.GetSpannedCellBoundsFromChildCellBounds<DataGridViewTextBoxCellEx>(this, cellBounds, singleVerticalBorderAdded, singleHorizontalBorderAdded);
            cellClip = DataGridViewCellExHelper.GetSpannedCellClipBounds<DataGridViewTextBoxCellEx>(viewTextBoxCellEx, cellBounds, singleVerticalBorderAdded, singleHorizontalBorderAdded);
            return base.PositionEditingPanel(cellBounds, cellClip, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, viewTextBoxCellEx.InFirstDisplayedColumn<DataGridViewTextBoxCellEx>(), viewTextBoxCellEx.InFirstDisplayedRow<DataGridViewTextBoxCellEx>());
        }

        protected override object GetValue(int rowIndex) => this.m_OwnerCell != null ? this.m_OwnerCell.GetValue(this.m_OwnerCell.RowIndex) : base.GetValue(rowIndex);

        protected override bool SetValue(int rowIndex, object value) => this.m_OwnerCell != null ? this.m_OwnerCell.SetValue(this.m_OwnerCell.RowIndex, value) : base.SetValue(rowIndex, value);

        protected override void OnDataGridViewChanged()
        {
            base.OnDataGridViewChanged();
            if (this.DataGridView != null)
                return;
            this.m_ColumnSpan = 1;
            this.m_RowSpan = 1;
        }

        protected override Rectangle BorderWidths(
          DataGridViewAdvancedBorderStyle advancedBorderStyle)
        {
            if (this.m_OwnerCell == null && this.m_ColumnSpan == 1 && this.m_RowSpan == 1)
                return base.BorderWidths(advancedBorderStyle);
            if (this.m_OwnerCell != null)
                return this.m_OwnerCell.BorderWidths(advancedBorderStyle);
            Rectangle rectangle1 = base.BorderWidths(advancedBorderStyle);
            Rectangle rectangle2 = this.DataGridView[this.ColumnIndex + this.ColumnSpan - 1, this.RowIndex + this.RowSpan - 1] is DataGridViewTextBoxCellEx viewTextBoxCellEx ? viewTextBoxCellEx.NativeBorderWidths(advancedBorderStyle) : rectangle1;
            return new Rectangle(rectangle1.X, rectangle1.Y, rectangle2.Width, rectangle2.Height);
        }

        private Rectangle NativeBorderWidths(
          DataGridViewAdvancedBorderStyle advancedBorderStyle)
        {
            return base.BorderWidths(advancedBorderStyle);
        }

        protected override Size GetPreferredSize(
          Graphics graphics,
          DataGridViewCellStyle cellStyle,
          int rowIndex,
          Size constraintSize)
        {
            if (this.OwnerCell != null)
                return new Size(0, 0);
            Size preferredSize = base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
            DataGridView grid = this.DataGridView;
            return new Size(preferredSize.Width - Enumerable.Range(this.ColumnIndex + 1, this.ColumnSpan - 1).Select<int, int>((Func<int, int>)(index => grid.Columns[index].Width)).Sum(), preferredSize.Height - Enumerable.Range(this.RowIndex + 1, this.RowSpan - 1).Select<int, int>((Func<int, int>)(index => grid.Rows[index].Height)).Sum());
        }

        private bool CellsRegionContainsSelectedCell(
          int columnIndex,
          int rowIndex,
          int columnSpan,
          int rowSpan)
        {
            return this.DataGridView != null && Enumerable.Range(columnIndex, columnSpan).SelectMany((Func<int, IEnumerable<int>>)(col => Enumerable.Range(rowIndex, rowSpan)), (col, row) =>
           {
               var data = new { col = col, row = row };
               return data;
           }).Where(_param1 => this.DataGridView[_param1.col, _param1.row].Selected).Select(_param0 => _param0.col).Any<int>();
        }
    }
}
