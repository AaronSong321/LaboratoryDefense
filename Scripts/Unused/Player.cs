using System;
using System.Xml;
using UnityEngine;


public class Player
{
    public class PerkInfo
    {
        public enum PerkChosenState { disabled, up, down }

        internal int currentLevel;
        internal int currentExp;
        internal PerkChosenState[] abilitiesSelected;
    }
    public enum LogInState { success, wrongPassword, doesNotExist }
    public enum RegisterState { success, alreadyExist }

    internal string playerName;
    internal Perk.PerkName selectedPerk;
    internal PerkInfo[] perkInfo;

    internal static Player currentPlayer;
    private static readonly int[] expToLevelUp = 
        {
            500,600,700,800,900,1100,1300,1500,1700,2000,
            2200,2420,2662,2928,3221,3543,3897,4287,4715,5187,
            6225,7470,8964,10757,12908,15490,18588,22305,26766,32120,
            38544,38544,46253,46253,55503,55503,66604,66604,79924,79924,
            90000,90000,100000,100000,100000,100000,100000,100000,100000,100000
        };

    internal void EnemyKilled(object sender, Enemy.EnemyKilledEventArgs e)
    {
        EarnExp(e.enemy);
    }
    internal void SubscribeEnemyKilled(Enemy e)
    {
        e.EnemyKilledEvent += EnemyKilled;
    }
    internal void UnsubscribeEnemyKilled(Enemy e)
    {
        e.EnemyKilledEvent -= EnemyKilled;
    }

    void EarnExp(Enemy e)
    {
        if (perkInfo[(int)selectedPerk].currentLevel == 50) return;
        perkInfo[(int)selectedPerk].currentExp += e.exp;
        if (perkInfo[(int)selectedPerk].currentExp > expToLevelUp[perkInfo[((int)selectedPerk)].currentLevel])
        {
            perkInfo[(int)selectedPerk].currentExp -= expToLevelUp[perkInfo[((int)selectedPerk)].currentLevel];
            LevelUp();
        }

        string filePath = Settings.GeneratePath("Players.xml");
        XmlDocument playerDocument = new XmlDocument();
        playerDocument.Load(filePath);
        XmlNodeList playerList = playerDocument.SelectSingleNode("Players").ChildNodes;
        foreach(XmlNode player in playerList)
        {
            if (((XmlElement)player).GetAttribute("name").Equals(playerName))
            {
                XmlElement perkNode = (XmlElement)player.ChildNodes.Item((int)selectedPerk);
                perkNode.SetAttribute("exp", perkInfo[(int)selectedPerk].currentExp.ToString());
                break;
            }
        }
        playerDocument.Save(filePath);
    }
    void LevelUp()
    {
        if (perkInfo[(int)selectedPerk].currentLevel == 50) return;
        perkInfo[(int)selectedPerk].currentLevel++;
        switch(perkInfo[(int)selectedPerk].currentLevel)
        {
            case 10: perkInfo[(int)selectedPerk].abilitiesSelected[0] = PerkInfo.PerkChosenState.up; break;
            case 20: perkInfo[(int)selectedPerk].abilitiesSelected[1] = PerkInfo.PerkChosenState.up; break;
            case 30: perkInfo[(int)selectedPerk].abilitiesSelected[2] = PerkInfo.PerkChosenState.up; break;
            case 40: perkInfo[(int)selectedPerk].abilitiesSelected[3] = PerkInfo.PerkChosenState.up; break;
            case 50: perkInfo[(int)selectedPerk].abilitiesSelected[4] = PerkInfo.PerkChosenState.up; break;
        }

        string filePath = Settings.GeneratePath("Players.xml");
        XmlDocument playerDocument = new XmlDocument();
        playerDocument.Load(filePath);
        XmlNodeList playerList = playerDocument.SelectSingleNode("Players").ChildNodes;
        foreach(XmlElement player in playerList)
        {
            if (player.GetAttribute("name").Equals(playerName))
            {
                XmlElement perkNode = (XmlElement)player.ChildNodes.Item((int)selectedPerk);
                perkNode.SetAttribute("level", perkInfo[(int)selectedPerk].currentLevel.ToString());
                break;
            }
        }
        playerDocument.Save(filePath);
    }

    internal static RegisterState Register(string playerName, string password)
    {
        string filePath = Settings.GeneratePath("Players.xml");
        XmlReaderSettings settings = new XmlReaderSettings
        {
            IgnoreComments = true
        };
        XmlDocument playerDocument = new XmlDocument();
        //playerDocument.Load(XmlReader.Create(filePath, settings));
        playerDocument.Load(filePath);
        XmlNode root = playerDocument.SelectSingleNode("Players");
        XmlNodeList playerList = root.ChildNodes;
        foreach(XmlNode player in playerList)
        {
            if (((XmlElement)player).GetAttribute("name") == playerName)
                return RegisterState.alreadyExist;
        }

        XmlElement newPlayer = playerDocument.CreateElement("Player");
        newPlayer.SetAttribute("name", playerName);
        newPlayer.SetAttribute("password", password);
        newPlayer.SetAttribute("selectedPerk", ((int)Perk.PerkName.MM).ToString());
        for (int i = 0; i < 4; i++)
        {
            XmlElement newPerk = playerDocument.CreateElement("Perk");
            newPerk.SetAttribute("name", Perk.GetString((Perk.PerkName)i));
            newPerk.SetAttribute("level", 0.ToString());
            newPerk.SetAttribute("exp", 0.ToString());
            for (int j = 0; j < 5; j++)
            {
                XmlElement newAbilities = playerDocument.CreateElement("Abilities");
                newAbilities.SetAttribute("levelRequired", (j + 1).ToString() + "0");
                newAbilities.SetAttribute("chosen", ((int)PerkInfo.PerkChosenState.disabled).ToString());
                newPerk.AppendChild(newAbilities);
            }
            newPlayer.AppendChild(newPerk);
        }
        root.AppendChild(newPlayer);
        playerDocument.AppendChild(root);
        playerDocument.Save(filePath);
        return RegisterState.success;
    }

    internal static LogInState LogIn(string playerName, string password)
    {
        string filePath = Settings.GeneratePath("Players.xml");
        XmlReaderSettings settings = new XmlReaderSettings
        {
            IgnoreComments = true
        };
        XmlDataDocument playerDocument = new XmlDataDocument();
        playerDocument.Load(XmlReader.Create(filePath, settings));
        XmlNodeList playerList = playerDocument.SelectSingleNode("Players").ChildNodes;
        bool found = false;
        foreach(XmlNode player in playerList)
        {
            if (((XmlElement)player).GetAttribute("name") == playerName)
            {
                found = true;
                if (((XmlElement)player).GetAttribute("password") == password)
                {
                    currentPlayer = new Player
                    {
                        playerName = playerName,
                        selectedPerk = Perk.GetPerkName(((XmlElement)player).GetAttribute("selectedPerk")),
                        perkInfo = new PerkInfo[4]
                    };
                    for (int i = 0; i < 4; i++)
                    {
                        XmlElement perkElement = (XmlElement)player.ChildNodes.Item(i);
                        currentPlayer.perkInfo[i] = new PerkInfo
                        {
                            currentLevel = Int32.Parse(perkElement.GetAttribute("level")),
                            currentExp = Int32.Parse(perkElement.GetAttribute("exp")),
                            abilitiesSelected = new PerkInfo.PerkChosenState[5]
                            {
                                (PerkInfo.PerkChosenState)Int32.Parse(((XmlElement)perkElement.ChildNodes.Item(0)).GetAttribute("chosen")),
                                (PerkInfo.PerkChosenState)Int32.Parse(((XmlElement)perkElement.ChildNodes.Item(1)).GetAttribute("chosen")),
                                (PerkInfo.PerkChosenState)Int32.Parse(((XmlElement)perkElement.ChildNodes.Item(2)).GetAttribute("chosen")),
                                (PerkInfo.PerkChosenState)Int32.Parse(((XmlElement)perkElement.ChildNodes.Item(3)).GetAttribute("chosen")),
                                (PerkInfo.PerkChosenState)Int32.Parse(((XmlElement)perkElement.ChildNodes.Item(4)).GetAttribute("chosen"))
                            }
                        };
                    }
                }
                else return LogInState.wrongPassword;

            }
            if (found) break;
        }
        if (found == true) return LogInState.success;
        else return LogInState.doesNotExist;
    }
}