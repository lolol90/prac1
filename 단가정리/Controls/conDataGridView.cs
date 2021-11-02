// Decompiled with JetBrains decompiler
// Type: smartMain.Controls.conDataGridView
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using smartMain.CLS;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace smartMain.Controls
{
    [ToolboxBitmap(typeof(TextBox))]
    public class conDataGridView : DataGridView
    {
        private Color borderColor = Color.White;
        private string keyboardCmd = "0";
        private string dirKey = "R";
        private string keyInput = "";
        private int lastCol = -1;
        private int lastRow = -1;
        private ButtonBorderStyle _borderStyle = ButtonBorderStyle.Solid;
        private static int WM_PAINT = 15;
        private IContainer components = (IContainer)null;

        [Description("테두리 색을 지정하세요.")]
        [Browsable(true)]
        [Category("con 모양 설정")]
        public Color _BorderColor
        {
            get => this.borderColor;
            set => this.borderColor = value;
        }

        [Browsable(true)]
        [Category("con 모양 설정")]
        [Description("Row 추가 가능여부를 입력하세요. (0=불가, 1=가능)")]
        public string _KeyboardCmd
        {
            get => this.keyboardCmd;
            set => this.keyboardCmd = value;
        }

        [Description("입력된 방향키의 값이 저장됩니다.")]
        [Browsable(true)]
        [Category("con 모양 설정")]
        public string _DirKey
        {
            get => this.dirKey;
            set => this.dirKey = value;
        }

        [Description("입력된 키보드의 값이 저장됩니다.")]
        [Category("con 모양 설정")]
        [Browsable(true)]
        public string _KeyInput
        {
            get => this.keyInput;
            set => this.keyInput = value;
        }

        [Category("con 모양 설정")]
        [Browsable(true)]
        [Description("마지막 작업 셀의 column index 값 저장.")]
        public int _LastCol
        {
            get => this.lastCol;
            set => this.lastCol = value;
        }

        [Browsable(true)]
        [Description("마지막 작업 셀의 row index 값 저장.")]
        [Category("con 모양 설정")]
        public int _LastRow
        {
            get => this.lastRow;
            set => this.lastRow = value;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg != conDataGridView.WM_PAINT)
                return;
            Graphics graphics = Graphics.FromHwnd(this.Handle);
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            ControlPaint.DrawBorder(graphics, bounds, this.borderColor, this._borderStyle);
            graphics.Dispose();
            m.Result = IntPtr.Zero;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            try
            {

                if (this.Rows.Count == 0)
                    return false;

                int rowIndex1 = this.CurrentCell.RowIndex;
                int columnIndex1 = this.CurrentCell.ColumnIndex;
                int num1;
                switch (keyData)
                {
                    case Keys.Return:
                        this.dirKey = "";
                        this.keyInput = "enter";
                        int columnIndex2 = -1;
                        int rowIndex2 = -1;
                        int num2;
                        int num3;
                        if (columnIndex1 == this.Columns.Count - 1)
                        {
                            try
                            {
                                this.CurrentCell = this[0, rowIndex1 + 1];
                                num2 = 0;
                                num3 = rowIndex1 + 1;
                            }
                            catch
                            {
                                num2 = columnIndex1;
                                num3 = rowIndex1 + 1;
                            }
                        }
                        else
                        {
                            num2 = columnIndex1 + 1;
                            num3 = rowIndex1;
                        }
                        for (int index1 = num3; index1 < this.Rows.Count; ++index1)
                        {
                            if (this.Rows[index1].Visible)
                            {
                                for (int index2 = num2; index2 < this.Columns.Count; ++index2)
                                {
                                    if (!this.Columns[index2].ReadOnly && this.Columns[index2].Visible && !this.Rows[index1].Cells[index2].ReadOnly)
                                    {
                                        rowIndex2 = index1;
                                        columnIndex2 = index2;
                                        break;
                                    }
                                }
                                num2 = 0;
                                if (rowIndex2 != -1)
                                    break;
                            }
                        }
                        if (rowIndex2 != -1 && columnIndex2 != -1)
                            this.CurrentCell = this[columnIndex2, rowIndex2];
                        else
                            this.CurrentCell = this[columnIndex1, rowIndex1];
                        return true;
                    case Keys.Insert:
                        num1 = 0;
                        break;
                    default:
                        num1 = keyData != Keys.F12 ? 1 : 0;
                        break;
                }
                if (num1 == 0)
                {
                    if (this.keyboardCmd == "1")
                    {
                        string str = (string)this[1, rowIndex1].Value ?? "";
                        int num4 = this.CurrentCell.ColumnIndex;
                        int columnIndex3 = this.CurrentCell.ColumnIndex;
                        this.Sort(this.Columns[1], ListSortDirection.Ascending);
                        for (int rowIndex3 = 0; rowIndex3 < this.Rows.Count; ++rowIndex3)
                        {
                            if (((string)this[1, rowIndex3].Value ?? "") == str)
                            {
                                this.CurrentCell = this[columnIndex3, rowIndex3];
                                num4 = rowIndex3;
                                break;
                            }
                        }
                        this.Rows.Insert(num4, 1);
                        int columnIndex4 = -1;
                        for (int index = 0; index < this.Columns.Count; ++index)
                        {
                            if (!this.Columns[index].ReadOnly && this.Columns[index].Visible && !this.Rows[num4].Cells[index].ReadOnly)
                            {
                                columnIndex4 = index;
                                break;
                            }
                        }
                        this.CurrentCell = this[columnIndex4, num4];
                    }
                    return true;
                }
                if ((keyData & Keys.Control) == Keys.Control && (keyData & Keys.Delete) == Keys.Delete)
                    return true;
                switch (keyData)
                {
                    case Keys.Escape:
                        this.dirKey = "";
                        int columnIndex5 = -1;
                        for (int index = 0; index < this.Columns.Count - 1; ++index)
                        {
                            if (this.Columns[index].Visible)
                            {
                                columnIndex5 = index;
                                break;
                            }
                        }
                        if (columnIndex5 != -1)
                        {
                            this.CurrentCell = this[columnIndex5, 0];
                            SendKeys.Send("+{TAB}");
                        }
                        return true;
                    case Keys.F1:
                        if (this.keyboardCmd == "1")
                        {
                            if (!this.Columns[0].Visible)
                            {
                                this.Columns[0].Visible = true;
                            }
                            else
                            {
                                this.Columns[0].HeaderText = "[ ]";
                                this.Columns[0].Visible = false;
                                for (int index = 0; index < this.Rows.Count; ++index)
                                    this.Rows[index].Cells[0].Value = (object)false;
                                for (int index = 1; index < this.Columns.Count; ++index)
                                {
                                    if (!this.Columns[index].ReadOnly && this.Columns[index].Visible && !this.Rows[rowIndex1].Cells[index].ReadOnly)
                                    {
                                        this.CurrentCell = this[index, rowIndex1];
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                        break;
                    case Keys.F4:
                        if (this.keyboardCmd == "1")
                        {
                            this.keyInput = "f4";
                            this.CurrentCell.ReadOnly = true;
                        }
                        return true;
                    case Keys.F6:
                        if (this.keyboardCmd == "1")
                            this.keyInput = "f6";
                        return true;
                    case Keys.F7:
                        if (this.keyboardCmd == "1")
                            this.keyInput = "f7";
                        return true;
                    case Keys.F8:
                        if (this.keyboardCmd == "1")
                            this.keyInput = "f8";
                        return true;
                    case Keys.F11:
                        if (this.keyboardCmd == "1")
                            this.keyInput = "f11";
                        return true;
                }
            }
            catch
            {
            }
            return base.ProcessDialogKey(keyData);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (this.Rows.Count == 0)
                    return false;

                int rowIndex1 = this.CurrentCell.RowIndex;
                int columnIndex1 = this.CurrentCell.ColumnIndex;
                if (keyData == (Keys.Delete | Keys.Control) && this.keyboardCmd == "1" && this.Rows.Count > 1)
                {
                    if (this.Columns[0].Visible)
                    {
                        this.Columns[0].HeaderText = "[ ]";
                        for (int index = this.Rows.Count - 1; index >= 0; --index)
                        {
                            this.EndEdit(); //체크박스 체크 후 적용 안된 항목 처리
                            if ((bool)this.Rows[index].Cells[0].Value)
                                this.Rows.RemoveAt(index);
                        }
                    }
                    else
                        this.Rows.RemoveAt(rowIndex1);
                }
                if (keyData == Keys.Right)
                {
                    if (this.Columns[columnIndex1].GetType() == typeof(DataGridViewComboBoxColumn))
                    {
                        this.dirKey = "R";
                        SendKeys.Send("{TAB}");
                        return true;
                    }
                    this.dirKey = "R";
                }
                if (keyData == Keys.Left)
                {
                    if (this.Columns[columnIndex1].GetType() == typeof(DataGridViewComboBoxColumn))
                    {
                        this.dirKey = "L";
                        SendKeys.Send("+{TAB}");
                        return true;
                    }
                    this.dirKey = "L";
                }
                if (keyData == Keys.Down)
                {
                    if (this.Columns[columnIndex1].GetType() != typeof(DataGridViewComboBoxColumn) && this.keyboardCmd == "1")
                    {
                        int columnIndex2 = -1;
                        int rowIndex2 = -1;
                        int num = 0;
                        for (int index1 = rowIndex1 + 1; index1 < this.Rows.Count; ++index1)
                        {
                            if (this.Rows[index1].Visible)
                            {
                                for (int index2 = num; index2 < this.Columns.Count; ++index2)
                                {
                                    if (!this.Columns[index2].ReadOnly && this.Columns[index2].Visible && !this.Rows[index1].Cells[index2].ReadOnly)
                                    {
                                        rowIndex2 = index1;
                                        columnIndex2 = index2;
                                        break;
                                    }
                                }
                                num = 0;
                                if (rowIndex2 != -1)
                                    break;
                            }
                        }
                        if (rowIndex2 != -1 && columnIndex2 != -1)
                            this.CurrentCell = this[columnIndex2, rowIndex2];
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnEnter(EventArgs e)
        {
            try
            {
                bool flag = false;
                if (this.lastCol != -1 && this.lastRow != -1)
                {
                    try
                    {
                        this.CurrentCell = this[this.lastCol, this.lastRow];
                        this.BeginEdit(true);
                        flag = true;
                    }
                    catch
                    {
                        this.lastCol = -1;
                        this.lastRow = -1;
                    }
                }
                if (flag)
                    return;
                int num1 = 0;
                int num2 = 0;
                int columnIndex = -1;
                int rowIndex = -1;
                for (int index1 = num2; index1 < this.Rows.Count; ++index1)
                {
                    if (this.Rows[index1].Visible)
                    {
                        for (int index2 = num1; index2 < this.Columns.Count; ++index2)
                        {
                            if (!this.Columns[index2].ReadOnly && this.Columns[index2].Visible && !this.Rows[index1].Cells[index2].ReadOnly)
                            {
                                rowIndex = index1;
                                columnIndex = index2;
                                break;
                            }
                        }
                        num1 = 0;
                        if (rowIndex != -1)
                            break;
                    }
                }
                if (rowIndex != -1 && columnIndex != -1)
                {
                    this.CurrentCell = this[columnIndex, rowIndex];
                    this.BeginEdit(true);
                }
            }
            catch
            {
            }
        }

        protected override void OnCellEnter(DataGridViewCellEventArgs e)
        {
            int num1;
            int num2;
            int num3;
            if (this.Columns[e.ColumnIndex].ReadOnly || !this.Columns[e.ColumnIndex].Visible || this.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly)
            {
                if (this._DirKey == "R")
                {
                    bool flag = false;
                    num1 = 0;
                    num2 = 0;
                    int num4 = -1;
                    num3 = -1;
                    int num5 = e.ColumnIndex + 1;
                    int rowIndex = e.RowIndex;
                    for (int index = num5; index < this.Columns.Count; ++index)
                    {
                        if (!this.Columns[index].ReadOnly && this.Columns[index].Visible && !this.Rows[rowIndex].Cells[index].ReadOnly)
                        {
                            num4 = index;
                            break;
                        }
                    }
                    if (num4 != -1)
                        flag = true;
                    if (!flag)
                    {
                        this._DirKey = "";
                        SendKeys.Send("+{TAB}");
                    }
                    else
                        SendKeys.Send("{TAB}");
                }
                else
                {
                    if (!(this._DirKey == "L"))
                        return;
                    bool flag = false;
                    num1 = 0;
                    num2 = 0;
                    int num6 = -1;
                    num3 = -1;
                    int num7 = e.ColumnIndex - 1;
                    int rowIndex = e.RowIndex;
                    for (int index = num7; index >= 0; --index)
                    {
                        if (!this.Columns[index].ReadOnly && this.Columns[index].Visible && !this.Rows[rowIndex].Cells[index].ReadOnly)
                        {
                            num6 = index;
                            break;
                        }
                    }
                    if (num6 != -1)
                        flag = true;
                    if (!flag)
                    {
                        this._DirKey = "";
                        SendKeys.Send("{TAB}");
                    }
                    else
                        SendKeys.Send("+{TAB}");
                }
            }
            else
                this._DirKey = "";
        }

        protected override void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
        {
            this[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightCyan;
            this.keyInput = "";
            this.lastCol = e.ColumnIndex;
            this.lastRow = e.RowIndex;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        //private void InitializeComponent() => this.components = (IContainer)new Container();
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
    }
}
