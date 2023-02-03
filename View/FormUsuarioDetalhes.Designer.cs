namespace MVP_SQLite_Dapper_UpDB.View
{
    partial class FormUsuarioDetalhes
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewAddresses = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddAddress = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddresses)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "First name:";
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelFirstName.Location = new System.Drawing.Point(83, 9);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(83, 20);
            this.labelFirstName.TabIndex = 1;
            this.labelFirstName.Text = "First name";
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLastName.Location = new System.Drawing.Point(83, 38);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(81, 20);
            this.labelLastName.TabIndex = 3;
            this.labelLastName.Text = "Last name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last name:";
            // 
            // dataGridViewAddresses
            // 
            this.dataGridViewAddresses.AllowUserToAddRows = false;
            this.dataGridViewAddresses.AllowUserToDeleteRows = false;
            this.dataGridViewAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAddresses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewAddresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddresses.Location = new System.Drawing.Point(1, 102);
            this.dataGridViewAddresses.Name = "dataGridViewAddresses";
            this.dataGridViewAddresses.ReadOnly = true;
            this.dataGridViewAddresses.RowTemplate.Height = 25;
            this.dataGridViewAddresses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAddresses.Size = new System.Drawing.Size(607, 282);
            this.dataGridViewAddresses.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Addresses:";
            // 
            // buttonAddAddress
            // 
            this.buttonAddAddress.Location = new System.Drawing.Point(83, 75);
            this.buttonAddAddress.Name = "buttonAddAddress";
            this.buttonAddAddress.Size = new System.Drawing.Size(75, 23);
            this.buttonAddAddress.TabIndex = 6;
            this.buttonAddAddress.Text = "add";
            this.buttonAddAddress.UseVisualStyleBackColor = true;
            this.buttonAddAddress.Click += new System.EventHandler(this.buttonAddAddress_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(574, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormUsuarioDetalhes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 383);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonAddAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewAddresses);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.label1);
            this.Name = "FormUsuarioDetalhes";
            this.Text = "User details";
            this.Load += new System.EventHandler(this.FormUsuarioDetalhes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddresses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label labelFirstName;
        private Label labelLastName;
        private Label label3;
        private DataGridView dataGridViewAddresses;
        private Label label2;
        private Button buttonAddAddress;
        private Button button1;
    }
}