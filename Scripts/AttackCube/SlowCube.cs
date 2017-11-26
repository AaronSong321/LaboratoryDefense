using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class SlowCube
{
    public int damage;
    public TowerDescription.AttackType attackType;
    public TowerDescription.TargetType targetType;
    public GameObject bulletPrefab;
    public bool isTracing;
    public bool enable;
    public int slowRadius;
    public int slowDuration;
    public double slowSpeedPercent;
    public GameObject hitEffect;

    public void Generate(SlowCube source)
    {
        damage = source.damage;
        attackType = source.attackType;
        targetType = source.targetType;
        bulletPrefab = source.bulletPrefab;
        isTracing = source.isTracing;
        hitEffect = source.hitEffect;
        slowRadius = source.slowRadius;
        slowDuration = source.slowDuration;
        slowSpeedPercent = source.slowSpeedPercent;
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
