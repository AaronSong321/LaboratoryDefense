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
    //private GameObject target;
    private Transform target;
    public float lowestDistance;
    public float speed;
    public int ballisticVelocity;

    public ImmediateCube ic;
    public ExplosionCube ec;
    public ExplosionFiringCube efc;
    public FiringCube fc;
    public SlowCube sc;
    public StunCube tc;
    
    public TowerDescription.AttackType mainDamageType;
    public Turret.TurretName fatherTower;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    void Update()
    {
        if (target == null)
        {
            Die();
            return;
        }

        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        Vector3 dir = target.position - transform.position;
        if (dir.magnitude < lowestDistance)
        {
            //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            //target.GetComponent<Enemy>().TakeDamage(damage * player.perk.Attack_adj);
            if (ic != null && ic.enable)
            {
                target.GetComponent<Enemy>().TakeDamage(ic.damage, ic.attackType);
            }
            if (ec != null && ec.enable)
            {
                Collider[] collider = Physics.OverlapSphere(transform.position, ec.explosionRadius, 1 << LayerMask.NameToLayer("Enemy"));
                foreach (Collider col in collider)
                {
                    col.GetComponentInParent<Enemy>().TakeDamage(ec.damage, ec.attackType);
                }
            }
            if (fc != null && fc.enable)
            {
                target.GetComponent<Enemy>().TakeDamage(fc.damage, fc.attackType);
                target.GetComponent<Enemy>().TakeFiringDebuff(fc);
            }
            if (sc != null && sc.enable)
            {
                target.GetComponent<Enemy>().TakeDamage(sc.damage, sc.attackType);
                target.GetComponent<Enemy>().TakeSlowDebuff(sc);
            }
            if (tc != null && tc.enable)
            {
                target.GetComponent<Enemy>().TakeDamage(tc.damage, tc.attackType);
                target.GetComponent<Enemy>().TakeStunDebuff(tc);
            }
            Die();
        }
    }

    public void Die()
    {
        if (hitEffect != null)
        {
            GameObject hit = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(hit, 1);
        }
        if (particleEffect != null)
        {
            GameObject particle = Instantiate(particleEffect, transform.position, transform.rotation);
            Destroy(particle, 1);
        }
        Destroy(gameObject);
    }
}