using System;
using smartMain.CLS;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using smartMain;

namespace 단가정리
{
    public partial class frm단가정리 : Form
    {
        private int iCnt;
        private string strValue;
        private bool bData = false;
        private string s구분 = "3";
        private wnGConstant wConst = new wnGConstant();
        private string sqlQuery = "";
        private bool bEditText = false;
        



        public frm단가정리()
        {
            InitializeComponent();
            Common.p_strConn = "DATA SOURCE = " + "218.38.14.33,14332".ToString()
                + ";INITIAL CATALOG = " + "test".ToString()
                + ";PERSIST SECURITY INFO = false;USER ID = " + "sa".ToString()
                + ";PASSWORD = " + "##wkdxj123".ToString() + ";";


        }

        private void frm단가정리_Load(object sender, EventArgs e)
        {
           /* this.spCont.Dock = DockStyle.Fill;
            this.panData1.Dock = DockStyle.Fill;
            this.panData2.Dock = DockStyle.Fill;
            this.panData4.Dock = DockStyle.Fill;
            this.panData5.Dock = DockStyle.Fill;*/
            this.cmbS사입품.Items.Clear();
            this.cmbS사입품.Items.Add((object)"(전체)");
            this.cmbS사입품.Items.Add((object)"상품만");
            this.cmbS사입품.Items.Add((object)"사입품만");
            this.cmbS사입품.SelectedIndex = 1;
            if (Common.p_strBox == "1")
            {
                this.GridRecord.Columns[1].Width += this.GridRecord.Columns[3].Width;
                this.GridRecord.Columns[2].Width += this.GridRecord.Columns[4].Width;
                this.GridRecord.Columns[3].Visible = false;
                this.GridRecord.Columns[4].Visible = false;
                this.GridRecord.Columns[5].HeaderText = "단가";
            }
            if (Common.p_strBox == "2")
            {
                this.GridRecord.Columns[1].Width += this.GridRecord.Columns[4].Width;
                this.GridRecord.Columns[2].Width += this.GridRecord.Columns[5].Width;
                this.GridRecord.Columns[3].HeaderText = "단가";
                this.GridRecord.Columns[4].Visible = false;
                this.GridRecord.Columns[5].Visible = false;
            }
            if (Common.p_strBox == "3")
                this.lbl단가.Text = "낱개단가";
            this.init_InputBox(true);
            this.bindData(this.makeSearchCondition());
            
        }

        private string makeSearchCondition()
        {
            StringBuilder stringBuilder = new StringBuilder();
            switch (this.txtS거래처코드.Text)
            {
                case "":
                    stringBuilder.Append("");
                    break;
                default:
                    stringBuilder.Append(" and a.거래처코드 = '" + this.txtS거래처코드.Text + "' ");
                    break;
            }
            switch (this.cmbS사입품.SelectedIndex)
            {
                case 1:
                    stringBuilder.Append(" and isnull(b.사입품, 'N') = 'N' ");
                    break;
                case 2:
                    stringBuilder.Append(" and isnull(b.사입품, 'N') = 'Y' ");
                    break;
                default:
                    stringBuilder.Append("");
                    break;
            }
            return stringBuilder.ToString();
        }

        private void bindData(string condition)
        {
            this.GridRecord.RowCount = 0;
            this.GridRecord.DataSource = (object)null;
            if (this.txtS거래처코드.Text == "")
                return;
            try
            {
                DataTable dataTable = new wnDm().fn_매출단가표_List(condition, Common.p_strConn);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    this.GridRecord.RowCount = dataTable.Rows.Count;
                    for (int index = 0; index < dataTable.Rows.Count; ++index)
                    {
                        this.GridRecord.Rows[index].Cells[0].Value = (object)dataTable.Rows[index]["상품코드"].ToString();
                        this.GridRecord.Rows[index].Cells[1].Value = (object)dataTable.Rows[index]["상품명"].ToString();
                        this.GridRecord.Rows[index].Cells[2].Value = (object)dataTable.Rows[index]["규격"].ToString();
                        DataGridViewCell cell1 = this.GridRecord.Rows[index].Cells[3];
                        Decimal num = Decimal.Parse(dataTable.Rows[index]["박스단가"].ToString());
                        string str1 = num.ToString(Common.p_strFormatUnit);
                        cell1.Value = (object)str1;
                        DataGridViewCell cell2 = this.GridRecord.Rows[index].Cells[4];
                        num = Decimal.Parse(dataTable.Rows[index]["중간단가"].ToString());
                        string str2 = num.ToString(Common.p_strFormatUnit);
                        cell2.Value = (object)str2;
                        DataGridViewCell cell3 = this.GridRecord.Rows[index].Cells[5];
                        num = Decimal.Parse(dataTable.Rows[index]["낱개단가"].ToString());
                        string str3 = num.ToString(Common.p_strFormatUnit);
                        cell3.Value = (object)str3;
                    }
                }
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }

        private void init_InputBox(bool bNew)
        {
            this.wConst.Form_Clear(this.spCont.Panel1.Controls);
            this.txt명칭.Enabled = true;
            this.btn거래처.Enabled = true;
            this.txt상품.Enabled = true;
            this.btn상품.Enabled = true;
            if (bNew)
            {
                this.bData = false;
                this.butDelete.Enabled = false;
            }
            else
            {
                this.bData = true;
                this.butDelete.Enabled = true;
                this.txt명칭.Enabled = false;
                this.btn거래처.Enabled = false;
                this.txt상품.Enabled = false;
                this.btn상품.Enabled = false;
            }
        }

        private void getDetailPost(string sCust, string sProd)
        {
            this.init_InputBox(false);
            try
            {
                DataTable dataTable = new wnDm().fn_매출단가표_Detail(sCust, sProd, Common.p_strConn);
                if (dataTable == null || dataTable.Rows.Count <= 0)
                    return;
                this.txt코드.Text = dataTable.Rows[0]["거래처코드"].ToString();
                this.bEditText = false;
                this.txt명칭.Text = dataTable.Rows[0]["거래처명"].ToString();
                this.txt상품코드.Text = dataTable.Rows[0]["상품코드"].ToString();
                this.txt상품.Text = dataTable.Rows[0]["상품명"].ToString();
                this.lbl규격.Text = dataTable.Rows[0]["규격"].ToString();
                if (Common.p_strBox == "2")
                    this.txt단가.Text = Decimal.Parse(dataTable.Rows[0]["박스단가"].ToString()).ToString(Common.p_strFormatUnit);
                else
                    this.txt단가.Text = Decimal.Parse(dataTable.Rows[0]["낱개단가"].ToString()).ToString(Common.p_strFormatUnit);
                this.txt박스입고단가.Text = Decimal.Parse(dataTable.Rows[0]["박스입고단가"].ToString()).ToString(Common.p_strFormatUnit);
                this.txt낱개입고단가.Text = Decimal.Parse(dataTable.Rows[0]["낱개입고단가"].ToString()).ToString(Common.p_strFormatUnit);
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }

        private bool validate_InputBox()
        {
            bool flag = true;
            try
            {
                if (this.txt코드.Text == "")
                {
                    int num = (int)MessageBox.Show("[ 매출처 ] 를 입력하세요.");
                    return false;
                }
                if (this.txt상품코드.Text == "")
                {
                    int num = (int)MessageBox.Show("[ 상품 ] 을 입력하세요.");
                    return false;
                }
                if (this.txt단가.Text == "")
                {
                    int num = (int)MessageBox.Show("[ 단가 ] 를 입력하세요.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
                int num = (int)MessageBox.Show("입력 데이터 확인 중에 오류가 있습니다.");
            }
            return flag;
        }

        private bool insertPost()
        {
            if (!this.validate_InputBox())
                return false;
            bool flag = false;
            try
            {
                wnAdo wnAdo = new wnAdo();
                if (this.get_Dup_Check(this.txt코드.Text, this.txt상품코드.Text))
                {
                    int num = (int)MessageBox.Show("이미 존재하는 상품의 단가이력입니다. [ " + this.txt상품.Text + " ]");
                    return flag;
                }
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(" declare @cnt as int ");
                stringBuilder.AppendLine(" declare @박스입고단가 as float ");
                stringBuilder.AppendLine(" declare @낱개입고단가 as float ");
                stringBuilder.AppendLine(" select @cnt = count(*) from T_매출단가표 ");
                stringBuilder.AppendLine(" where 사업자번호 = '" + Common.p_strCompID + "' ");
                stringBuilder.AppendLine("     and 지점코드 = @지점코드  ");
                stringBuilder.AppendLine("     and 거래처코드 = @p1 ");
                stringBuilder.AppendLine("     and 상품코드 = @p2 ");
                stringBuilder.AppendLine("     and 매출일자 = @p3 ");
                stringBuilder.AppendLine(" if (@cnt = 0) ");
                stringBuilder.AppendLine(" begin ");
                stringBuilder.AppendLine("     set @박스입고단가 = NULL ");
                stringBuilder.AppendLine("     select top 1 @박스입고단가 = 박스입고단가, @낱개입고단가 = 낱개입고단가 from T_매출단가표 ");
                stringBuilder.AppendLine("     where 사업자번호 = '" + Common.p_strCompID + "' ");
                stringBuilder.AppendLine("         and 지점코드 = @지점코드  ");
                stringBuilder.AppendLine("         and 거래처코드 = @p1 ");
                stringBuilder.AppendLine("         and 상품코드 = @p2 ");
                stringBuilder.AppendLine("         and 매출일자 <= @p3 ");
                stringBuilder.AppendLine("     order by 매출일자 desc ");
                stringBuilder.AppendLine("     if (@박스입고단가 is NULL) ");
                stringBuilder.AppendLine("     begin ");
                stringBuilder.AppendLine("         select @박스입고단가 = 박스입고단가, @낱개입고단가 = 낱개입고단가 from T_상품정보 ");
                stringBuilder.AppendLine("         where 사업자번호 = '" + Common.p_strCompID + "' ");
                stringBuilder.AppendLine("             and 지점코드 = @지점코드  ");
                stringBuilder.AppendLine("             and 상품코드 = @p2 ");
                stringBuilder.AppendLine("     end ");
                stringBuilder.AppendLine("     insert into T_매출단가표 ( ");
                stringBuilder.AppendLine("         사업자번호 ");
                stringBuilder.AppendLine("         , 지점코드 ");
                stringBuilder.AppendLine("         , 거래처코드 ");
                stringBuilder.AppendLine("         , 상품코드 ");
                stringBuilder.AppendLine("         , 매출일자 ");
                stringBuilder.AppendLine("         , 박스수량 ");
                stringBuilder.AppendLine("         , 중간수량 ");
                stringBuilder.AppendLine("         , 낱개수량 ");
                stringBuilder.AppendLine("         , 총수량 ");
                stringBuilder.AppendLine("         , 박스단가 ");
                stringBuilder.AppendLine("         , 낱개단가 ");
                stringBuilder.AppendLine("         , 박스입고단가 ");
                stringBuilder.AppendLine("         , 낱개입고단가 ");
                stringBuilder.AppendLine("     ) values ( ");
                stringBuilder.AppendLine("         '" + Common.p_strCompID + "' ");
                stringBuilder.AppendLine("         , @지점코드  ");
                stringBuilder.AppendLine("         , @p1 ");
                stringBuilder.AppendLine("         , @p2 ");
                stringBuilder.AppendLine("         , @p3 ");
                stringBuilder.AppendLine("         , 0 ");
                stringBuilder.AppendLine("         , 0 ");
                stringBuilder.AppendLine("         , 0 ");
                stringBuilder.AppendLine("         , 0 ");
                stringBuilder.AppendLine("         , @박스단가 ");
                stringBuilder.AppendLine("         , @낱개단가 ");
                stringBuilder.AppendLine("         , @박스입고단가 ");
                stringBuilder.AppendLine("         , @낱개입고단가 ");
                stringBuilder.AppendLine("     )  ");
                stringBuilder.AppendLine(" end ");
                stringBuilder.AppendLine(" else ");
                stringBuilder.AppendLine(" begin ");
                stringBuilder.AppendLine("     update T_매출단가표 set ");
                stringBuilder.AppendLine("         박스단가 = @박스단가 ");
                stringBuilder.AppendLine("         , 낱개단가 = @낱개단가 ");
                stringBuilder.AppendLine("     where 사업자번호 = '" + Common.p_strCompID + "' ");
                stringBuilder.AppendLine("         and 지점코드 = @지점코드  ");
                stringBuilder.AppendLine("         and 거래처코드 = @p1 ");
                stringBuilder.AppendLine("         and 상품코드 = @p2 ");
                stringBuilder.AppendLine("         and 매출일자 = @p3 ");
                stringBuilder.AppendLine(" end ");
                SqlCommand sCommand = new SqlCommand(stringBuilder.ToString());
                sCommand.Parameters.AddWithValue("@지점코드", (object)Common.p_strSpotCode);
                sCommand.Parameters.AddWithValue("@p1", (object)this.txt코드.Text);
                sCommand.Parameters.AddWithValue("@p2", (object)this.txt상품코드.Text);
                sCommand.Parameters.AddWithValue("@p3", (object)DateTime.Now.ToString("yyyy-MM-dd"));
                if (Common.p_strBox == "2")
                {
                    sCommand.Parameters.AddWithValue("@박스단가", (object)this.txt단가.Text.Replace(",", ""));
                    sCommand.Parameters.AddWithValue("@낱개단가", (object)"0");
                }
                else
                {
                    sCommand.Parameters.AddWithValue("@박스단가", (object)"0");
                    sCommand.Parameters.AddWithValue("@낱개단가", (object)this.txt단가.Text.Replace(",", ""));
                }
                flag = wnAdo.SqlCommandEtc(sCommand, "Insert_매출단가표_Table", Common.p_strConn) > 0;
                if (!flag)
                {
                    int num1 = (int)MessageBox.Show("저장 중에 오류가 발생했습니다.");
                }
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
                int num = (int)MessageBox.Show("데이터베이스에 문제가 발생했습니다.");
            }
            return flag;
        }

        private bool updatePost()
        {
            if (!this.validate_InputBox())
                return false;
            bool flag = false;
            try
            {
                wnAdo wnAdo = new wnAdo();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(" declare @cnt as int ");
                stringBuilder.AppendLine(" declare @박스입고단가 as float ");
                stringBuilder.AppendLine(" declare @낱개입고단가 as float ");
                stringBuilder.AppendLine(" select @cnt = count(*) from T_매출단가표 ");
                stringBuilder.AppendLine(" where 사업자번호 = '" + Common.p_strCompID + "' ");
                stringBuilder.AppendLine("     and 지점코드 = @지점코드  ");
                stringBuilder.AppendLine("     and 거래처코드 = @p1 ");
                stringBuilder.AppendLine("     and 상품코드 = @p2 ");
                stringBuilder.AppendLine("     and 매출일자 = @p3 ");
                stringBuilder.AppendLine(" if (@cnt = 0) ");
                stringBuilder.AppendLine(" begin ");
                stringBuilder.AppendLine("     set @박스입고단가 = NULL ");
                stringBuilder.AppendLine("     select top 1 @박스입고단가 = 박스입고단가, @낱개입고단가 = 낱개입고단가 from T_매출단가표 ");
                stringBuilder.AppendLine("     where 사업자번호 = '" + Common.p_strCompID + "' ");
                stringBuilder.AppendLine("         and 지점코드 = @지점코드  ");
                stringBuilder.AppendLine("         and 거래처코드 = @p1 ");
                stringBuilder.AppendLine("         and 상품코드 = @p2 ");
                stringBuilder.AppendLine("         and 매출일자 <= @p3 ");
                stringBuilder.AppendLine("     order by 매출일자 desc ");
                stringBuilder.AppendLine("     if (@박스입고단가 is NULL) ");
                stringBuilder.AppendLine("     begin ");
                stringBuilder.AppendLine("         select @박스입고단가 = 박스입고단가, @낱개입고단가 = 낱개입고단가 from T_상품정보 ");
                stringBuilder.AppendLine("         where 사업자번호 = '" + Common.p_strCompID + "' ");
                stringBuilder.AppendLine("             and 지점코드 = @지점코드  ");
                stringBuilder.AppendLine("             and 상품코드 = @p2 ");
                stringBuilder.AppendLine("     end ");
                stringBuilder.AppendLine("     insert into T_매출단가표 ( ");
                stringBuilder.AppendLine("         사업자번호 ");
                stringBuilder.AppendLine("         , 지점코드 ");
                stringBuilder.AppendLine("         , 거래처코드 ");
                stringBuilder.AppendLine("         , 상품코드 ");
                stringBuilder.AppendLine("         , 매출일자 ");
                stringBuilder.AppendLine("         , 박스수량 ");
                stringBuilder.AppendLine("         , 중간수량 ");
                stringBuilder.AppendLine("         , 낱개수량 ");
                stringBuilder.AppendLine("         , 총수량 ");
                stringBuilder.AppendLine("         , 박스단가 ");
                stringBuilder.AppendLine("         , 낱개단가 ");
                stringBuilder.AppendLine("         , 박스입고단가 ");
                stringBuilder.AppendLine("         , 낱개입고단가 ");
                stringBuilder.AppendLine("     ) values ( ");
                stringBuilder.AppendLine("         '" + Common.p_strCompID + "' ");
                stringBuilder.AppendLine("         , @지점코드  ");
                stringBuilder.AppendLine("         , @p1 ");
                stringBuilder.AppendLine("         , @p2 ");
                stringBuilder.AppendLine("         , @p3 ");
                stringBuilder.AppendLine("         , 0 ");
                stringBuilder.AppendLine("         , 0 ");
                stringBuilder.AppendLine("         , 0 ");
                stringBuilder.AppendLine("         , 0 ");
                stringBuilder.AppendLine("         , @박스단가 ");
                stringBuilder.AppendLine("         , @낱개단가 ");
                stringBuilder.AppendLine("         , @박스입고단가 ");
                stringBuilder.AppendLine("         , @낱개입고단가 ");
                stringBuilder.AppendLine("     )  ");
                stringBuilder.AppendLine(" end ");
                stringBuilder.AppendLine(" else ");
                stringBuilder.AppendLine(" begin ");
                stringBuilder.AppendLine("     update T_매출단가표 set ");
                stringBuilder.AppendLine("         박스단가 = @박스단가 ");
                stringBuilder.AppendLine("         , 낱개단가 = @낱개단가 ");
                stringBuilder.AppendLine("     where 사업자번호 = '" + Common.p_strCompID + "' ");
                stringBuilder.AppendLine("         and 지점코드 = @지점코드  ");
                stringBuilder.AppendLine("         and 거래처코드 = @p1 ");
                stringBuilder.AppendLine("         and 상품코드 = @p2 ");
                stringBuilder.AppendLine("         and 매출일자 = @p3 ");
                stringBuilder.AppendLine(" end ");
                SqlCommand sCommand = new SqlCommand(stringBuilder.ToString());
                sCommand.Parameters.AddWithValue("@지점코드", (object)Common.p_strSpotCode);
                sCommand.Parameters.AddWithValue("@p1", (object)this.txt코드.Text);
                sCommand.Parameters.AddWithValue("@p2", (object)this.txt상품코드.Text);
                sCommand.Parameters.AddWithValue("@p3", (object)DateTime.Now.ToString("yyyy-MM-dd"));
                if (Common.p_strBox == "2")
                {
                    sCommand.Parameters.AddWithValue("@박스단가", (object)this.txt단가.Text.Replace(",", ""));
                    sCommand.Parameters.AddWithValue("@낱개단가", (object)"0");
                }
                else
                {
                    sCommand.Parameters.AddWithValue("@박스단가", (object)"0");
                    sCommand.Parameters.AddWithValue("@낱개단가", (object)this.txt단가.Text.Replace(",", ""));
                }
                flag = wnAdo.SqlCommandEtc(sCommand, "Save_매출단가표_Table", Common.p_strConn) > 0;
                if (!flag)
                {
                    int num = (int)MessageBox.Show("저장 중에 오류가 발생했습니다.");
                }
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
                int num = (int)MessageBox.Show("데이터베이스에 문제가 발생했습니다.");
            }
            return flag;
        }

        private bool deletePost()
        {
            bool flag = false;
            try
            {
                wnDm wnDm = new wnDm();
                wnAdo wnAdo = new wnAdo();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(" delete from T_매출단가표 ");
                stringBuilder.AppendLine(" where 사업자번호 = '" + Common.p_strCompID + "' ");
                stringBuilder.AppendLine("     and 지점코드 = @지점코드  ");
                stringBuilder.AppendLine("     and 거래처코드 = @p1 ");
                stringBuilder.AppendLine("     and 상품코드 = @p2 ");
                stringBuilder.AppendLine(" delete from T_매출행사단가표 ");
                stringBuilder.AppendLine(" where 사업자번호 = '" + Common.p_strCompID + "' ");
                stringBuilder.AppendLine("     and 지점코드 = @지점코드  ");
                stringBuilder.AppendLine("     and 거래처코드 = @p1 ");
                stringBuilder.AppendLine("     and 상품코드 = @p2 ");
                SqlCommand sCommand = new SqlCommand(stringBuilder.ToString());
                sCommand.Parameters.AddWithValue("@지점코드", (object)Common.p_strSpotCode);
                sCommand.Parameters.AddWithValue("@p1", (object)this.txt코드.Text);
                sCommand.Parameters.AddWithValue("@p2", (object)this.txt상품코드.Text);
                flag = wnAdo.SqlCommandEtc(sCommand, "Delete_매출단가표_Table", Common.p_strConn) > 0;
                if (!flag)
                {
                    int num = (int)MessageBox.Show("삭제 중에 오류가 발생했습니다.");
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("데이터베이스에 문제가 발생했습니다.");
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
            return flag;
        }

        private bool get_Dup_Check(string sCust, string sProd)
        {
            try
            {
                DataTable dataTable = new wnDm().fn_매출단가표_Detail(sCust, sProd, Common.p_strConn);
                return dataTable != null && dataTable.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
                return true;
            }
        }


        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            this.init_InputBox(true);
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            this.butSave.Enabled = false;
            if (this.bData ? this.updatePost() : this.insertPost())
            {
                this.butSearch_Click((object)this, (EventArgs)null);
                this.butNew_Click((object)this, (EventArgs)null);
            }
            this.butSave.Enabled = true;
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("자료를 삭제하시겠습니까?", "삭제여부", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel || !this.deletePost())
                return;
            this.init_InputBox(true);
            this.bindData(this.makeSearchCondition());
            
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            this.init_InputBox(true);
            this.bindData(this.makeSearchCondition());
        }

        private void inputLast_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
            e.Handled = true;
            this.butSave.Focus();
        }

        private void GridRecord_DoubleClick(object sender, EventArgs e)
        {
            if (this.GridRecord.CurrentCell == null || this.GridRecord.CurrentCell.RowIndex < 0 || this.GridRecord.CurrentCell.ColumnIndex < 0)
                return;
            this.iCnt = this.GridRecord.CurrentCell.RowIndex;
            this.strValue = (string)this.GridRecord.Rows[this.iCnt].Cells[0].Value ?? "";
            this.getDetailPost(this.txtS거래처코드.Text, this.strValue);
           
        }

        private void GridRecord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                this.GridRecord_DoubleClick((object)this, (EventArgs)null);
            }
            if (e.KeyCode != Keys.Escape)
                return;
            e.Handled = true;
            this.txtS거래처.Focus();
        }




    }



   

}
