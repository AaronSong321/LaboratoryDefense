using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using UnityEngine;

class EnemyDescription
{
    //<definitions>
    public enum ResisType{ bullet, explosive, tesla, flame, toxic, nuclear, unknown};
    public enum EnemyType{ ground, air, ground_air, air_ground, unknown};
    public enum SizeType{ tiny, common, giant, boss, unknown};

    public class EnemyInfo
    {
        public string name;
		public string description;
        public int hp;
        public int damage;
        public int speed;
        public int money;
        public int weight;
        public EnemyType enemyType;
        public SizeType sizeType;
        public Dictionary<ResisType, double> resistance;
    }

    public static ResisType GetResisType(string s)
    {
        if (s.Equals("bullet")) return ResisType.bullet;
        if (s.Equals("explosive")) return ResisType.explosive;
        if (s.Equals("tesls")) return ResisType.tesla;
        if (s.Equals("flame")) return ResisType.flame;
        if (s.Equals("toxic")) return ResisType.toxic;
        if (s.Equals("nuclear")) return ResisType.nuclear;
        return ResisType.unknown;
    }
    
    public static EnemyType GetEnemyType(string s)
    {
        if (s.Equals("ground")) return EnemyType.ground;
        if (s.Equals("air")) return EnemyType.air;
        if (s.Equals("ground_air")) return EnemyType.ground_air;
        if (s.Equals("air_ground")) return EnemyType.air_ground;
        return EnemyType.unknown;
    }

    public static SizeType GetSizeType(string s)
    {
        if (s.Equals("tiny")) return SizeType.tiny;
        if (s.Equals("common")) return SizeType.common;
        if (s.Equals("giant")) return SizeType.giant;
        if (s.Equals("boss")) return SizeType.boss;
        return SizeType.unknown;
    }
    //</definitions>

    //<data>
    public EnemyInfo info;
    //</data>

    //<methods>
    //<create>
    public static void ReadFromXml(EnemyDescription[] ei, string filename)
    {
		XmlDocument enemyDocument = new XmlDocument();
		XmlReaderSettings settings = new XmlReaderSettings();
        settings.IgnoreComments = true;
		XmlReader enemyReader = XmlReader.Create(System.Environment.CurrentDirectory + "\\Files\\towers\\" + filename);
		enemyDocument.Load(enemyReader);
		
		XmlNode enemyRootNode = enemyDocument.SelectSingleNode("enemies");
		XmlNodeList enemyList = enemyRootNode.ChildNodes;
		ei = new EnemyDescription[enemyList.Count];
		int enemyCount = 0;
		foreach (XmlNode enemy in enemyList)
		{
			XmlElement enemyElement = (XmlElement)enemy;
			XmlNodeList enemyProperties = enemyElement.ChildNodes;
            ei[enemyCount].info.name = enemyProperties.Item(0).InnerText;
			ei[enemyCount].info.description = enemyProperties.Item(1).InnerText;
            ei[enemyCount].info.hp = Int32.Parse(enemyProperties.Item(2).InnerText);
			ei[enemyCount].info.damage = Int32.Parse(enemyProperties.Item(3).InnerText);
			ei[enemyCount].info.speed = Int32.Parse(enemyProperties.Item(4).InnerText);
			ei[enemyCount].info.money = Int32.Parse(enemyProperties.Item(5).InnerText);
			XmlElement enemyResistance = (XmlElement)enemyProperties.Item(6);
            XmlNodeList enemyResisList = enemyResistance.ChildNodes;
			foreach (XmlNode r in enemyList)
			{
                ei[enemyCount].info.resistance.Add(ResisType.bullet, Double.Parse(enemyResisList.Item(0).InnerText));
				ei[enemyCount].info.resistance.Add(ResisType.explosive, Double.Parse(enemyResisList.Item(1).InnerText));
				ei[enemyCount].info.resistance.Add(ResisType.tesla, Double.Parse(enemyResisList.Item(2).InnerText));
				ei[enemyCount].info.resistance.Add(ResisType.flame, Double.Parse(enemyResisList.Item(3).InnerText));
				ei[enemyCount].info.resistance.Add(ResisType.toxic, Double.Parse(enemyResisList.Item(4).InnerText));
				ei[enemyCount].info.resistance.Add(ResisType.nuclear, Double.Parse(enemyResisList.Item(5).InnerText));
			}
			enemyCount++;
		}
	}

    public static EnemyDescription LinqToXml(string enemyName, string fileName)
    {
        string path = System.Environment.CurrentDirectory + "\\Files\\enemies\\" + fileName;
        XElement rootNode = XElement.Load(path);
        IEnumerable<XElement> enemies = rootNode.Elements();

        XElement node = null;
        foreach (XElement theNode in enemies)
        {
            //Debug.Log(node.Element("name"));
            if (theNode.Element("name").Value .Equals(enemyName))
            {
                node = theNode;
                break;
            }
        }
        if (node == null)
        {
            Debug.Log("Enemy with name " + enemyName + " does not exist in the file " + fileName + ".");
            return null;
        }

        EnemyDescription ans = new EnemyDescription();
        ans.info = new EnemyInfo();
        ans.info.name = node.Element("name").Value;
        ans.info.hp = Int32.Parse(node.Element("health").Value);
        ans.info.damage = Int32.Parse(node.Element("dmg").Value);
        ans.info.money = Int32.Parse(node.Element("money").Value);
        ans.info.speed = Int32.Parse(node.Element("speed").Value);
        ans.info.weight = Int32.Parse(node.Element("weight").Value);
        ans.info.enemyType = EnemyDescription.GetEnemyType(node.Element("type").Value);
        ans.info.sizeType = EnemyDescription.GetSizeType(node.Element("size").Value);

        ans.info.resistance = new Dictionary<ResisType, double>();
        ans.info.resistance.Add(ResisType.bullet, Double.Parse(node.Element("resis_bullet").Value));
        ans.info.resistance.Add(ResisType.explosive, Double.Parse(node.Element("resis_explo").Value));
        ans.info.resistance.Add(ResisType.tesla, Double.Parse(node.Element("resis_tesla").Value));
        ans.info.resistance.Add(ResisType.flame, Double.Parse(node.Element("resis_flame").Value));
        ans.info.resistance.Add(ResisType.toxic, Double.Parse(node.Element("resis_toxic").Value));
        ans.info.resistance.Add(ResisType.nuclear, Double.Parse(node.Element("resis_nuclear").Value));

        return ans;
        /*
        IEnumerable<XElement> enemyNode = from enemy in enemies where enemy.Element("name").Equals(@"<name>"+enemyName+@"</name>") select enemy;
        foreach(XElement node in enemyNode)
        {
            if (ans.info == null)
            {
                ans.info = new EnemyInfo();
                ans.info.name = node.Element("name").Value;
                ans.info.hp = Int32.Parse(node.Element("health").Value);
                ans.info.damage = Int32.Parse(node.Element("damage").Value);
                ans.info.money = Int32.Parse(node.Element("money").Value);
                ans.info.speed = Int32.Parse(node.Element("speed").Value);
                ans.info.weight = Int32.Parse(node.Element("weight").Value);
                ans.info.enemyType = EnemyDescription.getEnemyType(node.Element("type").Value);
                ans.info.sizeType = EnemyDescription.getSizeType(node.Element("size").Value);

                if (ans.info.resistance == null)
                {
                    ans.info.resistance = new Dictionary<ResisType, double>();
                    ans.info.resistance.Add(ResisType.bullet, Double.Parse(node.Element("resis_bullet").Value));
                    ans.info.resistance.Add(ResisType.explosive, Double.Parse(node.Element("resis_explo").Value));
                    ans.info.resistance.Add(ResisType.tesla, Double.Parse(node.Element("resis_tesla").Value));
                    ans.info.resistance.Add(ResisType.flame, Double.Parse(node.Element("resis_flame").Value));
                    ans.info.resistance.Add(ResisType.toxic, Double.Parse(node.Element("resis_toxic").Value));
                    ans.info.resistance.Add(ResisType.nuclear, Double.Parse(node.Element("resis_nuclear").Value));
                }
            }
        }
        */
    }
    //</create>
	
    public override string ToString()
    {
        if (this.info == null) return "Null Reference";
        StringBuilder sb = new StringBuilder();
        sb.Append("Name:" + this.info.name + "\n");
        sb.Append("Health Point:" + this.info.hp + "\n");
        sb.Append("Damage:" + this.info.damage + "\n");
        sb.Append("Speed:" + this.info.speed + "\n");
        sb.Append("Size:" + this.info.sizeType + "\n");
        sb.Append("Type:" + this.info.enemyType + "\n");
        sb.Append("Money Providing:" + this.info.money + "\n");
        sb.Append("Resistance:\n");
        sb.Append("\tBullet:" + this.info.resistance[ResisType.bullet] + "\n");
        return sb.ToString();
    }
	//</methods>
}