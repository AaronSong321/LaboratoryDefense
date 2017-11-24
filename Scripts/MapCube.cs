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
    [HideInInspector]
    public Tower tower;
    //[HideInInspector]
    //public GameObject towerGo;
    [HideInInspector]
    public bool isUpgraded = false;

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
    }

    public void BuildTurret(TurretData turretData)
    {
        this.turretData = turretData;
        isUpgraded = false;
        turretGo = GameObject.Instantiate(turretData.turretPrefab, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }

    public void UpgradeTurret()
    {
        if(isUpgraded==true)return;

        Destroy(turretGo);
        isUpgraded = true;
        turretGo = GameObject.Instantiate(turretData.turretUpgradedPrefab, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }
    
    public void DestroyTurret()
    {
        if (turretData == null) DestroyTower();
        if (isUpgraded)
        {
            player.ChangeMoney((turretData.cost + turretData.costUpgraded) / 2);
        }
        else
        {
            player.ChangeMoney(turretData.cost/2);
        }
        Destroy(turretGo);
        isUpgraded = false;
        turretGo = null;
        turretData=null;
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }

    public void BuildTower(Tower tower)
    {
        this.tower = tower;
        isUpgraded = false;
        turretGo = GameObject.Instantiate(tower.towerPrefabLv1, transform.position, Quaternion.identity);
    }
    public void UpgradeTower()
    {
        switch(this.tower.level)
        {
            case 1: Destroy(tower);
                turretGo = GameObject.Instantiate(tower.towerPrefabLv2, transform.position, Quaternion.identity);
                break;
            case 2: Destroy(tower);
                turretGo = GameObject.Instantiate(tower.towerPrefabLv3, transform.position, Quaternion.identity);
                break;
            case 3: return;
        }
    }
    public void DestroyTower()
    {
        switch (this.tower.level)
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
