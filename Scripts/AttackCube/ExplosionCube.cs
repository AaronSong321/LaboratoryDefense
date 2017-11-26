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
    public bool isTracing;
    public bool enable;
    public float explosionRadius;
    public float explosionAttenuation;
    public GameObject hitEffect;
    
    public void Generate(ExplosionCube source)
    {
        damage = source.damage;
        attackType = source.attackType;
        targetType = source.targetType;
        bulletPrefab = source.bulletPrefab;
        isTracing = source.isTracing;
        explosionRadius = source.explosionRadius;
        explosionAttenuation = source.explosionAttenuation;
        hitEffect = source.hitEffect;
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