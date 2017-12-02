using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class StunDebuff: Debuff
{
    public TowerDescription.AttackType attackType;
    public float duration;
    public float timer;
    public GameObject effect;
    public GameObject particleEffect;

    public static bool operator>(StunDebuff a, StunDebuff b)
    {
        if (a.duration > b.duration) return true;
        else return false;
    }
    public static bool operator<(StunDebuff a, StunDebuff b)
    {
        if (a.duration < b.duration) return true;
        else return false;
    }
}