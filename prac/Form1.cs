using smartMain;
using smartMain.CLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void save_btn_Click(object sender, EventArgs e)
        {

        }

        private void delete_btn_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.spCont.Dock = DockStyle.Fill;
            this.init_InputBox(true);
            this.bindData(this.makeSearchCondition());
            this.tmFocusNew.Enabled = true;
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
