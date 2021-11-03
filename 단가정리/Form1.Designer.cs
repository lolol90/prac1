
namespace 단가정리
{
    partial class frm단가정리
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.spCont = new System.Windows.Forms.SplitContainer();
            this.lbl규격 = new System.Windows.Forms.Label();
            this.btn상품 = new System.Windows.Forms.Button();
            this.btn거래처 = new System.Windows.Forms.Button();
            this.txt상품코드 = new System.Windows.Forms.TextBox();
            this.txt코드old = new System.Windows.Forms.TextBox();
            this.txt코드 = new System.Windows.Forms.TextBox();
            this.txt낱개입고단가 = new System.Windows.Forms.TextBox();
            this.txt박스입고단가 = new System.Windows.Forms.TextBox();
            this.txt단가 = new System.Windows.Forms.TextBox();
            this.txt상품 = new System.Windows.Forms.TextBox();
            this.txt명칭 = new System.Windows.Forms.TextBox();
            this.lbl단가 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butSearch = new System.Windows.Forms.Button();
            this.cmbS사입품 = new System.Windows.Forms.ComboBox();
            this.btnS거래처 = new System.Windows.Forms.Button();
            this.txtS거래처코드 = new System.Windows.Forms.TextBox();
            this.txtS거래처 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.GridRecord = new System.Windows.Forms.DataGridView();
            this.panTitle = new System.Windows.Forms.Panel();
            this.butExit = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.butNew = new System.Windows.Forms.Button();
            this.tBtn3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panData1 = new System.Windows.Forms.Panel();
            this.panData2 = new System.Windows.Forms.Panel();
            this.panData3 = new System.Windows.Forms.Panel();
            this.panData4 = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.spCont)).BeginInit();
            this.spCont.Panel1.SuspendLayout();
            this.spCont.Panel2.SuspendLayout();
            this.spCont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridRecord)).BeginInit();
            this.panTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // spCont
            // 
            this.spCont.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spCont.IsSplitterFixed = true;
            this.spCont.Location = new System.Drawing.Point(0, 33);
            this.spCont.Name = "spCont";
            // 
            // spCont.Panel1
            // 
            this.spCont.Panel1.Controls.Add(this.lbl규격);
            this.spCont.Panel1.Controls.Add(this.btn상품);
            this.spCont.Panel1.Controls.Add(this.btn거래처);
            this.spCont.Panel1.Controls.Add(this.txt상품코드);
            this.spCont.Panel1.Controls.Add(this.txt코드old);
            this.spCont.Panel1.Controls.Add(this.txt코드);
            this.spCont.Panel1.Controls.Add(this.txt낱개입고단가);
            this.spCont.Panel1.Controls.Add(this.txt박스입고단가);
            this.spCont.Panel1.Controls.Add(this.txt단가);
            this.spCont.Panel1.Controls.Add(this.txt상품);
            this.spCont.Panel1.Controls.Add(this.txt명칭);
            this.spCont.Panel1.Controls.Add(this.lbl단가);
            this.spCont.Panel1.Controls.Add(this.label4);
            this.spCont.Panel1.Controls.Add(this.label3);
            this.spCont.Panel1.Controls.Add(this.label2);
            // 
            // spCont.Panel2
            // 
            this.spCont.Panel2.Controls.Add(this.butSearch);
            this.spCont.Panel2.Controls.Add(this.cmbS사입품);
            this.spCont.Panel2.Controls.Add(this.btnS거래처);
            this.spCont.Panel2.Controls.Add(this.txtS거래처코드);
            this.spCont.Panel2.Controls.Add(this.txtS거래처);
            this.spCont.Panel2.Controls.Add(this.label6);
            this.spCont.Panel2.Controls.Add(this.GridRecord);
            this.spCont.Size = new System.Drawing.Size(1119, 516);
            this.spCont.SplitterDistance = 382;
            this.spCont.TabIndex = 2;
            // 
            // lbl규격
            // 
            this.lbl규격.Location = new System.Drawing.Point(159, 89);
            this.lbl규격.Name = "lbl규격";
            this.lbl규격.Size = new System.Drawing.Size(120, 28);
            this.lbl규격.TabIndex = 115;
            this.lbl규격.Text = "규격";
            this.lbl규격.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn상품
            // 
            this.btn상품.BackColor = System.Drawing.Color.Gainsboro;
            this.btn상품.Font = new System.Drawing.Font("굴림", 6F);
            this.btn상품.ForeColor = System.Drawing.Color.Black;
            this.btn상품.Location = new System.Drawing.Point(347, 52);
            this.btn상품.Name = "btn상품";
            this.btn상품.Size = new System.Drawing.Size(17, 28);
            this.btn상품.TabIndex = 82;
            this.btn상품.TabStop = false;
            this.btn상품.Text = "▼";
            this.btn상품.UseVisualStyleBackColor = false;
            this.btn상품.Click += new System.EventHandler(this.btn상품_Click);
            // 
            // btn거래처
            // 
            this.btn거래처.BackColor = System.Drawing.Color.Gainsboro;
            this.btn거래처.Font = new System.Drawing.Font("굴림", 6F);
            this.btn거래처.ForeColor = System.Drawing.Color.Black;
            this.btn거래처.Location = new System.Drawing.Point(347, 17);
            this.btn거래처.Name = "btn거래처";
            this.btn거래처.Size = new System.Drawing.Size(17, 25);
            this.btn거래처.TabIndex = 2;
            this.btn거래처.TabStop = false;
            this.btn거래처.Text = "▼";
            this.btn거래처.UseVisualStyleBackColor = false;
            this.btn거래처.Click += new System.EventHandler(this.btn거래처_Click);
            // 
            // txt상품코드
            // 
            this.txt상품코드.BackColor = System.Drawing.Color.GhostWhite;
            this.txt상품코드.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt상품코드.Enabled = false;
            this.txt상품코드.Location = new System.Drawing.Point(205, 53);
            this.txt상품코드.MaxLength = 4;
            this.txt상품코드.Name = "txt상품코드";
            this.txt상품코드.Size = new System.Drawing.Size(38, 28);
            this.txt상품코드.TabIndex = 3;
            this.txt상품코드.TabStop = false;
            this.txt상품코드.Visible = false;
            // 
            // txt코드old
            // 
            this.txt코드old.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txt코드old.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt코드old.Enabled = false;
            this.txt코드old.Location = new System.Drawing.Point(266, 16);
            this.txt코드old.MaxLength = 4;
            this.txt코드old.Name = "txt코드old";
            this.txt코드old.Size = new System.Drawing.Size(20, 28);
            this.txt코드old.TabIndex = 81;
            this.txt코드old.TabStop = false;
            this.txt코드old.Visible = false;
            // 
            // txt코드
            // 
            this.txt코드.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txt코드.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt코드.Enabled = false;
            this.txt코드.Location = new System.Drawing.Point(240, 16);
            this.txt코드.MaxLength = 4;
            this.txt코드.Name = "txt코드";
            this.txt코드.Size = new System.Drawing.Size(20, 28);
            this.txt코드.TabIndex = 0;
            this.txt코드.TabStop = false;
            this.txt코드.Visible = false;
            // 
            // txt낱개입고단가
            // 
            this.txt낱개입고단가.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt낱개입고단가.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt낱개입고단가.Location = new System.Drawing.Point(159, 214);
            this.txt낱개입고단가.MaxLength = 18;
            this.txt낱개입고단가.Name = "txt낱개입고단가";
            this.txt낱개입고단가.Size = new System.Drawing.Size(120, 30);
            this.txt낱개입고단가.TabIndex = 80;
            this.txt낱개입고단가.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt박스입고단가
            // 
            this.txt박스입고단가.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt박스입고단가.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt박스입고단가.Location = new System.Drawing.Point(159, 168);
            this.txt박스입고단가.MaxLength = 18;
            this.txt박스입고단가.Name = "txt박스입고단가";
            this.txt박스입고단가.Size = new System.Drawing.Size(120, 30);
            this.txt박스입고단가.TabIndex = 79;
            this.txt박스입고단가.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt단가
            // 
            this.txt단가.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt단가.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt단가.Location = new System.Drawing.Point(159, 125);
            this.txt단가.MaxLength = 18;
            this.txt단가.Name = "txt단가";
            this.txt단가.Size = new System.Drawing.Size(120, 30);
            this.txt단가.TabIndex = 7;
            this.txt단가.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt단가.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputLast_KeyDown);
            // 
            // txt상품
            // 
            this.txt상품.Location = new System.Drawing.Point(159, 53);
            this.txt상품.MaxLength = 50;
            this.txt상품.Name = "txt상품";
            this.txt상품.Size = new System.Drawing.Size(192, 28);
            this.txt상품.TabIndex = 4;
            this.txt상품.TextChanged += new System.EventHandler(this.txt상품_TextChanged);
            this.txt상품.Enter += new System.EventHandler(this.txt상품_Enter);
            this.txt상품.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt상품_KeyDown);
            // 
            // txt명칭
            // 
            this.txt명칭.Location = new System.Drawing.Point(159, 16);
            this.txt명칭.MaxLength = 50;
            this.txt명칭.Name = "txt명칭";
            this.txt명칭.Size = new System.Drawing.Size(192, 28);
            this.txt명칭.TabIndex = 1;
            this.txt명칭.TextChanged += new System.EventHandler(this.txt명칭_TextChanged);
            this.txt명칭.Enter += new System.EventHandler(this.txt명칭_Enter);
            this.txt명칭.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt명칭_KeyDown);
            // 
            // lbl단가
            // 
            this.lbl단가.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(214)))), ((int)(((byte)(249)))));
            this.lbl단가.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl단가.Location = new System.Drawing.Point(13, 125);
            this.lbl단가.Name = "lbl단가";
            this.lbl단가.Size = new System.Drawing.Size(122, 28);
            this.lbl단가.TabIndex = 78;
            this.lbl단가.Text = "단가";
            this.lbl단가.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(214)))), ((int)(((byte)(249)))));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(12, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 28);
            this.label4.TabIndex = 77;
            this.label4.Text = "규격";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(214)))), ((int)(((byte)(249)))));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 28);
            this.label3.TabIndex = 76;
            this.label3.Text = "상품";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(214)))), ((int)(((byte)(249)))));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 28);
            this.label2.TabIndex = 75;
            this.label2.Text = "매출처";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butSearch
            // 
            this.butSearch.BackColor = System.Drawing.Color.LightSalmon;
            this.butSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSearch.Location = new System.Drawing.Point(428, 10);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(75, 30);
            this.butSearch.TabIndex = 1;
            this.butSearch.Tag = "검색";
            this.butSearch.Text = "검색";
            this.butSearch.UseVisualStyleBackColor = false;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // cmbS사입품
            // 
            this.cmbS사입품.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbS사입품.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbS사입품.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbS사입품.FormattingEnabled = true;
            this.cmbS사입품.Location = new System.Drawing.Point(334, 10);
            this.cmbS사입품.Name = "cmbS사입품";
            this.cmbS사입품.Size = new System.Drawing.Size(88, 26);
            this.cmbS사입품.TabIndex = 104;
            // 
            // btnS거래처
            // 
            this.btnS거래처.BackColor = System.Drawing.Color.Gainsboro;
            this.btnS거래처.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnS거래처.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnS거래처.Font = new System.Drawing.Font("굴림", 6F);
            this.btnS거래처.ForeColor = System.Drawing.Color.Black;
            this.btnS거래처.Location = new System.Drawing.Point(294, 12);
            this.btnS거래처.Name = "btnS거래처";
            this.btnS거래처.Size = new System.Drawing.Size(17, 20);
            this.btnS거래처.TabIndex = 102;
            this.btnS거래처.TabStop = false;
            this.btnS거래처.Text = "▼";
            this.btnS거래처.UseVisualStyleBackColor = false;
            this.btnS거래처.Click += new System.EventHandler(this.btnS거래처_Click);
            // 
            // txtS거래처코드
            // 
            this.txtS거래처코드.BackColor = System.Drawing.Color.GhostWhite;
            this.txtS거래처코드.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtS거래처코드.Enabled = false;
            this.txtS거래처코드.Location = new System.Drawing.Point(106, 12);
            this.txtS거래처코드.MaxLength = 4;
            this.txtS거래처코드.Name = "txtS거래처코드";
            this.txtS거래처코드.Size = new System.Drawing.Size(38, 28);
            this.txtS거래처코드.TabIndex = 100;
            this.txtS거래처코드.TabStop = false;
            this.txtS거래처코드.Visible = false;
            // 
            // txtS거래처
            // 
            this.txtS거래처.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtS거래처.Location = new System.Drawing.Point(76, 12);
            this.txtS거래처.MaxLength = 50;
            this.txtS거래처.Name = "txtS거래처";
            this.txtS거래처.Size = new System.Drawing.Size(221, 28);
            this.txtS거래처.TabIndex = 101;
            this.txtS거래처.TextChanged += new System.EventHandler(this.txtS거래처_TextChanged);
            this.txtS거래처.Enter += new System.EventHandler(this.txtS거래처_Enter);
            this.txtS거래처.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtS거래처_KeyDown);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(214)))), ((int)(((byte)(249)))));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(5, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 23);
            this.label6.TabIndex = 103;
            this.label6.Text = "매출처";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GridRecord
            // 
            this.GridRecord.AllowUserToAddRows = false;
            this.GridRecord.AllowUserToDeleteRows = false;
            this.GridRecord.AllowUserToOrderColumns = true;
            this.GridRecord.AllowUserToResizeRows = false;
            this.GridRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GridRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridRecord.BackgroundColor = System.Drawing.Color.White;
            this.GridRecord.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GridRecord.ColumnHeadersHeight = 30;
            this.GridRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.GridRecord.EnableHeadersVisualStyles = false;
            this.GridRecord.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.GridRecord.Location = new System.Drawing.Point(3, 42);
            this.GridRecord.Name = "GridRecord";
            this.GridRecord.ReadOnly = true;
            this.GridRecord.RowHeadersVisible = false;
            this.GridRecord.RowHeadersWidth = 62;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.GridRecord.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridRecord.RowTemplate.Height = 30;
            this.GridRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridRecord.Size = new System.Drawing.Size(726, 466);
            this.GridRecord.TabIndex = 2;
            this.GridRecord.DoubleClick += new System.EventHandler(this.GridRecord_DoubleClick);
            this.GridRecord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridRecord_KeyDown);
            // 
            // panTitle
            // 
            this.panTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(102)))), ((int)(((byte)(200)))));
            this.panTitle.Controls.Add(this.butExit);
            this.panTitle.Controls.Add(this.butDelete);
            this.panTitle.Controls.Add(this.butSave);
            this.panTitle.Controls.Add(this.butNew);
            this.panTitle.Controls.Add(this.tBtn3);
            this.panTitle.Controls.Add(this.label1);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(0, 0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(1414, 33);
            this.panTitle.TabIndex = 0;
            // 
            // butExit
            // 
            this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butExit.Location = new System.Drawing.Point(1329, 3);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(73, 27);
            this.butExit.TabIndex = 19;
            this.butExit.Tag = "종료";
            this.butExit.Text = "닫기";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // butDelete
            // 
            this.butDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butDelete.BackColor = System.Drawing.Color.Linen;
            this.butDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butDelete.Enabled = false;
            this.butDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDelete.Location = new System.Drawing.Point(1250, 3);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(73, 27);
            this.butDelete.TabIndex = 12;
            this.butDelete.Tag = "삭제";
            this.butDelete.Text = "삭제";
            this.butDelete.UseVisualStyleBackColor = false;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSave.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.butSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSave.ForeColor = System.Drawing.Color.Black;
            this.butSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSave.Location = new System.Drawing.Point(1171, 3);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(73, 27);
            this.butSave.TabIndex = 11;
            this.butSave.Tag = "저장";
            this.butSave.Text = "저장";
            this.butSave.UseVisualStyleBackColor = false;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butNew
            // 
            this.butNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butNew.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.butNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butNew.Location = new System.Drawing.Point(1092, 3);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(73, 27);
            this.butNew.TabIndex = 13;
            this.butNew.Tag = "추가";
            this.butNew.Text = "신규";
            this.butNew.UseVisualStyleBackColor = false;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // tBtn3
            // 
            this.tBtn3.BackColor = System.Drawing.Color.White;
            this.tBtn3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tBtn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tBtn3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tBtn3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tBtn3.Location = new System.Drawing.Point(231, 11);
            this.tBtn3.Name = "tBtn3";
            this.tBtn3.Size = new System.Drawing.Size(152, 24);
            this.tBtn3.TabIndex = 101;
            this.tBtn3.TabStop = false;
            this.tBtn3.Tag = "3";
            this.tBtn3.Text = "매출처별 상품단가 관리";
            this.tBtn3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림체", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(10, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 32);
            this.label1.TabIndex = 93;
            this.label1.Text = "단가정리";
            // 
            // panData1
            // 
            this.panData1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panData1.Location = new System.Drawing.Point(1135, 50);
            this.panData1.Name = "panData1";
            this.panData1.Size = new System.Drawing.Size(267, 83);
            this.panData1.TabIndex = 151;
            this.panData1.Visible = false;
            // 
            // panData2
            // 
            this.panData2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panData2.Location = new System.Drawing.Point(1135, 148);
            this.panData2.Name = "panData2";
            this.panData2.Size = new System.Drawing.Size(267, 83);
            this.panData2.TabIndex = 151;
            this.panData2.Visible = false;
            // 
            // panData3
            // 
            this.panData3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panData3.Location = new System.Drawing.Point(1135, 247);
            this.panData3.Name = "panData3";
            this.panData3.Size = new System.Drawing.Size(267, 83);
            this.panData3.TabIndex = 151;
            this.panData3.Visible = false;
            // 
            // panData4
            // 
            this.panData4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panData4.Location = new System.Drawing.Point(1135, 348);
            this.panData4.Name = "panData4";
            this.panData4.Size = new System.Drawing.Size(267, 83);
            this.panData4.TabIndex = 151;
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMsg.Font = new System.Drawing.Font("굴림체", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMsg.ForeColor = System.Drawing.Color.Green;
            this.lblMsg.Location = new System.Drawing.Point(1132, 474);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(313, 57);
            this.lblMsg.TabIndex = 270;
            this.lblMsg.Text = "Searching ...";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMsg.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 83F;
            this.dataGridViewTextBoxColumn1.HeaderText = "코드";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 83;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 207F;
            this.dataGridViewTextBoxColumn2.HeaderText = "상품명";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 207;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 207;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 155F;
            this.dataGridViewTextBoxColumn3.HeaderText = "규격";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 155;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 155;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 93F;
            this.dataGridViewTextBoxColumn4.HeaderText = "박스단가";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 93;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 93;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.FillWeight = 92F;
            this.dataGridViewTextBoxColumn5.HeaderText = "중간단가";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 92;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 92;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.FillWeight = 93F;
            this.dataGridViewTextBoxColumn6.HeaderText = "낱개단가";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 93;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 93;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 207F;
            this.Column1.HeaderText = "상품명";
            this.Column1.MinimumWidth = 207;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 155F;
            this.Column2.HeaderText = "규격";
            this.Column2.MinimumWidth = 155;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 93F;
            this.Column3.HeaderText = "박스단가";
            this.Column3.MinimumWidth = 93;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 92F;
            this.Column4.HeaderText = "중간단가";
            this.Column4.MinimumWidth = 92;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 93F;
            this.Column5.HeaderText = "낱개단가";
            this.Column5.MinimumWidth = 93;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // frm단가정리
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1414, 562);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.panData4);
            this.Controls.Add(this.panData3);
            this.Controls.Add(this.panData2);
            this.Controls.Add(this.panData1);
            this.Controls.Add(this.panTitle);
            this.Controls.Add(this.spCont);
            this.KeyPreview = true;
            this.Name = "frm단가정리";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm단가정리";
            this.spCont.Panel1.ResumeLayout(false);
            this.spCont.Panel1.PerformLayout();
            this.spCont.Panel2.ResumeLayout(false);
            this.spCont.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spCont)).EndInit();
            this.spCont.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridRecord)).EndInit();
            this.panTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spCont;
        private System.Windows.Forms.Button btn상품;
        private System.Windows.Forms.Button btn거래처;
        public System.Windows.Forms.TextBox txt상품코드;
        public System.Windows.Forms.TextBox txt코드old;
        public System.Windows.Forms.TextBox txt코드;
        private System.Windows.Forms.TextBox txt낱개입고단가;
        private System.Windows.Forms.TextBox txt박스입고단가;
        private System.Windows.Forms.TextBox txt단가;
        public System.Windows.Forms.TextBox txt상품;
        public System.Windows.Forms.TextBox txt명칭;
        private System.Windows.Forms.Label lbl단가;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.ComboBox cmbS사입품;
        private System.Windows.Forms.Button btnS거래처;
        public System.Windows.Forms.TextBox txtS거래처코드;
        public System.Windows.Forms.TextBox txtS거래처;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView GridRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Panel panTitle;
        private System.Windows.Forms.Button tBtn3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panData1;
        private System.Windows.Forms.Panel panData2;
        private System.Windows.Forms.Panel panData3;
        private System.Windows.Forms.Panel panData4;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lbl규격;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}

