using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class ExplosionCube
{
    public int damage;
    public TowerDescription.AttackType attackType;
    public TowerDescription.TargetType targetType;
    public GameObject bulletPrefab;
    public int ballisticVelocity;
    public bool isTracing;
    public bool enable;
    public GameObject target;
    public float explosionRadius;
    public float explosionAttenuation;
    public GameObject hitEffect;
    public GameObject particleEffect;
    
    public void Generate(ExplosionCube source)
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
        this.particleEffect = source.particleEffect;
    }

    public override String ToString()
    {
        StringBuilder ans = new StringBuilder();
        ans.Append("Explosion damage effect:\n");
        ans.Append(base.ToString());
        ans.Append("\tExplosion Radius: " + explosionRadius + "\n");
        ans.Append("\tExplosion Attenuation: " + explosionAttenuation + "\n");
        return ans.ToString();
    }
}