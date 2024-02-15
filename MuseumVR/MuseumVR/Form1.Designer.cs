namespace MuseumVR
{
    partial class Form1
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
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            pnlBottom = new System.Windows.Forms.Panel();
            pnlMain = new System.Windows.Forms.Panel();
            pnlTop = new System.Windows.Forms.Panel();
            button1 = new System.Windows.Forms.Button();
            tableLayoutPanel1.SuspendLayout();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(pnlBottom, 0, 2);
            tableLayoutPanel1.Controls.Add(pnlMain, 0, 1);
            tableLayoutPanel1.Controls.Add(pnlTop, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 900F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1408, 523);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Resize += tableLayoutPanel1_Resize;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
            pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlBottom.Location = new System.Drawing.Point(3, 967);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new System.Drawing.Size(1402, 58);
            pnlBottom.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = System.Drawing.Color.White;
            pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlMain.Location = new System.Drawing.Point(3, 67);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new System.Drawing.Size(1402, 894);
            pnlMain.TabIndex = 1;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
            pnlTop.Controls.Add(button1);
            pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlTop.Location = new System.Drawing.Point(3, 3);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new System.Drawing.Size(1402, 58);
            pnlTop.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(1323, 19);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1408, 523);
            Controls.Add(tableLayoutPanel1);
            DoubleBuffered = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "Form1";
            ShowIcon = false;
            Text = "Form1";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button button1;
    }
}
