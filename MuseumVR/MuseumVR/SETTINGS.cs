using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumVR
{
    internal static class SETTINGS
    {
        public static bool isInitialized = false;

        private static string museum_dir = "Data";
        private static int animation_time = 10;
        private static string nav_font_family = "Gabriola";
        private static int nav_font_style = 2;
        private static int nav_font_size = 28;
        private static string nav_font_color = "#000000";

        private static string btn_font_family = "Gabriola";
        private static int btn_font_style = 2;
        private static int btn_font_size = 28;
        private static string btn_font_color = "#000000";

        private static string full_screen = "ON";
        public static int ANIMATION_TIME
        {
            get
            {
                return animation_time;
            }
        }

        public static string NAV_FONT_FAMILY
        {
            get
            {
                return nav_font_family;
            }
        }

        public static int NAV_FONT_STYLE
        {
            get
            {
                return nav_font_style;
            }
        }

        public static int NAV_FONT_SIZE
        {
            get
            {
                return nav_font_size;
            }
        }

        public static Color NAV_FONT_COLOR
        {
            get
            {
                return Color.FromArgb(Int32.Parse(nav_font_color.Replace("#", ""), NumberStyles.HexNumber));
            }
        }


        public static string BTN_FONT_FAMILY
        {
            get
            {
                return btn_font_family;
            }
        }

        public static int BTN_FONT_STYLE
        {
            get
            {
                return btn_font_style;
            }
        }

        public static int BTN_FONT_SIZE
        {
            get
            {
                return btn_font_size;
            }
        }

        public static Color BTN_FONT_COLOR
        {
            get
            {
                return Color.FromArgb(Int32.Parse(btn_font_color.Replace("#", ""), NumberStyles.HexNumber));
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

                    sw.WriteLine($"NAV_LABEL_FONT = \"{nav_font_family}\" {nav_font_size} {nav_font_style} {nav_font_color}");
                    sw.WriteLine($"BUTTONS_FONT = \"{btn_font_family}\" {btn_font_size} {btn_font_style} {btn_font_color}");

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
                                MessageBox.Show("Ошибка в файле setting.txt. Значение ANIMATION_TIME  должно быть от 0 до 100");
                                continue;
                            }
                            animation_time = Convert.ToInt32(arr[1].Trim());
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ошибка в файле setting.txt. Значение ANIMATION_TIME  должно быть от 0 до 100");
                        }
                    }
                    else if (arr[0].Trim().ToUpper() == "NAV_LABEL_FONT" || arr[0].Trim().ToUpper() == "BUTTONS_FONT")
                    {
                        var a = arr[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        bool err = false;
                        string family = "", color = "";
                        int size = 24, style = 2;
                        if (a.Length != 4) {
                            err = true;
                            MessageBox.Show("Ошибка в файле setting.txt. Значение FONT должно быть указано в формате: \"Font Family\" size style color, например: \"Arial\" 24 2 #000000");
                        }
                        else {
                            family = a[0].Replace("\"", "").Trim();
                            color = a[3].Trim();

                            try
                            {
                                size = Convert.ToInt32(a[1].Trim());
                                if (size < 8 || size > 72) { err = true; }
                            }
                            catch (Exception) { err = true; }

                            try
                            {
                                style = Convert.ToInt32(a[2].Trim());
                                if (style < 0 || style > 8) { err = true; }
                            }
                            catch (Exception) { err = true; }

                            try
                            {
                                Color.FromArgb(Int32.Parse(a[3].Trim().Replace("#", ""), NumberStyles.HexNumber));
                            }
                            catch { err = true; }
                        }

                        if (err)
                        {
                            MessageBox.Show("Ошибка в файле setting.txt. Значение FONT должно быть указано в формате: \"Font Family\" size(8..72) style(0..8) color(hex_format), например: \"Arial\" 24 2 #000000");
                            continue;
                        }

                        if (arr[0].Trim().ToUpper() == "NAV_LABEL_FONT") {
                            nav_font_family = family;
                            nav_font_size = size;
                            nav_font_style = style;
                            nav_font_color = color;
                        }

                        if (arr[0].Trim().ToUpper() == "BUTTONS_FONT")
                        {
                            btn_font_family = family;
                            btn_font_size = size;
                            btn_font_style = style;
                            btn_font_color = color;
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
