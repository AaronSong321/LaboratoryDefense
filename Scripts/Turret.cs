using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public enum AttackType { bullet, explosive, tesla, flame, nuclear, unknown }
    public enum TargetType { ground, air, ground_all, ground_air, unknown }
    public enum TurretName { MG, CH, PB, SP, ST, PM, RL, PS, TF, TD, FT, MC, MW}
    private enum AnimosityMode { fifo, intelligent, complex}

    public float attackRateTime = 1;
    public TurretName turretName;
    internal float attackSpeed;
    internal float minRange = 0;
    internal float maxRange = 240;
    internal ImmediateCube ic;
    internal ExplosionCube ec;
    internal FiringCube fc;
    internal SlowCube sc;
    internal StunCube tc;

    public GameObject bulletPrefab;
    public Transform firePosition;
    public Transform head;
    SphereCollider minSphereCollider;
    SphereCollider maxSphereCollider;
    
    private List<GameObject> enemies = new List<GameObject>();
    private float timer = 0;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            enemies.Add(col.gameObject);
            if (enemies[0] != null && this*enemies[0].GetComponent<Enemy>() < this*enemies[enemies.Count-1].GetComponent<Enemy>())
            {
                GameObject t = enemies[enemies.Count - 1];
                enemies[enemies.Count - 1] = enemies[0];
                enemies[0] = t;
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
            enemies.Remove(col.gameObject);
        }
    }

    void Awake()
    {
        /*
        minSphereCollider = gameObject.AddComponent<SphereCollider>();
        minSphereCollider.isTrigger = true;
        minSphereCollider.center = new Vector3(0, 0.5f, 0);
        minSphereCollider.radius = minRange / 20;

        maxSphereCollider = gameObject.AddComponent<SphereCollider>();
        maxSphereCollider.isTrigger = true;
        maxSphereCollider.center = new Vector3(0, 0.5f, 0);
        maxSphereCollider.radius = maxRange / 20;
        */
    }
    void Start()
    {
        timer = attackRateTime;
        /*
        SphereCollider[] colliders = GetComponents<SphereCollider>();
        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log(turretName.ToString()+ i.ToString()+" "+colliders[i].radius.ToString());
        }
        */
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

        CalculateAnimosity(AnimosityMode.intelligent);
    }
    
    void CalculateAnimosity(AnimosityMode mode = AnimosityMode.fifo)
    {
        switch(mode)
        {
            case AnimosityMode.fifo: return;
            case AnimosityMode.complex:
                List<AnimosityPair> pairs = new List<AnimosityPair>(enemies.Count);
                for (int i = 0; i < enemies.Count; i++)
                    pairs[i] = new AnimosityPair(this, enemies[i].GetComponent<Enemy>());
                pairs.Sort();

                for (int i = 0; i < enemies.Count; i++)
                    enemies[i] = pairs[i].enemy.gameObject;
                return;
            case AnimosityMode.intelligent:
                for (int i = 0; i < enemies.Count; i++)
                    for (int j = i+1; j < enemies.Count; j++)
                        if (this*enemies[i].GetComponent<Enemy>() < this*enemies[j].GetComponent<Enemy>())
                        {
                            GameObject t = enemies[j];
                            enemies[j] = enemies[i];
                            enemies[i] = t;
                        }
                return;
        }

    }

    public static AttackType GetAttackType(string s)
    {
        if (s.Equals("bullet")) return AttackType.bullet;
        if (s.Equals("explosive")) return AttackType.explosive;
        if (s.Equals("tesla")) return AttackType.tesla;
        if (s.Equals("flame")) return AttackType.flame;
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

    public static GiantPreAnimoPair operator *(Turret t, Enemy e)
    {
        return new GiantPreAnimoPair(t, e);
    }
}
