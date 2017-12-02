using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


class SChoosingPerk : MonoBehaviour
{
    public enum PerkType {MM, MB, FR, TS, unknown };
    public PerkType GetPerkType(String s)
    {
        switch(s)
        {
            case "MM": return PerkType.MM;
            case "MB": return PerkType.MB;
            case "FR": return PerkType.FR;
            case "TS": return PerkType.TS;
        }
        return PerkType.unknown;
    }

    OutgameSettings outgameSettings;

    ToggleGroup TGMain;
        Toggle TOverview;
        Toggle TPerk;
        Toggle TOptions;
        Toggle TExit;

    CanvasGroup CGOverview;
        CanvasGroup CGMapChoosing;
            Dropdown DDMapChoosing;
        CanvasGroup CGDifficultyChoosing;
            Dropdown DDDifficultyChoosing;
        //CanvasGroup CGSquadInfo;
            //CanvasGroup CGPlayer1Info;
            //CanvasGroup CGPlayer2Info;
            //CanvasGroup CGPlayer3Info;
            Button BReady;
            Text XP1PerkLevel;
            Text XP1Name;

    CanvasGroup CGPerk;
        CanvasGroup CGSelectingPerk;
            CanvasGroup CGPerkMM;
            Text TMMLevel;
            CanvasGroup CGPerkMB;
            Text TMBLevel;
            CanvasGroup CGPerkFR;
            Text TFRLevel;
            CanvasGroup CGPerkTS;
            Text TTSLevel;
        ToggleGroup TGSelectingPerk;
            Toggle TPerkMM;
            Toggle TPerkMB;
            Toggle TPerkFR;
            Toggle TPerkTS;
        CanvasGroup CGAbilitiesSelected;
            Image I10Up;
            Image I10Down;
            Image I20Up;
            Image I20Down;
            Image I30Up;
            Image I30Down;
            Image I40Up;
            Image I40Down;
            Image I50Up;
            Image I50Down;
        CanvasGroup CGPerkConfiguration;
            Text TPerkConfiguration;

    CanvasGroup CGOptions;
        Dropdown DLanguage;

    CanvasGroup CGExit;
        Button BExitToMainMenu;
        Button BExitGame;

    List<String> mapString = new List<string>
    {
        "基础地图"
    };
    List<String> difficultyString = new List<String>
    {
        "理想化的", "势均力敌的", "富有挑战的", "令人绝望的"
    };
    List<String> languageString = new List<string>
    {
        "中文（简体）", "English"
    };
    void Awake()
    {
        TGMain = GameObject.Find("CMain/TGMain").GetComponent<ToggleGroup>();
        TOverview = GameObject.Find("CMain/TGMain/TOverview").GetComponent<Toggle>();
        TPerk = GameObject.Find("CMain/TGMain/TPerk").GetComponent<Toggle>();
        TOptions = GameObject.Find("CMain/TGMain/TOptions").GetComponent<Toggle>();
        TExit = GameObject.Find("CMain/TGMain/TExit").GetComponent<Toggle>();

        CGOverview = GameObject.Find("CMain/CGOverview").GetComponent<CanvasGroup>();
        CGMapChoosing = GameObject.Find("CMain/CGOverview/MapChoosing").GetComponent<CanvasGroup>();
        DDMapChoosing = GameObject.Find("CMain/CGOverview/MapChoosing/Dropdown").GetComponent<Dropdown>();
        DDMapChoosing.options.Clear();
        foreach (String map in mapString)
        {
            Dropdown.OptionData optionData = new Dropdown.OptionData
            {
                text = map
            };
            DDMapChoosing.options.Add(optionData);
        }
        DDMapChoosing.captionText.text = mapString[0];
        CGDifficultyChoosing = GameObject.Find("CMain/CGOverview/DifficultyChoosing").GetComponent<CanvasGroup>();
        DDDifficultyChoosing = GameObject.Find("CMain/CGOverview/DifficultyChoosing/Dropdown").GetComponent<Dropdown>();
        DDDifficultyChoosing.options.Clear();
        foreach (String difficulty in difficultyString)
        {
            Dropdown.OptionData optionData = new Dropdown.OptionData
            {
                text = difficulty
            };
            DDDifficultyChoosing.options.Add(optionData);
        }
        DDDifficultyChoosing.captionText.text = difficultyString[0];
        //CGSquadInfo = GameObject.Find("CMain/CGOverview/SquadInfo").GetComponent<CanvasGroup>();
        //CGPlayer1Info = GameObject.Find("CMain/CGOverview/SquadInfo/Player1Info").GetComponent<CanvasGroup>();
        //CGPlayer2Info = GameObject.Find("CMain/CGOverview/SquadInfo/Player2Info").GetComponent<CanvasGroup>();
        //CGPlayer3Info = GameObject.Find("CMain/CGOverview/SquadInfo/Player3Info").GetComponent<CanvasGroup>();
        BReady = GameObject.Find("CMain/CGOverview/SquadInfo/BReady").GetComponent<Button>();
        XP1PerkLevel = GameObject.Find("CMain/CGOverview/SquadInfo/Player1Info/PerkLevel").GetComponent<Text>();
        XP1Name = GameObject.Find("CMain/CGOverview/SquadInfo/Player1Info/Name").GetComponent<Text>();
        XP1Name.text = Player.currentPlayer.playerName;
        XP1PerkLevel.text = "Lv" + Player.currentPlayer.perkInfo[(int)Player.currentPlayer.selectedPerk].currentLevel.ToString()
            + Perk.GetChineseString(Player.currentPlayer.selectedPerk);

        CGPerk = GameObject.Find("CMain/CGPerk").GetComponent<CanvasGroup>();
        CGSelectingPerk = GameObject.Find("CMain/CGPerk/CGSelectingPerk").GetComponent<CanvasGroup>();
        CGPerkMM = GameObject.Find("CMain/CGPerk/CGSelectingPerk/CGPerkMM").GetComponent<CanvasGroup>();
        CGPerkMB = GameObject.Find("CMain/CGPerk/CGSelectingPerk/CGPerkMB").GetComponent<CanvasGroup>();
        CGPerkFR = GameObject.Find("CMain/CGPerk/CGSelectingPerk/CGPerkFR").GetComponent<CanvasGroup>();
        CGPerkTS = GameObject.Find("CMain/CGPerk/CGSelectingPerk/CGPerkTS").GetComponent<CanvasGroup>();
        TMMLevel = GameObject.Find("CMain/CGPerk/CGSelectingPerk/CGPerkMM/Level").GetComponent<Text>();
        TMBLevel = GameObject.Find("CMain/CGPerk/CGSelectingPerk/CGPerkMB/Level").GetComponent<Text>();
        TFRLevel = GameObject.Find("CMain/CGPerk/CGSelectingPerk/CGPerkFR/Level").GetComponent<Text>();
        TTSLevel = GameObject.Find("CMain/CGPerk/CGSelectingPerk/CGPerkTS/Level").GetComponent<Text>();
        TMMLevel.text = Player.currentPlayer.perkInfo[(int)Perk.PerkName.MM].currentLevel.ToString();
        TMBLevel.text = Player.currentPlayer.perkInfo[(int)Perk.PerkName.MB].currentLevel.ToString();
        TFRLevel.text = Player.currentPlayer.perkInfo[(int)Perk.PerkName.FR].currentLevel.ToString();
        TTSLevel.text = Player.currentPlayer.perkInfo[(int)Perk.PerkName.TS].currentLevel.ToString();

        CGAbilitiesSelected = GameObject.Find("CMain/CGPerk/CGAbilitiesSelected").GetComponent<CanvasGroup>();
        I10Up = GameObject.Find("CMain/CGPerk/CGAbilitiesSelected/Ability10Up").GetComponent<Image>();
        I10Down = GameObject.Find("CMain/CGPerk/CGAbilitiesSelected/Ability10Down").GetComponent<Image>();
        I20Up = GameObject.Find("CMain/CGPerk/CGAbilitiesSelected/Ability20Up").GetComponent<Image>();
        I20Down = GameObject.Find("CMain/CGPerk/CGAbilitiesSelected/Ability20Down").GetComponent<Image>();
        I30Up = GameObject.Find("CMain/CGPerk/CGAbilitiesSelected/Ability30Up").GetComponent<Image>();
        I30Down = GameObject.Find("CMain/CGPerk/CGAbilitiesSelected/Ability30Down").GetComponent<Image>();
        I40Up = GameObject.Find("CMain/CGPerk/CGAbilitiesSelected/Ability40Up").GetComponent<Image>();
        I40Down = GameObject.Find("CMain/CGPerk/CGAbilitiesSelected/Ability40Down").GetComponent<Image>();
        I50Up = GameObject.Find("CMain/CGPerk/CGAbilitiesSelected/Ability50Up").GetComponent<Image>();
        I50Down = GameObject.Find("CMain/CGPerk/CGAbilitiesSelected/Ability50Down").GetComponent<Image>();

        CGPerkConfiguration = GameObject.Find("CMain/CGPerk/CGPerkConfiguration").GetComponent<CanvasGroup>();
        TPerkConfiguration = GameObject.Find("CMain/CGPerk/CGPerkConfiguration/Scroll View/Viewport/Content").GetComponent<Text>();
        TGSelectingPerk = GameObject.Find("CMain/CGPerk/CGSelectingPerk").GetComponent<ToggleGroup>();
        TPerkMM = GameObject.Find("CMain/CGPerk/CGSelectingPerk/CGPerkMM").GetComponent<Toggle>();
        TPerkMB = GameObject.Find("CMain/CGPerk/CGSelectingPerk/CGPerkMB").GetComponent<Toggle>();
        TPerkFR = GameObject.Find("CMain/CGPerk/CGSelectingPerk/CGPerkFR").GetComponent<Toggle>();
        TPerkTS = GameObject.Find("CMain/CGPerk/CGSelectingPerk/CGPerkTS").GetComponent<Toggle>();

        CGOptions = GameObject.Find("CMain/CGOptions").GetComponent<CanvasGroup>();
        DLanguage = GameObject.Find("CMain/CGOptions/DLanguage").GetComponent<Dropdown>();
        DLanguage.options.Clear();
        foreach (String ls in languageString)
        {
            Dropdown.OptionData tempData = new Dropdown.OptionData
            {
                text = ls
            };
            DLanguage.options.Add(tempData);
        }
        DLanguage.captionText.text = languageString[0];

        CGExit = GameObject.Find("CMain/CGExit").GetComponent<CanvasGroup>();
        BExitToMainMenu = GameObject.Find("CMain/CGExit/BExitToMainMenu").GetComponent<Button>();
        BExitGame = GameObject.Find("CMain/CGExit/BExitGame").GetComponent<Button>();

        outgameSettings = OutgameSettings.LoadOutgameSettings();
    }

    void Start()
    {
        TGMain.SetAllTogglesOff();
        TOverview.Select();

        TGSelectingPerk.SetAllTogglesOff();
        TPerkMM.Select();

        CGOverview.gameObject.SetActive(true);
        CGPerk.gameObject.SetActive(false);
        CGOptions.gameObject.SetActive(false);
        CGExit.gameObject.SetActive(false);
    }

    public void OnOverviewClick()
    {
        CGOverview.gameObject.SetActive(true);
        CGPerk.gameObject.SetActive(false);
        CGOptions.gameObject.SetActive(false);
        CGExit.gameObject.SetActive(false);
    }
    public void OnPerkClick()
    {
        CGOverview.gameObject.SetActive(false);
        CGPerk.gameObject.SetActive(true);
        CGOptions.gameObject.SetActive(false);
        CGExit.gameObject.SetActive(false);
    }
    public void OnOptionsClick()
    {
        CGOverview.gameObject.SetActive(false);
        CGPerk.gameObject.SetActive(false);
        CGOptions.gameObject.SetActive(true);
        CGExit.gameObject.SetActive(false);
    }
    public void OnOptionsExit()
    {
        CGOverview.gameObject.SetActive(false);
        CGPerk.gameObject.SetActive(false);
        CGOptions.gameObject.SetActive(false);
        CGExit.gameObject.SetActive(true);
    }

    public void OnSelectingPerk()
    {
        if (TPerkMM.isOn)
        {
            TPerkConfiguration.text = Description.MachineMastery(outgameSettings.language);
            Player.currentPlayer.selectedPerk = Perk.PerkName.MM;
        }
        if (TPerkMB.isOn)
        {
            TPerkConfiguration.text = Description.MadBomber(outgameSettings.language);
            Player.currentPlayer.selectedPerk = Perk.PerkName.MB;
        }
        if (TPerkFR.isOn)
        {
            TPerkConfiguration.text = Description.FireRanger(outgameSettings.language);
            Player.currentPlayer.selectedPerk = Perk.PerkName.FR;
        }
        if (TPerkTS.isOn)
        {
            TPerkConfiguration.text = Description.ThunderSpirit(outgameSettings.language);
            Player.currentPlayer.selectedPerk = Perk.PerkName.TS;
        }
        XP1PerkLevel.text = "Lv" + Player.currentPlayer.perkInfo[(int)Player.currentPlayer.selectedPerk].currentLevel.ToString()
            + Perk.GetChineseString(Player.currentPlayer.selectedPerk);
    }

    public void OnReadyClick()
    {
        SceneManager.LoadScene("SoloGame");
    }

    public void OnLanguageClick()
    {
        outgameSettings.language = OutgameSettings.GetLanguage(DLanguage.captionText.text);
        outgameSettings.SaveOutgameSettings();
    }

    public void OnExitToMainMenuClick()
    {
        SceneManager.LoadScene("Welcome");
    }
    public void OnExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnChangingLanguage()
    {
        outgameSettings.language = OutgameSettings.GetLanguage(DLanguage.captionText.text);
        outgameSettings.SaveOutgameSettings();
    }
}