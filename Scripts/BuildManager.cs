using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {
    public TurretData STTurretData;
    public TurretData MGTurretData;
    public TurretData PBTurretData;
    public TurretData CHTurretData;
    public TurretData SPTurretData;
    private TurretData selectedTurretData;

    ToggleGroup TGTurrets;
    Toggle TMG;
    Toggle TST;
    Toggle TPB;
    Toggle TCH;
    Toggle TSP;

    private MapCube selectedMapCube;
    private Player player;
    public Animator moneyAnimator;
    public GameObject upgradeCanvas;
    private Animator upgradeCanvasAnimator;
    public Button buttonUpgrade;
    //Text XWave;
    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        TGTurrets = GameObject.Find("Canvas/TurretSwitch").GetComponent<ToggleGroup>();
        TMG = GameObject.Find("Canvas/TurretSwitch/TMG").GetComponent<Toggle>();
        TST = GameObject.Find("Canvas/TurretSwitch/TST").GetComponent<Toggle>();
        TPB = GameObject.Find("Canvas/TurretSwitch/TPB").GetComponent<Toggle>();
        TCH = GameObject.Find("Canvas/TurretSwitch/TCH").GetComponent<Toggle>();
        TSP = GameObject.Find("Canvas/TurretSwitch/TSP").GetComponent<Toggle>();
        //XWave = GameObject.Find("Canvas/XWave").GetComponent<Text>();
    }
    void Start()
    {
        upgradeCanvasAnimator = upgradeCanvas.GetComponent<Animator>();

        TGTurrets.SetAllTogglesOff();
    }

    void Update()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()==false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray,out hit, 1000, LayerMask.GetMask("MapCube"));
                if (isCollider)
                {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();
                    if (selectedTurretData != null && mapCube.turretGo == null)
                    {
                        if (player.Money > selectedTurretData.cost[0])
                        {
                            player.ChangeMoney(-selectedTurretData.cost[0]);
                            mapCube.BuildTurret(selectedTurretData);
                        }
                        else
                        {
                            moneyAnimator.SetTrigger("Flicker");
                        }
                    }
                    else if (mapCube.turretGo != null)
                    {
                        if (mapCube == selectedMapCube && upgradeCanvas.activeInHierarchy)
                        {
                            StartCoroutine(HideUpgradeUI());
                        }
                        else
                        {
                            ShowUpgradeUI(mapCube.transform.position, mapCube.currentLevel);
                        }
                        selectedMapCube = mapCube;
                    }

                }
            }
        }
    }

    /*
    public void OnTurretSelected()
    {
        Debug.Log("Selected tower:" + selectedTurretData);
        if (selectedTurretData == null) return;
        if (TMG.isOn) selectedTurretData = MGTurretData;
        if (TST.isOn) selectedTurretData = STTurretData;
        if (TPB.isOn) selectedTurretData = PBTurretData;
        if (TCH.isOn) selectedTurretData = CHTurretData;
        if (TSP.isOn) selectedTurretData = SPTurretData;
    }
    */

    public void OnPBSelected(bool isOn)
    {
        if (isOn) selectedTurretData = PBTurretData;
    }
    public void OnSTSelected(bool isOn)
    {
        if (isOn) selectedTurretData = STTurretData;
    }
    public void OnMGSelected(bool isOn)
    {
        if (isOn) selectedTurretData = MGTurretData;
    }
    public void OnCHSelected(bool isOn)
    {
        if (isOn) selectedTurretData = CHTurretData;
    }
    public void OnSPSelected(bool isOn)
    {
        if (isOn) selectedTurretData = SPTurretData;
    }

    void ShowUpgradeUI(Vector3 pos, int mapCurrentLevel)
    {
        StopCoroutine("HideUpgradeUI");
        upgradeCanvas.SetActive(false);
        upgradeCanvas.SetActive(true);
        upgradeCanvas.transform.position = pos;
        if (mapCurrentLevel == 3) 
            buttonUpgrade.interactable = false;
    }

    IEnumerator HideUpgradeUI()
    {
        upgradeCanvasAnimator.SetTrigger("Hide");
        yield return new WaitForSeconds(0.8f);
        upgradeCanvas.SetActive(false);
    }

    public void OnUpgradeButtonDown()
    {
        if (selectedMapCube.turretData != null)
        {
            switch(selectedMapCube.currentLevel)
            {
                case 0:
                case 3:
                    break;
                case 1:
                    if (player.Money >= selectedMapCube.turretData.cost[1])
                    {
                        player.ChangeMoney(-selectedMapCube.turretData.cost[1]);
                        selectedMapCube.UpgradeTurret();
                    }
                    else
                    {
                        moneyAnimator.SetTrigger("Flicker");
                    }
                    break;
                case 2:
                    if (player.Money >= selectedMapCube.turretData.cost[2])
                    {
                        player.ChangeMoney(-selectedMapCube.turretData.cost[2]);
                        selectedMapCube.UpgradeTurret();
                    }
                    else
                    {
                        moneyAnimator.SetTrigger("Flicker");
                    }
                    break;
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
