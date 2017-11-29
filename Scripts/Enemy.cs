using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public enum EnemyType { ground, air, ground_air, air_ground, unknown };
    public enum SizeType { tiny, common, giant, boss, unknown };

    public float speed = 10;
    public float hp = 150;
    public int damage = 50;
    public int enemyMoney = 100;
    public float bulletResis = 1f;
    public float explosiveResis = 1f;
    public float flameResis = 1f;
    public float teslaResis = 1f;
    public float nuclearResis = 1f;
    public EnemyType enemyType = EnemyType.ground;
    public SizeType sizeType = SizeType.tiny;

    public NavMeshAgent agent;
    public GameObject explosionEffect;
    private GameManager gameManager;
    private Slider hpSlider;

    float totalHp;
    float currentSpeed;
    bool stunned;
    FiringDebuff firingDebuff;
    SlowDebuff slowDebuff;
    StunDebuff stunDebuff;

    EnemySpawner es;
    Player player;
    SSoloGame scene;

    public class EnemyKilledEventArgs : EventArgs
    {
        public readonly Enemy enemy;
        public EnemyKilledEventArgs(Enemy enemy)
        {
            this.enemy = enemy;
        }
    }
    public delegate void EnemyKilledEventHandler(object sender, EnemyKilledEventArgs e);
    public event EnemyKilledEventHandler EnemyKilledEvent;

    public class EnemyReachEventArgs: EventArgs
    {
        public readonly Enemy enemy;
        public EnemyReachEventArgs(Enemy enemy)
        {
            this.enemy = enemy;
        }
    }
    public delegate void EnemyReachEventHandler(object sender, EnemyReachEventArgs e);
    public event EnemyReachEventHandler EnemyReachEvent;
    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        es = GameObject.Find("GameManager").GetComponent<EnemySpawner>();
        scene = GameObject.Find("SSoloGame").GetComponent<SSoloGame>();
    }

	void Start ()
    {
        totalHp = hp;
        currentSpeed = speed;
        stunned = false;
        firingDebuff = null;
        slowDebuff = null;
        stunDebuff = null;
        hpSlider = GetComponentInChildren<Slider>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed * player.perk.mobspeed_adj;
        agent.destination = GameObject.Find("End").GetComponent<Transform>().position;

        gameManager.SubscribeEnemyKilled(this);
        gameManager.SubscribeEnemyReach(this);
    }
	
	void Update ()
    {
        if (stunned == false) Move();
        TakeFiringDamage();
        TakeSlowDamage();
        TakeStunDamage();
	}


    void Move()
    {
        agent.destination = GameObject.Find("End").GetComponent<Transform>().position;
        if (!agent.pathPending && agent.remainingDistance != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance <= agent.stoppingDistance)
        {
            ReachDestination();
        }
    }
    
    void ReachDestination()
    {
        player.playerhp -= damage;
        EnemyReachEvent(this, new EnemyReachEventArgs(this));
        Destroy(gameObject);
    }
    
    public void TakeFiringDebuff(FiringCube fc)
    {
        FiringDebuff newFiringDebuf = new FiringDebuff
        {
            attackType = fc.attackType,
            damagePerSecond = fc.damagePerSecond,
            duration = fc.duration,
            timer = fc.duration
        };
        if (firingDebuff == null || newFiringDebuf > firingDebuff) firingDebuff = newFiringDebuf;
    }
    void TakeFiringDamage()
    {
        if (firingDebuff != null)
        {
            TakeDamage(Time.deltaTime * firingDebuff.damagePerSecond);
            firingDebuff.timer -= Time.deltaTime;
            if (firingDebuff.timer <= 0) firingDebuff = null;
        }
    }

    public void TakeSlowDebuff(SlowCube sc)
    {
        SlowDebuff newSlowDebuff = new SlowDebuff
        {
            attackType = sc.attackType,
            duration = sc.slowDuration,
            timer = sc.slowDuration
        };
        if (slowDebuff == null || newSlowDebuff > slowDebuff)
        {
            slowDebuff = newSlowDebuff;
            currentSpeed = speed * slowDebuff.slowPercent;
        }
    }
    void TakeSlowDamage()
    {
        if (slowDebuff != null)
        {
            slowDebuff.timer -= Time.deltaTime;
            if (slowDebuff.timer <= 0)
            {
                slowDebuff = null;
                currentSpeed = speed;
            }
        }
    }

    public void TakeStunDebuff(StunCube tc)
    {
        if (tc.possibility > UnityEngine.Random.value)
        {
            StunDebuff newStunDebuff = new StunDebuff
            {
                attackType = tc.attackType,
                duration = tc.stunDuration,
                timer = tc.stunDuration
            };
            if (stunDebuff == null || newStunDebuff > stunDebuff)
            {
                stunDebuff = newStunDebuff;
                stunned = true;
            }
        }

    }
    void TakeStunDamage()
    {
        if (stunDebuff != null)
        {
            stunDebuff.timer -= Time.deltaTime;
            if (stunDebuff.timer <= 0)
            {
                stunDebuff = null;
                stunned = false;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        hpSlider.value = hp / totalHp;
        if (hp <= 0)
        {
            Die();
        }
    }
    public void TakeDamage(float damage, TowerDescription.AttackType type)
    {
        switch(type)
        {
            case TowerDescription.AttackType.bullet: TakeDamage(damage * bulletResis); break;
            case TowerDescription.AttackType.explosive: TakeDamage(damage * explosiveResis); break;
            case TowerDescription.AttackType.flame: TakeDamage(damage * flameResis); break;
            case TowerDescription.AttackType.tesla: TakeDamage(damage * teslaResis); break;
            case TowerDescription.AttackType.nuclear: TakeDamage(damage * nuclearResis); break;
            case TowerDescription.AttackType.unknown: Debug.Log("Unknown damage taken."); TakeDamage(damage); break;
        }
    }

    void Die()
    {
        GameObject effect = Instantiate(explosionEffect, transform.position, transform.rotation);
        EnemyKilledEvent(this, new EnemyKilledEventArgs(this));
        Destroy(effect, 1.5f);
        Destroy(gameObject);
    }
}
