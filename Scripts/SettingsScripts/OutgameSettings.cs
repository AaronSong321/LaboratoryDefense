using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

public class OutgameSettings
{
    public enum Language { English, Chinese };

    public Language language = Language.Chinese;

    public static Language GetLanguage(String s)
    {
        Language ans;
        switch (s)
        {
            case "English":
                ans = Language.English;
                break;
            case "中文（简体）":
                ans = Language.Chinese;
                break;
            default:
                ans = Language.Chinese;
                break;
        }
        return ans;
    }
    public static string GetString(Language l)
    {
        switch(l)
        {
            case Language.Chinese: return "中文（简体）";
            case Language.English: return "English";
        }
        return "未知的语言包";
    }

    internal static OutgameSettings LoadOutgameSettings(string fileName = "OutgameSettings.xml")
    {
        OutgameSettings ans = new OutgameSettings();
        string filePath = Settings.GeneratePath(fileName);
        XmlReaderSettings settings = new XmlReaderSettings()
        {
            IgnoreComments = true
        };
        XmlDocument outgameSettingsDocument = new XmlDocument();
        outgameSettingsDocument.Load(XmlReader.Create(filePath, settings));
        XmlNodeList outgameSettingsNodeList = outgameSettingsDocument.SelectSingleNode("OutgameSettings").ChildNodes;
        XmlElement languageElement = (XmlElement)outgameSettingsNodeList.Item(0);
        ans.language = GetLanguage(languageElement.GetAttribute("language"));

        return ans;
    }

    internal static OutgameSettings CreateOutgameSettings(string fileName = "OutgameSettings.xml")
    {
        OutgameSettings ans = new OutgameSettings();
        ans.SaveOutgameSettings(fileName);
        return ans;
    }

    internal void SaveOutgameSettings(string fileName = "OutgameSettings.xml")
    {
        XmlDocument outgameSettingsDocument = new XmlDocument();
        XmlElement root = outgameSettingsDocument.CreateElement("OutgameSettings");
        XmlElement languageItem = outgameSettingsDocument.CreateElement("item");
        languageItem.SetAttribute("language", GetString(language));
        root.AppendChild(languageItem);
        outgameSettingsDocument.AppendChild(root);
        outgameSettingsDocument.Save(Settings.GeneratePath(fileName));
    }
}