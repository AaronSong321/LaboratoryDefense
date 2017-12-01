using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class WaveGenerator
{
    public enum Difficulty { hypothetical, rival, chanllenging, desperate}

    public GameObject[] enemyPrefabs;

    public static void Reshuffle<T>(List<T> list)
    {
        int num = list.Count;
        List<T> answer = new List<T>();
        System.Random c = new System.Random();
        for (int i = 0; i < num; i++)
        {
            int random_index = c.Next(0, list.Count);
            answer.Add(list[random_index]);
            list.RemoveAt(random_index);
        }
        for (int i = 0; i < num; i++)
        {
            list.Add(answer[i]);
        }
    }

    public List<GameObject>[] GenerateAllWaves(int count, Difficulty dif = Difficulty.hypothetical)
    {
        List<GameObject>[] waves = new List<GameObject>[count];
        for (int i = 0; i < count; i++)
        {
            waves[i] = new List<GameObject>();
            int[] thisWav = GenerateWave(i, Difficulty.hypothetical);
            for (int j = 0; j < thisWav.Length; j++)
            {
                for (int k = 0; k < thisWav[j]; k++)
                    waves[i].Add(enemyPrefabs[j]);
            }
            Reshuffle(waves[i]);
        }
        return waves;
    }

    public int[] GenerateWave(int no, Difficulty dif = Difficulty.hypothetical)
    {
        int[] answer = new int[enemyPrefabs.Length];
        if (dif == Difficulty.rival)
        {
            switch(no)
            {
                case 0: answer[0] = 20; break;
                case 1: answer[0] = 10;answer[1] = 5;answer[2] = 7; break;
                case 2: answer[0] = 8;answer[1] = 6;answer[2] = 3;answer[3] = 8;break;
                case 3: answer[0] = 6;answer[1] = 7;answer[2] = 3;answer[4] = 5;answer[5] = 5;answer[6] = 5; break;
                case 4: answer[0] = 5;answer[2] = 4;answer[3] = 5;answer[5] = 8;answer[7] = 2;break;
                case 5: answer[0] = 3;answer[2] = 8;answer[4] = 10;answer[6] = 5;answer[7] = 1;answer[8] = 3;break;
                case 6: answer[0] = 3;answer[2] = 8;answer[3] = 10;answer[5] = 10;answer[6] = 7;answer[8] = 2;answer[9] = 3;break;
                default: answer[4] = 8;answer[7] = 2;answer[8] = 5;answer[9] = 4;break;
            }
        }
        if (dif == Difficulty.hypothetical)
        {
            switch (no)
            {
                case 0: answer[0] = 15; break;//
                case 1: answer[0] = 8; answer[1] = 5; answer[2] = 5; break;
                case 2: answer[0] = 8; answer[1] = 6; answer[2] = 3; answer[3] = 5; break;
                case 3: answer[0] = 6; answer[1] = 3; answer[2] = 3; answer[4] = 3; answer[5] = 5; answer[6] = 3; break;
                case 4: answer[0] = 5; answer[2] = 4; answer[3] = 5; answer[5] = 6; answer[7] = 1; break;
                case 5: answer[0] = 3; answer[2] = 8; answer[4] = 8; answer[6] = 5; answer[7] = 1; answer[8] = 1; break;
                case 6: answer[0] = 3; answer[2] = 8; answer[3] = 8; answer[5] = 10; answer[6] = 7; answer[8] = 2; answer[9] = 2; break;
                default: answer[4] = 8; answer[7] = 2; answer[8] = 4; answer[9] = 2; break;
            }
        }
        return answer;
    }
}
