using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using UnityEngine;


public class IngameSettings
{
    public enum Map { basic, unknown }
    public enum Difficulty { hypothetical, rival, chanllenging, desperate, custom, unknown }

    internal Map map;
    internal Difficulty difficulty;

    public static Map GetMap(String mapString)
    {
        Map ans = Map.basic;
        switch(mapString)
        {
            case "basic": ans = Map.basic; break;
            default: ans = Map.unknown; break;
        }
        return ans;
    }
    public static String GetString(Map map)
    {
        switch(map)
        {
            case Map.basic: return "Basic";
            default: return "unknown map";
        }
    }

    public static Difficulty GetDifficulty(String difficulty)
    {
        switch(difficulty)
        {
            case "hypothetical": return Difficulty.hypothetical;
            case "rival": return Difficulty.rival;
            case "chanllenging": return Difficulty.chanllenging;
            case "desperate": return Difficulty.desperate;
            case "custom": return Difficulty.custom;
            default: return Difficulty.unknown;
        }
    }
    public static String GetString(Difficulty difficulty)
    {
        switch(difficulty)
        {
            case Difficulty.hypothetical: return "hypothetical";
            case Difficulty.rival: return "rival";
            case Difficulty.chanllenging: return "chanllenging";
            case Difficulty.desperate: return "desperate";
            case Difficulty.custom: return "custom";
            default: return "unknown difficulty";
        }
    }

    internal static IngameSettings LoadIngameSettings(string fileName = "IngameSettings.xml")
    {
        IngameSettings ans = new IngameSettings
        {
            map = Map.basic,
            difficulty = Difficulty.hypothetical
        };
        string filePath = Settings.GeneratePath(fileName);
        XmlReaderSettings settings = new XmlReaderSettings
        {
            IgnoreComments = true
        };
        XmlDocument ingameSettingsDocument = new XmlDocument();
        ingameSettingsDocument.Load(XmlReader.Create(filePath, settings));
        XmlNodeList ingameSettingsList = ingameSettingsDocument.SelectSingleNode("IngameSettings").ChildNodes;
        XmlElement mapItem = (XmlElement)ingameSettingsList.Item(0);
        ans.map = GetMap(mapItem.GetAttribute("map"));
        XmlElement difficultyItem = (XmlElement)ingameSettingsList.Item(1);
        ans.map = GetMap(mapItem.GetAttribute("difficulty"));
        return ans;
    }

    internal void SaveIngameSettings(string fileName = "IngameSettings.xml")
    {
        XmlDocument ingameSettingsDocument = new XmlDocument();
        XmlElement root = ingameSettingsDocument.CreateElement("IngameSettings");
        XmlElement mapItem = ingameSettingsDocument.CreateElement("item");
        mapItem.SetAttribute("map", GetString(map));
        XmlElement difficultyItem = ingameSettingsDocument.CreateElement("item");
        difficultyItem.SetAttribute("difficulty", GetString(difficulty));
        root.AppendChild(mapItem);
        root.AppendChild(difficultyItem);
        ingameSettingsDocument.AppendChild(root);
        ingameSettingsDocument.Save(Settings.GeneratePath(fileName));
    }
}