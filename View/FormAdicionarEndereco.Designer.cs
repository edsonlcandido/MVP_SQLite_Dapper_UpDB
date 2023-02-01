namespace MVP_SQLite_Dapper_UpDB.View
{
    partial class FormAdicionarEndereco
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
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnSearchByRua = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearchRua = new System.Windows.Forms.TextBox();
            this.buttonAddAddress = new System.Windows.Forms.Button();
            this.dgvEnderecos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnderecos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(313, 21);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(80, 30);
            this.btnShowAll.TabIndex = 2;
            this.btnShowAll.Text = "Clear";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnSearchByRua
            // 
            this.btnSearchByRua.Location = new System.Drawing.Point(227, 21);
            this.btnSearchByRua.Name = "btnSearchByRua";
            this.btnSearchByRua.Size = new System.Drawing.Size(80, 30);
            this.btnSearchByRua.TabIndex = 1;
            this.btnSearchByRua.Text = "Search";
            this.btnSearchByRua.UseVisualStyleBackColor = true;
            this.btnSearchByRua.Click += new System.EventHandler(this.btnSearchByRua_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 28;
            this.label6.Text = "Street";
            // 
            // txtSearchRua
            // 
            this.txtSearchRua.Location = new System.Drawing.Point(55, 26);
            this.txtSearchRua.Name = "txtSearchRua";
            this.txtSearchRua.Size = new System.Drawing.Size(166, 23);
            this.txtSearchRua.TabIndex = 0;
            // 
            // buttonAddAddress
            // 
            this.buttonAddAddress.Location = new System.Drawing.Point(12, 55);
            this.buttonAddAddress.Name = "buttonAddAddress";
            this.buttonAddAddress.Size = new System.Drawing.Size(166, 30);
            this.buttonAddAddress.TabIndex = 3;
            this.buttonAddAddress.Text = "Add selected";
            this.buttonAddAddress.UseVisualStyleBackColor = true;
            this.buttonAddAddress.Click += new System.EventHandler(this.buttonAddAddress_Click);
            // 
            // dgvEnderecos
            // 
            this.dgvEnderecos.AllowUserToAddRows = false;
            this.dgvEnderecos.AllowUserToDeleteRows = false;
            this.dgvEnderecos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEnderecos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvEnderecos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnderecos.Location = new System.Drawing.Point(2, 91);
            this.dgvEnderecos.MultiSelect = false;
            this.dgvEnderecos.Name = "dgvEnderecos";
            this.dgvEnderecos.ReadOnly = true;
            this.dgvEnderecos.RowTemplate.Height = 25;
            this.dgvEnderecos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEnderecos.Size = new System.Drawing.Size(606, 501);
            this.dgvEnderecos.TabIndex = 4;
            // 
            // FormAdicionarEndereco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 593);
            this.Controls.Add(this.dgvEnderecos);
            this.Controls.Add(this.buttonAddAddress);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnSearchByRua);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSearchRua);
            this.Name = "FormAdicionarEndereco";
            this.Text = "Add address";
            this.Load += new System.EventHandler(this.FormAdicionarEndereco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnderecos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnShowAll;
        private Button btnSearchByRua;
        private Label label6;
        private TextBox txtSearchRua;
        private Button buttonAddAddress;
        private DataGridView dgvEnderecos;
    }
}