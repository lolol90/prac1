// Decompiled with JetBrains decompiler
// Type: smartMain.frmBackRoot
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using smartMain.CLS;
using smartMain.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace smartMain
{
    public class frmBackRoot : Form
    {
        private IfrmInterface parentFrm = (IfrmInterface)null;
        private wnGConstant wConst = new wnGConstant();
        private string sqlQuery = "";
        private IContainer components = (IContainer)null;
        private Panel panCenter;
        private Button button1;
        private Button btnTile01;
        private DataGridView grdComp;
        private Label label2;
        private conTextBox nowTextSelect;
        private Button butSearch;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Button button2;
        private TextBox txtCompID;
        private Button butOut;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Label lbl모바일수;
        private Label lbl실사용자;
        private Label lbl사용업체;
        private Label lbl등록업체;
        private Label label8;
        private Label label6;
        private Label label4;
        private Label label1;
        private conDateTimePicker dtpDay;
        private Label label10;
        private Button btnView;
        private CheckBox chk계란;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column4;
        private conComboBox cmbS수량등록방식;

        public frmBackRoot(IfrmInterface pFrm)
        {
            this.InitializeComponent();
            this.parentFrm = pFrm;
        }

        private void frmBackAdmin_Load(object sender, EventArgs e)
        {
            this.cmbS수량등록방식.DisplayMember = "명칭";
            this.cmbS수량등록방식.ValueMember = "코드";
            this.sqlQuery = "select * from C_수량등록방식 ";
            this.wConst.ComboBox_Read(this.cmbS수량등록방식, this.sqlQuery, Common.p_strConnMain);
            this.nowTextSelect.Text = "";
            this.bindData(this.makeSearchCondition());
            conDateTimePicker dtpDay = this.dtpDay;
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.AddMonths(-1);
            string str = dateTime.ToString("yyyy-MM-dd");
            dtpDay.Text = str;
            this.btnView_Click((object)this, (EventArgs)null);
        }

        private void frmBackAdmin_Resize(object sender, EventArgs e)
        {
        }

        private void menuButton_Click(object sender, EventArgs e) => this.parentFrm.sub_Form(((Control)sender).Tag.ToString(), ((Control)sender).Text.ToString());

        private string makeSearchCondition()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (this.chk계란.Checked)
                stringBuilder.Append(" and isnull(a.계란업여부, 'N') = 'Y' ");
            switch ((string)this.cmbS수량등록방식.SelectedValue ?? "")
            {
                case "":
                    stringBuilder.Append("");
                    break;
                default:
                    stringBuilder.Append(" and a.수량등록방식코드 = '" + (string)this.cmbS수량등록방식.SelectedValue + "' ");
                    break;
            }
            switch (this.nowTextSelect.Text)
            {
                case "":
                    stringBuilder.Append("");
                    break;
                default:
                    stringBuilder.Append(" and (a.사업자번호 like '" + this.nowTextSelect.Text + "%' ");
                    stringBuilder.Append("     or a.상호명 like '%" + this.nowTextSelect.Text + "%' ");
                    stringBuilder.Append("     or a.상호별칭 like '%" + this.nowTextSelect.Text + "%' ");
                    stringBuilder.Append("     or a.대표자 like '" + this.nowTextSelect.Text + "%') ");
                    break;
            }
            return stringBuilder.ToString();
        }

        private void bindData(string condition)
        {
            this.grdComp.DataSource = (object)null;
            this.grdComp.RowCount = 0;
            try
            {
                DataTable dataTable = new wnDm().root_업체정보_List(condition, Common.p_strConnMain);
                if (dataTable == null || dataTable.Rows.Count <= 0)
                    return;
                this.grdComp.RowCount = dataTable.Rows.Count;
                for (int index = 0; index < dataTable.Rows.Count; ++index)
                {
                    this.grdComp.Rows[index].Cells[0].Value = (object)dataTable.Rows[index]["V사업자번호"].ToString();
                    this.grdComp.Rows[index].Cells[1].Value = (object)dataTable.Rows[index]["상호명"].ToString();
                    this.grdComp.Rows[index].Cells[2].Value = (object)dataTable.Rows[index]["상호별칭"].ToString();
                    this.grdComp.Rows[index].Cells[3].Value = (object)dataTable.Rows[index]["대표자"].ToString();
                    this.grdComp.Rows[index].Cells[6].Value = (object)dataTable.Rows[index]["수량등록방식명"].ToString();
                    this.grdComp.Rows[index].Cells[7].Value = (object)dataTable.Rows[index]["로그인일시"].ToString();
                }
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            this.bindData(this.makeSearchCondition());
            this.grdComp.Focus();
        }

        private void grdComp_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdComp.CurrentCell == null || this.grdComp.CurrentCell.RowIndex < 0 || this.grdComp.CurrentCell.ColumnIndex < 0)
                return;
            this.txtCompID.Text = (string)this.grdComp.Rows[this.grdComp.CurrentCell.RowIndex].Cells[0].Value ?? "";
            this.txtCompID.Text = this.txtCompID.Text.Replace("-", "");
            if (this.txtCompID.Text == "")
                return;
            this.call_CompLogin();
        }

        private void butOut_Click(object sender, EventArgs e)
        {
            this.txtCompID.Text = "0000000000";
            this.call_CompLogin();
        }

        private void call_CompLogin()
        {
            if (!this.get_Company_Info())
                return;
            this.get_Detail();
            foreach (Form mdiChild in this.ParentForm.MdiChildren)
            {
                if (mdiChild.Name != "frmBack" && mdiChild.Name != nameof(frmBackRoot))
                    mdiChild.Close();
            }
            int num = (int)MessageBox.Show("[ " + Common.p_strCompName + " ] 업체로 로그인 되었습니다.");
        }

        private bool get_Company_Info()
        {
            bool flag = false;
            try
            {
                SqlConnection connection = new SqlConnection(Common.p_strConnMain);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(" select a.* " + "     , b.디비주소 " + "     , b.디비명 " + "     , b.디비계정 " + "     , b.디비암호 " + " from T_업체정보 a " + "     inner join T_데이터베이스 b on b.디비순번 = a.디비순번 " + " where a.사업자번호 = '" + this.txtCompID.Text.Trim() + "' ", connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                DataTable dataTable = new DataTable();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataTable);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    if (dataTable.Rows[0]["사용여부"].ToString() == "Y")
                    {
                        Common.p_strUserID = dataTable.Rows[0]["대표아이디"].ToString();
                        Common.p_strCompNo = dataTable.Rows[0]["사업자번호"].ToString();
                        Common.p_strCompName = dataTable.Rows[0]["상호명"].ToString();
                        Common.p_strCEO = dataTable.Rows[0]["대표자"].ToString();
                        Common.p_strUptae = dataTable.Rows[0]["업태"].ToString();
                        Common.p_strJong = dataTable.Rows[0]["종목"].ToString();
                        Common.p_strZip = dataTable.Rows[0]["우편번호"].ToString();
                        Common.p_strAddr1 = dataTable.Rows[0]["주소"].ToString();
                        Common.p_strAddr2 = dataTable.Rows[0]["상세주소"].ToString();
                        Common.p_strEmail = dataTable.Rows[0]["이메일"].ToString();
                        Common.p_strTel = dataTable.Rows[0]["전화번호"].ToString();
                        Common.p_strFax = dataTable.Rows[0]["팩스번호"].ToString();
                        Common.p_strHome = dataTable.Rows[0]["홈페이지"].ToString();
                        Common.p_strConn = "DATA SOURCE = " + dataTable.Rows[0]["디비주소"].ToString() + ";INITIAL CATALOG = " + dataTable.Rows[0]["디비명"].ToString() + ";PERSIST SECURITY INFO = false;USER ID = " + dataTable.Rows[0]["디비계정"].ToString() + ";PASSWORD = " + dataTable.Rows[0]["디비암호"].ToString() + ";";
                        Common.p_PageSize = !(dataTable.Rows[0]["페이지사이즈"].ToString() == "") ? dataTable.Rows[0]["페이지사이즈"].ToString() : "0";
                        if (dataTable.Rows[0]["수량소수점여부"].ToString() == "Y")
                        {
                            Common.p_strFlag_Amount = "Y";
                            Common.p_strFormatAmount = "#,0.########";
                        }
                        else
                        {
                            Common.p_strFlag_Amount = "N";
                            Common.p_strFormatAmount = "#,0";
                        }
                        if (dataTable.Rows[0]["단가소수점여부"].ToString() == "Y")
                        {
                            Common.p_strFlag_Unit = "Y";
                            Common.p_strFormatUnit = "#,0.########";
                        }
                        else
                        {
                            Common.p_strFlag_Unit = "N";
                            Common.p_strFormatUnit = "#,0";
                        }
                        Common.p_strEgg = !(dataTable.Rows[0]["계란업여부"].ToString() == "Y") ? "N" : "Y";
                        Common.p_strNoVAT = !(dataTable.Rows[0]["면세여부"].ToString() == "Y") ? "N" : "Y";
                        Common.p_strBox = dataTable.Rows[0]["수량등록방식코드"].ToString();
                        Common.p_strBoxMiddle = !(dataTable.Rows[0]["중간제외여부"].ToString() == "Y") ? "N" : "Y";
                        Common.p_PopSheetPrint = !(dataTable.Rows[0]["거래명세서출력여부"].ToString() == "Y") ? "N" : "Y";
                        Common.p_PopPresPrint = !(dataTable.Rows[0]["견적서출력여부"].ToString() == "Y") ? "N" : "Y";
                        Common.p_PopBuyPrint = !(dataTable.Rows[0]["발주서출력여부"].ToString() == "Y") ? "N" : "Y";
                        Common.p_AutoCustCode = "Y";
                        Common.p_AutoProdCode = "Y";
                        Common.p_AutoCustLength = "6";
                        Common.p_AutoProdLength = "6";
                        Common.p_SheetBarcode = !(dataTable.Rows[0]["거래명세바코드여부"].ToString() == "Y") ? "N" : "Y";
                        Common.p_SheetBarcodeOnly = !(dataTable.Rows[0]["거래명세바코드숫자만"].ToString() == "Y") ? "N" : "Y";
                        Common.p_SheetVAT = !(dataTable.Rows[0]["거래명세부가세표시"].ToString() == "Y") ? "N" : "Y";
                        Common.p_SheetSpecial = !(dataTable.Rows[0]["거래명세특별양식"].ToString() == "Y") ? "N" : "Y";
                        Common.p_SheetNo = dataTable.Rows[0]["거래명세양식구분"].ToString();
                        Common.p_InternetXLS = !(dataTable.Rows[0]["인터넷엑셀"].ToString() == "Y") ? "N" : "Y";
                        Common.p_MaeChoolMoney = !(dataTable.Rows[0]["매출금액변경허용"].ToString() == "Y") ? "N" : "Y";
                        Common.p_strTaxProd = dataTable.Rows[0]["계산서대표품목"].ToString();
                        if (dataTable.Rows[0]["직인형식"].ToString() != "")
                        {
                            string filename = this.txtCompID.Text.Trim() + "." + dataTable.Rows[0]["직인형식"].ToString();
                            wnGConstant wnGconstant = new wnGConstant();
                            byte[] numArray = new byte[0];
                            byte[] pByte = (byte[])dataTable.Rows[0]["직인"];
                            if (pByte.Length > 0)
                                wnGconstant.ConvertByteToImage(pByte).Save(filename);
                        }
                        if (dataTable.Rows[0]["거래명세서파일명"].ToString() != "")
                        {
                            byte[] buffer = (byte[])dataTable.Rows[0]["거래명세서"];
                            using (FileStream fileStream = new FileStream(this.txtCompID.Text.Trim() + ".xlsx", FileMode.Create, FileAccess.ReadWrite))
                            {
                                using (BinaryWriter binaryWriter = new BinaryWriter((Stream)fileStream))
                                {
                                    binaryWriter.Write(buffer);
                                    binaryWriter.Close();
                                }
                            }
                        }
                        else if (File.Exists(this.txtCompID.Text.Trim() + ".xlsx"))
                            File.Delete(this.txtCompID.Text.Trim() + ".xlsx");
                        Common.p_AutoSaleTime = dataTable.Rows[0]["매출일자자동시각"].ToString();
                        Common.p_SaleNoDupl = !(dataTable.Rows[0]["매출상품중복불가"].ToString() == "Y") ? "N" : "Y";
                        Common.p_BankNo = dataTable.Rows[0]["계좌순번"].ToString();
                        Common.p_BoxAmtYN = !(dataTable.Rows[0]["낱개업체박스수량표시"].ToString() == "Y") ? "N" : "Y";
                        Common.p_OnlyEaUnitYN = !(dataTable.Rows[0]["전체업체낱개단가만표시"].ToString() == "Y") ? "N" : "Y";
                        Common.p_MoneyYN = !(dataTable.Rows[0]["거래명세잔고표시"].ToString() == "Y") ? "N" : "Y";
                        Common.p_CalcVAT = !(dataTable.Rows[0]["부가세분리"].ToString() == "Y") ? "N" : "Y";
                        Common.p_ProdUnitAll = !(dataTable.Rows[0]["매출상품단가일괄변경"].ToString() == "Y") ? "N" : "Y";
                        Common.p_ViewVisitor = !(dataTable.Rows[0]["방문자기준"].ToString() == "Y") ? "N" : "Y";
                        Common.p_strSpotYN = !(dataTable.Rows[0]["지점사용여부"].ToString() == "Y") ? "N" : "Y";
                        Common.p_NewLastSheet = !(dataTable.Rows[0]["매출신규최종전표여부"].ToString() == "Y") ? "N" : "Y";
                        Common.p_ProdAmtYN = !(dataTable.Rows[0]["납품분최종수량"].ToString() == "Y") ? "N" : "Y";
                        flag = true;
                    }
                    else
                    {
                        int num1 = (int)MessageBox.Show("해당 사업자는 [사용중지] 상태입니다.");
                    }
                }
                else
                {
                    int num2 = (int)MessageBox.Show("등록된 사업자가 아닙니다.");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("시스템 접속 중 오류 발생!");
            }
            return flag;
        }

        private void get_Detail()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Common.p_strConn);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(" select a.* " + "     , b.* " + " from T_사용자정보 a " + "     left outer join T_사용자권한 b on b.사업자번호 = a.사업자번호 and b.지점코드 = a.지점코드 and b.사원번호 = a.사원번호 " + " where a.사업자번호 = '" + this.txtCompID.Text.Trim() + "' " + "     and a.지점코드 = '0' " + "     and a.사원번호 = '100' ", connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                DataTable dataTable = new DataTable();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataTable);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    if (dataTable.Rows[0]["퇴사여부"].ToString() == "N")
                    {
                        if (this.Check_DBConnection(Common.p_strConn))
                        {
                            Common.p_strSpotCode = dataTable.Rows[0]["지점코드"].ToString();
                            Common.p_strUserNo = dataTable.Rows[0]["사원번호"].ToString();
                            Common.p_strUserID = dataTable.Rows[0]["UID"].ToString();
                            Common.p_strUserName = dataTable.Rows[0]["사용자명"].ToString();
                            Common.p_strUserAdmin = dataTable.Rows[0]["관리자여부"].ToString();
                            Common.p_strCompID = dataTable.Rows[0]["사업자번호"].ToString();
                            Common.p_Refresh = "1";
                            if (Common.p_strUserAdmin == "Y")
                            {
                                Common.p_Menu01 = "Y";
                                Common.p_Menu02 = "Y";
                                Common.p_Menu03 = "Y";
                                Common.p_Menu04 = "Y";
                                Common.p_Menu05 = "Y";
                                Common.p_Menu06 = "Y";
                                Common.p_Menu07 = "Y";
                                Common.p_Menu08 = "Y";
                                Common.p_Menu09 = "Y";
                                Common.p_strViewInnPrice = "Y";
                                Common.p_strVisitAll = "Y";
                                Common.p_strResultAll = "Y";
                                Common.p_strUnitMod = "Y";
                                Common.p_strDayMod = "Y";
                                Common.p_strDayModPrev = "Y";
                                Common.p_strDayModNext = "Y";
                            }
                            else
                            {
                                Common.p_Menu01 = dataTable.Rows[0]["매출관리"].ToString() == "Y" ? "Y" : "N";
                                Common.p_Menu02 = dataTable.Rows[0]["매입관리"].ToString() == "Y" ? "Y" : "N";
                                Common.p_Menu03 = dataTable.Rows[0]["재고관리"].ToString() == "Y" ? "Y" : "N";
                                Common.p_Menu04 = dataTable.Rows[0]["지출관리"].ToString() == "Y" ? "Y" : "N";
                                Common.p_Menu05 = dataTable.Rows[0]["장비관리"].ToString() == "Y" ? "Y" : "N";
                                Common.p_Menu06 = dataTable.Rows[0]["계산서관리"].ToString() == "Y" ? "Y" : "N";
                                Common.p_Menu07 = dataTable.Rows[0]["정보현황"].ToString() == "Y" ? "Y" : "N";
                                Common.p_Menu08 = dataTable.Rows[0]["거래처및상품등록"].ToString() == "Y" ? "Y" : "N";
                                Common.p_Menu09 = dataTable.Rows[0]["사업자및사원등록"].ToString() == "Y" ? "Y" : "N";
                                Common.p_strViewInnPrice = dataTable.Rows[0]["매입가표시"].ToString() == "Y" ? "Y" : "N";
                                Common.p_strVisitAll = dataTable.Rows[0]["방문전체"].ToString() == "Y" ? "Y" : "N";
                                Common.p_strResultAll = dataTable.Rows[0]["실적전체"].ToString() == "Y" ? "Y" : "N";
                                Common.p_strUnitMod = dataTable.Rows[0]["단가수정"].ToString() == "Y" ? "Y" : "N";
                                Common.p_strDayMod = dataTable.Rows[0]["일자변경"].ToString() == "Y" ? "Y" : "N";
                                Common.p_strDayModPrev = dataTable.Rows[0]["이전일자입력"].ToString() == "Y" ? "Y" : "N";
                                Common.p_strDayModNext = dataTable.Rows[0]["이후일자입력"].ToString() == "Y" ? "Y" : "N";
                            }
                        }
                        else
                        {
                            int num1 = (int)MessageBox.Show("시스템이 준비중이거나, 오류가 있습니다.\r\n시스템 공급업체로 문의하세요.");
                        }
                    }
                    else
                    {
                        int num2 = (int)MessageBox.Show("로그인에 실패헸습니다.");
                    }
                }
                else
                {
                    int num3 = (int)MessageBox.Show("로그인에 실패헸습니다.");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("시스템 접속 중 오류 발생!");
            }
        }

        public bool Check_DBConnection(string sConn)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = sConn;
                    sqlConnection.Open();
                    sqlConnection.Close();
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
            return true;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.lbl등록업체.Text = "0";
            this.lbl사용업체.Text = "0";
            this.lbl실사용자.Text = "0";
            this.lbl모바일수.Text = "0";
            this.get_Total_Comp();
            this.get_Using_Comp();
            this.get_Using_Member();
            this.get_Using_Member_mobile();
        }

        private void get_Total_Comp()
        {
            try
            {
                DataTable dataTable = new wnDm().root_업체정보_List("", Common.p_strConnMain);
                if (dataTable == null || dataTable.Rows.Count <= 0)
                    return;
                this.lbl등록업체.Text = dataTable.Rows.Count.ToString("#,0");
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }

        private void get_Using_Comp()
        {
            try
            {
                DataTable dataTable = new wnDm().root_업체정보_List(" and a.사업자번호 in (select 사업자번호 from T_로그인일시 where 로그인일시 >= '" + this.dtpDay.Text + " 00:00:00') ", Common.p_strConnMain);
                if (dataTable == null || dataTable.Rows.Count <= 0)
                    return;
                this.lbl사용업체.Text = dataTable.Rows.Count.ToString("#,0");
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }

        private void get_Using_Member()
        {
            try
            {
                DataTable dataTable = new wnDm().root_로그인일시_List(" and a.로그인일시 >= '" + this.dtpDay.Text + " 00:00:00' ", Common.p_strConnMain);
                if (dataTable == null || dataTable.Rows.Count <= 0)
                    return;
                this.lbl실사용자.Text = dataTable.Rows.Count.ToString("#,0");
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }

        private void get_Using_Member_mobile()
        {
            try
            {
                DataTable dataTable = new wnDm().root_로그인일시_List(" and a.로그인일시 >= '" + this.dtpDay.Text + " 00:00:00' and a.입력방법 = 'M' ", Common.p_strConnMain);
                if (dataTable == null || dataTable.Rows.Count <= 0)
                    return;
                this.lbl모바일수.Text = dataTable.Rows.Count.ToString("#,0");
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackRoot));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panCenter = new System.Windows.Forms.Panel();
            this.cmbS수량등록방식 = new smartMain.Controls.conComboBox();
            this.chk계란 = new System.Windows.Forms.CheckBox();
            this.btnView = new System.Windows.Forms.Button();
            this.dtpDay = new smartMain.Controls.conDateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl모바일수 = new System.Windows.Forms.Label();
            this.lbl실사용자 = new System.Windows.Forms.Label();
            this.lbl사용업체 = new System.Windows.Forms.Label();
            this.lbl등록업체 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.butOut = new System.Windows.Forms.Button();
            this.txtCompID = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.nowTextSelect = new smartMain.Controls.conTextBox();
            this.butSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.grdComp = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTile01 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdComp)).BeginInit();
            this.SuspendLayout();
            // 
            // panCenter
            // 
            this.panCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panCenter.Controls.Add(this.cmbS수량등록방식);
            this.panCenter.Controls.Add(this.chk계란);
            this.panCenter.Controls.Add(this.btnView);
            this.panCenter.Controls.Add(this.dtpDay);
            this.panCenter.Controls.Add(this.label10);
            this.panCenter.Controls.Add(this.lbl모바일수);
            this.panCenter.Controls.Add(this.lbl실사용자);
            this.panCenter.Controls.Add(this.lbl사용업체);
            this.panCenter.Controls.Add(this.lbl등록업체);
            this.panCenter.Controls.Add(this.label8);
            this.panCenter.Controls.Add(this.label6);
            this.panCenter.Controls.Add(this.label4);
            this.panCenter.Controls.Add(this.label1);
            this.panCenter.Controls.Add(this.button6);
            this.panCenter.Controls.Add(this.button5);
            this.panCenter.Controls.Add(this.button3);
            this.panCenter.Controls.Add(this.button4);
            this.panCenter.Controls.Add(this.butOut);
            this.panCenter.Controls.Add(this.txtCompID);
            this.panCenter.Controls.Add(this.button2);
            this.panCenter.Controls.Add(this.nowTextSelect);
            this.panCenter.Controls.Add(this.butSearch);
            this.panCenter.Controls.Add(this.label2);
            this.panCenter.Controls.Add(this.grdComp);
            this.panCenter.Controls.Add(this.button1);
            this.panCenter.Controls.Add(this.btnTile01);
            this.panCenter.Location = new System.Drawing.Point(6, 5);
            this.panCenter.Name = "panCenter";
            this.panCenter.Size = new System.Drawing.Size(1283, 603);
            this.panCenter.TabIndex = 99;
            // 
            // cmbS수량등록방식
            // 
            this.cmbS수량등록방식._BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmbS수량등록방식._FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbS수량등록방식.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbS수량등록방식.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbS수량등록방식.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbS수량등록방식.FormattingEnabled = true;
            this.cmbS수량등록방식.Location = new System.Drawing.Point(833, 38);
            this.cmbS수량등록방식.Name = "cmbS수량등록방식";
            this.cmbS수량등록방식.Size = new System.Drawing.Size(70, 21);
            this.cmbS수량등록방식.TabIndex = 3;
            // 
            // chk계란
            // 
            this.chk계란.AutoSize = true;
            this.chk계란.Location = new System.Drawing.Point(767, 40);
            this.chk계란.Name = "chk계란";
            this.chk계란.Size = new System.Drawing.Size(60, 16);
            this.chk계란.TabIndex = 2;
            this.chk계란.Text = "계란업";
            this.chk계란.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnView.BackColor = System.Drawing.Color.Transparent;
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.Location = new System.Drawing.Point(744, 581);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(36, 21);
            this.btnView.TabIndex = 111;
            this.btnView.Tag = "검색";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // dtpDay
            // 
            this.dtpDay._BorderColor = System.Drawing.Color.PowderBlue;
            this.dtpDay._FocusedBackColor = System.Drawing.Color.White;
            this.dtpDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDay.Location = new System.Drawing.Point(550, 581);
            this.dtpDay.Name = "dtpDay";
            this.dtpDay.Size = new System.Drawing.Size(85, 21);
            this.dtpDay.TabIndex = 110;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(641, 587);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 12);
            this.label10.TabIndex = 109;
            this.label10.Text = "이후 로그인 기준";
            // 
            // lbl모바일수
            // 
            this.lbl모바일수.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl모바일수.AutoSize = true;
            this.lbl모바일수.Location = new System.Drawing.Point(483, 587);
            this.lbl모바일수.Name = "lbl모바일수";
            this.lbl모바일수.Size = new System.Drawing.Size(11, 12);
            this.lbl모바일수.TabIndex = 109;
            this.lbl모바일수.Text = "0";
            // 
            // lbl실사용자
            // 
            this.lbl실사용자.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl실사용자.AutoSize = true;
            this.lbl실사용자.Location = new System.Drawing.Point(347, 587);
            this.lbl실사용자.Name = "lbl실사용자";
            this.lbl실사용자.Size = new System.Drawing.Size(11, 12);
            this.lbl실사용자.TabIndex = 109;
            this.lbl실사용자.Text = "0";
            // 
            // lbl사용업체
            // 
            this.lbl사용업체.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl사용업체.AutoSize = true;
            this.lbl사용업체.Location = new System.Drawing.Point(206, 587);
            this.lbl사용업체.Name = "lbl사용업체";
            this.lbl사용업체.Size = new System.Drawing.Size(11, 12);
            this.lbl사용업체.TabIndex = 109;
            this.lbl사용업체.Text = "0";
            // 
            // lbl등록업체
            // 
            this.lbl등록업체.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl등록업체.AutoSize = true;
            this.lbl등록업체.Location = new System.Drawing.Point(71, 587);
            this.lbl등록업체.Name = "lbl등록업체";
            this.lbl등록업체.Size = new System.Drawing.Size(11, 12);
            this.lbl등록업체.TabIndex = 109;
            this.lbl등록업체.Text = "0";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(412, 587);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 108;
            this.label8.Text = "모바일 수 :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(276, 587);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 108;
            this.label6.Text = "실 사용자 :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(139, 587);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 12);
            this.label4.TabIndex = 108;
            this.label4.Text = "사용업체 :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(4, 587);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 12);
            this.label1.TabIndex = 108;
            this.label1.Text = "등록업체 :";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(414, 143);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(130, 130);
            this.button6.TabIndex = 107;
            this.button6.Tag = "Z1관리자.frm업체별잔고재고";
            this.button6.Text = "업체별 잔고재고";
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Teal;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(5, 279);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(130, 130);
            this.button5.TabIndex = 108;
            this.button5.Tag = "Z1관리자.frm공지사항관리";
            this.button5.Text = "공지사항 관리";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(142, 143);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 130);
            this.button3.TabIndex = 105;
            this.button3.Tag = "Z1관리자.frm구장터변환";
            this.button3.Text = "장터지기 변환";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(6, 143);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 130);
            this.button4.TabIndex = 104;
            this.button4.Tag = "Z1관리자.frm폰번호검색";
            this.button4.Text = "폰번호 검색";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // butOut
            // 
            this.butOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butOut.BackColor = System.Drawing.Color.MistyRose;
            this.butOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butOut.FlatAppearance.BorderColor = System.Drawing.Color.LightSalmon;
            this.butOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.butOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.butOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butOut.ForeColor = System.Drawing.Color.Black;
            this.butOut.Image = ((System.Drawing.Image)(resources.GetObject("butOut.Image")));
            this.butOut.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOut.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.butOut.Location = new System.Drawing.Point(1212, 33);
            this.butOut.Name = "butOut";
            this.butOut.Size = new System.Drawing.Size(65, 29);
            this.butOut.TabIndex = 20;
            this.butOut.Tag = "종료";
            this.butOut.Text = "복귀";
            this.butOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOut.UseVisualStyleBackColor = false;
            this.butOut.Click += new System.EventHandler(this.butOut_Click);
            // 
            // txtCompID
            // 
            this.txtCompID.Location = new System.Drawing.Point(799, 11);
            this.txtCompID.Name = "txtCompID";
            this.txtCompID.Size = new System.Drawing.Size(43, 21);
            this.txtCompID.TabIndex = 0;
            this.txtCompID.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(141, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 130);
            this.button2.TabIndex = 99;
            this.button2.Tag = "Z1관리자.frm엑셀변환";
            this.button2.Text = "엑셀 변환";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.menuButton_Click);
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
            this.nowTextSelect.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.nowTextSelect.Location = new System.Drawing.Point(590, 38);
            this.nowTextSelect.MaxLength = 50;
            this.nowTextSelect.Name = "nowTextSelect";
            this.nowTextSelect.Size = new System.Drawing.Size(171, 22);
            this.nowTextSelect.TabIndex = 1;
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
            this.butSearch.Location = new System.Drawing.Point(932, 31);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(33, 33);
            this.butSearch.TabIndex = 10;
            this.butSearch.Tag = "검색";
            this.butSearch.UseVisualStyleBackColor = false;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(214)))), ((int)(((byte)(249)))));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(590, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(687, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "사업자 CEO 권한으로 로그인하기";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdComp
            // 
            this.grdComp.AllowUserToAddRows = false;
            this.grdComp.AllowUserToDeleteRows = false;
            this.grdComp.AllowUserToOrderColumns = true;
            this.grdComp.AllowUserToResizeColumns = false;
            this.grdComp.AllowUserToResizeRows = false;
            this.grdComp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdComp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdComp.BackgroundColor = System.Drawing.Color.White;
            this.grdComp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(239)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(181)))), ((int)(((byte)(189)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdComp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdComp.ColumnHeadersHeight = 30;
            this.grdComp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn33,
            this.dataGridViewTextBoxColumn34,
            this.Column3,
            this.dataGridViewTextBoxColumn35,
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column4});
            this.grdComp.EnableHeadersVisualStyles = false;
            this.grdComp.GridColor = System.Drawing.Color.PowderBlue;
            this.grdComp.Location = new System.Drawing.Point(590, 66);
            this.grdComp.Name = "grdComp";
            this.grdComp.ReadOnly = true;
            this.grdComp.RowHeadersVisible = false;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.grdComp.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.grdComp.RowTemplate.Height = 23;
            this.grdComp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdComp.Size = new System.Drawing.Size(687, 495);
            this.grdComp.TabIndex = 11;
            this.grdComp.DoubleClick += new System.EventHandler(this.grdComp_DoubleClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(5, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 130);
            this.button1.TabIndex = 98;
            this.button1.Tag = "Z1관리자.frm업체등록";
            this.button1.Text = "업체 등록";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // btnTile01
            // 
            this.btnTile01.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnTile01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTile01.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTile01.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.btnTile01.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTile01.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTile01.ForeColor = System.Drawing.Color.White;
            this.btnTile01.Location = new System.Drawing.Point(414, 7);
            this.btnTile01.Name = "btnTile01";
            this.btnTile01.Size = new System.Drawing.Size(130, 130);
            this.btnTile01.TabIndex = 100;
            this.btnTile01.Tag = "Z1관리자.frm데이터베이스";
            this.btnTile01.Text = "DB 관리";
            this.btnTile01.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTile01.UseVisualStyleBackColor = false;
            this.btnTile01.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "사업자번호";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "상호명";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 190;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "대표자";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.HeaderText = "사업자번호";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.FillWeight = 150F;
            this.dataGridViewTextBoxColumn34.HeaderText = "상호명";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "별칭";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.HeaderText = "대표자";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "대표아이디";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "DBConn";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column5
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column5.FillWeight = 70F;
            this.Column5.HeaderText = "수량방식";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column4.HeaderText = "최종로그인";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // frmBackRoot
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1301, 620);
            this.Controls.Add(this.panCenter);
            this.Name = "frmBackRoot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmBackAdmin";
            this.Load += new System.EventHandler(this.frmBackAdmin_Load);
            this.Resize += new System.EventHandler(this.frmBackAdmin_Resize);
            this.panCenter.ResumeLayout(false);
            this.panCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdComp)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
