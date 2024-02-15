using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumVR
{
    internal class Item
    {
        private List<Item> childs = new List<Item>();
        private Item parent;
        string path;
        public Item(string name, Item parent)
        {
            this.parent = parent;
            this.path = name;
        }

        public void AddItem(Item item)
        {
            childs.Add(item);
        }

        public void Show(int level)
        {
            string tab = new string('\t', level++);
            Console.WriteLine($"{tab}{path}");
            foreach (var item in childs)
            {
                item.Show(level);
            }
        }

        public Item GetParent() { return parent; }
        public string Path { 
            get { return path; } 
        }
        public string Name
        {
            get {
                string file_name = System.IO.Path.GetFileName(path);
                if (file_name.Length > 0)
                {
                    return file_name;
                }

                return path.Split().Last();
            }
        }
        public string StripName
        {
            get 
            {
                return strip(this.Name);   
            }
        }
        public int CountChilds {
            get { return this.childs.Count; }
        }

        public string GetFullName()
        {
            if (parent == null)
            {
                return "Museum";
            }
            return parent.GetFullName() + " :: " + path;
        }

        public void ShowMenu()
        {
            Console.Clear();
            string tab = new string('\t', 1);

            int i = 0;
            Console.WriteLine($"{GetFullName()}: ");
            bool child_free = false;
            foreach (var item in childs)
            {
                child_free = !item.HasChild() ? true : child_free;
                Console.WriteLine($"{tab} {i++}. {item.Path} {child_free}");
            }

            if (!child_free)
            {
                Console.Write("choose dir (for back -1): ");
                int index = Convert.ToInt32(Console.ReadLine());
                if (index < 0)
                {
                    if (parent == null)
                    {
                        ShowMenu();
                        return;
                    }
                    parent.ShowMenu();
                    return;
                }

                childs[index].ShowMenu();
                return;
            }

            Console.Write("for back any number: ");
            Console.ReadLine();
            parent.ShowMenu();
            if (parent == null)
            {
                ShowMenu();
                return;
            }

        }

        public bool HasChild()
        {
            return childs.Count > 0;
        }

        public Item this[int index]
        {
            get
            {
                return childs[index];
            }
        }
        private static string strip(string str)
        {
            return str.Split('_').Last();
        }
        public static string GetNavigationString(Item item)
        {
            string path = item.Path;
            if (path.IndexOf('\\') > 0)
            {
                path = path.Substring(path.IndexOf('\\') + 1);
            }

            string res = "";

            foreach (var s in path.Split('\\'))
            {
                res += strip(s) + " / ";
            }

            res = res.Substring(0, res.Length - 3);
            return res;
        }
    }
}
