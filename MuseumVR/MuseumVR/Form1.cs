using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumVR
{
    public partial class Form1 : Form
    {
        Navigator navigator;
        Map mapper;
        public Form1()
        {
            this.FormBorderStyle = SETTINGS.FULL_SCREEN ? FormBorderStyle.None : FormBorderStyle.Sizable;
            InitializeComponent();
            mapper = new Map(SETTINGS.MUSEUM_DIR);
            navigator = new Navigator(mapper.GetItem(), pnlMain, pnlTop, pnlBottom);

            navigator.UpdateCoord(this.Width, this.Height);

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            navigator.Update();
        }

        private void tableLayoutPanel1_Resize(object sender, EventArgs e)
        {
            navigator.UpdateCoord(this.Width, this.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            navigator.UpdateCoord(this.Width, this.Height);
        }
    }
}
