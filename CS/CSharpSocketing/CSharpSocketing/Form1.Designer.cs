namespace CSharpSocketing
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.setupTSBtn = new System.Windows.Forms.Button();
            this.tsPortFld = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.setupTCBtn = new System.Windows.Forms.Button();
            this.tcServerPortFld = new System.Windows.Forms.TextBox();
            this.tcServerIPFld = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.displayBox = new System.Windows.Forms.RichTextBox();
            this.sendMsgFld = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.newBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.uspFld = new System.Windows.Forms.TextBox();
            this.usClientIPFld = new System.Windows.Forms.TextBox();
            this.usClientPortFld = new System.Windows.Forms.TextBox();
            this.setupUSBtn = new System.Windows.Forms.Button();
            this.setupUCBtn = new System.Windows.Forms.Button();
            this.ucServerPortFld = new System.Windows.Forms.TextBox();
            this.ucServerIPFld = new System.Windows.Forms.TextBox();
            this.ucpFld = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(1, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(271, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.setupTSBtn);
            this.tabPage1.Controls.Add(this.tsPortFld);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(263, 474);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TCP Server";
            // 
            // setupTSBtn
            // 
            this.setupTSBtn.Location = new System.Drawing.Point(9, 76);
            this.setupTSBtn.Name = "setupTSBtn";
            this.setupTSBtn.Size = new System.Drawing.Size(248, 23);
            this.setupTSBtn.TabIndex = 2;
            this.setupTSBtn.Text = "Setup TCP Server";
            this.setupTSBtn.UseVisualStyleBackColor = true;
            this.setupTSBtn.Click += new System.EventHandler(this.setupTSBtn_Click);
            // 
            // tsPortFld
            // 
            this.tsPortFld.Location = new System.Drawing.Point(9, 36);
            this.tsPortFld.Name = "tsPortFld";
            this.tsPortFld.Size = new System.Drawing.Size(248, 20);
            this.tsPortFld.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listen Port";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.setupTCBtn);
            this.tabPage2.Controls.Add(this.tcServerPortFld);
            this.tabPage2.Controls.Add(this.tcServerIPFld);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(263, 474);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TCP Client";
            // 
            // setupTCBtn
            // 
            this.setupTCBtn.Location = new System.Drawing.Point(6, 118);
            this.setupTCBtn.Name = "setupTCBtn";
            this.setupTCBtn.Size = new System.Drawing.Size(251, 23);
            this.setupTCBtn.TabIndex = 4;
            this.setupTCBtn.Text = "Setup TCP Client";
            this.setupTCBtn.UseVisualStyleBackColor = true;
            this.setupTCBtn.Click += new System.EventHandler(this.setupTCBtn_Click);
            // 
            // tcServerPortFld
            // 
            this.tcServerPortFld.Location = new System.Drawing.Point(7, 82);
            this.tcServerPortFld.Name = "tcServerPortFld";
            this.tcServerPortFld.Size = new System.Drawing.Size(250, 20);
            this.tcServerPortFld.TabIndex = 3;
            // 
            // tcServerIPFld
            // 
            this.tcServerIPFld.Location = new System.Drawing.Point(6, 29);
            this.tcServerIPFld.Name = "tcServerIPFld";
            this.tcServerIPFld.Size = new System.Drawing.Size(251, 20);
            this.tcServerIPFld.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Transmit Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server IP";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.setupUSBtn);
            this.tabPage3.Controls.Add(this.usClientPortFld);
            this.tabPage3.Controls.Add(this.usClientIPFld);
            this.tabPage3.Controls.Add(this.uspFld);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(263, 474);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "UDP Server";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Transparent;
            this.tabPage4.Controls.Add(this.setupUCBtn);
            this.tabPage4.Controls.Add(this.ucServerPortFld);
            this.tabPage4.Controls.Add(this.ucServerIPFld);
            this.tabPage4.Controls.Add(this.ucpFld);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(263, 474);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "UDP Client";
            // 
            // displayBox
            // 
            this.displayBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayBox.Location = new System.Drawing.Point(274, 12);
            this.displayBox.Name = "displayBox";
            this.displayBox.Size = new System.Drawing.Size(498, 499);
            this.displayBox.TabIndex = 1;
            this.displayBox.Text = "";
            // 
            // sendMsgFld
            // 
            this.sendMsgFld.Location = new System.Drawing.Point(278, 529);
            this.sendMsgFld.Name = "sendMsgFld";
            this.sendMsgFld.Size = new System.Drawing.Size(391, 20);
            this.sendMsgFld.TabIndex = 2;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(688, 526);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(75, 23);
            this.sendBtn.TabIndex = 3;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // newBtn
            // 
            this.newBtn.Location = new System.Drawing.Point(5, 10);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(96, 23);
            this.newBtn.TabIndex = 4;
            this.newBtn.Text = "New Window";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Listen Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Client IP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Transmit Port";
            // 
            // uspFld
            // 
            this.uspFld.Location = new System.Drawing.Point(7, 31);
            this.uspFld.Name = "uspFld";
            this.uspFld.Size = new System.Drawing.Size(250, 20);
            this.uspFld.TabIndex = 3;
            // 
            // usClientIPFld
            // 
            this.usClientIPFld.Location = new System.Drawing.Point(7, 85);
            this.usClientIPFld.Name = "usClientIPFld";
            this.usClientIPFld.Size = new System.Drawing.Size(250, 20);
            this.usClientIPFld.TabIndex = 4;
            // 
            // usClientPortFld
            // 
            this.usClientPortFld.Location = new System.Drawing.Point(10, 139);
            this.usClientPortFld.Name = "usClientPortFld";
            this.usClientPortFld.Size = new System.Drawing.Size(247, 20);
            this.usClientPortFld.TabIndex = 5;
            // 
            // setupUSBtn
            // 
            this.setupUSBtn.Location = new System.Drawing.Point(10, 179);
            this.setupUSBtn.Name = "setupUSBtn";
            this.setupUSBtn.Size = new System.Drawing.Size(247, 23);
            this.setupUSBtn.TabIndex = 6;
            this.setupUSBtn.Text = "Setup UDP Server";
            this.setupUSBtn.UseVisualStyleBackColor = true;
            this.setupUSBtn.Click += new System.EventHandler(this.setupUSBtn_Click);
            // 
            // setupUCBtn
            // 
            this.setupUCBtn.Location = new System.Drawing.Point(10, 184);
            this.setupUCBtn.Name = "setupUCBtn";
            this.setupUCBtn.Size = new System.Drawing.Size(247, 23);
            this.setupUCBtn.TabIndex = 13;
            this.setupUCBtn.Text = "Setup UDP Client";
            this.setupUCBtn.UseVisualStyleBackColor = true;
            this.setupUCBtn.Click += new System.EventHandler(this.setupUCBtn_Click);
            // 
            // ucServerPortFld
            // 
            this.ucServerPortFld.Location = new System.Drawing.Point(10, 144);
            this.ucServerPortFld.Name = "ucServerPortFld";
            this.ucServerPortFld.Size = new System.Drawing.Size(247, 20);
            this.ucServerPortFld.TabIndex = 12;
            // 
            // ucServerIPFld
            // 
            this.ucServerIPFld.Location = new System.Drawing.Point(7, 90);
            this.ucServerIPFld.Name = "ucServerIPFld";
            this.ucServerIPFld.Size = new System.Drawing.Size(250, 20);
            this.ucServerIPFld.TabIndex = 11;
            // 
            // ucpFld
            // 
            this.ucpFld.Location = new System.Drawing.Point(7, 36);
            this.ucpFld.Name = "ucpFld";
            this.ucpFld.Size = new System.Drawing.Size(250, 20);
            this.ucpFld.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Transmit Port";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Server IP";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Listen Port";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.newBtn);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.sendMsgFld);
            this.Controls.Add(this.displayBox);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Communication System: ";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox displayBox;
        private System.Windows.Forms.TextBox sendMsgFld;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button setupTSBtn;
        private System.Windows.Forms.TextBox tsPortFld;
        private System.Windows.Forms.TextBox tcServerPortFld;
        private System.Windows.Forms.TextBox tcServerIPFld;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button setupTCBtn;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Button setupUSBtn;
        private System.Windows.Forms.TextBox usClientPortFld;
        private System.Windows.Forms.TextBox usClientIPFld;
        private System.Windows.Forms.TextBox uspFld;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button setupUCBtn;
        private System.Windows.Forms.TextBox ucServerPortFld;
        private System.Windows.Forms.TextBox ucServerIPFld;
        private System.Windows.Forms.TextBox ucpFld;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

