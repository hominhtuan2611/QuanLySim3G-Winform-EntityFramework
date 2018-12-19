namespace QuanLySim3G.SubForm
{
    partial class TimSim
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dgvSim = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTimKiemSim = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSoSim = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChonSim = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSim)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLySim3G.Properties.Resources.delete;
            this.pictureBox1.Location = new System.Drawing.Point(882, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 30);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(472, 33);
            this.panel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "TÌM SIM";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::QuanLySim3G.Properties.Resources.delete;
            this.pictureBox2.Location = new System.Drawing.Point(435, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 30);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // dgvSim
            // 
            this.dgvSim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSim.Location = new System.Drawing.Point(15, 89);
            this.dgvSim.Name = "dgvSim";
            this.dgvSim.Size = new System.Drawing.Size(447, 237);
            this.dgvSim.TabIndex = 5;
            this.dgvSim.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSim_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnChonSim);
            this.panel2.Controls.Add(this.btnTimKiemSim);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.txtSoSim);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(15, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(459, 42);
            this.panel2.TabIndex = 11;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnTimKiemSim
            // 
            this.btnTimKiemSim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(126)))), ((int)(((byte)(0)))));
            this.btnTimKiemSim.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(126)))), ((int)(((byte)(0)))));
            this.btnTimKiemSim.FlatAppearance.BorderSize = 10;
            this.btnTimKiemSim.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTimKiemSim.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimKiemSim.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTimKiemSim.Location = new System.Drawing.Point(289, 3);
            this.btnTimKiemSim.Name = "btnTimKiemSim";
            this.btnTimKiemSim.Size = new System.Drawing.Size(74, 28);
            this.btnTimKiemSim.TabIndex = 14;
            this.btnTimKiemSim.Text = "Tìm ";
            this.btnTimKiemSim.UseVisualStyleBackColor = false;
            this.btnTimKiemSim.Click += new System.EventHandler(this.btnTimKiemSim_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(70, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 1);
            this.panel1.TabIndex = 6;
            // 
            // txtSoSim
            // 
            this.txtSoSim.BackColor = System.Drawing.SystemColors.Control;
            this.txtSoSim.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSoSim.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSoSim.Location = new System.Drawing.Point(68, 10);
            this.txtSoSim.Name = "txtSoSim";
            this.txtSoSim.Size = new System.Drawing.Size(202, 17);
            this.txtSoSim.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(3, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sim";
            // 
            // btnChonSim
            // 
            this.btnChonSim.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnChonSim.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(126)))), ((int)(((byte)(0)))));
            this.btnChonSim.FlatAppearance.BorderSize = 10;
            this.btnChonSim.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChonSim.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnChonSim.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnChonSim.Location = new System.Drawing.Point(371, 3);
            this.btnChonSim.Name = "btnChonSim";
            this.btnChonSim.Size = new System.Drawing.Size(74, 28);
            this.btnChonSim.TabIndex = 15;
            this.btnChonSim.Text = "Chọn";
            this.btnChonSim.UseVisualStyleBackColor = false;
            this.btnChonSim.Click += new System.EventHandler(this.btnChonSim_Click);
            // 
            // TimSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 340);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvSim);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TimSim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TimSim";
            this.Load += new System.EventHandler(this.TimSim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSim)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvSim;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSoSim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTimKiemSim;
        private System.Windows.Forms.Button btnChonSim;
    }
}