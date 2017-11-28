using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public enum AttackType { bullet, explosive, tesla, flame, toxic, nuclear, unknown }
    public enum TargetType { ground, air, ground_all, ground_air, unknown }
    public enum TurretName { MG, CH, PB, SP, ST, PM, RL, PS, TF, TD, FT, MC, MW}

    public float attackRateTime = 1;

    public GameObject bulletPrefab;
    public Transform firePosition;
    public Transform head;

    private Player player;
    private List<GameObject> enemies = new List<GameObject>();
    private float timer = 0;

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

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        attackRateTime *= player.perk.AttackRateTime_adj;
        timer = attackRateTime;
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

    void Attack()
    {
        if (enemies[0] == null)
        {
            UpdateEnemies();
        }
        if (enemies.Count > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            bullet.GetComponent<BulletObj>().SetTarget(enemies[0].transform);
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
            enemies.RemoveAt(emptyIndex[i]-i);
        }
    }

    public static AttackType GetAttackType(string s)
    {
        if (s.Equals("bullet")) return AttackType.bullet;
        if (s.Equals("explosive")) return AttackType.explosive;
        if (s.Equals("tesls")) return AttackType.tesla;
        if (s.Equals("flame")) return AttackType.flame;
        if (s.Equals("toxic")) return AttackType.toxic;
        if (s.Equals("nuclear")) return AttackType.nuclear;
        return AttackType.unknown;
    }

    public static TargetType GetTargetType(string s)
    {
        if (s.Equals("ground")) return TargetType.ground;
        if (s.Equals("air")) return TargetType.air;
        if (s.Equals("ground_all")) return TargetType.air;
        if (s.Equals("ground_air")) return TargetType.ground_air;
        return TargetType.unknown;
    }
}
