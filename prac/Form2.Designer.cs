﻿
namespace prac
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.move_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // move_btn
            // 
            this.move_btn.Location = new System.Drawing.Point(295, 192);
            this.move_btn.Name = "move_btn";
            this.move_btn.Size = new System.Drawing.Size(75, 23);
            this.move_btn.TabIndex = 0;
            this.move_btn.Text = "버튼클릭";
            this.move_btn.UseVisualStyleBackColor = true;
            this.move_btn.Click += new System.EventHandler(this.move_btn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.move_btn);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button move_btn;
    }
}