namespace QuanLySim3G
{
    partial class QLSim
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dgSim = new System.Windows.Forms.DataGridView();
            this.qlCuocDTDataSet1 = new QuanLySim3G.QLCuocDTDataSet();
            this.simBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.simTableAdapter = new QuanLySim3G.QLCuocDTDataSetTableAdapters.SimTableAdapter();
            this.maSimDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soSimDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgSim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlCuocDTDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sim";
            // 
            // dgSim
            // 
            this.dgSim.AutoGenerateColumns = false;
            this.dgSim.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgSim.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgSim.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgSim.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgSim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSim.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maSimDataGridViewTextBoxColumn,
            this.soSimDataGridViewTextBoxColumn,
            this.statusDataGridViewCheckBoxColumn});
            this.dgSim.DataSource = this.simBindingSource;
            this.dgSim.Location = new System.Drawing.Point(23, 44);
            this.dgSim.Name = "dgSim";
            this.dgSim.Size = new System.Drawing.Size(1027, 590);
            this.dgSim.TabIndex = 5;
            // 
            // qlCuocDTDataSet1
            // 
            this.qlCuocDTDataSet1.DataSetName = "QLCuocDTDataSet";
            this.qlCuocDTDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // simBindingSource
            // 
            this.simBindingSource.DataMember = "Sim";
            this.simBindingSource.DataSource = this.qlCuocDTDataSet1;
            // 
            // simTableAdapter
            // 
            this.simTableAdapter.ClearBeforeFill = true;
            // 
            // maSimDataGridViewTextBoxColumn
            // 
            this.maSimDataGridViewTextBoxColumn.DataPropertyName = "MaSim";
            this.maSimDataGridViewTextBoxColumn.HeaderText = "MaSim";
            this.maSimDataGridViewTextBoxColumn.Name = "maSimDataGridViewTextBoxColumn";
            this.maSimDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // soSimDataGridViewTextBoxColumn
            // 
            this.soSimDataGridViewTextBoxColumn.DataPropertyName = "SoSim";
            this.soSimDataGridViewTextBoxColumn.HeaderText = "SoSim";
            this.soSimDataGridViewTextBoxColumn.Name = "soSimDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewCheckBoxColumn
            // 
            this.statusDataGridViewCheckBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewCheckBoxColumn.HeaderText = "Status";
            this.statusDataGridViewCheckBoxColumn.Name = "statusDataGridViewCheckBoxColumn";
            // 
            // Sim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1077, 618);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgSim);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Sim";
            this.Text = "Sim";
            this.Load += new System.EventHandler(this.Sim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlCuocDTDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgSim;
        private QLCuocDTDataSet qlCuocDTDataSet1;
        private System.Windows.Forms.BindingSource simBindingSource;
        private QLCuocDTDataSetTableAdapters.SimTableAdapter simTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSimDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soSimDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn statusDataGridViewCheckBoxColumn;
    }
}