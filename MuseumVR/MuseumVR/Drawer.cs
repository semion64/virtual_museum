using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumVR
{
    internal class Drawer
    {
        Panel pnl;
      

        //AxWMPLib.AxWindowsMediaPlayer video_player;

        public Drawer(Panel pnl) {
            this.pnl = pnl;

          /*  video_player = new AxWMPLib.AxWindowsMediaPlayer();

           // System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));

             ((System.ComponentModel.ISupportInitialize)video_player).BeginInit();
            video_player.Enabled = true;
            video_player.Location = new System.Drawing.Point(515, 63);
            video_player.Name = "axWindowsMediaPlayer";
            //axWindowsMediaPlayer.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            //axWindowsMediaPlayer.Size = new System.Drawing.Size(302, 276);
            video_player.TabIndex = 1;
            //axWindowsMediaPlayer.CreateControl();
            video_player.Dock = DockStyle.Fill;
            ((System.ComponentModel.ISupportInitialize)video_player).EndInit();*/

        }

        public void DrawSlide(Item item) {
            string ext = Path.GetExtension(item.Path);
            if (ext.ToUpper() == ".JPG" 
                || ext.ToUpper() == ".JPEG" 
                || ext.ToUpper() == ".PNG" 
                || ext.ToUpper() == ".SVG" 
                || ext.ToUpper() == ".WEBMP"
                || ext.ToUpper() == ".BMP"
                || ext.ToUpper() == ".GIF")
            {
                drawImage(new Bitmap(item.Path));
            }
            else if (ext.ToUpper() == ".MPG" 
                || ext.ToUpper() == ".AVI" 
                || ext.ToUpper() == ".MPEG" 
                || ext.ToUpper() == ".MP4" 
                || ext.ToUpper() == ".MPEG4" 
                || ext.ToUpper() == ".MOV" 
                || ext.ToUpper() == ".WMV" 
                || ext.ToUpper() == ".3GP" 
                || ext.ToUpper() == ".MP3" 
                || ext.ToUpper() == ".WMA") 
            {
                drawVideo(item.Path);
            }

            if (pnl.Controls.Count > 1)
            {
                pnl.Controls.Remove(pnl.Controls[0]);
            }

            return;
        }

        public void StopPlayer()
        {
            /*video_player.Ctlcontrols.stop();*/
        }

        private void drawVideo(string path)
        {
            /*pnl.Controls.Add(video_player);
            video_player.Visible = true;
            video_player.URL = path;*/
        }

        private void drawImage(Bitmap bit)
        {
            StopPlayer();
            PictureBox pbx = new PictureBox();
            pbx.SizeMode = PictureBoxSizeMode.StretchImage;
            pbx.Dock = DockStyle.Fill;
            pbx.Image = bit;
            pnl.Controls.Add((PictureBox)pbx);
        }
    }
}
