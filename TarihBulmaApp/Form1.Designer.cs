namespace TarihBulmaApp
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
            this.cbBox01 = new System.Windows.Forms.ComboBox();
            this.cbBox02 = new System.Windows.Forms.ComboBox();
            this.daysPanel = new System.Windows.Forms.Panel();
            this.btnCrsmb = new System.Windows.Forms.Button();
            this.btnPzr = new System.Windows.Forms.Button();
            this.btnCmts = new System.Windows.Forms.Button();
            this.btnCuma = new System.Windows.Forms.Button();
            this.btnPrsmb = new System.Windows.Forms.Button();
            this.btnSali = new System.Windows.Forms.Button();
            this.btnPzrts = new System.Windows.Forms.Button();
            this.mCalendar01 = new System.Windows.Forms.MonthCalendar();
            this.mCalendar02 = new System.Windows.Forms.MonthCalendar();
            this.Lbox01 = new System.Windows.Forms.ListBox();
            this.daysPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbBox01
            // 
            this.cbBox01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBox01.FormattingEnabled = true;
            this.cbBox01.Items.AddRange(new object[] {
            "Günlük",
            "Haftalık"});
            this.cbBox01.Location = new System.Drawing.Point(25, 29);
            this.cbBox01.Name = "cbBox01";
            this.cbBox01.Size = new System.Drawing.Size(162, 24);
            this.cbBox01.TabIndex = 0;
            this.cbBox01.SelectedIndexChanged += new System.EventHandler(this.cbBox01_SelectedIndexChanged);
            // 
            // cbBox02
            // 
            this.cbBox02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBox02.FormattingEnabled = true;
            this.cbBox02.Location = new System.Drawing.Point(25, 119);
            this.cbBox02.Name = "cbBox02";
            this.cbBox02.Size = new System.Drawing.Size(162, 24);
            this.cbBox02.TabIndex = 1;
            this.cbBox02.SelectedIndexChanged += new System.EventHandler(this.cbBox02_SelectedIndexChanged);
            // 
            // daysPanel
            // 
            this.daysPanel.Controls.Add(this.btnCrsmb);
            this.daysPanel.Controls.Add(this.btnPzr);
            this.daysPanel.Controls.Add(this.btnCmts);
            this.daysPanel.Controls.Add(this.btnCuma);
            this.daysPanel.Controls.Add(this.btnPrsmb);
            this.daysPanel.Controls.Add(this.btnSali);
            this.daysPanel.Controls.Add(this.btnPzrts);
            this.daysPanel.Location = new System.Drawing.Point(25, 258);
            this.daysPanel.Name = "daysPanel";
            this.daysPanel.Size = new System.Drawing.Size(368, 196);
            this.daysPanel.TabIndex = 2;
            this.daysPanel.Visible = false;
            // 
            // btnCrsmb
            // 
            this.btnCrsmb.Location = new System.Drawing.Point(250, 19);
            this.btnCrsmb.Name = "btnCrsmb";
            this.btnCrsmb.Size = new System.Drawing.Size(98, 39);
            this.btnCrsmb.TabIndex = 0;
            this.btnCrsmb.Text = "Çarşamba";
            this.btnCrsmb.UseVisualStyleBackColor = true;
            this.btnCrsmb.Click += new System.EventHandler(this.Btn_OnClick);
            // 
            // btnPzr
            // 
            this.btnPzr.Location = new System.Drawing.Point(250, 133);
            this.btnPzr.Name = "btnPzr";
            this.btnPzr.Size = new System.Drawing.Size(98, 39);
            this.btnPzr.TabIndex = 0;
            this.btnPzr.Text = "Pazar";
            this.btnPzr.UseVisualStyleBackColor = true;
            this.btnPzr.Click += new System.EventHandler(this.Btn_OnClick);
            // 
            // btnCmts
            // 
            this.btnCmts.Location = new System.Drawing.Point(16, 133);
            this.btnCmts.Name = "btnCmts";
            this.btnCmts.Size = new System.Drawing.Size(98, 39);
            this.btnCmts.TabIndex = 0;
            this.btnCmts.Text = "Cumartesi";
            this.btnCmts.UseVisualStyleBackColor = true;
            this.btnCmts.Click += new System.EventHandler(this.Btn_OnClick);
            // 
            // btnCuma
            // 
            this.btnCuma.Location = new System.Drawing.Point(188, 79);
            this.btnCuma.Name = "btnCuma";
            this.btnCuma.Size = new System.Drawing.Size(98, 39);
            this.btnCuma.TabIndex = 0;
            this.btnCuma.Text = "Cuma";
            this.btnCuma.UseVisualStyleBackColor = true;
            this.btnCuma.Click += new System.EventHandler(this.Btn_OnClick);
            // 
            // btnPrsmb
            // 
            this.btnPrsmb.Location = new System.Drawing.Point(73, 79);
            this.btnPrsmb.Name = "btnPrsmb";
            this.btnPrsmb.Size = new System.Drawing.Size(98, 39);
            this.btnPrsmb.TabIndex = 0;
            this.btnPrsmb.Text = "Perşembe";
            this.btnPrsmb.UseVisualStyleBackColor = true;
            this.btnPrsmb.Click += new System.EventHandler(this.Btn_OnClick);
            // 
            // btnSali
            // 
            this.btnSali.Location = new System.Drawing.Point(133, 19);
            this.btnSali.Name = "btnSali";
            this.btnSali.Size = new System.Drawing.Size(98, 39);
            this.btnSali.TabIndex = 0;
            this.btnSali.Text = "Salı";
            this.btnSali.UseVisualStyleBackColor = true;
            this.btnSali.Click += new System.EventHandler(this.Btn_OnClick);
            // 
            // btnPzrts
            // 
            this.btnPzrts.Location = new System.Drawing.Point(16, 19);
            this.btnPzrts.Name = "btnPzrts";
            this.btnPzrts.Size = new System.Drawing.Size(98, 39);
            this.btnPzrts.TabIndex = 0;
            this.btnPzrts.Text = "Pazartesi";
            this.btnPzrts.UseVisualStyleBackColor = true;
            this.btnPzrts.Click += new System.EventHandler(this.Btn_OnClick);
            // 
            // mCalendar01
            // 
            this.mCalendar01.Location = new System.Drawing.Point(442, 18);
            this.mCalendar01.Name = "mCalendar01";
            this.mCalendar01.TabIndex = 1;
            this.mCalendar01.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mCalendar01_DateChanged);
            // 
            // mCalendar02
            // 
            this.mCalendar02.Location = new System.Drawing.Point(442, 247);
            this.mCalendar02.Name = "mCalendar02";
            this.mCalendar02.TabIndex = 1;
            this.mCalendar02.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mCalendar01_DateChanged);
            // 
            // Lbox01
            // 
            this.Lbox01.FormattingEnabled = true;
            this.Lbox01.ItemHeight = 16;
            this.Lbox01.Location = new System.Drawing.Point(775, 18);
            this.Lbox01.Name = "Lbox01";
            this.Lbox01.Size = new System.Drawing.Size(268, 532);
            this.Lbox01.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 616);
            this.Controls.Add(this.Lbox01);
            this.Controls.Add(this.mCalendar02);
            this.Controls.Add(this.mCalendar01);
            this.Controls.Add(this.daysPanel);
            this.Controls.Add(this.cbBox02);
            this.Controls.Add(this.cbBox01);
            this.Name = "Form1";
            this.Text = "Form1";
            this.daysPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBox01;
        private System.Windows.Forms.ComboBox cbBox02;
        private System.Windows.Forms.Panel daysPanel;
        private System.Windows.Forms.Button btnCrsmb;
        private System.Windows.Forms.Button btnPzr;
        private System.Windows.Forms.Button btnCmts;
        private System.Windows.Forms.Button btnCuma;
        private System.Windows.Forms.Button btnPrsmb;
        private System.Windows.Forms.Button btnSali;
        private System.Windows.Forms.Button btnPzrts;
        private System.Windows.Forms.MonthCalendar mCalendar01;
        private System.Windows.Forms.MonthCalendar mCalendar02;
        private System.Windows.Forms.ListBox Lbox01;
    }
}

