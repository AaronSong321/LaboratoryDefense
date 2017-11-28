using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
    public Transform START;
    private Coroutine coroutine;

    public float enemyInterval = 0.2f;
    public float waveInterval = 5f;
    public int waveCount;
    public WaveGenerator.Difficulty gameDifficulty;

    List<GameObject>[] allWaves;
    int countEnemyAlive = 0;
    int currentWave = 0;
    Text XWave;
    Text XEnemyCount;

    public WaveGenerator generator;

    void Awake()
    {
        XWave = GameObject.Find("Canvas/XWave").GetComponent<Text>();
        XEnemyCount = GameObject.Find("Canvas/XEnemyCount").GetComponent<Text>();
        currentWave = 0;
    }
    void Start()
    {
        allWaves = generator.GenerateAllWaves(waveCount, gameDifficulty);
        XWave.text = "波数    " + currentWave + " / " + allWaves.Length;
        XEnemyCount.text = "剩余敌人数量    0 / 0";
        coroutine = StartCoroutine(SpawnEnemy());
    }
    public void Stop()
    {
        StopCoroutine(coroutine);
    }

    public void EnemyKilled(object sender, Enemy.EnemyKilledEventArgs e)
    {
        countEnemyAlive--;
        XEnemyCount.text = "剩余敌人数量  " + countEnemyAlive + " / " + allWaves[currentWave - 1].Count;
    }
    public void SubscribeEnemyKilledEvent(Enemy e)
    {
        e.EnemyKilledEvent += new Enemy.EnemyKilledEventHandler(EnemyKilled);
    }
    public void UnsubscribeEnemyKilledEvent(Enemy e)
    {
        e.EnemyKilledEvent -= new Enemy.EnemyKilledEventHandler(EnemyKilled);
    }

    IEnumerator SpawnEnemy()
    {
        foreach (List<GameObject> wave in allWaves)
        {
            currentWave++;
            XWave.text = "波数    " + currentWave + " / " + allWaves.Length;
            countEnemyAlive = wave.Count;
            XEnemyCount.text = "剩余敌人数量    " + countEnemyAlive + " / " + wave.Count;
            for (int i = 0; i < wave.Count; i++)
            {
                Instantiate(wave[i], START.position, START.rotation);
                if (i != wave.Count - 1)
                    yield return new WaitForSeconds(enemyInterval);
            }
            while (countEnemyAlive > 0)
                yield return 0;
            yield return new WaitForSeconds(waveInterval);
        }
        while (countEnemyAlive > 0)
            yield return 0;
        GameManager.Instance.Win();
    }
}
