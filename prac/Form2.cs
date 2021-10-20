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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void move_btn_Click(object sender, EventArgs e)
        {
           
                this.Visible = false; // 현재 폼 안보이게 하기
                Form장비등록 frm = new Form장비등록(); // 새 폼 생성¬
                frm.Owner = this; // 새 폼의 오너를 현재 폼으로
                frm.Show(); // 새폼 보여 주 기 
            
            
        }
    }
}
