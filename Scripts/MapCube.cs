using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour {
    [HideInInspector]
    public GameObject turretGo;//保存当前cube身上的炮台
    [HideInInspector]
    public TurretData turretData;
    //[HideInInspector]
    //public GameObject towerGo;
    [HideInInspector]
    internal int currentLevel = 0;

    public GameObject buildEffect;
    private Player player;
    private Renderer renderer;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Start()
    {
        renderer = GetComponent<Renderer>();
        currentLevel = 0;
    }

    public void BuildTurret(TurretData turretData)
    {
        this.turretData = turretData;
        currentLevel = 1;
        turretGo = Instantiate(turretData.turretPrefab[0], transform.position, Quaternion.identity);
        GameObject effect = Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }

    public void UpgradeTurret()
    {
        GameObject tempEffect;
        switch (currentLevel)
        {
            case 0: return;
            case 1: Destroy(turretGo);
                turretGo = Instantiate(turretData.turretPrefab[1], transform.position, Quaternion.identity);
                tempEffect = Instantiate(buildEffect, transform.position, Quaternion.identity);
                Destroy(tempEffect, 1.5f);
                break;
            case 2: Destroy(turretGo);
                turretGo = Instantiate(turretData.turretPrefab[2], transform.position, Quaternion.identity);
                tempEffect = Instantiate(buildEffect, transform.position, Quaternion.identity);
                Destroy(tempEffect, 1.5f);
                break;
            case 3: return;
        }
    }
    
    public void DestroyTurret()
    {
        switch (currentLevel)
        {
            case 0: break;
            case 1: player.ChangeMoney(turretData.cost[0] / 2); break;
            case 2: player.ChangeMoney((turretData.cost[0] + turretData.cost[1]) / 2); break;
            case 3: player.ChangeMoney((turretData.cost[0] + turretData.cost[1] + turretData.cost[2]) / 2); break;
        }
        Destroy(turretGo);
        currentLevel = 0;
        turretGo = null;
        turretData = null;
        GameObject effect = Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }
    /*
    public void BuildTower(Tower tower)
    {
        this.tower = tower;
        isUpgraded = false;
        turretGo = Instantiate(tower.towerPrefabLv1, transform.position, Quaternion.identity);
    }
    public void UpgradeTower()
    {
        switch(tower.level)
        {
            case 1: Destroy(tower);
                turretGo = Instantiate(tower.towerPrefabLv2, transform.position, Quaternion.identity);
                break;
            case 2: Destroy(tower);
                turretGo = Instantiate(tower.towerPrefabLv3, transform.position, Quaternion.identity);
                break;
            case 3: return;
        }
    }
    public void DestroyTower()
    {
        switch (tower.level)
        {
            case 1: player.ChangeMoney(tower.money);
                break;
            case 2: player.ChangeMoney(tower.money);
                break;
            case 3:player.ChangeMoney(tower.money * 2);
                break;
        }
        Destroy(turretGo);
        turretGo = null;
        tower = null;
    }
    */
    void OnMouseEnter()
    {

        if (turretGo == null && EventSystem.current.IsPointerOverGameObject()==false)
        {
            renderer.material.color = Color.red;
        }
    }
    void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
