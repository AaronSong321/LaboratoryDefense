using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class SlowDebuff: Debuff
{
    public float slowPercent;
    public float duration;
    public float timer;
    public GameObject effect;
    public GameObject particleEffect;
}