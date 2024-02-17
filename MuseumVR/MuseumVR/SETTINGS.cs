using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MuseumVR
{
    internal static class SETTINGS
    {
        public static bool isInitialized = false;

        private static string museum_dir = "Data";
        private static int animation_time = 10;
        private static string font_family = "Gabriola";
        private static int font_style = 2;
        private static int font_size = 28;
        private static string full_screen = "ON";
        public static int ANIMATION_TIME
        {
            get
            {
                return animation_time;
            }
        }

        public static string FONT_FAMILY
        {
            get
            {
                return font_family;
            }
        }

        public static int FONT_STYLE
        {
            get
            {
                return font_style;
            }
        }

        public static int FONT_SIZE
        {
            get
            {
                return font_size;
            }
        }

        public static string MUSEUM_DIR 
        {
            get 
            {
                return museum_dir;
            }        
        }

        public static bool FULL_SCREEN
        {
            get
            {
                return full_screen == "ON";
            }
        }

        static SETTINGS()
        {
            if (!File.Exists("settings.txt")) {
                using (var sw = new StreamWriter("settings.txt"))
                {
                    
                    sw.WriteLine($"MUSEUM_DIR = {museum_dir}");
                    sw.WriteLine($"ANIMATION_TIME = {animation_time}");
                    sw.WriteLine($"FONT_FAMILY = {font_family}");
                    sw.WriteLine($"FONT_STYLE = {font_style}");
                    sw.WriteLine($"FONT_SIZE = {font_size}");
                    sw.WriteLine($"FULL_SCREEN = {full_screen}");
                }
            }
            using (StreamReader sr = new StreamReader("settings.txt"))
            {
                while (!sr.EndOfStream)
                {
                    
                    var line = sr.ReadLine();
                    var arr = line.Split('=');

                    if (arr[0].Trim().ToUpper() == "MUSEUM_DIR")
                    {
                        try
                        {
                            if (!Directory.Exists(arr[1].Trim()))
                            {
                                System.Windows.Forms.MessageBox.Show("Ошибка в файле setting.txt. Значение MUSEUM_DIR ссылается на несуществующую директорию. Проверьте правильность директории или укажите полный путь. Если имеются, то удалите пробелы в конце и в начале названия директории.");
                                continue;
                            }

                            museum_dir = arr[1].Trim();
                        }
                        catch (Exception)
                        {
                            System.Windows.Forms.MessageBox.Show("Ошибка в файле setting.txt. Значение ANIMATION_TIME  должно быть от 0 до 100");
                        }
                    }
                    else if (arr[0].Trim().ToUpper() == "ANIMATION_TIME")
                    {
                        try
                        {
                            int time = Convert.ToInt32(arr[1].Trim());
                            if (time < 0 || time > 100)
                            {
                                System.Windows.Forms.MessageBox.Show("Ошибка в файле setting.txt. Значение ANIMATION_TIME  должно быть от 0 до 100");
                                continue;
                            }
                            animation_time = Convert.ToInt32(arr[1].Trim());
                        }
                        catch (Exception)
                        {
                            System.Windows.Forms.MessageBox.Show("Ошибка в файле setting.txt. Значение ANIMATION_TIME  должно быть от 0 до 100");
                        }
                    }
                    else if (arr[0].Trim().ToUpper() == "FONT_FAMILY")
                    {
                        if (arr[1].Trim().Length > 0)
                        {
                            font_family = arr[1].Trim();
                        }
                    }
                    else if (arr[0].Trim().ToUpper() == "FONT_STYLE")
                    {
                        try
                        {
                            int style = Convert.ToInt32(arr[1].Trim());
                            if (style < 0 || style > 8) {
                                System.Windows.Forms.MessageBox.Show("Ошибка в файле setting.txt. Значение FONT_STYLE должно быть от 0 до 8ми");
                                continue;
                            }

                            font_style = style;
                        }
                        catch (Exception)
                        {
                            System.Windows.Forms.MessageBox.Show("Ошибка в файле setting.txt. Значение FONT_STYLE должно быть от 0 до 8ми");
                        }
                    }
                    else if (arr[0].Trim().ToUpper() == "FONT_SIZE")
                    {
                        try
                        {
                            int s = Convert.ToInt32(arr[1].Trim());
                            if (s < 8 || s > 72)
                            {
                                System.Windows.Forms.MessageBox.Show("Ошибка в файле setting.txt. Значение FONT_SIZE должно быть от 8 до 72-x");
                                continue;
                            }

                            font_size = s;
                        }
                        catch (Exception)
                        {
                            System.Windows.Forms.MessageBox.Show("Ошибка в файле setting.txt. Значение FONT_SIZE должно быть от 8 до 72-x");
                        }
                    }
                    else if (arr[0].Trim().ToUpper() == "FULL_SCREEN")
                    {
                        try
                        {
                            var s = arr[1].Trim().ToUpper();
                            if (s == "ON")
                            {
                                full_screen = "ON";
                            }
                            else if (s == "OFF")
                            {
                                full_screen = "OFF";
                            }
                            else 
                            {
                                System.Windows.Forms.MessageBox.Show("Ошибка в файле setting.txt. Значение FULL_SCREEN должно принимать значение ON или OFF");
                                continue;
                            }
                        }
                        catch (Exception)
                        {
                            System.Windows.Forms.MessageBox.Show("Ошибка в файле setting.txt. Значение FONT_SIZE должно быть от 8 до 72-x");
                        }
                    }
                }
            }

            isInitialized = true;
        }
    }
}
