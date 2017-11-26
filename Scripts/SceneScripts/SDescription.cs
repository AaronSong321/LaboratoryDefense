using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SDescription : MonoBehaviour {
    EnemyDescription elfin, crawler, zombie, thirsty, butcher, unicorn, desolator, manmoth, tank, dragon;

    CanvasGroup canvasGroup_Turrent;
    CanvasGroup canvasGroup_Monster;
    CanvasGroup canvasGroup_Perk;

    ToggleGroup toggleGroup_Turrent;
    ToggleGroup toggleGroup_Monster;
    ToggleGroup toggleGroup_Perk;
    ToggleGroup toggleGroup_Main;

    Toggle toggle_Turrent;
    Toggle toggle_Monster;
    Toggle toggle_Perk;

    Toggle toggle_MachineGun;
    Toggle toggle_CrossbowHunter;
    Toggle toggle_Sniper;
    Toggle toggle_PillBox;
    Toggle toggle_SharpnelThrower;
    Toggle toggle_PatriotMissile;
    Toggle toggle_Rocket;
    Toggle toggle_Prisim;
    Toggle toggle_Transformer;
    Toggle toggle_Thunder;
    Toggle toggle_FlameThrower;
    Toggle toggle_MolotovCocktail;
    Toggle toggle_Micro;
    Text text_Tower;

    Toggle toggle_Elfin;
    Toggle toggle_Crawler;
    Toggle toggle_Zombie;
    Toggle toggle_Thirsty;
    Toggle toggle_Butcher;
    Toggle toggle_Unicorn;
    Toggle toggle_Desolator;
    Toggle toggle_Manmoth;
    Toggle toggle_Tank;
    Toggle toggle_Dragon;
    Text text_Monster;

    Toggle toggle_MM;
    Toggle toggle_MB;
    Toggle toggle_FR;
    Toggle toggle_TS;
    Text text_Perk;

    void Awake()
    {
        canvasGroup_Turrent = GameObject.Find("Canvas_Main/CanvasGroup_Turrent").GetComponent<CanvasGroup>();
        canvasGroup_Monster = GameObject.Find("Canvas_Main/CanvasGroup_Monster").GetComponent<CanvasGroup>();
        canvasGroup_Perk = GameObject.Find("Canvas_Main/CanvasGroup_Perk").GetComponent<CanvasGroup>();
        
        toggleGroup_Main = GameObject.Find("Canvas_Main/ToggleGroup").GetComponent<ToggleGroup>();
        toggleGroup_Turrent = GameObject.Find("Canvas_Main/CanvasGroup_Turrent/ToggleGroup_Turrent").GetComponent<ToggleGroup>();
        toggleGroup_Monster = GameObject.Find("Canvas_Main/CanvasGroup_Monster/ToggleGroup_Monster").GetComponent<ToggleGroup>();
        toggleGroup_Perk = GameObject.Find("Canvas_Main/CanvasGroup_Perk/ToggleGroup_Perk").GetComponent<ToggleGroup>();

        //<toggleGroup_Main>
        toggle_Turrent = GameObject.Find("Canvas_Main/ToggleGroup/Toggle_Turrent").GetComponent<Toggle>();
        toggle_Monster = GameObject.Find("Canvas_Main/ToggleGroup/Toggle_Monster").GetComponent<Toggle>();
        toggle_Perk = GameObject.Find("Canvas_Main/ToggleGroup/Toggle_Perk").GetComponent<Toggle>();
        //</toggleGroup_Main>

        //<toggleGroup_Turrent>
        toggle_MachineGun = GameObject.Find("Canvas_Main/CanvasGroup_Turrent/ToggleGroup_Turrent/Toggle_MachineGun").GetComponent<Toggle>();
        toggle_CrossbowHunter = GameObject.Find("Canvas_Main/CanvasGroup_Turrent/ToggleGroup_Turrent/Toggle_CrossbowHunter").GetComponent<Toggle>();
        toggle_Sniper = GameObject.Find("Canvas_Main/CanvasGroup_Turrent/ToggleGroup_Turrent/Toggle_Sniper").GetComponent<Toggle>();
        toggle_PillBox = GameObject.Find("Canvas_Main/CanvasGroup_Turrent/ToggleGroup_Turrent/Toggle_PillBox").GetComponent<Toggle>();
        toggle_SharpnelThrower = GameObject.Find("Canvas_Main/CanvasGroup_Turrent/ToggleGroup_Turrent/Toggle_SharpnelThrower").GetComponent<Toggle>();
        toggle_Rocket = GameObject.Find("Canvas_Main/CanvasGroup_Turrent/ToggleGroup_Turrent/Toggle_Rocket").GetComponent<Toggle>();
        toggle_PatriotMissile = GameObject.Find("Canvas_Main/CanvasGroup_Turrent/ToggleGroup_Turrent/Toggle_PatriotMissile").GetComponent<Toggle>();
        toggle_Prisim = GameObject.Find("Canvas_Main/CanvasGroup_Turrent/ToggleGroup_Turrent/Toggle_Prisim").GetComponent<Toggle>();
        toggle_Transformer = GameObject.Find("Canvas_Main/CanvasGroup_Turrent/ToggleGroup_Turrent/Toggle_Transformer").GetComponent<Toggle>();
        toggle_Thunder = GameObject.Find("Canvas_Main/CanvasGroup_Turrent/ToggleGroup_Turrent/Toggle_Thunder").GetComponent<Toggle>();
        toggle_FlameThrower = GameObject.Find("Canvas_Main/CanvasGroup_Turrent/ToggleGroup_Turrent/Toggle_FlameThrower").GetComponent<Toggle>();
        toggle_MolotovCocktail = GameObject.Find("Canvas_Main/CanvasGroup_Turrent/ToggleGroup_Turrent/Toggle_MolotovCocktail").GetComponent<Toggle>();
        toggle_Micro = GameObject.Find("Canvas_Main/CanvasGroup_Turrent/ToggleGroup_Turrent/Toggle_Micro").GetComponent<Toggle>();
        text_Tower = GameObject.Find("Canvas_Main/CanvasGroup_Turrent/Scroll View/Viewport/Content").GetComponent<Text>();
        text_Tower.text = Description.MachineGun(SWelcome.languageChosen);
        //</toggleGroup_Turrent>

        //<toggleGroup_Monster>
        toggle_Elfin = GameObject.Find("Canvas_Main/CanvasGroup_Monster/ToggleGroup_Monster/Toggle_Elfin").GetComponent<Toggle>();
        toggle_Crawler = GameObject.Find("Canvas_Main/CanvasGroup_Monster/ToggleGroup_Monster/Toggle_Crawler").GetComponent<Toggle>();
        toggle_Zombie = GameObject.Find("Canvas_Main/CanvasGroup_Monster/ToggleGroup_Monster/Toggle_Zombie").GetComponent<Toggle>();
        toggle_Thirsty = GameObject.Find("Canvas_Main/CanvasGroup_Monster/ToggleGroup_Monster/Toggle_Thirsty").GetComponent<Toggle>();
        toggle_Butcher = GameObject.Find("Canvas_Main/CanvasGroup_Monster/ToggleGroup_Monster/Toggle_Butcher").GetComponent<Toggle>();
        toggle_Unicorn = GameObject.Find("Canvas_Main/CanvasGroup_Monster/ToggleGroup_Monster/Toggle_Unicorn").GetComponent<Toggle>();
        toggle_Desolator = GameObject.Find("Canvas_Main/CanvasGroup_Monster/ToggleGroup_Monster/Toggle_Desolator").GetComponent<Toggle>();
        toggle_Manmoth = GameObject.Find("Canvas_Main/CanvasGroup_Monster/ToggleGroup_Monster/Toggle_Manmoth").GetComponent<Toggle>();
        toggle_Tank = GameObject.Find("Canvas_Main/CanvasGroup_Monster/ToggleGroup_Monster/Toggle_Tank").GetComponent<Toggle>();
        toggle_Dragon = GameObject.Find("Canvas_Main/CanvasGroup_Monster/ToggleGroup_Monster/Toggle_Dragon").GetComponent<Toggle>();
        text_Monster = GameObject.Find("Canvas_Main/CanvasGroup_Monster/Scroll View/Viewport/Content").GetComponent<Text>();
        text_Monster.text = Description.Elfin(SWelcome.languageChosen);
        //</toggleGroup_Monster>

        toggle_MM = GameObject.Find("Canvas_Main/CanvasGroup_Perk/ToggleGroup_Perk/Toggle_MachineMastery").GetComponent<Toggle>();
        toggle_MB = GameObject.Find("Canvas_Main/CanvasGroup_Perk/ToggleGroup_Perk/Toggle_MadBomber").GetComponent<Toggle>();
        toggle_FR = GameObject.Find("Canvas_Main/CanvasGroup_Perk/ToggleGroup_Perk/Toggle_FireRanger").GetComponent<Toggle>();
        toggle_TS = GameObject.Find("Canvas_Main/CanvasGroup_Perk/ToggleGroup_Perk/Toggle_ThunderSpirit").GetComponent<Toggle>();
        text_Perk = GameObject.Find("Canvas_Main/CanvasGroup_Perk/Scroll View/Viewport/Content").GetComponent<Text>();
        text_Perk.text = Description.MachineMastery(SWelcome.languageChosen);
    }

    void Start()
    {
        toggleGroup_Main.SetAllTogglesOff();
        toggle_Turrent.isOn = true;
        toggleGroup_Turrent.SetAllTogglesOff();
        toggle_MachineGun.isOn = true;
        toggleGroup_Monster.SetAllTogglesOff();
        toggle_Elfin.isOn = true;
        toggleGroup_Perk.SetAllTogglesOff();
        toggle_MM.isOn = true;

        canvasGroup_Turrent.gameObject.SetActive(true);
        canvasGroup_Monster.gameObject.SetActive(false);
        canvasGroup_Perk.gameObject.SetActive(false);
    }

    public void OnClick_Back()
    {
        SceneManager.LoadScene("Welcome");
    }

    public void OnClick_Turrent()
    {
        if (toggle_Turrent.isOn)
        {
            canvasGroup_Turrent.gameObject.SetActive(true);
            canvasGroup_Monster.gameObject.SetActive(false);
            canvasGroup_Perk.gameObject.SetActive(false);
        }
    }
    public void OnClick_Monster()
    {
        if (toggle_Monster.isOn)
        {
            canvasGroup_Turrent.gameObject.SetActive(false);
            canvasGroup_Monster.gameObject.SetActive(true);
            canvasGroup_Perk.gameObject.SetActive(false);
        }
    }
    public void OnClick_Perk()
    {
        if (toggle_Perk.isOn)
        {
            canvasGroup_Turrent.gameObject.SetActive(false);
            canvasGroup_Monster.gameObject.SetActive(false);
            canvasGroup_Perk.gameObject.SetActive(true);
        }
    }

    public void OnClick_AnyMonster()
    {
        if (toggle_Elfin.isOn) text_Monster.text = Description.Elfin(SWelcome.languageChosen);
        if (toggle_Crawler.isOn) text_Monster.text = Description.Crawler(SWelcome.languageChosen);
        if (toggle_Zombie.isOn) text_Monster.text = Description.Zombie(SWelcome.languageChosen);
        if (toggle_Thirsty.isOn) text_Monster.text = Description.Thirsty(SWelcome.languageChosen);
        if (toggle_Butcher.isOn) text_Monster.text = Description.Butcher(SWelcome.languageChosen);
        if (toggle_Unicorn.isOn) text_Monster.text = Description.Unicron(SWelcome.languageChosen);
        if (toggle_Desolator.isOn) text_Monster.text = Description.Desolator(SWelcome.languageChosen);
        if (toggle_Manmoth.isOn) text_Monster.text = Description.Manmoth(SWelcome.languageChosen);
        if (toggle_Tank.isOn) text_Monster.text = Description.Tank(SWelcome.languageChosen);
        if (toggle_Dragon.isOn) text_Monster.text = Description.Dragon(SWelcome.languageChosen);
    }

    public void OnClick_AnyTurrent()
    {
        if (toggle_MachineGun.isOn) text_Tower.text = Description.MachineGun(SWelcome.languageChosen);
        if (toggle_CrossbowHunter.isOn) text_Tower.text = Description.CrossbowHunter(SWelcome.languageChosen);
        if (toggle_Sniper.isOn) text_Tower.text = Description.Sniper(SWelcome.languageChosen);
        if (toggle_PillBox.isOn) text_Tower.text = Description.PillBox(SWelcome.languageChosen);
        if (toggle_SharpnelThrower.isOn) text_Tower.text = Description.SharpnelThrower(SWelcome.languageChosen);
        if (toggle_PatriotMissile.isOn) text_Tower.text = Description.PatriotMissile(SWelcome.languageChosen);
        if (toggle_Rocket.isOn) text_Tower.text = Description.Rocket(SWelcome.languageChosen);
        if (toggle_Prisim.isOn) text_Tower.text = Description.Prisim(SWelcome.languageChosen);
        if (toggle_Transformer.isOn) text_Tower.text = Description.Transformer(SWelcome.languageChosen);
        if (toggle_Thunder.isOn) text_Tower.text = Description.Thunder(SWelcome.languageChosen);
        if (toggle_FlameThrower.isOn) text_Tower.text = Description.FlameThrower(SWelcome.languageChosen);
        if (toggle_MolotovCocktail.isOn) text_Tower.text = Description.MolotovCocktail(SWelcome.languageChosen);
        if (toggle_Micro.isOn) text_Tower.text = Description.Micro(SWelcome.languageChosen);
    }

    public void OnClick_AnyPerk()
    {
        if (toggle_MM.isOn) text_Perk.text = Description.MachineMastery(SWelcome.languageChosen);
        if (toggle_MB.isOn) text_Perk.text = Description.MadBomber(SWelcome.languageChosen);
        if (toggle_FR.isOn) text_Perk.text = Description.FireRanger(SWelcome.languageChosen);
        if (toggle_TS.isOn) text_Perk.text = Description.ThunderSpirit(SWelcome.languageChosen);
    }
}
