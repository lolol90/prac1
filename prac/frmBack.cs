// Decompiled with JetBrains decompiler
// Type: smartMain.frmBack
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace smartMain
{
    public class frmBack : Form
    {
        private const int APPCOMMAND_VOLUME_MUTE = 524288;
        private const int APPCOMMAND_VOLUME_UP = 655360;
        private const int APPCOMMAND_VOLUME_DOWN = 589824;
        private const int WM_APPCOMMAND = 793;
        private IfrmInterface parentFrm = (IfrmInterface)null;
        private string strOldURL = "";
        private int nADTimerCnt = 0;
        private IContainer components = (IContainer)null;
        private Panel panCenter;
        private WebBrowser webStart;
        private Timer tmRefresh;
        private WebBrowser web카카오;
        private Timer tmAD;
        private WebBrowser web구글;
        private WebBrowser web카카오2;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(
          IntPtr hWnd,
          int Msg,
          IntPtr wParam,
          IntPtr lParam);

        private void Mute() => frmBack.SendMessageW(this.Handle, 793, this.Handle, (IntPtr)524288);

        private void VolDown() => frmBack.SendMessageW(this.Handle, 793, this.Handle, (IntPtr)589824);

        private void VolUp() => frmBack.SendMessageW(this.Handle, 793, this.Handle, (IntPtr)655360);

        public frmBack(IfrmInterface pFrm)
        {
            this.InitializeComponent();
            this.parentFrm = pFrm;
        }

        private void frmBack_Load(object sender, EventArgs e)
        {
            this.panCenter.Dock = DockStyle.Fill;
            this.webStart.ScriptErrorsSuppressed = true;
            this.strOldURL = "";
            this.webStart.Navigate(this.strOldURL);
        }

        private void frmBack_Resize(object sender, EventArgs e)
        {
            this.panCenter.Left = this.ClientSize.Width / 2 - this.panCenter.Width / 2;
            this.panCenter.Top = this.ClientSize.Height / 2 - this.panCenter.Height / 2;
        }

        private void menuButton_Click(object sender, EventArgs e) => this.parentFrm.sub_Form(((Control)sender).Tag.ToString(), ((Control)sender).Text.ToString());

        private void webStart_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!(Common.p_strHome != ""))
                return;
            this.webStart.Document.Body.Style = "zoom:100%";
        }

        private void tmRefresh_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Common.p_strHome != "")
                {
                    if (!("http://" + Common.p_strHome != this.strOldURL))
                        return;
                    this.strOldURL = "http://" + Common.p_strHome;
                    this.webStart.Navigate(this.strOldURL);
                }
                else if ("" != this.strOldURL)
                {
                    this.strOldURL = "";
                    this.webStart.Navigate(this.strOldURL);
                }
            }
            catch
            {
            }
        }

        private void frmBack_Activated(object sender, EventArgs e) => this.tmRefresh.Enabled = true;

        private void frmBack_Deactivate(object sender, EventArgs e) => this.tmRefresh.Enabled = false;

        private void tmAD_Tick(object sender, EventArgs e)
        {
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
            this.panCenter = new System.Windows.Forms.Panel();
            this.webStart = new System.Windows.Forms.WebBrowser();
            this.tmRefresh = new System.Windows.Forms.Timer(this.components);
            this.web카카오 = new System.Windows.Forms.WebBrowser();
            this.tmAD = new System.Windows.Forms.Timer(this.components);
            this.web구글 = new System.Windows.Forms.WebBrowser();
            this.web카카오2 = new System.Windows.Forms.WebBrowser();
            this.panCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panCenter
            // 
            this.panCenter.Controls.Add(this.webStart);
            this.panCenter.Location = new System.Drawing.Point(5, 5);
            this.panCenter.Name = "panCenter";
            this.panCenter.Size = new System.Drawing.Size(1170, 428);
            this.panCenter.TabIndex = 97;
            // 
            // webStart
            // 
            this.webStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webStart.Location = new System.Drawing.Point(0, 0);
            this.webStart.MinimumSize = new System.Drawing.Size(20, 20);
            this.webStart.Name = "webStart";
            this.webStart.Size = new System.Drawing.Size(1170, 428);
            this.webStart.TabIndex = 0;
            this.webStart.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webStart_DocumentCompleted);
            // 
            // tmRefresh
            // 
            this.tmRefresh.Interval = 1000;
            this.tmRefresh.Tick += new System.EventHandler(this.tmRefresh_Tick);
            // 
            // web카카오
            // 
            this.web카카오.Location = new System.Drawing.Point(1059, 512);
            this.web카카오.MinimumSize = new System.Drawing.Size(20, 20);
            this.web카카오.Name = "web카카오";
            this.web카카오.Size = new System.Drawing.Size(116, 26);
            this.web카카오.TabIndex = 98;
            this.web카카오.Visible = false;
            // 
            // tmAD
            // 
            this.tmAD.Interval = 1000;
            this.tmAD.Tick += new System.EventHandler(this.tmAD_Tick);
            // 
            // web구글
            // 
            this.web구글.Location = new System.Drawing.Point(937, 512);
            this.web구글.MinimumSize = new System.Drawing.Size(20, 20);
            this.web구글.Name = "web구글";
            this.web구글.Size = new System.Drawing.Size(116, 26);
            this.web구글.TabIndex = 99;
            this.web구글.Visible = false;
            // 
            // web카카오2
            // 
            this.web카카오2.Location = new System.Drawing.Point(1059, 480);
            this.web카카오2.MinimumSize = new System.Drawing.Size(20, 20);
            this.web카카오2.Name = "web카카오2";
            this.web카카오2.Size = new System.Drawing.Size(116, 26);
            this.web카카오2.TabIndex = 100;
            this.web카카오2.Visible = false;
            // 
            // frmBack
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1206, 550);
            this.Controls.Add(this.web카카오2);
            this.Controls.Add(this.web구글);
            this.Controls.Add(this.web카카오);
            this.Controls.Add(this.panCenter);
            this.Name = "frmBack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmBack";
            this.Activated += new System.EventHandler(this.frmBack_Activated);
            this.Deactivate += new System.EventHandler(this.frmBack_Deactivate);
            this.Load += new System.EventHandler(this.frmBack_Load);
            this.Resize += new System.EventHandler(this.frmBack_Resize);
            this.panCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
