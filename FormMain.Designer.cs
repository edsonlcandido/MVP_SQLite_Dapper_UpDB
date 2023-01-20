namespace MVP_SQLite_Dapper_UpDB
{
    partial class FormMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAddresses = new System.Windows.Forms.Button();
            this.buttonUsers = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAddresses);
            this.panel1.Controls.Add(this.buttonUsers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 705);
            this.panel1.TabIndex = 0;
            // 
            // buttonAddresses
            // 
            this.buttonAddresses.Location = new System.Drawing.Point(15, 59);
            this.buttonAddresses.Margin = new System.Windows.Forms.Padding(6);
            this.buttonAddresses.Name = "buttonAddresses";
            this.buttonAddresses.Size = new System.Drawing.Size(224, 32);
            this.buttonAddresses.TabIndex = 1;
            this.buttonAddresses.Text = "Addresses";
            this.buttonAddresses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddresses.UseVisualStyleBackColor = true;
            this.buttonAddresses.Click += new System.EventHandler(this.buttonAddresses_Click);
            // 
            // buttonUsers
            // 
            this.buttonUsers.Location = new System.Drawing.Point(15, 15);
            this.buttonUsers.Margin = new System.Windows.Forms.Padding(6);
            this.buttonUsers.Name = "buttonUsers";
            this.buttonUsers.Size = new System.Drawing.Size(224, 32);
            this.buttonUsers.TabIndex = 0;
            this.buttonUsers.Text = "Users";
            this.buttonUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUsers.UseVisualStyleBackColor = true;
            this.buttonUsers.Click += new System.EventHandler(this.buttonUsers_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Users and Addresses";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Button buttonAddresses;
        private Button buttonUsers;
        private MenuStrip menuStrip1;
    }
}