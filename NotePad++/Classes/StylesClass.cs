using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

namespace NotePad__
{
    class StylesClass
    {
        public static string Theme { get; set; }
        public static Color BackColor { get; set; }
        public static Color DefaultLanguageColor{ get; set; }
        public static Color KeywordsColor { get; set; }
        public static Color StringsColor { get; set; }
        public static Color CommentLinesColor { get; set; }
        public static Color CommentBlocksColor { get; set; }
        public static string DefaultLanguage { get; set; }
        public static Color DocumentMapBackColor { get; set; }
        public static Color DocumentMapForeColor { get; set; }
        public static Color NumberMarginBackColor { get; set; }
        public static Color NumberMarginForeColor { get; set; }
        public static Color BookmarkMarginBackColor { get; set; }
        public static Color BookmarkMarginForeColor { get; set; }
        public static bool ShowStatusBar { get; set; }
        public static bool HideTaskBar { get; set; }
        public static bool ShowNewIcon { get; set; }
        public static bool ShowOpenIcon { get; set; }
        public static bool ShowSaveIcon { get; set; }
        public static bool ShowFindIcon { get; set; }
        public static bool ShowFindAndReplaceIcon { get; set; }
        public static bool ShowDocumentMapIcon { get; set; }
        public static bool ShowToUpperIcon { get; set; }
        public static bool ShowVersionsIcon { get; set; }
        public static bool ShowCopyIcon { get; set; }
        public static bool ShowCutIcon { get; set; }
        public static bool ShowPasteIcon { get; set; }
        public static bool ShowFontIcon { get; set; }
        public static bool ShowBoldIcon { get; set; }
        public static bool ShowItalicIcon { get; set; }
        public static bool ShowUnderLineIcon { get; set; }


        static XmlDocument xmlDoc = new XmlDocument();
        private static string xmlFilePath = "../../settings.xml";

        public static void GetAllStylesIntoProperties()
        {
            xmlDoc.Load(xmlFilePath);

            //Theme
            Theme = xmlDoc.SelectSingleNode("Settings/UserSettings/General/Theme").InnerText;

            //BackColor
            BackColor = GetColorFromARGB(xmlDoc.SelectSingleNode("Settings/UserSettings/General/BackColor").InnerText);

            //Laguage
            DefaultLanguageColor = GetColorFromARGB(xmlDoc.SelectSingleNode("Settings/UserSettings/TextArea/DefaultColor").InnerText);
            KeywordsColor = GetColorFromARGB(xmlDoc.SelectSingleNode("Settings/UserSettings/TextArea/KeywordsColor").InnerText);
            StringsColor = GetColorFromARGB(xmlDoc.SelectSingleNode("Settings/UserSettings/TextArea/StringsColor").InnerText);
            CommentLinesColor = GetColorFromARGB(xmlDoc.SelectSingleNode("Settings/UserSettings/TextArea/CommentLinesColor").InnerText);
            CommentBlocksColor = GetColorFromARGB(xmlDoc.SelectSingleNode("Settings/UserSettings/TextArea/CommentBlocksColor").InnerText);
            DefaultLanguage = xmlDoc.SelectSingleNode("Settings/UserSettings/TextArea/DefaultLanguage").InnerText;

            //Others
            DocumentMapBackColor = GetColorFromARGB(xmlDoc.SelectSingleNode("Settings/UserSettings/DocumentMap/BackColor").InnerText);
            DocumentMapForeColor = GetColorFromARGB(xmlDoc.SelectSingleNode("Settings/UserSettings/DocumentMap/ForeColor").InnerText);
            NumberMarginBackColor = GetColorFromARGB(xmlDoc.SelectSingleNode("Settings/UserSettings/NumberMargin/BackColor").InnerText);
            NumberMarginForeColor = GetColorFromARGB(xmlDoc.SelectSingleNode("Settings/UserSettings/NumberMargin/ForeColor").InnerText);
            BookmarkMarginBackColor = GetColorFromARGB(xmlDoc.SelectSingleNode("Settings/UserSettings/BookmarkMargin/BackColor").InnerText);
            BookmarkMarginForeColor = GetColorFromARGB(xmlDoc.SelectSingleNode("Settings/UserSettings/BookmarkMargin/ForeColor").InnerText);

            //show status bar
            ShowStatusBar = Boolean.Parse(xmlDoc.SelectSingleNode("Settings/UserSettings/General/ShowStatusBar").InnerText);
            //hide task bar
            HideTaskBar = Boolean.Parse(xmlDoc.SelectSingleNode("Settings/UserSettings/General/HideTaskBar").InnerText);

            //Task bar
            ShowNewIcon = Boolean.Parse(xmlDoc.SelectSingleNode("Settings/UserSettings/General/New").InnerText);
            ShowOpenIcon = Boolean.Parse(xmlDoc.SelectSingleNode("Settings/UserSettings/General/Open").InnerText);
            ShowSaveIcon = Boolean.Parse(xmlDoc.SelectSingleNode("Settings/UserSettings/General/Save").InnerText);
            ShowDocumentMapIcon = Boolean.Parse(xmlDoc.SelectSingleNode("Settings/UserSettings/General/DocumentMap").InnerText);
            ShowFindIcon = Boolean.Parse(xmlDoc.SelectSingleNode("Settings/UserSettings/General/Find").InnerText);
            ShowFindAndReplaceIcon = Boolean.Parse(xmlDoc.SelectSingleNode("Settings/UserSettings/General/FindAndReplace").InnerText);
            ShowToUpperIcon = Boolean.Parse(xmlDoc.SelectSingleNode("Settings/UserSettings/General/ToUpper").InnerText);
            ShowVersionsIcon = Boolean.Parse(xmlDoc.SelectSingleNode("Settings/UserSettings/General/Versions").InnerText);
            ShowCopyIcon = Boolean.Parse(xmlDoc.SelectSingleNode("Settings/UserSettings/General/Copy").InnerText);
            ShowCutIcon = Boolean.Parse(xmlDoc.SelectSingleNode("Settings/UserSettings/General/Cut").InnerText);
            ShowPasteIcon = Boolean.Parse(xmlDoc.SelectSingleNode("Settings/UserSettings/General/Paste").InnerText);
            ShowFontIcon = Boolean.Parse(xmlDoc.SelectSingleNode("Settings/UserSettings/General/Font").InnerText);
            ShowBoldIcon = Boolean.Parse(xmlDoc.SelectSingleNode("Settings/UserSettings/General/Bold").InnerText);
            ShowItalicIcon = Boolean.Parse(xmlDoc.SelectSingleNode("Settings/UserSettings/General/Italic").InnerText);
            ShowUnderLineIcon = Boolean.Parse(xmlDoc.SelectSingleNode("Settings/UserSettings/General/Underline").InnerText);
        }

        public static void SaveSetting(string xpath, string setting)
        {
            xmlDoc.Load(xmlFilePath);
            //save to xml
            xmlDoc.SelectSingleNode(xpath).InnerText = setting;
            xmlDoc.Save(xmlFilePath);
        }

        private static Color GetColorFromARGB(string colorText)
        {
            return Color.FromArgb(int.Parse(colorText));
        }

    }
}
