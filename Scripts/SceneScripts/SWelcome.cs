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
    CanvasGroup CGOptions;
    CanvasGroup CGMain;
    CanvasGroup CGLogin;
        InputField IFName;
        InputField IFPassword;
        Text XMessage;

    void Awake()
    {
        languageString = new List<string>
        {
            "English",
            "中文（简体）"
        };

        CGOptions = GameObject.Find("Canvas/CGOptions").GetComponent<CanvasGroup>();
        CGMain = GameObject.Find("Canvas/CGMain").GetComponent<CanvasGroup>();
        CGLogin = GameObject.Find("Canvas/CGLogin").GetComponent<CanvasGroup>();
        optionsDropdown = GameObject.Find("Canvas/CGOptions/Dropdown").GetComponent<Dropdown>();
        IFName = GameObject.Find("Canvas/CGLogin/IFName").GetComponent<InputField>();
        IFPassword = GameObject.Find("Canvas/CGLogin/IFPassword").GetComponent<InputField>();
        XMessage = GameObject.Find("Canvas/CGLogin/XMessage").GetComponent<Text>();

        IFName.characterLimit = 15;
        IFName.lineType = InputField.LineType.SingleLine;
        IFPassword.characterLimit = 15;
        IFPassword.lineType = InputField.LineType.SingleLine;
        IFPassword.contentType = InputField.ContentType.Password;

        optionsDropdown.options.Clear();
        foreach (string ls in languageString)
        {
            Dropdown.OptionData tempOptionData = new Dropdown.OptionData();
            tempOptionData.text = ls;
            optionsDropdown.options.Add(tempOptionData);
        }
        optionsDropdown.captionText.text = languageString[0];
        CGOptions.gameObject.SetActive(false);
        
        string path = "OutgameSettings.xml";
        if (!File.Exists(Settings.GeneratePath(path)))
            outgameSettings = OutgameSettings.CreateOutgameSettings(path);
        else
            outgameSettings = OutgameSettings.LoadOutgameSettings(path);

        if (Player.currentPlayer == null)
        {
            CGMain.interactable = false;
            CGLogin.gameObject.SetActive(true);
        }
        else CGLogin.gameObject.SetActive(false);
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
        CGOptions.gameObject.SetActive(true);
        CGMain.interactable = false;
    }

    public void OnClick_Back()
    {
        CGOptions.gameObject.SetActive(false);
        CGMain.interactable = true;
    }

    public void OnChangingLanguage()
    {
        outgameSettings.language = OutgameSettings.GetLanguage(optionsDropdown.captionText.text);
        outgameSettings.SaveOutgameSettings();
    }

    public void OnLogin()
    {
        string playerName = IFName.text;
        string password = IFPassword.text;
        Player.LogInState logInState = Player.LogIn(playerName, password);
        switch(logInState)
        {
            case Player.LogInState.doesNotExist: XMessage.text = "用户不存在"; break;
            case Player.LogInState.wrongPassword: XMessage.text = "密码错误"; break;
            case Player.LogInState.success: CGLogin.gameObject.SetActive(false); CGMain.interactable = true; break;
        }
    }

    public void OnRegister()
    {
        string playerName = IFName.text;
        string password = IFPassword.text;
        Player.RegisterState registerState = Player.Register(playerName, password);
        switch(registerState)
        {
            case Player.RegisterState.alreadyExist: XMessage.text = "用户名已存在"; break;
            case Player.RegisterState.success:
                XMessage.text = "注册成功，请登录";
                IFPassword.text = "";
                break;
        }
    }
}
