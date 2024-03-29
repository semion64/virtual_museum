﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace MuseumVR
{
    
    internal class Menu
    {
        public enum Buttons
        {
            Back, Next, Prev
        }

        private Panel pnl_main;
        private Panel pnl_bottom;

        Dictionary<Buttons, Button> btns;
        public Menu()
        {
            pnl_main = new Panel();

            pnl_main.BackColor = Color.Transparent;
            
            pnl_main.Padding = new Padding(8);

            pnl_bottom = new Panel(); 
            pnl_bottom.Dock = DockStyle.Fill;
           
            btns = new Dictionary<Buttons, Button>();

            btns[Buttons.Back] = ImageButton.Create(Resources.Pic.BtnBack, 0, 0);
            btns[Buttons.Next] = ImageButton.Create(Resources.Pic.BtnNext, 0, 0);
            btns[Buttons.Prev] = ImageButton.Create(Resources.Pic.BtnPrev, 0, 0);
         
            pnl_bottom.Controls.Add(btns[Buttons.Back]);
        }

        public Panel MainPanel 
        {
            get { return pnl_main; }
        }

        public Panel BottomPanel
        {
            get { return pnl_bottom; }
        }

        public Button GetButton(Buttons btn) 
        {
            return btns[btn];
        }


        public delegate void BtnClickDelegate(object? sender, EventArgs e);
        public delegate void BtnMenuClickDelegate(object? sender, EventArgs e, Item it);

        public void SetButtonClickProc(Buttons button, BtnClickDelegate btn_click)
        {
            btns[button].Click += (o, e) => { btn_click(o, e); };
        }

        public void SetButtonVisibility(Buttons button, bool visible) { 
            btns[button].Visible = visible;
        }

        public List<Button> Update(Item item, BtnMenuClickDelegate btn_click)
        {
            pnl_main.AutoScroll = false ;
            List<Button> buttons = new List<Button>();
            pnl_main.Controls.Clear();
            SetButtonVisibility(Menu.Buttons.Prev, false);
            SetButtonVisibility(Menu.Buttons.Next, false);
            int top = 8;
            for (int i = 0; i < item.CountChilds; ++i)
            {
                Button btn = ImageButton.Create(Resources.Pic.BtnMenu, 8, top, DockStyle.None);
                btn.Text = item[i].StripName;
                Item it = item[i];
                btn.Click += (sender, EventArgs) => { btn_click(sender, EventArgs, it); };
                pnl_main.Controls.Add(btn);
                btn.Visible = true;
                top = btn.Bottom + 8;
                buttons.Add(btn);
            }
            pnl_main.AutoScroll = true;
            return buttons;

        }

        public void UpdateCoord(int margin, Panel main, Panel bottom) {
            Button btn_prev = btns[Buttons.Prev];
            Button btn_next = btns[Buttons.Next];
            Button btn_back = btns[Buttons.Back];
            pnl_main.Height = main.Height;
            pnl_main.Width = (pnl_main.Height * 4) / 3;
           
            btn_prev.Top = pnl_main.Height / 2 - btn_prev.Height / 2;
            btn_prev.Left = margin;

            btn_next.Top = pnl_main.Height / 2 - btn_next.Height / 2;
            btn_next.Left = main.Width - margin - btn_next.Width;

            btn_back.Top = bottom.Height / 2 - btn_back.Height / 2;
            btn_back.Left = bottom.Width / 2 - btn_back.Width / 2;

            centeredPanel(pnl_main, main);
            centeredPanel(pnl_bottom, bottom);
        }

        private void centeredPanel(Control front, Control back)
        {
            front.Left = back.Width / 2 - front.Width / 2;
            front.Top = back.Height / 2 - front.Height / 2;
        }
    }

}
