using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class ExplosionFiringCube
{
    public GameObject target;
    public float explosionRadius;
    public float explosionAttenuation;
    public GameObject hitEffect;
    public GameObject explosionParticleEffect;
    public int damage;
    public TowerDescription.AttackType attackType;
    public TowerDescription.TargetType targetType;
    public GameObject bulletPrefab;
    public bool isTracing;
    public bool enable;
    public int firingRadius;
    public int duration;
    public int damagePerSecond;
    public GameObject firingParticleEffect;

    public void Generate(ExplosionFiringCube source)
    {
        damage = source.damage;
        attackType = source.attackType;
        targetType = source.targetType;
        bulletPrefab = source.bulletPrefab;
        isTracing = source.isTracing;
        target = source.target;
        explosionRadius = source.explosionRadius;
        explosionAttenuation = source.explosionAttenuation;
        hitEffect = source.hitEffect;
        explosionParticleEffect = source.explosionParticleEffect;

        firingRadius = source.firingRadius;
        duration = source.duration;
        damagePerSecond = source.damagePerSecond;
        firingParticleEffect = source.firingParticleEffect;
    }

    public override string ToString()
    {
        StringBuilder ans = new StringBuilder();
        ans.Append("Range Firing damage effect:\n");
        ans.Append(base.ToString());
        ans.Append("\tExplosion Radius: " + explosionRadius + "\n");
        ans.Append("\tExplosion Attenuation: " + explosionAttenuation + "\n");
        ans.Append("\tFiring Radius: " + firingRadius + "\n");
        ans.Append("\tFiring Damage Per Second: " + damagePerSecond + "\n");
        ans.Append("\tFiring Duration: " + duration + "\n");
        return base.ToString();
    }
}