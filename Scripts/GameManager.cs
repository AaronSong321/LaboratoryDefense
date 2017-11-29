using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject endUI;
    public Text endMessage;

    public static GameManager Instance;
    private EnemySpawner enemySpawner;
    public WaveGenerator waveGenerator;

    public int[] initMoney;
    internal int money;
    public int initBaseHp = 30;
    int baseHp;
    public WaveGenerator.Difficulty difficulty = WaveGenerator.Difficulty.hypothetical;
    public int waveCount = 8;
    int currentWave;
    List<GameObject>[] waves;
    int enemyAliveCount;

    public float waveInterval;
    Coroutine gameCycleCoroutine;

    Text xMoney;
    Text xWave;
    Text xEnemyAliveCount;
    Text xBaseHp;

    internal void EnemyKilled(object sender, Enemy.EnemyKilledEventArgs e)
    {
        enemyAliveCount--;
        EarnMoney(e.enemy);
        xEnemyAliveCount.text = "剩余敌人数量    " + enemyAliveCount +" / " + waves[currentWave-1].Count;
    }
    internal void SubscribeEnemyKilled(Enemy e)
    {
        e.EnemyKilledEvent += new Enemy.EnemyKilledEventHandler(EnemyKilled);
    }
    internal void UnsubscribeEnemyKilled(Enemy e)
    {
        e.EnemyKilledEvent -= new Enemy.EnemyKilledEventHandler(EnemyKilled);
    }

    internal void EnemyReach(object sender, Enemy.EnemyReachEventArgs e)
    {
        enemyAliveCount--;
        TakeDamage(e.enemy);
        xEnemyAliveCount.text = "剩余敌人数量    " + enemyAliveCount + " / " + waves[currentWave - 1].Count;
        xBaseHp.text = "基地生命值    " + baseHp;
    }
    internal void SubscribeEnemyReach(Enemy e)
    {
        e.EnemyReachEvent += new Enemy.EnemyReachEventHandler(EnemyReach);
    }
    internal void UnsubscribeEnemyReach(Enemy e)
    {
        e.EnemyReachEvent -= new Enemy.EnemyReachEventHandler(EnemyReach);
    }

    void SpendMoney(object sender, BuildManager.SpendMoneyEventArgs e)
    {
        money -= e.moneySpent;
        xMoney.text = "$ " + money;
    }
    internal void SubscribeSpendMoney(BuildManager buildManager)
    {
        buildManager.SpendMoneyEvent += new BuildManager.SpendMoneyEventHandler(SpendMoney);
    }
    internal void UnsubscribeSpendMoney(BuildManager buildManager)
    {
        buildManager.SpendMoneyEvent -= new BuildManager.SpendMoneyEventHandler(SpendMoney);
    }

    void ReturnMoney(object sender, MapCube.ReturnMoneyEventArgs e)
    {
        money += e.moneyReturn;
        xMoney.text = "$ " + money;
    }
    internal void SubscribeReturnMoney(MapCube cube)
    {
        cube.ReturnMoneyEvent += new MapCube.ReturnMoneyEventHandler(ReturnMoney);
    }
    internal void UnsubscribeReturnMoney(MapCube cube)
    {
        cube.ReturnMoneyEvent -= new MapCube.ReturnMoneyEventHandler(ReturnMoney);
    }

    void Awake()
    {
        Instance = this;
        enemySpawner = GetComponent<EnemySpawner>();
        xMoney = GameObject.Find("Canvas/Money").GetComponent<Text>();
        xWave = GameObject.Find("Canvas/XWave").GetComponent<Text>();
        xEnemyAliveCount = GameObject.Find("Canvas/XEnemyCount").GetComponent<Text>();
        xBaseHp = GameObject.Find("Canvas/XBaseHP").GetComponent<Text>();
    }

    void Start()
    {
        waves = waveGenerator.GenerateAllWaves(waveCount, difficulty);
        
        baseHp = initBaseHp;
        currentWave = 0;

        xMoney.text = "$ " + money;
        xWave.text = "当前波数    " + currentWave + " / " + waveCount;
        xEnemyAliveCount.text = "剩余敌人数量    " + "0 / 0";
        xBaseHp.text = "基地生命值    " + baseHp;

        gameCycleCoroutine = StartCoroutine(StartGameCycle());
    }

    void TakeDamage(Enemy e)
    {
        int damageTaken = e.damage;
        if (damageTaken > baseHp)
        {
            baseHp = 0;
            Fail();
        }
        else baseHp -= damageTaken;
    }

    void EarnMoney(Enemy e)
    {
        money += e.enemyMoney;
        xMoney.text = "$ " + money;
    }

    IEnumerator StartGameCycle()
    {
        for (int i = 0; i < waveCount; i++)
        {
            bool moneySent = true;
            if (moneySent)
            {
                money += initMoney[currentWave];
                xMoney.text = "$ " + money;
                moneySent = false;
            }
            yield return new WaitForSeconds(waveInterval);
            currentWave++;
            xWave.text = "当前波数    " + currentWave + " / " + waveCount;
            enemyAliveCount = waves[currentWave - 1].Count;
            xEnemyAliveCount.text = "剩余敌人数量    " + enemyAliveCount + " / " + waves[currentWave - 1].Count;
            yield return StartCoroutine(enemySpawner.SpawnEnemy(waves[i]));
            while (enemyAliveCount > 0)
                yield return 0;
        }
        Win();
    }

    void Win()
    {
        endUI.SetActive(true);
        endMessage.text = "胜 利";
    }
    void Fail()
    {
        enemySpawner.StopSpawnEnemy();
        StopCoroutine(gameCycleCoroutine);
        endUI.SetActive(true);
        endMessage.text = "失 败";
    }

    public void OnButtonRetry()
    {
        SceneManager.LoadScene("ChoosingPerk");
    }
    public void OnButtonMenu()
    {
        SceneManager.LoadScene("Welcome");
    }
}
