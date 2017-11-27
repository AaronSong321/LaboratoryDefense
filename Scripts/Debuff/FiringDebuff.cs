using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class FiringDebuff: Debuff
{
    public TowerDescription.AttackType attackType;
    public float damagePerSecond;
    public float duration;
    public float timer;
    public GameObject effect;
    public GameObject particleEffect;

    public static bool operator>(FiringDebuff a, FiringDebuff b)
    {
        if (a.damagePerSecond * a.duration > b.damagePerSecond * b.duration) return true;
        else return false;
    }

    public static bool operator<(FiringDebuff a, FiringDebuff b)
    {
        if (a.damagePerSecond * a.duration < b.damagePerSecond * b.duration) return true;
        else return false;
    }
}