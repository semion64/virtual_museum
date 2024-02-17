using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumVR
{
    internal static class ImageButton
    {
        //static Dictionary<string, Bitmap> btn_bitmap = new Dictionary<string, Bitmap>();
        static bool isInitialized = false;
        static Button btn;
        static ImageButton()
        {
           /* btn_bitmap["menu"] = Resources.Image(Resources.Pic.BtnMenu);
            btn_bitmap["menu-hover"] = Resources.Image(Resources.Pic.BtnMenuHover);
            btn_bitmap["prev"] = Resources.Image(Resources.Pic.BtnPrev);
            btn_bitmap["prev-hover"] = Resources.Image(Resources.Pic.BtnPrevHover);
            btn_bitmap["next"] = Resources.Image(Resources.Pic.BtnNext);
            btn_bitmap["next-hover"] = Resources.Image(Resources.Pic.BtnNextHover);
            btn_bitmap["back"] = Resources.Image(Resources.Pic.BtnBack);
            btn_bitmap["back-hover"] = Resources.Image(Resources.Pic.BtnBackHover);*/
            isInitialized = true;
        }

        static public  Button Create(Resources.Pic btn_name, int left, int top, DockStyle dockStyle = DockStyle.None)
        {
            Button btn = new Button();
            btn.Visible = false;
            btn.Left = left;
            btn.Top = top;
            btn.Dock = dockStyle;

            btn.BackgroundImage = Resources.Image(btn_name);
            btn.BackgroundImageLayout = ImageLayout.Stretch;
            btn.BackColor = Color.Transparent;
            btn.Size = Resources.Image(btn_name).Size;

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatStyle = FlatStyle.Flat;
            btn.UseVisualStyleBackColor = false;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn.MouseDown += (sender, EventArgs) => { btn_MouseDown(sender, EventArgs, btn_name); };
            btn.MouseUp += (sender, EventArgs) => { btn_MouseUp(sender, EventArgs, btn_name); };
            btn.Font = new Font(SETTINGS.BTN_FONT_FAMILY, SETTINGS.BTN_FONT_SIZE, (FontStyle)SETTINGS.NAV_FONT_STYLE);
            btn.ForeColor = SETTINGS.BTN_FONT_COLOR;
            
            return btn;
        }

        static private void btn_MouseDown(object sender, MouseEventArgs eventArgs, Resources.Pic btn_name)
        {
            ((Button)sender).BackgroundImage = Resources.Image((Resources.Pic) Enum.Parse(typeof(Resources.Pic), $"{btn_name.ToString()}Hover", true));
        }
        static private void btn_MouseUp(object sender, MouseEventArgs eventArgs, Resources.Pic btn_name)
        {
            ((Button)sender).BackgroundImage = Resources.Image(btn_name);
        }
    }
}
