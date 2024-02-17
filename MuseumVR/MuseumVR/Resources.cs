using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumVR
{
    internal static class Resources
    {
        public enum Pic {
            BtnMenu,
            BtnMenuHover,
            BtnBack,
            BtnBackHover,
            BtnNext,
            BtnNextHover,
            BtnPrev,
            BtnPrevHover,
            TopPanel,
            MainPanel,
            BottomPanel,
            WaitPanel,
            WaitAnim
        }

        static bool isInitialized = false;
        static Dictionary<Pic, Bitmap> bitmaps;

        static Resources() {
            bitmaps = new Dictionary<Pic, Bitmap>();
            string dir = "layout";
            bitmaps[Pic.TopPanel] = new Bitmap($"{dir}/panels/top.png");
            bitmaps[Pic.BottomPanel] = new Bitmap($"{dir}/panels/bottom.png");
            bitmaps[Pic.MainPanel] = new Bitmap($"{dir}/panels/main.png");
            bitmaps[Pic.WaitPanel] = new Bitmap($"{dir}/panels/wait.png");
            bitmaps[Pic.WaitAnim] = new Bitmap($"{dir}/panels/wait.gif");
            bitmaps[Pic.BtnNext] = new Bitmap($"{dir}/buttons/next.png");
            bitmaps[Pic.BtnNextHover] = new Bitmap($"{dir}/buttons/next_hover.png");
            bitmaps[Pic.BtnBack] = new Bitmap($"{dir}/buttons/back.png");
            bitmaps[Pic.BtnBackHover] = new Bitmap($"{dir}/buttons/back_hover.png");
            bitmaps[Pic.BtnPrev] = new Bitmap($"{dir}/buttons/prev.png");
            bitmaps[Pic.BtnPrevHover] = new Bitmap($"{dir}/buttons/prev_hover.png");
            bitmaps[Pic.BtnMenu] = new Bitmap($"{dir}/buttons/menu.png");
            bitmaps[Pic.BtnMenuHover] = new Bitmap($"{dir}/buttons/menu_hover.png");

            isInitialized = true;
        }

        public static Bitmap Image(Pic pic)  {
            return bitmaps[pic];
        }
    }
}
