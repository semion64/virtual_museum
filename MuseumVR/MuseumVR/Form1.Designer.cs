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
            pnlBottom = new System.Windows.Forms.Panel();
            pnlMain = new System.Windows.Forms.Panel();
            pnlTop = new System.Windows.Forms.Panel();
            SuspendLayout();
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
            pnlBottom.Dock = System.Windows.Forms.DockStyle.Top;
            pnlBottom.Location = new System.Drawing.Point(0, 312);
            pnlBottom.Margin = new System.Windows.Forms.Padding(0);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new System.Drawing.Size(1408, 64);
            pnlBottom.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = System.Drawing.Color.White;
            pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            pnlMain.Location = new System.Drawing.Point(0, 64);
            pnlMain.Margin = new System.Windows.Forms.Padding(0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new System.Drawing.Size(1408, 248);
            pnlMain.TabIndex = 1;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
            pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTop.Location = new System.Drawing.Point(0, 0);
            pnlTop.Margin = new System.Windows.Forms.Padding(0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new System.Drawing.Size(1408, 64);
            pnlTop.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1408, 523);
            Controls.Add(pnlBottom);
            Controls.Add(pnlMain);
            Controls.Add(pnlTop);
            DoubleBuffered = true;
            Name = "Form1";
            ShowIcon = false;
            Text = "MuseumVR";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += Form1_Load;
            Resize += Form1_Resize;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTop;
    }
}
