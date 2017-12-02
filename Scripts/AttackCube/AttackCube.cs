using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class AttackCube
{
    public int damage;
    public TowerDescription.AttackType attackType;
    public TowerDescription.TargetType targetType;
    public GameObject bulletPrefab;
    public int ballisticVelocity;
    public bool isTracing;

    public override string ToString()
    {
        StringBuilder ans = new StringBuilder();
        ans.Append("\tDirect Damage: " + damage + "\n");
        ans.Append("\tAttack Type: " + attackType + "\n");
        ans.Append("\tTarget Type: " + targetType + "\n");
        ans.Append("\tTracing:" + (isTracing ? "Yes" : "No") + "\n");
        return ans.ToString();
    }

    /*
    public AttackCube()
    {
        damage = 36;
        attackType = TowerDescription.AttackType.bullet;
        targetType = TowerDescription.TargetType.ground;
        bulletPrefab = null;
        ballisticVelocity = 1000;
        isTracing = true;
    }
    
    public AttackCube(AttackCube source)
    {
        this.damage = source.damage;
        this.attackType = source.attackType;
        this.targetType = source.targetType;
        this.bulletPrefab = source.bulletPrefab;
        this.ballisticVelocity = source.ballisticVelocity;
        this.isTracing = source.isTracing;
    }
    */
}

