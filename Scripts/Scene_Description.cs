using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Description : MonoBehaviour {
    //TowerDescription[] td;
    EnemyDescription elfin, crawler, zombie, thirsty, butcher, unicorn, desolator, manmoth, tank, dragon;
    void Awake()
    {
        //TowerDescription.ReadFromXml(td, "tower.xml");
        elfin = EnemyDescription.LinqToXml("Elfin", "enemy_hypo.xml");
        crawler = EnemyDescription.LinqToXml("Crawler", "enemy_hypo.xml");
        zombie = EnemyDescription.LinqToXml("Zombie", "enemy_hypo.xml");
        thirsty = EnemyDescription.LinqToXml("Thirsty", "enemy_hypo.xml");
        butcher = EnemyDescription.LinqToXml("Butcher", "enemy_hypo.xml");
        unicorn = EnemyDescription.LinqToXml("Unicorn", "enemy_hypo.xml");
        desolator = EnemyDescription.LinqToXml("Desolator", "enemy_hypo.xml");
        manmoth = EnemyDescription.LinqToXml("Manmoth", "enemy_hypo.xml");
        tank = EnemyDescription.LinqToXml("Tank", "enemy_hypo.xml");
        dragon = EnemyDescription.LinqToXml("Dragon", "enemy_hypo.xml");
    }

    public void OnClick_Back()
    {
        SceneManager.LoadScene("Welcome");
    }
}
