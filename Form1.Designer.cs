
namespace LeagueAutoLogin
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.autologinBTN = new System.Windows.Forms.Button();
            this.savelogCB = new System.Windows.Forms.CheckBox();
            this.userTB = new System.Windows.Forms.TextBox();
            this.passTB = new System.Windows.Forms.TextBox();
            this.userLBL = new System.Windows.Forms.Label();
            this.passLBL = new System.Windows.Forms.Label();
            this.executeCB = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // autologinBTN
            // 
            this.autologinBTN.Location = new System.Drawing.Point(108, 136);
            this.autologinBTN.Name = "autologinBTN";
            this.autologinBTN.Size = new System.Drawing.Size(75, 23);
            this.autologinBTN.TabIndex = 0;
            this.autologinBTN.Text = "AutoLogin";
            this.autologinBTN.UseVisualStyleBackColor = true;
            this.autologinBTN.Click += new System.EventHandler(this.autologinBTN_Click);
            // 
            // savelogCB
            // 
            this.savelogCB.AutoSize = true;
            this.savelogCB.Location = new System.Drawing.Point(95, 114);
            this.savelogCB.Name = "savelogCB";
            this.savelogCB.Size = new System.Drawing.Size(107, 19);
            this.savelogCB.TabIndex = 1;
            this.savelogCB.Text = "Save LoginData";
            this.savelogCB.UseVisualStyleBackColor = true;
            // 
            // userTB
            // 
            this.userTB.Location = new System.Drawing.Point(95, 41);
            this.userTB.Name = "userTB";
            this.userTB.Size = new System.Drawing.Size(100, 23);
            this.userTB.TabIndex = 2;
            // 
            // passTB
            // 
            this.passTB.Location = new System.Drawing.Point(95, 85);
            this.passTB.Name = "passTB";
            this.passTB.Size = new System.Drawing.Size(100, 23);
            this.passTB.TabIndex = 3;
            // 
            // userLBL
            // 
            this.userLBL.AutoSize = true;
            this.userLBL.Location = new System.Drawing.Point(115, 24);
            this.userLBL.Name = "userLBL";
            this.userLBL.Size = new System.Drawing.Size(60, 15);
            this.userLBL.TabIndex = 4;
            this.userLBL.Text = "Username";
            // 
            // passLBL
            // 
            this.passLBL.AutoSize = true;
            this.passLBL.Location = new System.Drawing.Point(116, 68);
            this.passLBL.Name = "passLBL";
            this.passLBL.Size = new System.Drawing.Size(57, 15);
            this.passLBL.TabIndex = 5;
            this.passLBL.Text = "Password";
            // 
            // executeCB
            // 
            this.executeCB.AutoSize = true;
            this.executeCB.Location = new System.Drawing.Point(56, 165);
            this.executeCB.Name = "executeCB";
            this.executeCB.Size = new System.Drawing.Size(206, 19);
            this.executeCB.TabIndex = 6;
            this.executeCB.Text = "AutoLogin when League Executed";
            this.executeCB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 202);
            this.Controls.Add(this.executeCB);
            this.Controls.Add(this.passLBL);
            this.Controls.Add(this.userLBL);
            this.Controls.Add(this.passTB);
            this.Controls.Add(this.userTB);
            this.Controls.Add(this.savelogCB);
            this.Controls.Add(this.autologinBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "League AutoLogin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button autologinBTN;
        private System.Windows.Forms.CheckBox savelogCB;
        private System.Windows.Forms.TextBox userTB;
        private System.Windows.Forms.TextBox passTB;
        private System.Windows.Forms.Label userLBL;
        private System.Windows.Forms.Label passLBL;
        private System.Windows.Forms.CheckBox executeCB;
    }
}

