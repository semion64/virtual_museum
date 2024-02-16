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
            InitializeComponent();
            pnlMain.BackgroundImage = new Bitmap("pic/main.png");
            mapper = new Map(SETTINGS.MUSEUM_DIR);
            navigator = new Navigator(mapper.GetItem(), pnlMain, pnlTop, pnlBottom);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            navigator.Update();
        }

        private void tableLayoutPanel1_Resize(object sender, EventArgs e)
        {
            navigator.UpdateCoord();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
