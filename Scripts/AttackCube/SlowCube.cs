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
    public int slowDuration;
    public float slowSpeedPercent;
    public GameObject hitEffect;

    public void Generate(SlowCube source)
    {
        damage = source.damage;
        attackType = source.attackType;
        targetType = source.targetType;
        bulletPrefab = source.bulletPrefab;
        isTracing = source.isTracing;
        hitEffect = source.hitEffect;
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
        return base.ToString();
    }
}
