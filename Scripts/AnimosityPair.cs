using System;
using UnityEngine;

public class AnimosityPair: IComparable
{
    public readonly Turret turret;
    public readonly Enemy enemy;
    
    internal float timeSpent;
    internal float timeToPass;
    internal float damageOutput;
    internal float damageTaken;
    internal float damageOverflow;
    internal float slowEffect;
    internal float stunTimeExpectancy;
    internal float odometer;

    float timeAnimosity;
    float damageAnimosity;
    float overflowAnimosity;
    float animosity;

    static float enemyKilledPerTower = 3.3f;
    static float timeFactor = -0.2f;
    static float damageFactor = 1f;
    static float overflowFactor = -0.3f;

    static float mapCubeInterval = 125f;

    public AnimosityPair(Turret t, Enemy e)
    {
        turret = t;
        enemy = e;

        SimulateAttackProcess();
        CalculateAnimosisty();
    }

    void SimulateAttackProcess()
    {
        damageTaken = 0;
        damageOutput = 0;
        timeSpent = 0;
        slowEffect = 1;
        stunTimeExpectancy = 0;
        
        while (damageTaken < enemy.totalHp)
        {
            timeSpent += turret.attackRateTime;
            if (turret.ic != null && turret.ic.enable)
            {
                damageOutput += turret.ic.damage;
                damageTaken += turret.ic.damage * enemy.GetResis(turret.ic.attackType);
            }
            if (turret.ec != null && turret.ec.enable)
            {
                damageOutput += turret.ec.damage;
                damageTaken += turret.ec.damage * enemy.GetResis(turret.ec.attackType);
            }
            if (turret.fc != null && turret.fc.enable)
            {
                damageOutput += turret.ec.damage;
                damageTaken += turret.ec.damage * enemy.GetResis(turret.ec.attackType);
                if (turret.attackRateTime > turret.fc.duration)
                {
                    damageOutput += turret.fc.damagePerSecond * turret.fc.duration;
                    damageTaken += turret.fc.damagePerSecond * turret.fc.duration * enemy.GetResis(turret.fc.attackType);
                }
                else
                {
                    damageOutput += turret.fc.damagePerSecond * turret.attackRateTime;
                    damageTaken += turret.fc.damagePerSecond * turret.attackRateTime * enemy.GetResis(turret.fc.attackType);
                }
            }
            if (turret.sc != null && turret.sc.enable)
            {
                damageOutput += turret.sc.damage;
                damageTaken += turret.sc.damage * enemy.GetResis(turret.sc.attackType);
                if (turret.attackRateTime > turret.sc.slowDuration)
                    slowEffect = 1 + turret.sc.slowDuration / turret.attackRateTime * (turret.sc.slowSpeedPercent - 1);
                else slowEffect = turret.sc.slowSpeedPercent;
            }
            if (turret.tc != null && turret.tc.enable)
            {
                damageOutput += turret.tc.damage;
                damageTaken += turret.tc.damage * enemy.GetResis(turret.tc.attackType);
                stunTimeExpectancy += turret.tc.stunDuration * turret.tc.possibility;
                if (turret.tc.stunDuration > turret.attackRateTime) stunTimeExpectancy -= turret.tc.possibility * turret.tc.possibility * (turret.tc.stunDuration - turret.attackRateTime);
            }
        }

        damageOverflow = damageTaken - enemy.totalHp;

        odometer = 0;
        timeToPass = 0;
        for (float distance = 1.5f * mapCubeInterval; distance < turret.maxRange; distance += mapCubeInterval)
        {
            odometer += Single.Parse((2 * (Math.Pow(Pow(turret.maxRange, 2) - Pow(distance, 2), 0.5))).ToString());
            if (distance < turret.minRange)
                odometer -= Single.Parse((2*(Math.Pow(Pow(turret.maxRange,2)-Pow(turret.minRange,2),0.5))).ToString());
        }
        odometer *= 2;
        timeToPass = odometer / (enemy.speed * slowEffect) + stunTimeExpectancy;
    }

    void CalculateAnimosisty()
    {
        timeAnimosity = timeToPass / timeSpent;
        timeAnimosity = Single.Parse(Pow(1 / timeAnimosity - 1 / enemyKilledPerTower, 2).ToString()) / Single.Parse(Pow(1/(enemyKilledPerTower-1)-1/enemyKilledPerTower,2).ToString());
        damageAnimosity = damageTaken / damageOutput - 1;
        overflowAnimosity = damageOverflow / damageTaken;
        animosity = timeAnimosity * timeFactor + damageAnimosity * damageFactor + overflowAnimosity * overflowFactor;
    }

    public static bool operator>(AnimosityPair left, AnimosityPair right)
    {
        return left.animosity > right.animosity;
    }
    public static bool operator<(AnimosityPair left, AnimosityPair right)
    {
        return left.animosity < right.animosity;
    }

    static double Pow(float a, float b)
    {
        return Math.Pow(Double.Parse(a.ToString()), Double.Parse(b.ToString()));
    }

    int IComparable.CompareTo(object obj)
    {
        try
        {
            AnimosityPair pair = (AnimosityPair)obj;
            if (animosity > pair.animosity) return 1;
            else if (animosity == pair.animosity) return 0;
            else return -1;
        }
        catch(InvalidCastException e)
        {
            Debug.Log(e.StackTrace);
        }
        return -10;
    }
}