namespace DerbyTime
{
    partial class EditDriver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditDriver));
            this.lbl_DriverNo = new System.Windows.Forms.Label();
            this.ddl_DriverNo = new System.Windows.Forms.ComboBox();
            this.lbl_Pack = new System.Windows.Forms.Label();
            this.ddl_Pack = new System.Windows.Forms.ComboBox();
            this.lbl_Den = new System.Windows.Forms.Label();
            this.ddl_Den = new System.Windows.Forms.ComboBox();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.lbl_Err = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_DriverNo
            // 
            this.lbl_DriverNo.AutoSize = true;
            this.lbl_DriverNo.Location = new System.Drawing.Point(32, 11);
            this.lbl_DriverNo.Name = "lbl_DriverNo";
            this.lbl_DriverNo.Size = new System.Drawing.Size(48, 13);
            this.lbl_DriverNo.TabIndex = 0;
            this.lbl_DriverNo.Text = "Driver #:";
            // 
            // ddl_DriverNo
            // 
            this.ddl_DriverNo.Location = new System.Drawing.Point(80, 9);
            this.ddl_DriverNo.Name = "ddl_DriverNo";
            this.ddl_DriverNo.Size = new System.Drawing.Size(50, 21);
            this.ddl_DriverNo.TabIndex = 1;
            this.ddl_DriverNo.Text = "ddl_DriverNo";
            // 
            // lbl_Pack
            // 
            this.lbl_Pack.AutoSize = true;
            this.lbl_Pack.Location = new System.Drawing.Point(32, 39);
            this.lbl_Pack.Name = "lbl_Pack";
            this.lbl_Pack.Size = new System.Drawing.Size(45, 13);
            this.lbl_Pack.TabIndex = 2;
            this.lbl_Pack.Text = "Pack #:";
            // 
            // ddl_Pack
            // 
            this.ddl_Pack.FormattingEnabled = true;
            this.ddl_Pack.Location = new System.Drawing.Point(80, 36);
            this.ddl_Pack.Name = "ddl_Pack";
            this.ddl_Pack.Size = new System.Drawing.Size(75, 21);
            this.ddl_Pack.TabIndex = 3;
            // 
            // lbl_Den
            // 
            this.lbl_Den.AutoSize = true;
            this.lbl_Den.Location = new System.Drawing.Point(32, 66);
            this.lbl_Den.Name = "lbl_Den";
            this.lbl_Den.Size = new System.Drawing.Size(30, 13);
            this.lbl_Den.TabIndex = 4;
            this.lbl_Den.Text = "Den:";
            // 
            // ddl_Den
            // 
            this.ddl_Den.FormattingEnabled = true;
            this.ddl_Den.Location = new System.Drawing.Point(80, 64);
            this.ddl_Den.Name = "ddl_Den";
            this.ddl_Den.Size = new System.Drawing.Size(100, 21);
            this.ddl_Den.TabIndex = 5;
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(32, 95);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(38, 13);
            this.lbl_Name.TabIndex = 6;
            this.lbl_Name.Text = "Name:";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(80, 92);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(150, 20);
            this.txt_Name.TabIndex = 7;
            // 
            // lbl_Err
            // 
            this.lbl_Err.AutoSize = true;
            this.lbl_Err.ForeColor = System.Drawing.Color.Red;
            this.lbl_Err.Location = new System.Drawing.Point(32, 115);
            this.lbl_Err.Name = "lbl_Err";
            this.lbl_Err.Size = new System.Drawing.Size(0, 13);
            this.lbl_Err.TabIndex = 8;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(80, 131);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.Text = "Submit";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // EditDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 166);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lbl_Err);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.ddl_Den);
            this.Controls.Add(this.lbl_Den);
            this.Controls.Add(this.ddl_Pack);
            this.Controls.Add(this.lbl_Pack);
            this.Controls.Add(this.ddl_DriverNo);
            this.Controls.Add(this.lbl_DriverNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditDriver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Driver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_DriverNo;
        private System.Windows.Forms.ComboBox ddl_DriverNo;
        private System.Windows.Forms.Label lbl_Pack;
        private System.Windows.Forms.ComboBox ddl_Pack;
        private System.Windows.Forms.Label lbl_Den;
        private System.Windows.Forms.ComboBox ddl_Den;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label lbl_Err;
        private System.Windows.Forms.Button btn_OK;

    }
}