namespace DerbyTime
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.btn_Drivers = new System.Windows.Forms.Button();
            this.btn_Race = new System.Windows.Forms.Button();
            this.btn_Config = new System.Windows.Forms.Button();
            this.btn_About = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Drivers
            // 
            this.btn_Drivers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Drivers.Image = global::DerbyTime.Properties.Resources.Menu_Wheel;
            this.btn_Drivers.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Drivers.Location = new System.Drawing.Point(12, 93);
            this.btn_Drivers.Name = "btn_Drivers";
            this.btn_Drivers.Size = new System.Drawing.Size(225, 75);
            this.btn_Drivers.TabIndex = 2;
            this.btn_Drivers.Text = "Driver\r\nRegistration";
            this.btn_Drivers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Drivers.UseVisualStyleBackColor = true;
            this.btn_Drivers.Click += new System.EventHandler(this.btn_Drivers_Click);
            // 
            // btn_Race
            // 
            this.btn_Race.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Race.Image = global::DerbyTime.Properties.Resources.Menu_Flag;
            this.btn_Race.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Race.Location = new System.Drawing.Point(12, 174);
            this.btn_Race.Name = "btn_Race";
            this.btn_Race.Size = new System.Drawing.Size(224, 75);
            this.btn_Race.TabIndex = 1;
            this.btn_Race.Text = "Race!";
            this.btn_Race.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Race.UseVisualStyleBackColor = true;
            this.btn_Race.Click += new System.EventHandler(this.btn_Race_Click);
            // 
            // btn_Config
            // 
            this.btn_Config.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Config.Image = global::DerbyTime.Properties.Resources.Menu_Gear;
            this.btn_Config.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Config.Location = new System.Drawing.Point(12, 12);
            this.btn_Config.Name = "btn_Config";
            this.btn_Config.Size = new System.Drawing.Size(225, 75);
            this.btn_Config.TabIndex = 0;
            this.btn_Config.Text = "System\r\nConfiguration";
            this.btn_Config.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Config.UseVisualStyleBackColor = true;
            this.btn_Config.Click += new System.EventHandler(this.btn_Config_Click);
            // 
            // btn_About
            // 
            this.btn_About.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_About.Image = global::DerbyTime.Properties.Resources.Menu_Info;
            this.btn_About.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_About.Location = new System.Drawing.Point(80, 255);
            this.btn_About.Name = "btn_About";
            this.btn_About.Size = new System.Drawing.Size(90, 38);
            this.btn_About.TabIndex = 3;
            this.btn_About.Text = "About";
            this.btn_About.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_About.UseVisualStyleBackColor = true;
            this.btn_About.Click += new System.EventHandler(this.btn_About_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 305);
            this.Controls.Add(this.btn_About);
            this.Controls.Add(this.btn_Drivers);
            this.Controls.Add(this.btn_Race);
            this.Controls.Add(this.btn_Config);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DerbyTime!";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Config;
        private System.Windows.Forms.Button btn_Race;
        private System.Windows.Forms.Button btn_Drivers;
        private System.Windows.Forms.Button btn_About;
    }
}