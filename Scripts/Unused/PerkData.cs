using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PerkData
{
    public float AttackRateTime_adj;
    public float Attack_adj;
    public float mobspeed_adj;
    public float money_adj;
    public PerkType type;
}
public enum PerkType
{
    Shooter,
    Explosive,
    Slimeball
}