using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumVR
{
    internal class Waitning
    {
        Panel pnl;
        bool active = false;
        Timer tmr;
        int tick = 0;
        int limit;
        public Waitning(Panel pnl_main, int limit = 5)
        {
            pnl = new Panel();
            pnl.Visible = false;
            pnl.BackColor = Color.White;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = new Bitmap("pic/wait.gif");
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Left = pnl_main.Width / 2 - pictureBox.Width / 2;
            pictureBox.Top = pnl_main.Height / 2 - pictureBox.Height / 2;

            pnl.Dock = DockStyle.Fill;
            pnl.Controls.Add(pictureBox);
            pictureBox.Visible = true;
            tmr = new Timer();
            tmr.Interval = 100;
            tmr.Tick += Tmr_Tick;
            this.limit = limit;
            pnl.Name = "wait";
        }

        private void Tmr_Tick(object? sender, EventArgs e)
        {
            ++tick;
            if (tick == limit)
            {
                stop();
            }
        }
        
        private void stop()
        {
            tick = 0;
            active = false;
            pnl.Visible = false;
            tmr.Enabled = false;
           
            drawFunc?.Invoke();
        }

        public Panel Panel { get { return pnl; } }

        public delegate void DrawFunc();
        DrawFunc drawFunc;
        public bool Start(DrawFunc drawFunc = null)
        {
            //if (active)
           // {
             //   return false;
           // }

            this.drawFunc = drawFunc;

            active = true;
            tmr.Enabled = true;
            pnl.Visible = true;

            return true;
        }
    }

    internal class Drawer
    {
        bool WAIT_ANIMATION = true;
        Panel pnl;
        Panel panelContent;
        //AxWMPLib.AxWindowsMediaPlayer video_player;
        Waitning waitning;
        public Drawer(Panel pnl) {
            this.pnl = pnl;
            waitning = new Waitning(pnl);
            panelContent = new Panel();
            panelContent.Dock = DockStyle.Fill;
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
                if (WAIT_ANIMATION)
                {
                    this.pnl.Controls.Add(waitning.Panel);
                    waitning.Start();
                    drawImage(new Bitmap(item.Path));
                    panelContent.Visible = true;
                }
                else 
                {
                    drawImage(new Bitmap(item.Path));
                }
               
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
            if (WAIT_ANIMATION == false)
            {
                 if (pnl.Controls.Count > 1)
                 {
                    pnl.Controls.Remove(pnl.Controls[0]);
                 }
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
            if (WAIT_ANIMATION)
            {
                panelContent.Visible = false;
                StopPlayer();
                PictureBox pbx = new PictureBox();
                pbx.Visible = true;
                pbx.SizeMode = PictureBoxSizeMode.StretchImage;
                pbx.Dock = DockStyle.Fill;
                pbx.Image = bit;
                panelContent.Controls.Clear();
                panelContent.Controls.Add(pbx);
                pnl.Controls.Add(panelContent);
            }
            else
            {
                PictureBox pbx = new PictureBox();
                pbx.SizeMode = PictureBoxSizeMode.StretchImage;
                pbx.Dock = DockStyle.Fill;
                pbx.Image = bit;
                pnl.Controls.Add((PictureBox)pbx);
            }
        }
    }
}
