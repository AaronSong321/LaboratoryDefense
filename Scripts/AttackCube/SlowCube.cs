using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class SlowCube: AttackCube
{
    public GameObject target;
    public int slowRadius;
    public int slowDuration;
    public double slowSpeedPercent;
    public GameObject hitEffect;
    public GameObject particleEffect;

    public void Generate(SlowCube source)
    {
        this.damage = source.damage;
        this.attackType = source.attackType;
        this.targetType = source.targetType;
        this.bulletPrefab = source.bulletPrefab;
        this.ballisticVelocity = source.ballisticVelocity;
        this.isTracing = source.isTracing;
        this.target = source.target;
        this.hitEffect = source.hitEffect;
        this.slowRadius = source.slowRadius;
        this.slowDuration = source.slowDuration;
        this.slowSpeedPercent = source.slowSpeedPercent;
        this.particleEffect = source.particleEffect;
    }

    public override string ToString()
    {
        StringBuilder ans = new StringBuilder();
        ans.Append("Slow Effect:\n");
        ans.Append(base.ToString());
        ans.Append("\tPercent: " + slowSpeedPercent + "\n");
        ans.Append("\tDuration: " + slowDuration + "\n");
        ans.Append("\tRadius: " + slowRadius + "\n");
        return base.ToString();
    }
}
