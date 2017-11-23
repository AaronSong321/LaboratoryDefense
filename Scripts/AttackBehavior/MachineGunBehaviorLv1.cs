using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class MachineGunBehavior1: AttackBehavior
{
    void Awake()
    {
        ic = new ImmediateCube();
        ic.attackType = TowerDescription.AttackType.bullet;
        ic.damage = 36;
        ic.ballisticVelocity = 1000;
        ic.targetType = TowerDescription.TargetType.ground;
    }
}

