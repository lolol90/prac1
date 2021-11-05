// Decompiled with JetBrains decompiler
// Type: smartMain.팝업.pop거래처검색
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using smartMain.CLS;
using smartMain.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace smartMain.팝업
{
    public class pop거래처검색 : Form
    {
        public bool bDragging = false;
        public Point Offset;
        private int iCnt;
        private string strValue;
        private bool bData = false;
        private wnGConstant wConst = new wnGConstant();
        private string sqlQuery = "";
        public string sRetCode = "";
        public string sRetName = "";
        public string sInOut = "";
        public string aAllFlg = "N";
        public string sUsedYN = "";
        public bool b사입처 = false;
        public string s계산서여부 = "";
        public string s중상여부 = "";
        private bool bSearch = false;
        private IContainer components = (IContainer)null;
        private Panel panBack;
        private Panel panel3;
        private Panel panel2;
        private Button butExit;
        private Label lblTitle;
        private Panel panHead;
        private Timer tmFocus;
        private Panel panList;
        private DataGridView GridRecord;
        private Button butSearch;
        public conTextBox nowTextSelect;
        public conComboBox cmb거래처구분;
        private Timer tmClose;
        private Label label2;
        public conTextBox txt대표자명;
        private Label label1;
        private Label label15;
        public conTextBox txt거래처담당자;
        private Label label3;
        private conComboBox cmb사용여부;
        private Label label4;
        private Label label5;

        public pop거래처검색()
        {
            this.InitializeComponent();
            this.Width = this.panBack.Width;
            this.Height = this.panBack.Height;
        }

        private void pop거래처검색_Load(object sender, EventArgs e)
        {
            this.panList.Dock = DockStyle.Fill;
            this.wConst.setCombo_공용코드(this.cmb거래처구분, "C_거래처구분", "ALL");
            this.wConst.setCombo_공용코드(this.cmb사용여부, "C_거래처여부", "ALL");
            if (this.sInOut == "")
                this.cmb거래처구분.Enabled = true;
            this.cmb거래처구분.SelectedValue = (object)this.sInOut;
            this.cmb사용여부.SelectedValue = (object)this.sUsedYN;
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
            if (this.b사입처)
                stringBuilder.Append(" and a.거래처코드 in (select 주매입처코드 from T_상품정보 where 사업자번호 = '" + Common.p_strCompID + "' and 지점코드 = '" + Common.p_strSpotCode + "' and 사입품 = 'Y') ");
            if (this.s중상여부 == "중상만")
                stringBuilder.Append(" and isnull(a.중상여부, '0') = '1' ");
            if (this.s중상여부 == "중상제외")
                stringBuilder.Append(" and isnull(a.중상여부, '0') = '0' ");
            if (this.s계산서여부 == "Y")
                stringBuilder.Append(" and a.계산서여부 = 'Y' ");
            switch ((string)this.cmb거래처구분.SelectedValue ?? "")
            {
                case "1":
                    stringBuilder.Append(" and a.거래처구분 = '1' ");
                    break;
                case "2":
                    stringBuilder.Append(" and a.거래처구분 = '2' ");
                    break;
                case "3":
                    stringBuilder.Append(" and a.거래처구분 = '3' ");
                    break;
                case "4":
                    stringBuilder.Append(" and (a.거래처구분 = '1' or a.거래처구분 = '3') ");
                    break;
                case "5":
                    stringBuilder.Append(" and (a.거래처구분 = '2' or a.거래처구분 = '3') ");
                    break;
                default:
                    stringBuilder.Append("");
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
            switch (this.nowTextSelect.Text)
            {
                case "":
                    stringBuilder.Append("");
                    break;
                default:
                    stringBuilder.Append(" and (a.거래처명 like '%" + this.nowTextSelect.Text + "%' ");
                    stringBuilder.Append("     or (a.거래처명 like dbo.Parse_Han2('%" + this.nowTextSelect.Text + "%') and a.초성명칭 like dbo.Parse_Han('%" + this.nowTextSelect.Text + "%')) ");
                    stringBuilder.Append("     or a.대표자명 like '" + this.nowTextSelect.Text + "%' ");
                    stringBuilder.Append("     or a.거래처담당자 like '" + this.nowTextSelect.Text + "%' ");
                    stringBuilder.Append("     or a.거래처사업자번호 like '" + this.nowTextSelect.Text + "%' ");
                    stringBuilder.Append("     or a.Old_Code like '" + this.nowTextSelect.Text + "%' ");
                    stringBuilder.Append("     or a.정식명칭 like '%" + this.nowTextSelect.Text + "%' ) ");
                    break;
            }
            switch (this.txt대표자명.Text)
            {
                case "":
                    stringBuilder.Append("");
                    break;
                default:
                    stringBuilder.Append(" and a.대표자명 like '%" + this.txt대표자명.Text + "%' ");
                    break;
            }
            switch (this.txt거래처담당자.Text)
            {
                case "":
                    stringBuilder.Append("");
                    break;
                default:
                    stringBuilder.Append(" and a.거래처담당자 like '%" + this.txt거래처담당자.Text + "%' ");
                    break;
            }
            return stringBuilder.ToString();
        }

        private string makeSearchCondition2()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (this.b사입처)
                stringBuilder.Append(" and a.거래처코드 in (select 주매입처코드 from T_상품정보 where 사업자번호 = '" + Common.p_strCompID + "' and 지점코드 = '" + Common.p_strSpotCode + "' and 사입품 = 'Y') ");
            if (this.s중상여부 == "중상만")
                stringBuilder.Append(" and isnull(a.중상여부, '0') = '1' ");
            if (this.s중상여부 == "중상제외")
                stringBuilder.Append(" and isnull(a.중상여부, '0') = '0' ");
            if (this.s계산서여부 == "Y")
                stringBuilder.Append(" and a.계산서여부 = 'Y' ");
            switch ((string)this.cmb거래처구분.SelectedValue ?? "")
            {
                case "1":
                    stringBuilder.Append(" and a.거래처구분 = '1' ");
                    break;
                case "2":
                    stringBuilder.Append(" and a.거래처구분 = '2' ");
                    break;
                case "3":
                    stringBuilder.Append(" and a.거래처구분 = '3' ");
                    break;
                case "4":
                    stringBuilder.Append(" and (a.거래처구분 = '1' or a.거래처구분 = '3') ");
                    break;
                case "5":
                    stringBuilder.Append(" and (a.거래처구분 = '2' or a.거래처구분 = '3') ");
                    break;
                default:
                    stringBuilder.Append("");
                    break;
            }
            switch (this.nowTextSelect.Text)
            {
                case "":
                    stringBuilder.Append("");
                    break;
                default:
                    stringBuilder.Append(" and a.거래처코드 = '" + this.nowTextSelect.Text + "' ");
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
                this.GridRecord.DataSource = (object)new wnDm().fn_거래처_List_팝업(condition, this.aAllFlg, Common.p_strConn);
                this.GridRecord.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
                this.GridRecord.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;
                this.GridRecord.Columns[0].Frozen = true;
                this.GridRecord.Columns[1].Frozen = true;
                this.GridRecord.Columns[2].Frozen = true;
                this.GridRecord.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.GridRecord.Columns[0].Width = 80;
                this.GridRecord.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.GridRecord.Columns[1].Width = 80;
                this.GridRecord.Columns[2].Width = 200;
                this.GridRecord.Columns["정식명칭"].Width = 150;
                this.GridRecord.Columns["거래처구분"].Width = 80;
                this.GridRecord.Columns["거래처구분"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.GridRecord.Columns["담당자"].Width = 70;
                this.GridRecord.Columns["대표자명"].Width = 100;
                this.GridRecord.Columns["사업자번호"].Width = 120;
                this.GridRecord.Columns["사업자번호"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.GridRecord.Columns["거래개시일"].Width = 100;
                this.GridRecord.Columns["거래개시일"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.GridRecord.Columns["담당사원"].Width = 70;
                this.GridRecord.Columns["담당사원"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.GridRecord.Columns["우편번호"].Width = 70;
                this.GridRecord.Columns["우편번호"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.GridRecord.Columns["주소"].Width = 300;
                this.GridRecord.Columns["상세주소"].Width = 300;
                this.GridRecord.Columns["적용단가"].Width = 100;
                this.GridRecord.Columns["적용단가"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.GridRecord.Columns["부가세구분"].Width = 80;
                this.GridRecord.Columns["부가세구분"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.GridRecord.Columns["계산서여부"].Width = 80;
                this.GridRecord.Columns["계산서여부"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.GridRecord.Columns["발행율"].Width = 60;
                this.GridRecord.Columns["발행율"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.GridRecord.Columns["발행율"].DefaultCellStyle.Format = "#,0";
                this.GridRecord.Columns["계좌정보"].Width = 200;
                this.GridRecord.Columns["여신"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.GridRecord.Columns["여신"].DefaultCellStyle.Format = "#,0";
                this.GridRecord.Columns["사용여부"].Width = 70;
                this.GridRecord.Columns["사용여부"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            if (this.nowTextSelect.Text.Trim() == "" && int.Parse(Common.p_PageSize) > 0)
            {
                int num = (int)MessageBox.Show("검색어를 입력하세요.");
                this.nowTextSelect.Focus();
            }
            else
            {
                this.bSearch = true;
                this.bindData(this.makeSearchCondition());
                this.tmFocus.Enabled = true;
            }
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

        private void cmb거래처구분_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape)
                return;
            e.Handled = true;
            this.butExit_Click((object)this, (EventArgs)null);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pop거래처검색));
            this.panBack = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panList = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt거래처담당자 = new smartMain.Controls.conTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt대표자명 = new smartMain.Controls.conTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmb사용여부 = new smartMain.Controls.conComboBox();
            this.nowTextSelect = new smartMain.Controls.conTextBox();
            this.cmb거래처구분 = new smartMain.Controls.conComboBox();
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
            this.panBack.Size = new System.Drawing.Size(1233, 615);
            this.panBack.TabIndex = 3;
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
            this.panel3.Size = new System.Drawing.Size(1227, 609);
            this.panel3.TabIndex = 1;
            // 
            // panList
            // 
            this.panList.Controls.Add(this.label4);
            this.panList.Controls.Add(this.label5);
            this.panList.Controls.Add(this.label3);
            this.panList.Controls.Add(this.txt거래처담당자);
            this.panList.Controls.Add(this.label2);
            this.panList.Controls.Add(this.txt대표자명);
            this.panList.Controls.Add(this.label1);
            this.panList.Controls.Add(this.label15);
            this.panList.Controls.Add(this.cmb사용여부);
            this.panList.Controls.Add(this.nowTextSelect);
            this.panList.Controls.Add(this.cmb거래처구분);
            this.panList.Controls.Add(this.GridRecord);
            this.panList.Controls.Add(this.butSearch);
            this.panList.Location = new System.Drawing.Point(0, 57);
            this.panList.Name = "panList";
            this.panList.Size = new System.Drawing.Size(1127, 457);
            this.panList.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(669, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 12);
            this.label4.TabIndex = 109;
            this.label4.Text = "* 거래처명 초성 검색 가능";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(822, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(291, 12);
            this.label5.TabIndex = 108;
            this.label5.Text = "* 검색어 : 거래처명, 대표자명, 담당자명, 사업자번호";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(12, 441);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 12);
            this.label3.TabIndex = 104;
            this.label3.Text = "* 검색어 : 거래처명, 대표자명, 담당자명, 사업자번호";
            // 
            // txt거래처담당자
            // 
            this.txt거래처담당자._AutoTab = true;
            this.txt거래처담당자._BorderColor = System.Drawing.Color.LightSkyBlue;
            this.txt거래처담당자._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt거래처담당자._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt거래처담당자._WaterMarkText = "";
            this.txt거래처담당자.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt거래처담당자.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt거래처담당자.Location = new System.Drawing.Point(694, 88);
            this.txt거래처담당자.Name = "txt거래처담당자";
            this.txt거래처담당자.Size = new System.Drawing.Size(78, 22);
            this.txt거래처담당자.TabIndex = 4;
            this.txt거래처담당자.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(214)))), ((int)(((byte)(249)))));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(598, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 22);
            this.label2.TabIndex = 103;
            this.label2.Text = "거래처담당자";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // txt대표자명
            // 
            this.txt대표자명._AutoTab = true;
            this.txt대표자명._BorderColor = System.Drawing.Color.LightSkyBlue;
            this.txt대표자명._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt대표자명._WaterMarkColor = System.Drawing.Color.Gray;
            this.txt대표자명._WaterMarkText = "";
            this.txt대표자명.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt대표자명.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt대표자명.Location = new System.Drawing.Point(514, 88);
            this.txt대표자명.Name = "txt대표자명";
            this.txt대표자명.Size = new System.Drawing.Size(78, 22);
            this.txt대표자명.TabIndex = 3;
            this.txt대표자명.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(214)))), ((int)(((byte)(249)))));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(426, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 22);
            this.label1.TabIndex = 101;
            this.label1.Text = "대표자명";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(214)))), ((int)(((byte)(249)))));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label15.Location = new System.Drawing.Point(242, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 22);
            this.label15.TabIndex = 100;
            this.label15.Text = "검색어";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb사용여부
            // 
            this.cmb사용여부._BorderColor = System.Drawing.Color.LightSkyBlue;
            this.cmb사용여부._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmb사용여부.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb사용여부.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb사용여부.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmb사용여부.FormattingEnabled = true;
            this.cmb사용여부.Location = new System.Drawing.Point(159, 11);
            this.cmb사용여부.Name = "cmb사용여부";
            this.cmb사용여부.Size = new System.Drawing.Size(77, 21);
            this.cmb사용여부.TabIndex = 1;
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
            this.nowTextSelect.Location = new System.Drawing.Point(330, 10);
            this.nowTextSelect.Name = "nowTextSelect";
            this.nowTextSelect.Size = new System.Drawing.Size(145, 22);
            this.nowTextSelect.TabIndex = 2;
            this.nowTextSelect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nowTextSelect_KeyDown);
            // 
            // cmb거래처구분
            // 
            this.cmb거래처구분._BorderColor = System.Drawing.Color.LightSkyBlue;
            this.cmb거래처구분._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmb거래처구분.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb거래처구분.Enabled = false;
            this.cmb거래처구분.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb거래처구분.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmb거래처구분.FormattingEnabled = true;
            this.cmb거래처구분.Location = new System.Drawing.Point(14, 11);
            this.cmb거래처구분.Name = "cmb거래처구분";
            this.cmb거래처구분.Size = new System.Drawing.Size(139, 21);
            this.cmb거래처구분.TabIndex = 0;
            this.cmb거래처구분.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb거래처구분_KeyDown);
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
            this.GridRecord.Size = new System.Drawing.Size(1099, 400);
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
            this.butSearch.Image = ((System.Drawing.Image)(resources.GetObject("butSearch.Image")));
            this.butSearch.Location = new System.Drawing.Point(481, 5);
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
            this.panel2.Size = new System.Drawing.Size(1227, 56);
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
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.butExit.Location = new System.Drawing.Point(1159, 23);
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
            this.lblTitle.Size = new System.Drawing.Size(133, 22);
            this.lblTitle.TabIndex = 95;
            this.lblTitle.Text = "거래처 검색";
            // 
            // panHead
            // 
            this.panHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(102)))), ((int)(((byte)(200)))));
            this.panHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHead.Location = new System.Drawing.Point(0, 0);
            this.panHead.Name = "panHead";
            this.panHead.Size = new System.Drawing.Size(1227, 20);
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
            // pop거래처검색
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1245, 627);
            this.Controls.Add(this.panBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "pop거래처검색";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "pop거래처검색";
            this.Load += new System.EventHandler(this.pop거래처검색_Load);
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
