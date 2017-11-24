using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
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
            case "FR":return PerkType.FR;
            case "TS": return PerkType.TS;
        }
        return PerkType.unknown;
    }

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
        CanvasGroup CGSquadInfo;
            CanvasGroup CGPlayer1Info;
            CanvasGroup CGPlayer2Info;
            CanvasGroup CGPlayer3Info;
            Button BReady;

    CanvasGroup CGPerk;
        CanvasGroup CGSelectingPerk;
            CanvasGroup CGPerkMM;
            CanvasGroup CGPerkMB;
            CanvasGroup CGPerkFR;
            CanvasGroup CGPerkTS;
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

    void Awake()
    {
        TGMain = GameObject.Find("CMain/TGMain").GetComponent<ToggleGroup>();
        TOverview = GameObject.Find("CMain/TGMain/TOverview").GetComponent<Toggle>();
        TPerk = GameObject.Find("CMain/TGMain/TPerk").GetComponent<Toggle>();
        TOptions = GameObject.Find("CMain/TGMain/TOptions").GetComponent<Toggle>();
        TExit = GameObject.Find("CMain/TGMain/TExit").GetComponent<Toggle>();
        TGMain.SetAllTogglesOff();
        TOverview.Select();

        CGOverview = GameObject.Find("Canvas/CGOverview").GetComponent<CanvasGroup>();
        CGMapChoosing = GameObject.Find("CMain/CGOverview/MapChoosing").GetComponent<CanvasGroup>();
        DDMapChoosing = GameObject.Find("CMain/CGOverview/MapChoosing/Dropdown").GetComponent<Dropdown>();
        CGDifficultyChoosing = GameObject.Find("CMain/CGOverview/DifficultyChoosing").GetComponent<CanvasGroup>();
        DDDifficultyChoosing = GameObject.Find("CMain/CGOverview/DifficultyChoosing/Dropdown").GetComponent<Dropdown>();
        CGSquadInfo = GameObject.Find("CMain/CGOverview/SquadInfo").GetComponent<CanvasGroup>();
        CGPlayer1Info = GameObject.Find("CMain/CGOverview/SquadInfo/Player1Info").GetComponent<CanvasGroup>();
        CGPlayer2Info = GameObject.Find("CMain/CGOverview/SquadInfo/Player2Info").GetComponent<CanvasGroup>();
        CGPlayer3Info = GameObject.Find("CMain/CGOverview/SquadInfo/Player3Info").GetComponent<CanvasGroup>();
        BReady = GameObject.Find("CMain/CGOverview/SquadInfo/BReady").GetComponent<Button>();

        CGPerk = GameObject.Find("CMain/CGPerk").GetComponent<CanvasGroup>();
        CGSelectingPerk = GameObject.Find("CMain/CGPerk/CGSelectingPerk").GetComponent<CanvasGroup>();
        CGPerkMM = GameObject.Find("CMain/CGPerk/CGPerkMM").GetComponent<CanvasGroup>();
        CGPerkMB = GameObject.Find("CMain/CGPerk/CGPerkMB").GetComponent<CanvasGroup>();
        CGPerkFR = GameObject.Find("CMain/CGPerk/CGPerkFR").GetComponent<CanvasGroup>();
        CGPerkTS = GameObject.Find("CMain/CGPerk/CGPerkTS").GetComponent<CanvasGroup>();
        CGAbilitiesSelected = GameObject.Find("CMain/CGAbilitiesSelected").GetComponent<CanvasGroup>();
        I10Up = GameObject.Find("CMain/CGAbilitiesSelected/Ability10Up").GetComponent<Image>();
        I10Down = GameObject.Find("CMain/CGAbilitiesSelected/Ability10Down").GetComponent<Image>();
        I20Up = GameObject.Find("CMain/CGAbilitiesSelected/Ability20Up").GetComponent<Image>();
        I20Down = GameObject.Find("CMain/CGAbilitiesSelected/Ability20Down").GetComponent<Image>();
        I30Up = GameObject.Find("CMain/CGAbilitiesSelected/Ability30Up").GetComponent<Image>();
        I30Down = GameObject.Find("CMain/CGAbilitiesSelected/Ability30Down").GetComponent<Image>();
        I40Up = GameObject.Find("CMain/CGAbilitiesSelected/Ability40Up").GetComponent<Image>();
        I40Down = GameObject.Find("CMain/CGAbilitiesSelected/Ability40Down").GetComponent<Image>();
        I50Up = GameObject.Find("CMain/CGAbilitiesSelected/Ability50Up").GetComponent<Image>();
        I50Down = GameObject.Find("CMain/CGAbilitiesSelected/Ability50Down").GetComponent<Image>();
        CGPerkConfiguration = GameObject.Find("CMain/CGPerkConfiguration").GetComponent<CanvasGroup>();
        TPerkConfiguration = GameObject.Find("CMain/CGPerkConfiguraion/Scroll View/Viewport/Content").GetComponent<Text>();
    }

    public void OnOverviewClick()
    {
        CGOverview.gameObject.SetActive(true);
        CGPerk.gameObject.SetActive(false);
    }
    public void OnPerkClick()
    {
        CGOverview.gameObject.SetActive(false);
        CGPerk.gameObject.SetActive(true);
    }
    public void OnOptionsClick()
    {
        CGOverview.gameObject.SetActive(false);
        CGPerk.gameObject.SetActive(false);
    }
}