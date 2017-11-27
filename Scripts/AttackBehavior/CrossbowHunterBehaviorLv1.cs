using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class CrossbowHunterBehaviorLv1: AttackBehavior
{
    void Awake()
    {
        tc = new StunCube();
        tc.damage = 110;
        tc.stunDuration = 0.5;
        tc.possibility = 0.07;
        tc.ballisticVelocity = 850;
        tc.attackType = TowerDescription.AttackType.bullet;
        tc.targetType = TowerDescription.TargetType.ground_air;
    }
}
