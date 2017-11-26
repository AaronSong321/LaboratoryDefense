using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SSoloGame : MonoBehaviour
{
    Button BPause;

    void Awake()
    {
        BPause = GameObject.Find("Canvas/BPause").GetComponent<Button>();
    }

    public void OnPauseClick()
    {
        if (Time.timeScale == 1) Time.timeScale = 0;
        if (Time.timeScale == 0) Time.timeScale = 1;
    }

    /*
    public GameObject endUI;
    public Text endMessage;

    public static SSoloGame Instance;
    private EnemySpawner enemySpawner;
    void Awake()
    {
        Instance = this;
        enemySpawner = GetComponent<EnemySpawner>();
    }

    public void Win()
    {
        endUI.SetActive(true);
        endMessage.text = "胜 利";
    }
    public void Failed()
    {
        enemySpawner.Stop();
        endUI.SetActive(true);
        endMessage.text = "失 败";
    }

    public void OnButtonRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnButtonMenu()
    {
        SceneManager.LoadScene("Welcome");
    }
    */
}
