namespace DerbyTime.Controls
{
    partial class DriverControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_RaceNum = new System.Windows.Forms.Label();
            this.lbl_ChildName = new System.Windows.Forms.Label();
            this.lbl_PackNo = new System.Windows.Forms.Label();
            this.lbl_Den = new System.Windows.Forms.Label();
            this.img_Den = new System.Windows.Forms.PictureBox();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.img_Den)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_RaceNum
            // 
            this.lbl_RaceNum.AutoSize = true;
            this.lbl_RaceNum.BackColor = System.Drawing.Color.Transparent;
            this.lbl_RaceNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_RaceNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RaceNum.ForeColor = System.Drawing.Color.White;
            this.lbl_RaceNum.Location = new System.Drawing.Point(0, 0);
            this.lbl_RaceNum.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_RaceNum.Name = "lbl_RaceNum";
            this.lbl_RaceNum.Padding = new System.Windows.Forms.Padding(5);
            this.lbl_RaceNum.Size = new System.Drawing.Size(76, 43);
            this.lbl_RaceNum.TabIndex = 0;
            this.lbl_RaceNum.Text = "999";
            this.lbl_RaceNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ChildName
            // 
            this.lbl_ChildName.AutoEllipsis = true;
            this.lbl_ChildName.AutoSize = true;
            this.lbl_ChildName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChildName.Location = new System.Drawing.Point(75, 0);
            this.lbl_ChildName.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lbl_ChildName.MaximumSize = new System.Drawing.Size(200, 25);
            this.lbl_ChildName.Name = "lbl_ChildName";
            this.lbl_ChildName.Size = new System.Drawing.Size(198, 25);
            this.lbl_ChildName.TabIndex = 1;
            this.lbl_ChildName.Text = "ChildOfTheNightOhYeah";
            // 
            // lbl_PackNo
            // 
            this.lbl_PackNo.AutoSize = true;
            this.lbl_PackNo.Location = new System.Drawing.Point(80, 29);
            this.lbl_PackNo.Name = "lbl_PackNo";
            this.lbl_PackNo.Size = new System.Drawing.Size(42, 13);
            this.lbl_PackNo.TabIndex = 2;
            this.lbl_PackNo.Text = "Pack #";
            this.lbl_PackNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Den
            // 
            this.lbl_Den.AutoSize = true;
            this.lbl_Den.Location = new System.Drawing.Point(175, 30);
            this.lbl_Den.Name = "lbl_Den";
            this.lbl_Den.Size = new System.Drawing.Size(30, 13);
            this.lbl_Den.TabIndex = 3;
            this.lbl_Den.Text = "Den:";
            this.lbl_Den.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // img_Den
            // 
            this.img_Den.BackgroundImage = global::DerbyTime.Properties.Resources.Badge_Scout_2000;
            this.img_Den.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.img_Den.Location = new System.Drawing.Point(276, 3);
            this.img_Den.Name = "img_Den";
            this.img_Den.Size = new System.Drawing.Size(41, 41);
            this.img_Den.TabIndex = 5;
            this.img_Den.TabStop = false;
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackgroundImage = global::DerbyTime.Properties.Resources.Menu_Edit_64;
            this.btn_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Edit.Location = new System.Drawing.Point(323, 3);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(41, 41);
            this.btn_Edit.TabIndex = 6;
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackgroundImage = global::DerbyTime.Properties.Resources.Menu_Delete_64;
            this.btn_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Delete.Location = new System.Drawing.Point(370, 3);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(41, 41);
            this.btn_Delete.TabIndex = 7;
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // DriverControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.img_Den);
            this.Controls.Add(this.lbl_Den);
            this.Controls.Add(this.lbl_PackNo);
            this.Controls.Add(this.lbl_ChildName);
            this.Controls.Add(this.lbl_RaceNum);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DriverControl";
            this.Size = new System.Drawing.Size(415, 47);
            ((System.ComponentModel.ISupportInitialize)(this.img_Den)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_RaceNum;
        private System.Windows.Forms.Label lbl_ChildName;
        private System.Windows.Forms.Label lbl_PackNo;
        private System.Windows.Forms.Label lbl_Den;
        private System.Windows.Forms.PictureBox img_Den;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_Delete;
    }
}
