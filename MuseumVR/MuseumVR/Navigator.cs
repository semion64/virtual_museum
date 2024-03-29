﻿using Microsoft.VisualBasic;
using MuseumVR.Properties;
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
    internal class Navigator
    {
        private Item currentItem;
        private Panel template_main;
        private Panel template_bottom;
        private Panel template_top;

        private Slider slider;

        private Drawer drawer;
       
        private Menu menu;
        private NavLabel navLabel;
        public Navigator(Item item, Panel main_panel, Panel top_panel, Panel bottom_panel) {
            this.currentItem = item;
            this.template_main = main_panel;
            this.template_top = top_panel;
            this.template_bottom = bottom_panel;
            
            initControls();

            drawer = SETTINGS.ANIMATION_TIME > 0 ? new DrawerAnimated(menu.MainPanel) : new DrawerSimple(menu.MainPanel);
        }

        public void Update()
        {
            updateMainPanel(currentItem);
            updateBottomPanel(currentItem);
        }
        
        private void updateMainPanel(Item item) {
            if (item[0].CountChilds == 0)
            {
                menu.MainPanel.Controls.Clear();
                startSlider(item);

                navLabel.Text = Item.GetNavigationString(item[0]);
                return;
            }

            menu.MainPanel.Controls.Clear();
            updateMenu(item);
        }

        private void updateBottomPanel(Item item)
        {
            if (currentItem.GetParent() == null) 
            {
                menu.SetButtonVisibility(Menu.Buttons.Back, false);
                return;
            }

            menu.SetButtonVisibility(Menu.Buttons.Back, true);
        }

        private void btn_Click_Main(object? sender, EventArgs e, Item item)
        {
            currentItem = item;
            Update();
        }

        private void btn_Click_Prev(object? sender, EventArgs e)
        {
            if (slider.Count > 1) 
            {
                menu.SetButtonVisibility(Menu.Buttons.Next, true); 
            }

            drawer.DrawSlide(slider.PrevSlide());
            navLabel.Text = Item.GetNavigationString(slider.CurrSlide());

            if (slider.Curr == 0) 
            { 
                menu.SetButtonVisibility(Menu.Buttons.Prev, false); 
            }
        }

        private void btn_Click_Next(object? sender, EventArgs e)
        {
            if (slider.Count > 1) 
            {
                menu.SetButtonVisibility(Menu.Buttons.Prev, true); 
            }

            drawer.DrawSlide(slider.NextSlide());
            navLabel.Text = Item.GetNavigationString(slider.CurrSlide());

            if (slider.Curr == slider.Count - 1) 
            { 
                menu.SetButtonVisibility(Menu.Buttons.Next, false); 
            }
        }

        private void btn_Click_Back(object? sender, EventArgs e)
        {
            drawer.StopPlayer();
            btn_Click_Main(null, null, currentItem.GetParent());
        }

        private void startSlider(Item item)
        {
            slider = new Slider(item);
            drawer.DrawSlide(slider.CurrSlide());
            if (item.CountChilds > 1)
            {
                menu.SetButtonVisibility(Menu.Buttons.Next, true);
            }
        }

        private void updateMenu(Item item)
        {
            menu.Update(item, btn_Click_Main);
            navLabel.Text = Item.GetNavigationString(item);
        }

        private void initControls() {

            template_main.BackgroundImage = Resources.Image(Resources.Pic.PanelMain);
            template_top.BackgroundImage = Resources.Image(Resources.Pic.PanelTop);
            template_bottom.BackgroundImage = Resources.Image(Resources.Pic.PanelBottom);
            template_main.BackgroundImageLayout = ImageLayout.Stretch;
            template_main.BackgroundImageLayout = ImageLayout.Stretch;
            template_main.BackgroundImageLayout = ImageLayout.Stretch;

            this.menu = new Menu();
            menu.SetButtonClickProc(Menu.Buttons.Next, btn_Click_Next);
            menu.SetButtonClickProc(Menu.Buttons.Prev, btn_Click_Prev);
            menu.SetButtonClickProc(Menu.Buttons.Back, btn_Click_Back);

            template_main.Controls.Add(menu.GetButton(Menu.Buttons.Next));
            template_main.Controls.Add(menu.GetButton(Menu.Buttons.Prev));
            template_main.Controls.Add(menu.MainPanel);
            template_bottom.Controls.Add(menu.BottomPanel);

            navLabel = new NavLabel(template_top);
            template_top.Controls.Add(navLabel.Label);
        }
        public void UpdateCoord(int width, int height)
        {
            int margin = 64;
            template_top.Height = Resources.Image(Resources.Pic.PanelTop).Height;
            template_bottom.Height = Resources.Image(Resources.Pic.PanelBottom).Height;
            template_main.Height = height - template_top.Height - template_bottom.Height;

            menu.UpdateCoord(margin, template_main, template_bottom);
            drawer.UpdateCoord();
            navLabel.UpdateCoord();
        }
    }
}
