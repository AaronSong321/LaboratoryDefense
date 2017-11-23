using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Tower: MonoBehaviour
{
    public AttackBehavior attackBehavior;
    public double firingRate;
    public double rangeMin;
    public double rangeMax;
    public int money;
    public float attackRateTime = 1;
    private float timer = 0;
    public GameObject bulletPrefab;
    public Transform firePosition;
    public Transform head;
    private List<GameObject> enemies = new List<GameObject>();
    private Player player;

    public bool useLaser = false;

    public float damageRate = 70;

    public override string ToString()
    {
        StringBuilder ans = new StringBuilder();
        if (attackBehavior == null) return ans.ToString();
        ans.Append("Name: " + name + "\n");
        if (attackBehavior.ic != null) ans.Append(attackBehavior.ic.ToString() + "\n");
        if (attackBehavior.ec != null) ans.Append(attackBehavior.ec.ToString() + "\n");
        if (attackBehavior.fc != null) ans.Append(attackBehavior.fc.ToString() + "\n");
        if (attackBehavior.efc != null) ans.Append(attackBehavior.efc.ToString() + "\n");
        if (attackBehavior.sc != null) ans.Append(attackBehavior.sc.ToString() + "\n");
        if (attackBehavior.tc != null) ans.Append(attackBehavior.tc.ToString() + "\n");
        return base.ToString();
    }

    void Attack()
    {
        if (enemies[0] == null)
        {
            UpdateEnemies();
        }
        if (enemies.Count > 0)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
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