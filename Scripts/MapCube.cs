using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    [HideInInspector]
    public GameObject turretGo;
    [HideInInspector]
    public TurretData turretData;
    [HideInInspector]
    internal int currentLevel = 0;

    private GameManager gameManager;

    public GameObject buildEffect;
    private Renderer mapRenderer;
    private Color color;

    public class ReturnMoneyEventArgs: EventArgs
    {
        public int moneyReturn;
        public ReturnMoneyEventArgs(int money)
        {
            moneyReturn = money;
        }
    }
    public delegate void ReturnMoneyEventHandler(object sender, ReturnMoneyEventArgs e);
    public event ReturnMoneyEventHandler ReturnMoneyEvent;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        gameManager.SubscribeReturnMoney(this);

        mapRenderer = GetComponent<Renderer>();
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
                currentLevel = 2;
                break;
            case 2: Destroy(turretGo);
                turretGo = Instantiate(turretData.turretPrefab[2], transform.position, Quaternion.identity);
                tempEffect = Instantiate(buildEffect, transform.position, Quaternion.identity);
                Destroy(tempEffect, 1.5f);
                currentLevel = 3;
                break;
            case 3: return;
        }
    }
    
    public void DestroyTurret()
    {
        switch (currentLevel)
        {
            case 0: break;
            case 1: ReturnMoneyEvent(this, new ReturnMoneyEventArgs(turretData.cost[0] / 2)); break;
            case 2: ReturnMoneyEvent(this, new ReturnMoneyEventArgs((turretData.cost[0] + turretData.cost[1]) / 2)); break;
            case 3: ReturnMoneyEvent(this, new ReturnMoneyEventArgs((turretData.cost[0] + turretData.cost[1] + turretData.cost[2]) / 2)); break;
        }
        Destroy(turretGo);
        currentLevel = 0;
        turretGo = null;
        turretData = null;
        GameObject effect = Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }
    
    void OnMouseEnter()
    {
        if (turretGo == null && EventSystem.current.IsPointerOverGameObject()==false)
        {
            color = Color.green;
            color.a /= 4;
            mapRenderer.material.color = color;
        }
    }
    void OnMouseExit()
    {
        color = Color.white;
        color.a /= 4;
        mapRenderer.material.color = color;
    }
}
