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
    public bool isTracing;
    public bool enable;
    public float stunDuration;
    public float possibility;
    public GameObject hitEffect;

    public void Generate(StunCube source)
    {
        damage = source.damage;
        attackType = source.attackType;
        targetType = source.targetType;
        bulletPrefab = source.bulletPrefab;
        isTracing = source.isTracing;
        hitEffect = source.hitEffect;
        stunDuration = source.stunDuration;
        possibility = source.possibility;
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