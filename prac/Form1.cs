using smartMain;
using smartMain.CLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prac
{
    public partial class Form장비등록 : Form
    {
        private SplitContainer spCont;
        private wnGConstant wConst = new wnGConstant();
        private string sqlQuery = "";
        private bool bData = false;
        private int iCnt;
        private Timer tmFocusList;
        private Timer tmFocusNew;
        private string strValue;

        public Form장비등록(){
           this.InitializeComponent();
            Common.p_strConn = "DATA SOURCE = " + "218.38.14.33,14332".ToString()
                 + ";INITIAL CATALOG = " + "test".ToString()
                 + ";PERSIST SECURITY INFO = false;USER ID = " +"sa".ToString()
                 + ";PASSWORD = " + "##wkdxj123".ToString() + ";";
                }

        private string makeSearchCondition()
        {
            StringBuilder stringBuilder = new StringBuilder();
            switch (this.SearchText.Text)
            {
                case "":
                    stringBuilder.Append("");
                    break;
                default:
                    stringBuilder.Append(" and a.장비명 like '" + this.SearchText.Text + "%' ");
                    break;
            }
            return stringBuilder.ToString();
        }

        private void init_InputBox(bool bNew)
        {
            this.wConst.Form_Clear(this.panel3.Controls);
            if (bNew)
            {
                this.bData = false;
                this.delete_btn.Enabled = false;
                this.textCode.Enabled = true;
            }
            else
            {
                this.bData = true;
                this.delete_btn.Enabled = true;
                this.textCode.Enabled = false;
            }
        }

        private void bindData(string condition)
        {
            this.GridView.RowCount = 0;
            this.GridView.DataSource = (object)null;
            try
            {
                DataTable dataTable = new wnDm().fn_장비_List(condition, Common.p_strConn);
                if (dataTable == null || dataTable.Rows.Count <= 0)
                    return;
                this.GridView.RowCount = dataTable.Rows.Count;
                for (int index = 0; index < dataTable.Rows.Count; ++index)
                {
                    this.GridView.Rows[index].Cells[0].Value = (object)dataTable.Rows[index]["장비코드"].ToString();
                    this.GridView.Rows[index].Cells[1].Value = (object)dataTable.Rows[index]["장비명"].ToString();
                    this.GridView.Rows[index].Cells[2].Value = (object)dataTable.Rows[index]["규격"].ToString();
                    this.GridView.Rows[index].Cells[3].Value = (object)dataTable.Rows[index]["비고"].ToString();
                }
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }

        private bool insertPost()
        {
            bool flag = false;
            try
            {
                wnAdo wnAdo = new wnAdo();
                if (this.get_Dup_Check(this.textCode.Text, ""))
                {
                    int num = (int)MessageBox.Show("이미 존재하는 값입니다. [ " + this.textCode.Text + " ]");
                    return flag;
                }
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("declare @strKey nvarchar(3) ");
                stringBuilder.AppendLine("set @strKey = '" + this.textCode.Text + "' ");
                stringBuilder.AppendLine("insert into T_장비정보 (  ");
                stringBuilder.AppendLine("     사업자번호                  ");
                stringBuilder.AppendLine("     , 장비코드                  ");
                stringBuilder.AppendLine("     , 장비명                    ");
                stringBuilder.AppendLine("     , 규격                      ");
                stringBuilder.AppendLine("     , 교환주기                  ");
                stringBuilder.AppendLine("     , 비고                      ");
                stringBuilder.AppendLine(" ) values ( ");
                stringBuilder.AppendLine("     '" + Common.p_strCompID + "' ");
                stringBuilder.AppendLine("     , @strKey                   ");
                stringBuilder.AppendLine("     , @장비명                   ");
                stringBuilder.AppendLine("     , @규격                     ");
                stringBuilder.AppendLine("     , @교환주기                 ");
                stringBuilder.AppendLine("     , @비고                     ");
                stringBuilder.AppendLine(" )  ");
                SqlCommand sCommand = new SqlCommand(stringBuilder.ToString());
                sCommand.Parameters.AddWithValue("@장비명", (object)this.textName.Text);
                sCommand.Parameters.AddWithValue("@규격", (object)this.textSize.Text);
                sCommand.Parameters.AddWithValue("@교환주기", (object)this.text교환주기.Text.Replace(",", ""));
                sCommand.Parameters.AddWithValue("@비고", (object)this.text비고.Text);
                flag = wnAdo.SqlCommandEtc(sCommand, "Insert_장비정보_Table", Common.p_strConn) > 0;
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
            bool flag = false;
            try
            {
                wnAdo wnAdo = new wnAdo();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("update T_장비정보 set     ");
                stringBuilder.AppendLine("     장비명 = @장비명            ");
                stringBuilder.AppendLine("     , 규격 = @규격              ");
                stringBuilder.AppendLine("     , 교환주기 = @교환주기      ");
                stringBuilder.AppendLine("     , 비고 = @비고              ");
                stringBuilder.AppendLine(" where 사업자번호 = '" + Common.p_strCompID + "' ");
                stringBuilder.AppendLine("     and 장비코드 = @p1          ");
                SqlCommand sCommand = new SqlCommand(stringBuilder.ToString());
                sCommand.Parameters.AddWithValue("@p1", (object)this.textCode.Text);
                sCommand.Parameters.AddWithValue("@장비명", (object)this.textName.Text);
                sCommand.Parameters.AddWithValue("@규격", (object)this.textSize.Text);
                sCommand.Parameters.AddWithValue("@교환주기", (object)this.text교환주기.Text.Replace(",", ""));
                sCommand.Parameters.AddWithValue("@비고", (object)this.text비고.Text);
                flag = wnAdo.SqlCommandEtc(sCommand, "Save_장비정보_Table", Common.p_strConn) > 0;
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

        private bool get_Dup_Check(string sNew, string sOld)
        {
            try
            {
                if (!(sNew != sOld))
                    return false;
                DataTable dataTable = new wnDm().fn_장비_Detail(sNew, Common.p_strConn);
                return dataTable != null && dataTable.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
                return true;
            }
        }

        private bool validate_InputBox()
        {
            bool flag = true;
            try
            {
                if (this.textCode.Text == "")
                {
                    int num = (int)MessageBox.Show("[ 코드 ] 을 입력하세요.");
                    return false;
                }
                if (this.textName.Text == "")
                {
                    int num = (int)MessageBox.Show("[ 장비명 ] 을 입력하세요.");
                    return false;
                }
                if (this.text교환주기.Text == "")
                    this.text교환주기.Text = "0";
            }
            catch (Exception ex)
            {
                flag = false;
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
                int num = (int)MessageBox.Show("입력 데이터 확인 중에 오류가 있습니다.");
            }
            return flag;
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.init_InputBox(true);
            
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            this.save_btn.Enabled = false;
            if (!this.validate_InputBox())
            {
                this.save_btn.Enabled = true;
            }
            else
            {
                if (this.bData ? this.updatePost() : this.insertPost())
                {
                    this.Search_btn_Click((object)this, (EventArgs)null);
                    this.button1_Click((object)this, (EventArgs)null);
                }
                this.save_btn.Enabled = true;
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            this.init_InputBox(true);
            this.bindData(this.makeSearchCondition());
            /*this.tmFocusNew.Enabled = true;*/
        }

        

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            
            this.Close();
            /*Form2 frm = new Form2();
            frm.Show();*/
            
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            this.init_InputBox(true);
            this.bindData(this.makeSearchCondition());
        }

        private void getDetailPost(string sKey)
        {
            this.init_InputBox(false);
            try
            {
                DataTable dataTable = new wnDm().fn_장비_Detail(sKey, Common.p_strConn);
                if (dataTable == null || dataTable.Rows.Count <= 0)
                    return;
                this.textCode.Text = dataTable.Rows[0]["장비코드"].ToString();
                this.textName.Text = dataTable.Rows[0]["장비명"].ToString();
                this.textSize.Text = dataTable.Rows[0]["규격"].ToString();
                this.text교환주기.Text = int.Parse(dataTable.Rows[0]["교환주기"].ToString()).ToString("#,0");
                this.text비고.Text = dataTable.Rows[0]["비고"].ToString();
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }




        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            if (this.GridView.CurrentCell == null || this.GridView.CurrentCell.RowIndex < 0 || this.GridView.CurrentCell.ColumnIndex < 0)
                return;
            this.iCnt = this.GridView.CurrentCell.RowIndex;
            this.strValue = (string)this.GridView.Rows[this.iCnt].Cells[0].Value ?? "";
            this.getDetailPost(this.strValue);
            
        }

        private void GridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                this.GridView_DoubleClick((object)this, (EventArgs)null);
            }
            if (e.KeyCode != Keys.Escape)
                return;
            e.Handled = true;
            this.SearchText.Focus();
        }



    }
}
