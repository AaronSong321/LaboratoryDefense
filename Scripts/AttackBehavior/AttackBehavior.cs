using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class AttackBehavior
{
    public ImmediateCube ic;
    public ExplosionCube ec;
    public ExplosionFiringCube efc;
    public FiringCube fc;
    public SlowCube sc;
    public StunCube tc;
}
