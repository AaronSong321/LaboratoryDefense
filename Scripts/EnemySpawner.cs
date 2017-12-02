using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemySpawner : MonoBehaviour
{
    public Transform START;
    public float enemyInterval;

    internal void StopSpawnEnemy()
    {
        StopAllCoroutines();
    }

    internal IEnumerator SpawnEnemy(List<GameObject> wave)
    {
        for (int i = 0; i < wave.Count - 1; i++)
        {
            Instantiate(wave[i], START.position, START.rotation);
            yield return new WaitForSeconds(enemyInterval);
        }
        Instantiate(wave[wave.Count-1], START.position, START.rotation);
        yield break;
    }
}
