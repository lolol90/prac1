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
       

        public Form장비등록(){
           this.InitializeComponent();
            Common.p_strConn = "DATA SOURCE = " + "218.38.14.33,14332".ToString()
                 + ";INITIAL CATALOG = " + "test".ToString()
                 + ";PERSIST SECURITY INFO = false;USER ID = " +"sa".ToString()
                 + ";PASSWORD = " + "##wkdxj123".ToString() + ";";
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
           
        }

        

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 frm = new Form2();
            frm.Show();
            
        }
    }
}
