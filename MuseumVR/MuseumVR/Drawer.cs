using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumVR
{
    internal class Waitning
    {
        Panel pnl;
        Panel pnl_main;
        System.Windows.Forms.Timer tmr;
        int tick = 0;
        int limit;
        PictureBox pbx_wait_gif;
        public Waitning(Panel pnl_main, int limit = 5)
        {
            this.pnl_main = pnl_main;
            
            pnl = new Panel();
            pnl.Dock = DockStyle.Fill;
            pnl.Visible = false;
            pnl.BackgroundImage = Resources.Image(Resources.Pic.PanelWait);
            pnl.BackgroundImageLayout = ImageLayout.Stretch;

            pbx_wait_gif = new PictureBox();
            pbx_wait_gif.Image = Resources.Image(Resources.Pic.AnimWait);
            pbx_wait_gif.SizeMode = PictureBoxSizeMode.AutoSize;
           
            pnl.Controls.Add(pbx_wait_gif);
            pbx_wait_gif.Visible = true;
            tmr = new System.Windows.Forms.Timer();
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
            pnl.Visible = false;
            tmr.Enabled = false;
           
            drawFunc?.Invoke();
        }

        public Panel Panel { get { return pnl; } }

        public delegate void DrawFunc();
        DrawFunc drawFunc;
        public bool Start(DrawFunc drawFunc = null)
        {
            this.drawFunc = drawFunc;

            tmr.Enabled = true;
            pnl.Visible = true;

            return true;
        }

        public void UpdateCoord() {
            pbx_wait_gif.Left = pnl_main.Width / 2 - pbx_wait_gif.Width / 2;
            pbx_wait_gif.Top = pnl_main.Height / 2 - pbx_wait_gif.Height / 2;
        }
    }


    internal abstract class Drawer
    {
        protected bool WAIT_ANIMATION = true;
        protected Panel pnl;
        //AxWMPLib.AxWindowsMediaPlayer video_player;
        protected Waitning waitning;
        public Drawer(Panel pnl) {
            this.pnl = pnl;
            waitning = new Waitning(pnl, SETTINGS.ANIMATION_TIME);
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

        public virtual void DrawSlide(Item item) {
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

        abstract protected void drawImage(Bitmap bit);

        public void UpdateCoord() { 
            waitning.UpdateCoord();
        }
    }

    internal class DrawerSimple : Drawer
    {
        public DrawerSimple(Panel pnl) : base(pnl)
        {
        }

        protected override void drawImage(Bitmap bit)
        {
            PictureBox pbx = new PictureBox();
            pbx.SizeMode = PictureBoxSizeMode.StretchImage;
            pbx.Dock = DockStyle.Fill;
            pbx.Image = bit;
            pnl.Controls.Add((PictureBox)pbx);
        }

        public override void DrawSlide(Item item) {
            base.DrawSlide(item);
            if (pnl.Controls.Count > 1)
            {
                pnl.Controls.Remove(pnl.Controls[0]);
            }
        }
    }

    internal class DrawerAnimated : Drawer
    {

        protected Panel panelContent;
        public DrawerAnimated(Panel pnl) : base(pnl)
        {
            panelContent = new Panel();
            panelContent.Dock = DockStyle.Fill;
            this.pnl.Controls.Add(waitning.Panel);
        }

        protected override void drawImage(Bitmap bit)
        {
            this.pnl.Controls.Add(waitning.Panel);
            waitning.Start();

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
            panelContent.Visible = true;
        }
    }
}
