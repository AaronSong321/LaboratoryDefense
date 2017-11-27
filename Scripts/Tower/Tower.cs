using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Tower: MonoBehaviour
{
    public AttackBehavior attackBehavior;
    public float firingRate;
    //public float rangeMin;
    //public float rangeMax;
    public int money;
    private float attackRateTime;
    private float timer;
    public GameObject bulletPrefab;
    public GameObject towerPrefabLv1;
    public GameObject towerPrefabLv2;
    public GameObject towerPrefabLv3;
    public Transform firePosition;
    public Transform head;
    private List<GameObject> enemies = new List<GameObject>();
    private Player player;
    public int level;

    void Awake()
    {
        attackRateTime = 100 / firingRate;
        timer = 0;
    }

    void Update()
    {
        if (enemies.Count > 0 && enemies[0] != null)
        {
            Vector3 targetPosition = enemies[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);
        }

        timer += Time.deltaTime;
        if (enemies.Count > 0 && timer >= attackRateTime)
        {
            timer = 0;
            Attack();
        }
    }

    /*
    public override string ToString()
    {
        StringBuilder ans = new StringBuilder();
        ans.Append("Name: " + name + "\n");
        if (ic != null) ans.Append(ic.ToString() + "\n");
        if (ec != null) ans.Append(ec.ToString() + "\n");
        if (fc != null) ans.Append(fc.ToString() + "\n");
        if (efc != null) ans.Append(efc.ToString() + "\n");
        if (sc != null) ans.Append(sc.ToString() + "\n");
        if (tc != null) ans.Append(tc.ToString() + "\n");
        return base.ToString();
    }
    */

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            enemies.Add(col.gameObject);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
            enemies.Remove(col.gameObject);
        }
    }

    void Attack()
    {
        if (enemies[0] == null)
        {
            UpdateEnemies();
        }
        if (enemies.Count > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            bullet.GetComponent<Bullet>().SetTarget(enemies[0].transform);
        }
        else
        {
            timer = attackRateTime;
        }
    }

    void UpdateEnemies()
    {
        //enemys.RemoveAll(null);
        List<int> emptyIndex = new List<int>();
        for (int index = 0; index < enemies.Count; index++)
        {
            if (enemies[index] == null)
            {
                emptyIndex.Add(index);
            }
        }

        for (int i = 0; i < emptyIndex.Count; i++)
        {
            enemies.RemoveAt(emptyIndex[i] - i);
        }
    }
}