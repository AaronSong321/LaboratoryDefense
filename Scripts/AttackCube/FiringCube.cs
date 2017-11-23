using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class FiringCube: AttackCube
{
    public GameObject target;
    public int duration;
    public int damagePerSecond;
    public int radius;
    public GameObject hitEffect;
    public GameObject particleEffect;

    public FiringCube(FiringCube source)
    {
        this.damage = source.damage;
        this.attackType = source.attackType;
        this.targetType = source.targetType;
        this.bulletPrefab = source.bulletPrefab;
        this.ballisticVelocity = source.ballisticVelocity;
        this.isTracing = source.isTracing;
        this.target = source.target;
        this.radius = source.radius;
        this.duration = source.duration;
        this.damagePerSecond = source.damagePerSecond;
        this.particleEffect = source.particleEffect;
    }

    public override string ToString()
    {
        StringBuilder ans = new StringBuilder();
        ans.Append("Firing Effect:\n");
        ans.Append("\tDirect Damage: " + damage + "\n");
        ans.Append("\tAttack Type: " + attackType + "\n");
        ans.Append("\tTarget Type: " + targetType + "\n");
        ans.Append("\tTracing:" + (isTracing ? "Yes" : "No") + "\n");
        ans.Append("\tDamage Per Second: " + damagePerSecond + "\n");
        ans.Append("\tRadius: " + radius + "\n");
        ans.Append("\tDuraion: " + duration + "\n");
        return ans.ToString();
    }
}
