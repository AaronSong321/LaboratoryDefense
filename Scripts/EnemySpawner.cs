using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    public Wave[] waves;
    public Transform START;
    public float waveRate = 0.2f;
    private Coroutine coroutine;

    internal static int CountEnemyAlive = 0;
    int currentWave = 0;
    Text XWave;
    //Text XEnemyCount;

    void Awake()
    {
        XWave = GameObject.Find("Canvas/XWave").GetComponent<Text>();
        //XEnemyCount = GameObject.Find("Canvas/XEnemyCount").GetComponent<Text>();
        currentWave = 0;
    }
    void Start()
    {
        XWave.text = "波数    " + currentWave + " / " + waves.Length;
        //XEnemyCount.text = "剩余敌人数量  0 / 0";
        coroutine = StartCoroutine(SpawnEnemy());
    }
    public void Stop()
    {
        StopCoroutine(coroutine);
    }
    IEnumerator SpawnEnemy()
    {
        foreach (Wave wave in waves)
        {
            currentWave++;
            XWave.text = "波数    " + currentWave + " / " + waves.Length;
            //XEnemyCount.text = "剩余敌人数量  "+CountEnemyAlive+" / "+waves[currentWave-1].count;
            for (int i = 0; i < wave.count; i++)
            {
                Instantiate(wave.enemyPrefab, START.position, Quaternion.identity);
                CountEnemyAlive++;
                if(i!=wave.count-1)
                    yield return new WaitForSeconds(wave.rate);
            }
            while (CountEnemyAlive > 0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(waveRate);
        }
        while (CountEnemyAlive > 0)
        {
            yield return 0;
        }
        GameManager.Instance.Win();
    }
}
