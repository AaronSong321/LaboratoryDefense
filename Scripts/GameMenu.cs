using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    public void OnStartGame()
    {
        //SceneManager.LoadScene("MainScene");
        SceneManager.LoadScene("SoloGame");
    }
    public void OnExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
