using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int damage = 50;

    public float speed = 20;

    public GameObject explosionEffectPrefab;

    private float distanceArriveTarget = 1.2f;

    private Transform target;
    private Player player;
    public void SetTarget(Transform _target)
    {
        target = _target;
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
        if (dir.magnitude < distanceArriveTarget)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if (tag == "Missile")
            {
                float explosionRadius = 4f;
                Collider[] collider = Physics.OverlapSphere(transform.position, explosionRadius, 1 << LayerMask.NameToLayer("Enemy"));
                foreach (Collider col in collider)
                {
                    col.GetComponentInParent<Enemy>().TakeDamage(damage * player.perk.Attack_adj);
                }
            }
            else if (tag == "Continuous")
            {
                float firingDuration = 4f;
                float firingDamagePerSecond = 10000f;
                //target.GetComponent<Enemy>().TakeFiringDebuff(firingDamagePerSecond, firingDuration);
            }
            else
            {
                target.GetComponent<Enemy>().TakeDamage(damage * player.perk.Attack_adj);
            }
            Die();   
        }
    }

    void Die()
    {
        GameObject effect = Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
        Destroy(effect, 1);
        Destroy(this.gameObject);
    }

}
