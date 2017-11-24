using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class BulletObj : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject hitEffect;
    public GameObject particleEffect;
    public GameObject target;
    public float lowestDistance;
    public float speed;
    public Tower fatherTower;
    public ImmediateCube ic;
    public ExplosionCube ec;
    public ExplosionFiringCube efc;
    public FiringCube fc;
    public SlowCube sc;
    public StunCube tc;

    public Player player;

    void Start()
    {
        
    }


    void Update()
    {
        if (target == null)
        {
            Die();
            return;
        }

        transform.LookAt(target.transform.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        Vector3 dir = target.transform.position - transform.position;
        if (dir.magnitude < lowestDistance)
        {
            //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            //target.GetComponent<Enemy>().TakeDamage(damage * player.perk.Attack_adj);
            if (ic != null && ic.enable)
            {
                target.GetComponent<Enemy>().TakeDamage(ic.damage);
            }
            if (ec != null && ec.enable)
            {
                Collider[] collider = Physics.OverlapSphere(transform.position, ec.explosionRadius, 1 << LayerMask.NameToLayer("Enemy"));
                foreach (Collider col in collider)
                {
                    col.GetComponentInParent<Enemy>().TakeDamage(ec.damage * player.perk.Attack_adj);
                }
            }
            Die();
        }
    }

    public void Die()
    {
        if (hitEffect != null)
        {
            GameObject hit = GameObject.Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(hit, 1);
        }
        if (particleEffect != null)
        {
            GameObject particle = GameObject.Instantiate(particleEffect, transform.position, transform.rotation);
            Destroy(particle, 1);
        }
        Destroy(this.gameObject);
    }
}