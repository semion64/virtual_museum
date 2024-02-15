using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MuseumVR
{
    internal class Map
    {
        Item item;
        public Map(string museum_dir)
        {
            item = new Item("", null);
            dirSearch(museum_dir, item);
        }

        public void Show()
        {
            item.Show(0);
        }

        public void ShowMenu()
        {
            item.ShowMenu();
        }

        public Item GetItem() { 
            return item; 
        }
        private void dirSearch(string sDir, Item parent)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    Item new_dir = new Item(d, parent);

                    foreach (string f in Directory.GetFiles(d))
                    {
                        new_dir.AddItem(new Item(f, new_dir));
                        //Console.WriteLine(f);
                    }

                    parent.AddItem(new_dir);
                    dirSearch(d, new_dir);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
    }
}
