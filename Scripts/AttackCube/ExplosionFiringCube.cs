using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class ExplosionFiringCube: AttackCube
{
    public GameObject target;
    public int explosionRadius;
    public double explosionAttenuation;
    public GameObject hitEffect;
    public GameObject explosionParticleEffect;

    public int firingRadius;
    public int duration;
    public int damagePerSecond;
    public GameObject firingParticleEffect;

    public ExplosionFiringCube(ExplosionFiringCube source)
    {
        this.damage = source.damage;
        this.attackType = source.attackType;
        this.targetType = source.targetType;
        this.bulletPrefab = source.bulletPrefab;
        this.ballisticVelocity = source.ballisticVelocity;
        this.isTracing = source.isTracing;
        this.target = source.target;
        this.explosionRadius = source.explosionRadius;
        this.explosionAttenuation = source.explosionAttenuation;
        this.hitEffect = source.hitEffect;
        this.explosionParticleEffect = source.explosionParticleEffect;

        this.firingRadius = source.firingRadius;
        this.duration = source.duration;
        this.damagePerSecond = source.damagePerSecond;
        this.firingParticleEffect = source.firingParticleEffect;
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