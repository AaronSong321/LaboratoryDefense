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
    public Tower fatherTower;
    public ImmediateCube ic;
    public ExplosionCube ec;
    public ExplosionFiringCube efc;
    public FiringCube fc;
    public SlowCube sc;
    public StunCube tc;

    public void ApplyFatherTower(Tower tower)
    {
        if (tower == null)
        {
            Debug.Log("Father tower (MachineGunLv1 expected) does not exist when creating a bullet (MachineGunBulletLv1).");
            return;
        }
        fatherTower = tower;
        if (tower.attackBehavior.ic == null)
        {
            Debug.Log("Father tower (MachineGunLv1) does not have an existing reference to ic (ImmediateCube expected).");
            return;
        }
        ic.Generate(tower.attackBehavior.ic);
    }

    void Start()
    {
        ApplyFatherTower(fatherTower);
    }


    void Update()
    {
        if (target == null)
        {
            Die();
            return;
        }

        transform.LookAt(target.transform.position);
        transform.Translate(Vector3.forward * ic.ballisticVelocity * Time.deltaTime);

        Vector3 dir = target.transform.position - transform.position;
        if (dir.magnitude < lowestDistance)
        {
            //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            //target.GetComponent<Enemy>().TakeDamage(damage * player.perk.Attack_adj);
            target.GetComponent<Enemy>().TakeDamage(ic.damage);
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