using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumVR
{
    internal class ImageButton
    {
        static Dictionary<string, Bitmap> btn_bitmap = new Dictionary<string, Bitmap>();
        static bool created = false;
        public ImageButton()
        {
           
        }
        static public  Button Create(string img_name, int left, int top, DockStyle dockStyle = DockStyle.None)
        {
            if(!created)
            {
                btn_bitmap["menu"] = new Bitmap("pic/btn_menu.png");
                btn_bitmap["menu-hover"] = new Bitmap("pic/btn_menu_hover.png");
                btn_bitmap["prev"] = new Bitmap("pic/prev.png");
                btn_bitmap["prev-hover"] = new Bitmap("pic/prev_hover.png");
                btn_bitmap["next"] = new Bitmap("pic/next.png");
                btn_bitmap["next-hover"] = new Bitmap("pic/next_hover.png");
                btn_bitmap["back"] = new Bitmap("pic/back.png");
                btn_bitmap["back-hover"] = new Bitmap("pic/back_hover.png");
                created = true;
            }

            Button btn = new Button();
            btn.Visible = false;
            btn.Left = left;
            btn.Top = top;
            btn.Dock = dockStyle;

            btn.BackgroundImage = btn_bitmap[img_name];
            btn.BackColor = Color.Transparent;
            btn.Size = btn_bitmap[img_name].Size;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatStyle = FlatStyle.Flat;
            btn.UseVisualStyleBackColor = false;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn.MouseDown += (sender, EventArgs) => { btn_MouseDown(sender, EventArgs, img_name); };
            btn.MouseUp += (sender, EventArgs) => { btn_MouseUp(sender, EventArgs, img_name); };
            btn.Font = new Font("Gabriola", 28, FontStyle.Italic);
            
            return btn;
        }

        static private void btn_MouseDown(object sender, MouseEventArgs eventArgs, string img_name)
        {
            ((Button)sender).BackgroundImage = btn_bitmap[img_name + "-hover"];
        }
        static private void btn_MouseUp(object sender, MouseEventArgs eventArgs, string img_name)
        {
            ((Button)sender).BackgroundImage = btn_bitmap[img_name];
        }
    }
}
