namespace AP1
{
    partial class MdiMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFrmAcademyRecord = new System.Windows.Forms.Button();
            this.btnEmploymentRecord = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.pbUni = new System.Windows.Forms.PictureBox();
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUni)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 561);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pbUni, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFrmAcademyRecord, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnEmploymentRecord, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAbout, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnFrmAcademyRecord
            // 
            this.btnFrmAcademyRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrmAcademyRecord.BackColor = System.Drawing.Color.White;
            this.btnFrmAcademyRecord.FlatAppearance.BorderSize = 0;
            this.btnFrmAcademyRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrmAcademyRecord.Location = new System.Drawing.Point(3, 193);
            this.btnFrmAcademyRecord.Name = "btnFrmAcademyRecord";
            this.btnFrmAcademyRecord.Size = new System.Drawing.Size(194, 55);
            this.btnFrmAcademyRecord.TabIndex = 1;
            this.btnFrmAcademyRecord.Text = "Registro Académico";
            this.btnFrmAcademyRecord.UseVisualStyleBackColor = false;
            this.btnFrmAcademyRecord.Click += new System.EventHandler(this.BtnFrmAcademyRecord_Click);
            // 
            // btnEmploymentRecord
            // 
            this.btnEmploymentRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmploymentRecord.FlatAppearance.BorderSize = 0;
            this.btnEmploymentRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmploymentRecord.Location = new System.Drawing.Point(3, 315);
            this.btnEmploymentRecord.Name = "btnEmploymentRecord";
            this.btnEmploymentRecord.Size = new System.Drawing.Size(194, 55);
            this.btnEmploymentRecord.TabIndex = 2;
            this.btnEmploymentRecord.Text = "Registro Laboral";
            this.btnEmploymentRecord.UseVisualStyleBackColor = true;
            this.btnEmploymentRecord.Click += new System.EventHandler(this.BtnEmploymentRecord_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Location = new System.Drawing.Point(3, 437);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(194, 55);
            this.btnAbout.TabIndex = 3;
            this.btnAbout.Text = "Acerca de";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // pbUni
            // 
            this.pbUni.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbUni.Image = global::AP1.Properties.Resources.logo;
            this.pbUni.Location = new System.Drawing.Point(26, 47);
            this.pbUni.Name = "pbUni";
            this.pbUni.Size = new System.Drawing.Size(147, 96);
            this.pbUni.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUni.TabIndex = 0;
            this.pbUni.TabStop = false;
            this.pbUni.Visible = false;
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Location = new System.Drawing.Point(200, 0);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(492, 561);
            this.ContainerPanel.TabIndex = 1;
            // 
            // MdiMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(692, 561);
            this.Controls.Add(this.ContainerPanel);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(620, 500);
            this.Name = "MdiMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmización y Estructuras de Datos";
            this.Load += new System.EventHandler(this.MdiMain_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUni)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnEmploymentRecord;
        private System.Windows.Forms.PictureBox pbUni;
        private System.Windows.Forms.Button btnFrmAcademyRecord;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Panel ContainerPanel;
    }
}