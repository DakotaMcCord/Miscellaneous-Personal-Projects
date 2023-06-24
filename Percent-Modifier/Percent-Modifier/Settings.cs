using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Percent_Modifier {
    public class Settings {
        public static XmlDocument SettingsXML = new XmlDocument();
        public static readonly string SettingsPath = Directory.GetCurrentDirectory().ToString() + @"\Settings.xml";
        public static bool AddToIndex = false;
        public static int StackSize = 0;
        public static string IndexPath = "None";
        public static Color BarBuffColour = Color.Green;
        public static Color BarDebuffColour = Color.Crimson;
        public static Color BuffColour = Color.LightGreen;
        public static Color DebuffColour = Color.LightCoral;

        static Settings() {
            Set();
        }

        public static void Set() {
            if (File.Exists(SettingsPath)) {
                SettingsXML.Load(SettingsPath);
                AddToIndex = Boolean.Parse(SettingsXML.DocumentElement.ChildNodes[0].InnerText);
                StackSize = Int32.Parse(SettingsXML.DocumentElement.ChildNodes[1].InnerText);
                IndexPath = SettingsXML.DocumentElement.ChildNodes[2].InnerText;
            }
        }
    }
}
