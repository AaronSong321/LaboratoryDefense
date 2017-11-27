using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class FiringCube
{
    public int damage;
    public TowerDescription.AttackType attackType;
    public TowerDescription.TargetType targetType;
    public GameObject bulletPrefab;
    public bool isTracing;
    public bool enable;
    public int duration;
    public int damagePerSecond;
    public float radius;
    public GameObject hitEffect;

    public void Generate(FiringCube source)
    {
        damage = source.damage;
        attackType = source.attackType;
        targetType = source.targetType;
        bulletPrefab = source.bulletPrefab;
        isTracing = source.isTracing;
        radius = source.radius;
        duration = source.duration;
        damagePerSecond = source.damagePerSecond;
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
