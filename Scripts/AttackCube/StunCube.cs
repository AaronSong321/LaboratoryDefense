using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class StunCube
{
    public int damage;
    public TowerDescription.AttackType attackType;
    public TowerDescription.TargetType targetType;
    public GameObject bulletPrefab;
    public int ballisticVelocity;
    public bool isTracing;
    public bool enable;
    public GameObject target;
    public double stunDuration;
    public double possibility;
    public GameObject hitEffect;
    public GameObject particleEffect;

    public void Generate(StunCube source)
    {
        this.damage = source.damage;
        this.attackType = source.attackType;
        this.targetType = source.targetType;
        this.bulletPrefab = source.bulletPrefab;
        this.ballisticVelocity = source.ballisticVelocity;
        this.isTracing = source.isTracing;
        this.target = source.target;
        this.hitEffect = source.hitEffect;
        this.stunDuration = source.stunDuration;
        this.possibility = source.possibility;
        this.particleEffect = source.particleEffect;
    }

    public override string ToString()
    {
        StringBuilder ans = new StringBuilder();
        ans.Append("Stun Effect:\n");
        ans.Append(base.ToString());
        ans.Append("\tDuration:" + stunDuration + "\n");
        ans.Append("\tPossibility: " + possibility + "\n");
        return base.ToString();
    }
}