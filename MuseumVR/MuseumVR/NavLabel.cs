using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumVR
{
    internal class NavLabel
    {
        Label lbl_nav;
        public NavLabel()
        {
            lbl_nav = new Label();
            lbl_nav.Width = 1700;
            lbl_nav.Height = 75;
            lbl_nav.Font = new Font(SETTINGS.FONT_FAMILY, SETTINGS.FONT_SIZE, (FontStyle)(SETTINGS.FONT_STYLE));
            lbl_nav.BackColor = Color.Transparent;
        }

        public string Text 
        { 
            set { lbl_nav.Text = value; }
        }
        public Label Label
        {
            get { return lbl_nav; }
        }

        public void Centered(Panel pnl)
        {
            lbl_nav.Top = pnl.Height / 2 - lbl_nav.Height / 2;
            lbl_nav.Left = pnl.Width / 2 - lbl_nav.Width / 2;
        }

        
    }
}
