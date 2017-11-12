using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float speed = 10;
    public float hp = 150;
    private float totalHp;
    public GameObject explosionEffect;
    private Slider hpSlider;

    public int damage = 50;
    public int enemyMoney = 100;
    private Player player;
    public bool isAirunit = false;
    public NavMeshAgent agent;
    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
	void Start () {
        totalHp = hp;
        hpSlider = GetComponentInChildren<Slider>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed * player.perk.mobspeed_adj;
        agent.destination = GameObject.Find("End").GetComponent<Transform>().position;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}


    void Move()
    {
        agent.destination = GameObject.Find("End").GetComponent<Transform>().position;
        /*if (index > positions.Length - 1) return;
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
        if (Vector3.Distance(positions[index].position, transform.position) < 0.2f)
        {
            index++;
        }*/
        if (!agent.pathPending && agent.remainingDistance != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance <= agent.stoppingDistance)
        {
            ReachDestination();
        }
    }
    //达到终点
    void ReachDestination()
    {
        player.Playerhp -= damage;
        GameObject.Destroy(this.gameObject);
    }


    void OnDestroy()
    {
        EnemySpawner.CountEnemyAlive--;
    }

    public void TakeDamage(float damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        hpSlider.value = (float)hp / totalHp;
        if (hp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffect, transform.position, transform.rotation);
        player.ChangeMoney((int)(enemyMoney*player.perk.money_adj));
        Destroy(effect, 1.5f);
        Destroy(this.gameObject);
    }

}
