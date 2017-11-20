using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Welcome : MonoBehaviour {
    public void onClick_Start()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void onClick_Description()
    {
        SceneManager.LoadScene("Description");
    }

    public void onClick_Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
