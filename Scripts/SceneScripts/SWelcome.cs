using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SWelcome : MonoBehaviour
{
    List<string> languageString;

    OutgameSettings outgameSettings;

    Dropdown optionsDropdown;
    CanvasGroup canvasGroup_Options;

    Button button_Start;
    Button button_Description;
    Button button_Options;
    Button button_Quit;

    void Awake()
    {
        languageString = new List<string>();
        languageString.Add("English");
        languageString.Add("中文（简体）");

        canvasGroup_Options = GameObject.Find("MainCanvas/CanvasGroup_Options").GetComponent<CanvasGroup>();
        optionsDropdown = GameObject.Find("MainCanvas/CanvasGroup_Options/Dropdown").GetComponent<Dropdown>();
        button_Start = GameObject.Find("MainCanvas/Button_Start").GetComponent<Button>();
        button_Description = GameObject.Find("MainCanvas/Button_Description").GetComponent<Button>();
        button_Options = GameObject.Find("MainCanvas/Button_Options").GetComponent<Button>();
        button_Quit = GameObject.Find("MainCanvas/Button_Quit").GetComponent<Button>();

        optionsDropdown.options.Clear();
        foreach (string ls in languageString)
        {
            Dropdown.OptionData tempOptionData = new Dropdown.OptionData();
            tempOptionData.text = ls;
            optionsDropdown.options.Add(tempOptionData);
        }
        optionsDropdown.captionText.text = languageString[0];
        canvasGroup_Options.gameObject.SetActive(false);
        
        string path = "OutgameSettings.xml";
        if (!File.Exists(Settings.GeneratePath(path)))
            outgameSettings = OutgameSettings.CreateOutgameSettings(path);
        else
            outgameSettings = OutgameSettings.LoadOutgameSettings(path);
    }

    public void OnClick_Start()
    {
        SceneManager.LoadScene("ChoosingPerk");
    }

    public void OnClick_Description()
    {
        SceneManager.LoadScene("Description");
    }

    public void OnClick_Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnClick_Options()
    {
        canvasGroup_Options.gameObject.SetActive(true);
        button_Start.interactable = false;
        button_Description.interactable = false;
        button_Options.GetComponent<Button>().interactable = false;
        button_Quit.GetComponent<Button>().interactable = false;
        //languageChosen = Description.GetLanguage(optionsDropdown.options[optionsDropdown.value].text);
    }

    public void OnClick_Back()
    {
        canvasGroup_Options.gameObject.SetActive(false);
        button_Start.interactable = true;
        button_Description.interactable = true;
        button_Options.GetComponent<Button>().interactable = true;
        button_Quit.GetComponent<Button>().interactable = true;
    }

    public void OnChangingLanguage()
    {
        outgameSettings.language = OutgameSettings.GetLanguage(optionsDropdown.captionText.text);
        outgameSettings.SaveOutgameSettings();
    }
}
