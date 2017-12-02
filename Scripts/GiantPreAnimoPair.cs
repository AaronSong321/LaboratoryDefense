using System;
using System.Collections.Generic;
using System.IO;


public class GiantPreAnimoPair: IComparable
{
    internal readonly Turret turret;
    internal readonly Enemy enemy;
    internal readonly int animosity;
    
    public GiantPreAnimoPair(Turret t, Enemy e)
    {
        turret = t;
        enemy = e;
        animosity = dictionary[t.turretName][e.enemyName];
    }

    internal static Dictionary<Turret.TurretName, Dictionary<Enemy.EnemyName, int>> dictionary;
    internal static void ReadAnimosityFromCsv(string fileName = "GiantPriAnimosity.csv")
    {
        string[] fileData = File.ReadAllLines(Settings.GeneratePath(fileName));
        dictionary = new Dictionary<Turret.TurretName, Dictionary<Enemy.EnemyName, int>>();
        for (int i = 1; i < fileData.Length; i++)
        {
            string[] line = fileData[i].Split(',');
            Dictionary<Enemy.EnemyName, int> animoOfTurret = new Dictionary<Enemy.EnemyName, int>();
            for (int j = 1; j < line.Length; j++)
            {
                animoOfTurret.Add((Enemy.EnemyName)(j - 1), Int32.Parse(line[j]));
            }
            dictionary.Add((Turret.TurretName)(i - 1), animoOfTurret);
        }
    }

    public int CompareTo(object obj)
    {
        GiantPreAnimoPair other = (GiantPreAnimoPair)obj;
        return animosity - other.animosity;
    }

    public static bool operator>(GiantPreAnimoPair left, GiantPreAnimoPair right)
    {
        return left.animosity > right.animosity;
    }
    public static bool operator<(GiantPreAnimoPair left, GiantPreAnimoPair right)
    {
        return left.animosity < right.animosity;
    }
}