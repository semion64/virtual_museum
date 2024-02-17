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
        Panel pnl;
        public NavLabel(Panel panel)
        {
            lbl_nav = new Label();
            lbl_nav.AutoSize = true;
            lbl_nav.Font = new Font(SETTINGS.NAV_FONT_FAMILY, SETTINGS.NAV_FONT_SIZE, (FontStyle)(SETTINGS.NAV_FONT_STYLE));
            lbl_nav.ForeColor = SETTINGS.NAV_FONT_COLOR;
            lbl_nav.BackColor = Color.Transparent;
            this.pnl = panel;
        }

        public string Text 
        { 
            set { lbl_nav.Text = value; UpdateCoord();}
        }
        public Label Label
        {
            get { return lbl_nav; }
        }

        public void UpdateCoord()
        {
            lbl_nav.Left = pnl.Width / 16;
            lbl_nav.Top = pnl.Height / 2 - lbl_nav.Height / 2;
            
        }

        
    }
}
