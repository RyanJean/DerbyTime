using System.Linq;
namespace DerbyTime
{
    partial class ConfigurationSettings
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
            { components.Dispose(); }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fld_PackNumber = new System.Windows.Forms.TextBox();
            this.fld_PackLocation = new System.Windows.Forms.TextBox();
            this.fld_LaneCount = new System.Windows.Forms.ComboBox();
            this.fld_Algorithm = new System.Windows.Forms.ComboBox();
            this.fld_Shuffle = new System.Windows.Forms.CheckBox();
            this.AlgorithmInfoBox = new System.Windows.Forms.GroupBox();
            this.AlgorithmInfo = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.fld_SaveRace = new System.Windows.Forms.CheckBox();
            this.AlgorithmInfoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter the following configuration settings so that DerbyTime can operate.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pack #:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pack Location:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "# of Lanes:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Scheduling Algorithm:";
            // 
            // fld_PackNumber
            // 
            this.fld_PackNumber.Location = new System.Drawing.Point(153, 40);
            this.fld_PackNumber.Name = "fld_PackNumber";
            this.fld_PackNumber.Size = new System.Drawing.Size(50, 20);
            this.fld_PackNumber.TabIndex = 6;
            // 
            // fld_PackLocation
            // 
            this.fld_PackLocation.Location = new System.Drawing.Point(153, 65);
            this.fld_PackLocation.Name = "fld_PackLocation";
            this.fld_PackLocation.Size = new System.Drawing.Size(150, 20);
            this.fld_PackLocation.TabIndex = 7;
            // 
            // fld_LaneCount
            // 
            this.fld_LaneCount.FormattingEnabled = true;
            this.fld_LaneCount.Location = new System.Drawing.Point(153, 90);
            this.fld_LaneCount.Name = "fld_LaneCount";
            this.fld_LaneCount.Size = new System.Drawing.Size(50, 21);
            this.fld_LaneCount.TabIndex = 8;
            // 
            // fld_Algorithm
            // 
            this.fld_Algorithm.FormattingEnabled = true;
            this.fld_Algorithm.Location = new System.Drawing.Point(153, 115);
            this.fld_Algorithm.Name = "fld_Algorithm";
            this.fld_Algorithm.Size = new System.Drawing.Size(150, 21);
            this.fld_Algorithm.TabIndex = 9;
            // 
            // fld_Shuffle
            // 
            this.fld_Shuffle.AutoSize = true;
            this.fld_Shuffle.Checked = true;
            this.fld_Shuffle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fld_Shuffle.Location = new System.Drawing.Point(153, 140);
            this.fld_Shuffle.Name = "fld_Shuffle";
            this.fld_Shuffle.Size = new System.Drawing.Size(96, 17);
            this.fld_Shuffle.TabIndex = 11;
            this.fld_Shuffle.Text = "Shuffle Heats?";
            this.fld_Shuffle.UseVisualStyleBackColor = true;
            // 
            // AlgorithmInfoBox
            // 
            this.AlgorithmInfoBox.Controls.Add(this.AlgorithmInfo);
            this.AlgorithmInfoBox.Location = new System.Drawing.Point(15, 163);
            this.AlgorithmInfoBox.Name = "AlgorithmInfoBox";
            this.AlgorithmInfoBox.Size = new System.Drawing.Size(381, 100);
            this.AlgorithmInfoBox.TabIndex = 12;
            this.AlgorithmInfoBox.TabStop = false;
            this.AlgorithmInfoBox.Text = "Algorithm Information:";
            // 
            // AlgorithmInfo
            // 
            this.AlgorithmInfo.Location = new System.Drawing.Point(7, 20);
            this.AlgorithmInfo.Multiline = true;
            this.AlgorithmInfo.Name = "AlgorithmInfo";
            this.AlgorithmInfo.Size = new System.Drawing.Size(368, 74);
            this.AlgorithmInfo.TabIndex = 0;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(113, 270);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 13;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(228, 270);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 14;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // fld_SaveRace
            // 
            this.fld_SaveRace.AutoSize = true;
            this.fld_SaveRace.Checked = true;
            this.fld_SaveRace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fld_SaveRace.Location = new System.Drawing.Point(255, 140);
            this.fld_SaveRace.Name = "fld_SaveRace";
            this.fld_SaveRace.Size = new System.Drawing.Size(111, 17);
            this.fld_SaveRace.TabIndex = 15;
            this.fld_SaveRace.Text = "Auto-Save Race?";
            this.fld_SaveRace.UseVisualStyleBackColor = true;
            // 
            // ConfigurationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 305);
            this.Controls.Add(this.fld_SaveRace);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.AlgorithmInfoBox);
            this.Controls.Add(this.fld_Shuffle);
            this.Controls.Add(this.fld_Algorithm);
            this.Controls.Add(this.fld_LaneCount);
            this.Controls.Add(this.fld_PackLocation);
            this.Controls.Add(this.fld_PackNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConfigurationSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration Settings";
            this.AlgorithmInfoBox.ResumeLayout(false);
            this.AlgorithmInfoBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fld_PackNumber;
        private System.Windows.Forms.TextBox fld_PackLocation;
        private System.Windows.Forms.ComboBox fld_LaneCount;
        private System.Windows.Forms.ComboBox fld_Algorithm;
        private System.Windows.Forms.CheckBox fld_Shuffle;
        private System.Windows.Forms.CheckBox fld_SaveRace;
        private System.Windows.Forms.GroupBox AlgorithmInfoBox;
        private System.Windows.Forms.TextBox AlgorithmInfo;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancel;
    }
}