// Decompiled with JetBrains decompiler
// Type: smartMain.frmCheck
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace smartMain
{
    public class frmCheck : Form
    {
        public bool bRet = false;
        private IContainer components = (IContainer)null;
        private Panel panMain;
        private Panel panel1;
        internal Label lblToday;
        internal Panel Panel2;
        internal Label Label6;
        internal Label label1;
        private Timer tmSec;
        private Timer tmStart;

        public frmCheck() => this.InitializeComponent();

        private void frmCheck_Load(object sender, EventArgs e)
        {
            this.Width = this.panMain.Width;
            this.Height = this.panMain.Height;
            this.tmStart.Enabled = true;
        }

        public bool Check_DBConnection()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = Common.p_strConnMain;
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

        private void tmSec_Tick(object sender, EventArgs e)
        {
            this.lblToday.Text = DateTime.Now.ToString("ss");
            Application.DoEvents();
        }

        private void tmStart_Tick(object sender, EventArgs e)
        {
            this.tmStart.Enabled = false;
            this.bRet = this.Check_DBConnection();
            this.Close();
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
            this.panMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblToday = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label6 = new System.Windows.Forms.Label();
            this.tmSec = new System.Windows.Forms.Timer(this.components);
            this.tmStart = new System.Windows.Forms.Timer(this.components);
            this.panMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panMain
            // 
            this.panMain.BackColor = System.Drawing.Color.Gray;
            this.panMain.Controls.Add(this.panel1);
            this.panMain.Controls.Add(this.Panel2);
            this.panMain.Location = new System.Drawing.Point(0, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(278, 107);
            this.panMain.TabIndex = 47;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblToday);
            this.panel1.Location = new System.Drawing.Point(3, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 72);
            this.panel1.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 19);
            this.label1.TabIndex = 40;
            this.label1.Text = "데이터베이스 연결 확인 중...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblToday
            // 
            this.lblToday.BackColor = System.Drawing.SystemColors.Window;
            this.lblToday.Location = new System.Drawing.Point(9, 53);
            this.lblToday.Name = "lblToday";
            this.lblToday.Size = new System.Drawing.Size(253, 19);
            this.lblToday.TabIndex = 39;
            this.lblToday.Text = "0";
            this.lblToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblToday.Visible = false;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Panel2.Controls.Add(this.Label6);
            this.Panel2.Location = new System.Drawing.Point(3, 3);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(272, 28);
            this.Panel2.TabIndex = 46;
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Label6.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label6.ForeColor = System.Drawing.Color.White;
            this.Label6.Location = new System.Drawing.Point(8, 4);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(256, 19);
            this.Label6.TabIndex = 29;
            this.Label6.Text = "■ 환경 체크 ■";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tmSec
            // 
            this.tmSec.Interval = 1000;
            this.tmSec.Tick += new System.EventHandler(this.tmSec_Tick);
            // 
            // tmStart
            // 
            this.tmStart.Tick += new System.EventHandler(this.tmStart_Tick);
            // 
            // frmCheck
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(328, 259);
            this.Controls.Add(this.panMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCheck";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCheck";
            this.Load += new System.EventHandler(this.frmCheck_Load);
            this.panMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
