using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Media.Imaging;

using Autodesk.Revit;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace SheetIndex
{
    public class CreateRibbonTab
    {
        static string _name = ((AssemblyTitleAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute), false)).Title;
        static string _tooltip_long_description = ((AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyDescriptionAttribute), false)).Description;
        static string _text = ((AssemblyTitleAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute), false)).Title;
        static string _namespace_prefix = typeof(App).Namespace + ".";
        const string Message = "Generate Sheet Index from Consultants PDF files";

        private static BitmapImage NewBitmapImage(Assembly a, string imageName)
        {
            //Make sure any referenced images' property  'Build Action' is set to 'Embedd Resource'
            Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream("SheetIndex.Graphics." + imageName);
            BitmapImage img = new BitmapImage();

            img.BeginInit();
            img.StreamSource = s;
            img.EndInit();

            return img;
        }

        public void tabAndButtons(UIControlledApplication UIConApp)
        {
            //Assembly Info trademark set to "Kirksey"
            string tabName = ((AssemblyTrademarkAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTrademarkAttribute), false)).Trademark;
            try { UIConApp.CreateRibbonTab(tabName); }
            catch { }

            Assembly exe = Assembly.GetExecutingAssembly();
            string path = exe.Location;
            string className = GetType().FullName.Replace("CreateRibbonTab", "Command");

            PushButtonData d = new PushButtonData(_name, _text, path, className);
            d.ToolTip = "Generate Sheet Index from Consultants PDF files";
            d.Image = NewBitmapImage(exe, "SheetSpecUpdate16.png");
            d.LargeImage = NewBitmapImage(exe, "SheetSpecUpdate32.png");
            d.LongDescription = _tooltip_long_description;

            RibbonPanel m_projectPanel = UIConApp.CreateRibbonPanel(tabName, _name);
            List<RibbonItem> projectButtons = new List<RibbonItem>();
            projectButtons.Add(m_projectPanel.AddItem(d));
        }
    }
}
