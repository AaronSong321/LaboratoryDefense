using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {

    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData standardTurretData;
    private TurretData selectedTurretData;

    public Tower ST;
    public Tower TF;
    public Tower selectedTower;
    
    private MapCube selectedMapCube;
    private Player player;
    public Animator moneyAnimator;
    public GameObject upgradeCanvas;
    private Animator upgradeCanvasAnimator;
    public Button buttonUpgrade;

    ToggleGroup TGTowers;
    Toggle TSharpnelThrower;
    Toggle TTransFormer;

    void Awake()
    {
        TGTowers = GameObject.Find("Canvas/TurretSwitch").GetComponent<ToggleGroup>();
        TSharpnelThrower = GameObject.Find("Canvas/TurretSwitch/TSharpnelThrower").GetComponent<Toggle>();
        TTransFormer = GameObject.Find("Canvas/TurretSwitch/TTransFormer").GetComponent<Toggle>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        selectedTower = null;
    }
    void Start()
    {
        upgradeCanvasAnimator = upgradeCanvas.GetComponent<Animator>();
    }

    void Update()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()==false)
            {
                //开发炮台的建造
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray,out hit, 1000, LayerMask.GetMask("MapCube"));
                if (isCollider)
                {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();
                    if (selectedTurretData != null && mapCube.turretGo == null)
                    {
                        //可以创建 
                        if (player.Money > selectedTurretData.cost)
                        {
                            player.ChangeMoney(-selectedTurretData.cost);
                            mapCube.BuildTurret(selectedTurretData);
                        }
                        else
                        {
                            //提示钱不够
                            moneyAnimator.SetTrigger("Flicker");
                        }
                    }
                    else if (selectedTower != null && mapCube.turretGo == null)
                    {
                        if (player.Money > selectedTower.money)
                        {
                            player.ChangeMoney(-selectedTower.money);
                            mapCube.BuildTower(selectedTower);
                        }
                    }
                    else if (mapCube.turretGo != null)
                    {
                        
                        // 升级处理
                        
                        //if (mapCube.isUpgraded)
                        //{
                        //    ShowUpgradeUI(mapCube.transform.position, true);
                        //}
                        //else
                        //{
                        //    ShowUpgradeUI(mapCube.transform.position, false);
                        //}
                        if (mapCube == selectedMapCube && upgradeCanvas.activeInHierarchy)
                        {
                            StartCoroutine(HideUpgradeUI());
                        }
                        else
                        {
                            ShowUpgradeUI(mapCube.transform.position, mapCube.isUpgraded);
                        }
                        selectedMapCube = mapCube;
                    }

                }
            }
        }
    }

    public void OnTowerSelected()
    {
        if (TSharpnelThrower.isOn)
        {
            selectedTower = ST;
            selectedTurretData = null;
        }
        if (TTransFormer.isOn) selectedTower = TF;
        Debug.Log("selectedTower = " + selectedTower);
        Debug.Log("selectedTurretData = " + selectedTurretData);
    }

    public void OnLaserSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = laserTurretData;
            selectedTower = null;
        }
        Debug.Log("selectedTower = " + selectedTower);
        Debug.Log("selectedTurretData = " + selectedTurretData);
    }

    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = missileTurretData;
            selectedTower = null;
        }
        Debug.Log("selectedTower = " + selectedTower);
        Debug.Log("selectedTurretData = " + selectedTurretData);
    }
    public void OnStandardSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = standardTurretData;
            selectedTower = null;
        }
        Debug.Log("selectedTower = " + selectedTower);
        Debug.Log("selectedTurretData = " + selectedTurretData);
    }

    void ShowUpgradeUI(Vector3 pos, bool isDisableUpgrade=false)
    {
        StopCoroutine("HideUpgradeUI");
        upgradeCanvas.SetActive(false);
        upgradeCanvas.SetActive(true);
        upgradeCanvas.transform.position = pos;
        buttonUpgrade.interactable = !isDisableUpgrade;
    }

    IEnumerator HideUpgradeUI()
    {
        upgradeCanvasAnimator.SetTrigger("Hide");
        //upgradeCanvas.SetActive(false);
        yield return new WaitForSeconds(0.8f);
        upgradeCanvas.SetActive(false);
    }

    public void OnUpgradeButtonDown()
    {
        if (selectedMapCube.turretData != null)
        {
            if (player.Money >= selectedMapCube.turretData.costUpgraded)
            {
                player.ChangeMoney(-selectedMapCube.turretData.costUpgraded);
                selectedMapCube.UpgradeTurret();
            }
            else
            {
                moneyAnimator.SetTrigger("Flicker");
            }
        }
        else
        {
            if (player.Money >= selectedMapCube.tower.money)
            {
                player.ChangeMoney(-selectedMapCube.tower.money);
                selectedMapCube.UpgradeTower();
            }
            else
            {
                moneyAnimator.SetTrigger("Flicker");
            }
        }

        StartCoroutine(HideUpgradeUI());
    }
    public void OnDestroyButtonDown()
    {
        selectedMapCube.DestroyTurret();
        StartCoroutine(HideUpgradeUI());
    }
     
}
