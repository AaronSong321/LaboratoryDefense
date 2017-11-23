using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class FiringDebuff: Debuff
{
    public int damagePerSecond;
    public float duration;
    public float timer;
    public GameObject effect;
    public GameObject particleEffect;
}