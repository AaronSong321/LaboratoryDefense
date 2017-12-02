using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class SlowDebuff: Debuff
{
    public TowerDescription.AttackType attackType;
    public float slowPercent;
    public float duration;
    public float timer;
    public GameObject effect;
    public GameObject particleEffect;

    public static bool operator>(SlowDebuff a, SlowDebuff b)
    {
        if (a.duration * (1 - a.slowPercent) > b.duration * (1 - b.slowPercent)) return true;
        else return false;
    }

    public static bool operator<(SlowDebuff a, SlowDebuff b)
    {
        if (a.duration * (1 - a.slowPercent) < b.duration * (1 - b.slowPercent)) return true;
        else return false;
    }
}