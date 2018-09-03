namespace RangeFinder
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
            this.UserListPath = new System.Windows.Forms.TextBox();
            this.import_Csv_btn = new System.Windows.Forms.Button();
            this.RangeListPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UserListBrowser = new System.Windows.Forms.Button();
            this.RangeListBrowser = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // UserListPath
            // 
            this.UserListPath.Location = new System.Drawing.Point(249, 73);
            this.UserListPath.Name = "UserListPath";
            this.UserListPath.Size = new System.Drawing.Size(238, 20);
            this.UserListPath.TabIndex = 3;
            // 
            // import_Csv_btn
            // 
            this.import_Csv_btn.Location = new System.Drawing.Point(355, 205);
            this.import_Csv_btn.Name = "import_Csv_btn";
            this.import_Csv_btn.Size = new System.Drawing.Size(132, 23);
            this.import_Csv_btn.TabIndex = 4;
            this.import_Csv_btn.Text = "EXECUTE";
            this.import_Csv_btn.UseVisualStyleBackColor = true;
            this.import_Csv_btn.Click += new System.EventHandler(this.ImportUserCsv_click);
            // 
            // RangeListPath
            // 
            this.RangeListPath.Location = new System.Drawing.Point(249, 141);
            this.RangeListPath.Name = "RangeListPath";
            this.RangeListPath.Size = new System.Drawing.Size(238, 20);
            this.RangeListPath.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "User List Csv Path";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Range Csv Path";
            // 
            // UserListBrowser
            // 
            this.UserListBrowser.Location = new System.Drawing.Point(515, 70);
            this.UserListBrowser.Name = "UserListBrowser";
            this.UserListBrowser.Size = new System.Drawing.Size(75, 23);
            this.UserListBrowser.TabIndex = 7;
            this.UserListBrowser.Text = "Browse";
            this.UserListBrowser.UseVisualStyleBackColor = true;
            this.UserListBrowser.Click += new System.EventHandler(this.UserListBrowser_Click);
            // 
            // RangeListBrowser
            // 
            this.RangeListBrowser.Location = new System.Drawing.Point(515, 137);
            this.RangeListBrowser.Name = "RangeListBrowser";
            this.RangeListBrowser.Size = new System.Drawing.Size(75, 23);
            this.RangeListBrowser.TabIndex = 8;
            this.RangeListBrowser.Text = "Browse";
            this.RangeListBrowser.UseVisualStyleBackColor = true;
            this.RangeListBrowser.Click += new System.EventHandler(this.RangeListBrowser_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(731, 417);
            this.Controls.Add(this.RangeListBrowser);
            this.Controls.Add(this.UserListBrowser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RangeListPath);
            this.Controls.Add(this.import_Csv_btn);
            this.Controls.Add(this.UserListPath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox UserListPath;
        private System.Windows.Forms.Button import_Csv_btn;
        private System.Windows.Forms.TextBox RangeListPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UserListBrowser;
        private System.Windows.Forms.Button RangeListBrowser;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

