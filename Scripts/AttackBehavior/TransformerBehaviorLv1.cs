using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class TransformerBehaviorLv1: AttackBehavior
{
    void Awake()
    {
        sc = new SlowCube();
        sc.damage = 35;
        sc.attackType = TowerDescription.AttackType.tesla;
        sc.slowDuration = 3;
        sc.slowRadius = 25;
        sc.slowSpeedPercent = 0.8;
    }
}

