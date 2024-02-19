using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumVR
{
    internal class VideoPlayer
    {
        // https://stackoverflow.com/questions/4015217/cant-find-references-microsoft-directx-audiovideoplayback-and-microsoft-directx
        // https://www.microsoft.com/ru-ru/download/details.aspx?id=6812
        AxWMPLib.AxWindowsMediaPlayer video_player;
        Panel pnl;
        public VideoPlayer(Panel pnl)
        {
            video_player = new AxWMPLib.AxWindowsMediaPlayer();
            this.pnl = pnl;
            // System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));

            ((System.ComponentModel.ISupportInitialize)video_player).BeginInit();
            video_player.Enabled = true;

            //video_player.Location = new System.Drawing.Point(515, 63);
            video_player.Name = "axWindowsMediaPlayer";
            //axWindowsMediaPlayer.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            //axWindowsMediaPlayer.Size = new System.Drawing.Size(302, 276);
            video_player.TabIndex = 1;
            //axWindowsMediaPlayer.CreateControl();
            video_player.Dock = DockStyle.Fill;
            ((System.ComponentModel.ISupportInitialize)video_player).EndInit();
        }

        // private Video video;
        public void Start(string path)
        {
            try
            {
                pnl.Controls.Add(video_player);
                video_player.Visible = true;
                video_player.URL = path;
                video_player.Size = pnl.Size;
            }
            catch
            {
                MessageBox.Show($"Не могу воспроизвести видео файл: {path}");
            }
        }

        public void Stop()
        {
            
            try 
            {
                if (video_player.Visible) {
                    video_player.Visible = false;
                    pnl.Controls.Remove(video_player);
                }
                video_player.Ctlcontrols.stop();
            }
            catch 
            {

            }
        }
    }
}
