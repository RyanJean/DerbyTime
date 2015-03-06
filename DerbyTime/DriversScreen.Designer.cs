namespace DerbyTime
{
    partial class DriversScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriversScreen));
            this.DriversPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_Load = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DriversPanel
            // 
            this.DriversPanel.AutoScroll = true;
            this.DriversPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DriversPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.DriversPanel.Location = new System.Drawing.Point(12, 68);
            this.DriversPanel.Name = "DriversPanel";
            this.DriversPanel.Size = new System.Drawing.Size(434, 262);
            this.DriversPanel.TabIndex = 0;
            this.DriversPanel.WrapContents = false;
            // 
            // btn_Load
            // 
            this.btn_Load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Load.Image = global::DerbyTime.Properties.Resources.Menu_Load_40;
            this.btn_Load.Location = new System.Drawing.Point(13, 12);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(50, 50);
            this.btn_Load.TabIndex = 1;
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Save.Image = global::DerbyTime.Properties.Resources.Menu_Save_40;
            this.btn_Save.Location = new System.Drawing.Point(69, 12);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(50, 50);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Add.Image = global::DerbyTime.Properties.Resources.Menu_Add_40;
            this.btn_Add.Location = new System.Drawing.Point(396, 12);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(50, 50);
            this.btn_Add.TabIndex = 3;
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Ok.Location = new System.Drawing.Point(0, 336);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(458, 23);
            this.btn_Ok.TabIndex = 4;
            this.btn_Ok.Text = "Use These Drivers";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // DriversScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 359);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.DriversPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DriversScreen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drivers";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel DriversPanel;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Ok;


    }
}