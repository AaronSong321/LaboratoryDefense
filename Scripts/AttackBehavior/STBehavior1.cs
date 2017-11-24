using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class STBehavior1: AttackBehavior
{
    void Awake()
    {
        ec = new ExplosionCube();
        ec.damage = 70;
        ec.explosionAttenuation = 1;
        ec.explosionRadius = 80;
        ec.attackType = TowerDescription.AttackType.explosive;
        ec.targetType = TowerDescription.TargetType.ground;
    }
}