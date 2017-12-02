using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretData
{
    public GameObject[] turretPrefab;
    internal class LevelInfo
    {
        internal int cost;
        internal float attackSpeed;
        internal float minRange = 0;
        internal float maxRange = 240;
        internal ImmediateCube ic;
        internal ExplosionCube ec;
        internal FiringCube fc;
        internal SlowCube sc;
        internal StunCube tc;
    }

    internal LevelInfo level1, level2, level3;
}