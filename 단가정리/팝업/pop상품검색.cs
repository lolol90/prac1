// Decompiled with JetBrains decompiler
// Type: smartMain.팝업.pop상품검색
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using smartMain.CLS;
using smartMain.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace smartMain.팝업
{
    public class pop상품검색 : Form
    {
        public bool bDragging = false;
        public Point Offset;
        private string s납품분여부 = "N";
        private int iCnt;
        private string strValue;
        private bool bData = false;
        private wnGConstant wConst = new wnGConstant();
        private string sqlQuery = "";
        public string sRetCode = "";
        public string sRetName = "";
        public string sCustCode = "";
        public string sCustGubun = "";
        public string sUsedYN = "";
        private bool bSearch = false;
        private IContainer components = (IContainer)null;
        private Panel panBack;
        private Panel panel3;
        private Panel panel2;
        private Button butExit;
        private Label lblTitle;
        private Panel panHead;
        private Panel panList;
        private conComboBox cmb사용여부;
        private DataGridView GridRecord;
        private Button butSearch;
        private Timer tmFocus;
        public conTextBox nowTextSelect;
        private Timer tmClose;
        private Label label4;
        private Label label2;
        private conComboBox cmbS상품유형코드;

        public pop상품검색()
        {
            this.InitializeComponent();
            this.Width = this.panBack.Width;
            this.Height = this.panBack.Height;
        }

        private void pop상품검색_Load(object sender, EventArgs e)
        {
            this.panList.Dock = DockStyle.Fill;
            this.wConst.setCombo_공용코드(this.cmb사용여부, "C_상품여부", "ALL");
            this.cmb사용여부.SelectedValue = (object)this.sUsedYN;
            this.wConst.setCombo_업체용코드(this.cmbS상품유형코드, "P_상품유형", "");
            this.cmbS상품유형코드.SelectedIndex = 0;
            this.bindData(this.makeSearchCondition());
            if (this.sUsedYN != "2")
            {
                if (this.GridRecord.RowCount == 1)
                {
                    this.sRetCode = (string)this.GridRecord.Rows[0].Cells[0].Value ?? "";
                    this.sRetName = (string)this.GridRecord.Rows[0].Cells[2].Value ?? "";
                    this.Close();
                }
                if (this.GridRecord.RowCount == 0)
                {
                    this.bindData(this.makeSearchCondition2());
                    if (this.GridRecord.RowCount == 1)
                    {
                        this.sRetCode = (string)this.GridRecord.Rows[0].Cells[0].Value ?? "";
                        this.sRetName = (string)this.GridRecord.Rows[0].Cells[2].Value ?? "";
                        this.Close();
                    }
                }
            }
            this.tmFocus.Enabled = true;
        }

        private string makeSearchCondition()
        {
            StringBuilder stringBuilder = new StringBuilder();
            switch (this.nowTextSelect.Text)
            {
                case "":
                    this.s납품분여부 = "N";
                    stringBuilder.Append("");
                    break;
                default:
                    string str1 = this.nowTextSelect.Text.Substring(0, 1);
                    string str2 = this.nowTextSelect.Text;
                    this.s납품분여부 = "N";
                    if (str1 == "/" && this.sCustCode != "")
                    {
                        this.s납품분여부 = "Y";
                        str2 = str2.Substring(1, str2.Length - 1);
                    }
                    stringBuilder.Append(" and (a.상품명 like '%" + str2 + "%' ");
                    stringBuilder.Append("     or (a.초성명칭 like dbo.Parse_Han2('%" + str2 + "%') and a.초성명칭 like dbo.Parse_Han('%" + str2 + "%')) ");
                    stringBuilder.Append("     or a.박스바코드 = '" + str2 + "' ");
                    stringBuilder.Append("     or a.중간바코드 = '" + str2 + "' ");
                    stringBuilder.Append("     or a.낱개바코드 = '" + str2 + "' ");
                    stringBuilder.Append("     ) ");
                    break;
            }
            switch ((string)this.cmbS상품유형코드.SelectedValue ?? "")
            {
                case "":
                    stringBuilder.Append("");
                    break;
                default:
                    stringBuilder.Append(" and a.상품유형코드 = '" + (string)this.cmbS상품유형코드.SelectedValue + "' ");
                    break;
            }
            switch ((string)this.cmb사용여부.SelectedValue ?? "")
            {
                case "":
                    stringBuilder.Append("");
                    break;
                default:
                    stringBuilder.Append(" and a.사용여부 = '" + (string)this.cmb사용여부.SelectedValue + "' ");
                    break;
            }
            return stringBuilder.ToString();
        }

        private string makeSearchCondition2()
        {
            StringBuilder stringBuilder = new StringBuilder();
            switch (this.nowTextSelect.Text)
            {
                case "":
                    stringBuilder.Append("");
                    break;
                default:
                    stringBuilder.Append(" and a.상품코드 = '" + this.nowTextSelect.Text + "' ");
                    break;
            }
            switch ((string)this.cmb사용여부.SelectedValue ?? "")
            {
                case "":
                    stringBuilder.Append("");
                    break;
                default:
                    stringBuilder.Append(" and a.사용여부 = '" + (string)this.cmb사용여부.SelectedValue + "' ");
                    break;
            }
            return stringBuilder.ToString();
        }

        private void bindData(string condition)
        {
            this.GridRecord.DataSource = (object)null;
            this.GridRecord.RowCount = 0;
            try
            {
                DataTable dataTable = new wnDm().fn_상품_List_Popup(condition, this.s납품분여부, this.sCustGubun, this.sCustCode, true, Common.p_strConn);
                this.GridRecord.DataSource = (object)dataTable;
                this.GridRecord.Columns[0].Frozen = true;
                this.GridRecord.Columns[1].Frozen = true;
                this.GridRecord.Columns[2].Frozen = true;
                this.GridRecord.Columns[3].Frozen = true;
                this.GridRecord.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.GridRecord.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.GridRecord.Columns[2].Width = 200;
                this.GridRecord.Columns["납품납입분"].Visible = false;
                this.GridRecord.Columns["선택"].Visible = false;
                this.GridRecord.Columns["현재고"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.GridRecord.Columns["현재고"].DefaultCellStyle.Format = Common.p_strFormatAmount;
                this.GridRecord.Columns["정렬순서"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (Common.p_strEgg == "Y")
                {
                    if (Common.p_strBox == "1" || Common.p_strBox == "3")
                    {
                        this.GridRecord.Columns["알_입고단가"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        this.GridRecord.Columns["알_판매단가"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        this.GridRecord.Columns["알_중상입고단가"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        this.GridRecord.Columns["알_입고단가"].DefaultCellStyle.Format = Common.p_strFormatUnit;
                        this.GridRecord.Columns["알_판매단가"].DefaultCellStyle.Format = Common.p_strFormatUnit;
                        this.GridRecord.Columns["알_중상입고단가"].DefaultCellStyle.Format = Common.p_strFormatUnit;
                    }
                    if (Common.p_strBox == "2" || Common.p_strBox == "3")
                    {
                        this.GridRecord.Columns["입수수량"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        this.GridRecord.Columns["입수수량"].DefaultCellStyle.Format = Common.p_strFormatAmount;
                        this.GridRecord.Columns["판_입고단가"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        this.GridRecord.Columns["판_판매단가"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        this.GridRecord.Columns["판_중상입고단가"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        this.GridRecord.Columns["판_입고단가"].DefaultCellStyle.Format = Common.p_strFormatUnit;
                        this.GridRecord.Columns["판_판매단가"].DefaultCellStyle.Format = Common.p_strFormatUnit;
                        this.GridRecord.Columns["판_중상입고단가"].DefaultCellStyle.Format = Common.p_strFormatUnit;
                    }
                    if (Common.p_strBox == "1")
                    {
                        this.GridRecord.Columns["알_입고단가"].HeaderText = "입고단가";
                        this.GridRecord.Columns["알_판매단가"].HeaderText = "판매단가";
                        this.GridRecord.Columns["알_중상입고단가"].HeaderText = "중상입고단가";
                        this.GridRecord.Columns["알_바코드"].HeaderText = "바코드";
                    }
                    if (Common.p_strBox == "2")
                    {
                        this.GridRecord.Columns["판_입고단가"].HeaderText = "입고단가";
                        this.GridRecord.Columns["판_판매단가"].HeaderText = "판매단가";
                        this.GridRecord.Columns["판_중상입고단가"].HeaderText = "중상입고단가";
                        this.GridRecord.Columns["판_바코드"].HeaderText = "바코드";
                    }
                }
                else
                {
                    if (Common.p_strBox == "1" || Common.p_strBox == "3")
                    {
                        this.GridRecord.Columns["낱개입고단가"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        this.GridRecord.Columns["낱개판매단가"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        this.GridRecord.Columns["낱개중상입고단가"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        this.GridRecord.Columns["낱개입고단가"].DefaultCellStyle.Format = Common.p_strFormatUnit;
                        this.GridRecord.Columns["낱개판매단가"].DefaultCellStyle.Format = Common.p_strFormatUnit;
                        this.GridRecord.Columns["낱개중상입고단가"].DefaultCellStyle.Format = Common.p_strFormatUnit;
                    }
                    if (Common.p_strBox == "3")
                    {
                        this.GridRecord.Columns["중간입수수량"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        this.GridRecord.Columns["중간입수수량"].DefaultCellStyle.Format = Common.p_strFormatAmount;
                    }
                    if (Common.p_strBox == "2" || Common.p_strBox == "3")
                    {
                        this.GridRecord.Columns["입수수량"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        this.GridRecord.Columns["입수수량"].DefaultCellStyle.Format = Common.p_strFormatAmount;
                        this.GridRecord.Columns["박스입고단가"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        this.GridRecord.Columns["박스판매단가"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        this.GridRecord.Columns["박스중상입고단가"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        this.GridRecord.Columns["박스입고단가"].DefaultCellStyle.Format = Common.p_strFormatUnit;
                        this.GridRecord.Columns["박스판매단가"].DefaultCellStyle.Format = Common.p_strFormatUnit;
                        this.GridRecord.Columns["박스중상입고단가"].DefaultCellStyle.Format = Common.p_strFormatUnit;
                    }
                    if (Common.p_strBox == "1")
                    {
                        this.GridRecord.Columns["낱개입고단가"].HeaderText = "입고단가";
                        this.GridRecord.Columns["낱개판매단가"].HeaderText = "판매단가";
                        this.GridRecord.Columns["낱개중상입고단가"].HeaderText = "중상입고단가";
                        this.GridRecord.Columns["낱개바코드"].HeaderText = "바코드";
                    }
                    if (Common.p_strBox == "2")
                    {
                        this.GridRecord.Columns["박스입고단가"].HeaderText = "입고단가";
                        this.GridRecord.Columns["박스판매단가"].HeaderText = "판매단가";
                        this.GridRecord.Columns["박스중상입고단가"].HeaderText = "중상입고단가";
                        this.GridRecord.Columns["박스바코드"].HeaderText = "바코드";
                    }
                }
                this.GridRecord.Columns["사용여부"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (dataTable == null || dataTable.Rows.Count <= 0)
                    return;
                this.tmFocus.Enabled = true;
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            this.bSearch = true;
            this.bindData(this.makeSearchCondition());
            this.GridRecord.Focus();
        }

        private void butExit_Click(object sender, EventArgs e) => this.Close();

        private void tmFocus_Tick(object sender, EventArgs e)
        {
            this.tmFocus.Enabled = false;
            if (this.GridRecord.Rows.Count > 0)
            {
                if (this.nowTextSelect.Text == "")
                {
                    if (this.bSearch)
                        this.GridRecord.Focus();
                    else
                        this.nowTextSelect.Focus();
                }
                else
                    this.GridRecord.Focus();
            }
            else
                this.nowTextSelect.Focus();
        }

        private void GridRecord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                this.nowTextSelect.Focus();
            }
            if (e.KeyCode != Keys.Return && e.KeyCode != Keys.Return)
                return;
            e.Handled = true;
            if (this.GridRecord.RowCount == 0 || this.GridRecord.CurrentCell == null || this.GridRecord.CurrentCell.RowIndex < 0 || this.GridRecord.CurrentCell.ColumnIndex < 0)
                return;
            this.iCnt = this.GridRecord.CurrentCell.RowIndex;
            this.sRetCode = (string)this.GridRecord.Rows[this.iCnt].Cells[0].Value ?? "";
            this.sRetName = (string)this.GridRecord.Rows[this.iCnt].Cells[2].Value ?? "";
            this.Close();
        }

        private void GridRecord_DoubleClick(object sender, EventArgs e)
        {
            if (this.GridRecord.CurrentCell == null)
                return;
            this.iCnt = this.GridRecord.CurrentCell.RowIndex;
            this.sRetCode = (string)this.GridRecord.Rows[this.iCnt].Cells[0].Value ?? "";
            this.sRetName = (string)this.GridRecord.Rows[this.iCnt].Cells[2].Value ?? "";
            this.Close();
        }

        private void panHead_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.bDragging = true;
                this.Offset = new Point(e.X, e.Y);
            }
            this.BringToFront();
        }

        private void panHead_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.bDragging)
                return;
            this.Left = e.X + this.Left - this.Offset.X;
            this.Top = e.Y + this.Top - this.Offset.Y;
        }

        private void panHead_MouseUp(object sender, MouseEventArgs e) => this.bDragging = false;

        private void nowTextSelect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                this.butExit_Click((object)this, (EventArgs)null);
            }
            if (e.KeyCode != Keys.Return)
                return;
            e.Handled = true;
            this.butSearch_Click((object)this, (EventArgs)null);
        }

        private void tmClose_Tick(object sender, EventArgs e)
        {
        }

        private void GridRecord_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            //루프 수정
            if ((((string)dataGridView.Rows[e.RowIndex].Cells["사용여부"].Value ?? "") == "중지"))
            {
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.DarkRed;
            }
            else if (((string)dataGridView.Rows[e.RowIndex].Cells["사용여부"].Value ?? "") == "삭제")
            {
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Gray;
            }
            else if (double.Parse(dataGridView.Rows[e.RowIndex].Cells["현재고"].Value.ToString()) <= 0.0)
            {
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Red;
            }
            if (((string)dataGridView.Rows[e.RowIndex].Cells["납품납입분"].Value ?? "") != "")
            {
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.LightGreen;
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pop상품검색));
            this.panBack = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panList = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbS상품유형코드 = new smartMain.Controls.conComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb사용여부 = new smartMain.Controls.conComboBox();
            this.nowTextSelect = new smartMain.Controls.conTextBox();
            this.GridRecord = new System.Windows.Forms.DataGridView();
            this.butSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.butExit = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panHead = new System.Windows.Forms.Panel();
            this.tmFocus = new System.Windows.Forms.Timer(this.components);
            this.tmClose = new System.Windows.Forms.Timer(this.components);
            this.panBack.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridRecord)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBack
            // 
            this.panBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(214)))), ((int)(((byte)(249)))));
            this.panBack.Controls.Add(this.panel3);
            this.panBack.Location = new System.Drawing.Point(0, 0);
            this.panBack.Name = "panBack";
            this.panBack.Size = new System.Drawing.Size(1228, 630);
            this.panBack.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panList);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1222, 624);
            this.panel3.TabIndex = 1;
            // 
            // panList
            // 
            this.panList.Controls.Add(this.label2);
            this.panList.Controls.Add(this.cmbS상품유형코드);
            this.panList.Controls.Add(this.label4);
            this.panList.Controls.Add(this.cmb사용여부);
            this.panList.Controls.Add(this.nowTextSelect);
            this.panList.Controls.Add(this.GridRecord);
            this.panList.Controls.Add(this.butSearch);
            this.panList.Location = new System.Drawing.Point(0, 57);
            this.panList.Name = "panList";
            this.panList.Size = new System.Drawing.Size(1133, 456);
            this.panList.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(214)))), ((int)(((byte)(249)))));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(344, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 22);
            this.label2.TabIndex = 281;
            this.label2.Text = "상품유형";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbS상품유형코드
            // 
            this.cmbS상품유형코드._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmbS상품유형코드._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbS상품유형코드.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbS상품유형코드.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbS상품유형코드.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbS상품유형코드.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbS상품유형코드.FormattingEnabled = true;
            this.cmbS상품유형코드.Location = new System.Drawing.Point(432, 11);
            this.cmbS상품유형코드.Name = "cmbS상품유형코드";
            this.cmbS상품유형코드.Size = new System.Drawing.Size(122, 21);
            this.cmbS상품유형코드.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(1024, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 12);
            this.label4.TabIndex = 107;
            this.label4.Text = "* 초성 검색 가능";
            // 
            // cmb사용여부
            // 
            this.cmb사용여부._BorderColor = System.Drawing.Color.LightSkyBlue;
            this.cmb사용여부._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmb사용여부.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb사용여부.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb사용여부.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmb사용여부.FormattingEnabled = true;
            this.cmb사용여부.Location = new System.Drawing.Point(14, 11);
            this.cmb사용여부.Name = "cmb사용여부";
            this.cmb사용여부.Size = new System.Drawing.Size(77, 21);
            this.cmb사용여부.TabIndex = 0;
            // 
            // nowTextSelect
            // 
            this.nowTextSelect._AutoTab = true;
            this.nowTextSelect._BorderColor = System.Drawing.Color.LightSkyBlue;
            this.nowTextSelect._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nowTextSelect._WaterMarkColor = System.Drawing.Color.Gray;
            this.nowTextSelect._WaterMarkText = "";
            this.nowTextSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nowTextSelect.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nowTextSelect.Location = new System.Drawing.Point(97, 10);
            this.nowTextSelect.Name = "nowTextSelect";
            this.nowTextSelect.Size = new System.Drawing.Size(241, 22);
            this.nowTextSelect.TabIndex = 1;
            this.nowTextSelect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nowTextSelect_KeyDown);
            // 
            // GridRecord
            // 
            this.GridRecord.AllowUserToAddRows = false;
            this.GridRecord.AllowUserToDeleteRows = false;
            this.GridRecord.AllowUserToOrderColumns = true;
            this.GridRecord.AllowUserToResizeRows = false;
            this.GridRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridRecord.BackgroundColor = System.Drawing.Color.White;
            this.GridRecord.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(239)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(181)))), ((int)(((byte)(189)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridRecord.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridRecord.ColumnHeadersHeight = 30;
            this.GridRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridRecord.DefaultCellStyle = dataGridViewCellStyle2;
            this.GridRecord.EnableHeadersVisualStyles = false;
            this.GridRecord.GridColor = System.Drawing.Color.PowderBlue;
            this.GridRecord.Location = new System.Drawing.Point(14, 38);
            this.GridRecord.Name = "GridRecord";
            this.GridRecord.ReadOnly = true;
            this.GridRecord.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.GridRecord.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.GridRecord.RowTemplate.Height = 23;
            this.GridRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridRecord.Size = new System.Drawing.Size(1105, 415);
            this.GridRecord.TabIndex = 11;
            this.GridRecord.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridRecord_CellFormatting);
            this.GridRecord.DoubleClick += new System.EventHandler(this.GridRecord_DoubleClick);
            this.GridRecord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridRecord_KeyDown);
            // 
            // butSearch
            // 
            this.butSearch.BackColor = System.Drawing.Color.Transparent;
            this.butSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butSearch.FlatAppearance.BorderSize = 0;
            this.butSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.butSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            /*this.butSearch.Image = ((System.Drawing.Image)(resources.GetObject("butSearch.Image")));*/
            this.butSearch.Location = new System.Drawing.Point(560, 5);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(33, 33);
            this.butSearch.TabIndex = 10;
            this.butSearch.Tag = "검색";
            this.butSearch.UseVisualStyleBackColor = false;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(102)))), ((int)(((byte)(200)))));
            this.panel2.Controls.Add(this.butExit);
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Controls.Add(this.panHead);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1222, 56);
            this.panel2.TabIndex = 1;
            // 
            // butExit
            // 
            this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butExit.BackColor = System.Drawing.Color.Transparent;
            this.butExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(102)))), ((int)(((byte)(200)))));
            this.butExit.FlatAppearance.BorderSize = 0;
            this.butExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(62)))), ((int)(((byte)(138)))));
            this.butExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butExit.ForeColor = System.Drawing.Color.White;
            /*this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));*/
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.butExit.Location = new System.Drawing.Point(1154, 23);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(65, 29);
            this.butExit.TabIndex = 2;
            this.butExit.Tag = "종료";
            this.butExit.Text = "닫기";
            this.butExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.UseVisualStyleBackColor = false;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(10, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(110, 22);
            this.lblTitle.TabIndex = 95;
            this.lblTitle.Text = "상품 검색";
            // 
            // panHead
            // 
            this.panHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(102)))), ((int)(((byte)(200)))));
            this.panHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHead.Location = new System.Drawing.Point(0, 0);
            this.panHead.Name = "panHead";
            this.panHead.Size = new System.Drawing.Size(1222, 20);
            this.panHead.TabIndex = 1;
            this.panHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panHead_MouseDown);
            this.panHead.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panHead_MouseMove);
            this.panHead.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panHead_MouseUp);
            // 
            // tmFocus
            // 
            this.tmFocus.Tick += new System.EventHandler(this.tmFocus_Tick);
            // 
            // tmClose
            // 
            this.tmClose.Tick += new System.EventHandler(this.tmClose_Tick);
            // 
            // pop상품검색
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1240, 642);
            this.Controls.Add(this.panBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "pop상품검색";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "pop상품찾기";
            this.Load += new System.EventHandler(this.pop상품검색_Load);
            this.panBack.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panList.ResumeLayout(false);
            this.panList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridRecord)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
