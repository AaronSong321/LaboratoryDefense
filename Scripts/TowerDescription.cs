using System;
using System.Xml;
using System.Collections.Generic;
using UnityEngine;

public class TowerDescription
{
    public enum AttackType { bullet, explosive, tesla, flame, toxic, nuclear, unknown};
    public enum TargetType { ground, air, ground_all, ground_air, unknown};
    public class LevelInfo
    {
        public string name;
        public AttackType attackType;
        public int damage;
        public int firingRate;
        public int rangeMin;
        public int rangeMax;
        public int money;
        public int ballisticVelocity;
        public TargetType targetType;
    }

    public static AttackType GetAttackType(string s)
    {
        if (s.Equals("bullet")) return AttackType.bullet;
        if (s.Equals("explosive")) return AttackType.explosive;
        if (s.Equals("tesls")) return AttackType.tesla;
        if (s.Equals("flame")) return AttackType.flame;
        if (s.Equals("toxic")) return AttackType.toxic;
        if (s.Equals("nuclear")) return AttackType.nuclear;
        return AttackType.unknown;
    }

    public static TargetType GetTargetType(string s)
    {
        if (s.Equals("ground")) return TargetType.ground;
        if (s.Equals("air")) return TargetType.air;
        if (s.Equals("ground_all")) return TargetType.air;
        if (s.Equals("ground_air")) return TargetType.ground_air;
        return TargetType.unknown;
    }

    public LevelInfo[] levels;

    public static void ReadFromXml(string Tower, string filename)
    {
        /*        
        string path = System.Environment.CurrentDirectory + @"\Files\towers\" + filename;
        XmlDocument turrentDocument = new XmlDocument();
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.IgnoreComments = true;
        
        XmlReader turrentReader = XmlReader.Create(System.Environment.CurrentDirectory + "\\Files\\towers\\" + filename);
        turrentDocument.Load(turrentReader);

        XmlNode turrentRootNode = turrentDocument.SelectSingleNode("Towers");
        XmlNodeList turrentLists = turrentRootNode.ChildNodes;
        td = new TowerDescription[turrentLists.Count];
        int turrentCount = 0;
        foreach (XmlNode turrent in turrentLists)
        {
            td[turrentCount] = new TowerDescription();
            int levelCount = 0;
            foreach (XmlNode turrentLevel in turrent.ChildNodes)
            {
                XmlElement turrentElement = (XmlElement)turrentLevel;
                //no attributes
                XmlNodeList turrentProperties = turrentElement.ChildNodes;
                td[turrentCount].levels[levelCount].attackType = TowerDescription.getAttackType(turrentProperties.Item(0).InnerText);
                td[turrentCount].levels[levelCount].damage = Int32.Parse(turrentProperties.Item(1).InnerText);
                td[turrentCount].levels[levelCount].firingRate = Int32.Parse(turrentProperties.Item(2).InnerText);
                td[turrentCount].levels[levelCount].rangeMin = Int32.Parse(turrentProperties.Item(3).InnerText);
                td[turrentCount].levels[levelCount].rangeMax = Int32.Parse(turrentProperties.Item(4).InnerText);
                td[turrentCount].levels[levelCount].money = Int32.Parse(turrentProperties.Item(5).InnerText);
                td[turrentCount].levels[levelCount].ballisticVelocity = Int32.Parse(turrentProperties.Item(6).InnerText);
                td[turrentCount].levels[levelCount].targetType = TowerDescription.getTargetType(turrentProperties.Item(7).InnerText);
                td[turrentCount].levels[levelCount].name = turrentProperties.Item(8).InnerText;

                levelCount++;
            }
            turrentCount++;
        }
        */
    }
}

