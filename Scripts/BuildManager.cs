using System;
using System.Collections;
using System.Xml;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    TurretData selectedTurretData;
    public TurretData[] turrets;
    GameObject TGTurrets;

    private MapCube selectedMapCube;
    public Animator moneyAnimator;
    public GameObject upgradeCanvas;
    public Button buttonUpgrade;
    private GameManager gameManager;

    public class SpendMoneyEventArgs: EventArgs
    {
        public int moneySpent;
        public SpendMoneyEventArgs(int moneySpent)
        {
            this.moneySpent = moneySpent;
        }
    }
    public delegate void SpendMoneyEventHandler(object sender, SpendMoneyEventArgs e);
    public event SpendMoneyEventHandler SpendMoneyEvent;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        TGTurrets = GameObject.Find("Canvas/TurretSwitch");

        TGTurrets.GetComponent<ToggleGroup>().SetAllTogglesOff();
        ReadTurretsFromXml("Turrets.xml");
    }
    void Start()
    {
        gameManager.SubscribeSpendMoney(this);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("MapCube"));
                if (isCollider)
                {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();
                    if (selectedTurretData != null && mapCube.turretGo == null)
                    {
                        if (gameManager.money >= selectedTurretData.level1.cost)
                        {
                            SpendMoneyEvent(this, new SpendMoneyEventArgs(selectedTurretData.level1.cost));
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
                            upgradeCanvas.SetActive(false);
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

    
    public void OnMGSelected()
    {
        selectedTurretData = turrets[(int)Turret.TurretName.MG];
    }
    public void OnCHSelected()
    {
        selectedTurretData = turrets[(int)Turret.TurretName.CH];
    }
    public void OnPBSelected()
    {
        selectedTurretData = turrets[(int)Turret.TurretName.PB];
    }
    public void OnSPSelected()
    {
        selectedTurretData = turrets[(int)Turret.TurretName.SP];
    }
    public void OnSTSelected()
    {
        selectedTurretData = turrets[(int)Turret.TurretName.ST];
    }
    public void OnRLSelected()
    {
        selectedTurretData = turrets[(int)Turret.TurretName.RL];
    }
    public void OnPMSelected()
    {
        selectedTurretData = turrets[(int)Turret.TurretName.PM];
    }
    public void OnPSSelected()
    {
        selectedTurretData = turrets[(int)Turret.TurretName.PS];
    }
    public void OnTFSelected()
    {
        selectedTurretData = turrets[(int)Turret.TurretName.TF];
    }
    public void OnTDSelected()
    {
        selectedTurretData = turrets[(int)Turret.TurretName.TD];
    }
    
    

    void ShowUpgradeUI(Vector3 pos, int mapCurrentLevel)
    {
        upgradeCanvas.SetActive(false);
        upgradeCanvas.SetActive(true);
        upgradeCanvas.transform.position = pos;
        if (mapCurrentLevel == 3)
            buttonUpgrade.gameObject.SetActive(false);
        else
            buttonUpgrade.gameObject.SetActive(true);
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
                    if (gameManager.money >= selectedMapCube.turretData.level1.cost)
                    {
                        SpendMoneyEvent(this, new SpendMoneyEventArgs(selectedMapCube.turretData.level2.cost));
                        selectedMapCube.UpgradeTurret();
                    }
                    else
                    {
                        moneyAnimator.SetTrigger("Flicker");
                    }
                    break;
                case 2:
                    if (gameManager.money >= selectedMapCube.turretData.level2.cost)
                    {
                        SpendMoneyEvent(this, new SpendMoneyEventArgs(selectedMapCube.turretData.level2.cost));
                        selectedMapCube.UpgradeTurret();
                    }
                    else
                    {
                        moneyAnimator.SetTrigger("Flicker");
                    }
                    break;
            }
        }
        upgradeCanvas.SetActive(false);
    }
    public void OnDestroyButtonDown()
    {
        selectedMapCube.DestroyTurret();
        upgradeCanvas.SetActive(false);
    }

    void ReadTurretsFromXml(string fileName = "Turrets.xml")
    {
        string filePath = Settings.GeneratePath(fileName);
        XmlReaderSettings settings = new XmlReaderSettings
        {
            IgnoreComments = true
        };

        XmlReader turretReader = XmlReader.Create(filePath, settings);
        XmlDocument turretDocument = new XmlDocument();
        turretDocument.Load(turretReader);

        XmlNode turretRootNode = turretDocument.SelectSingleNode("Turrets");
        XmlNodeList turretLists = turretRootNode.ChildNodes;
        
        for (int i = 0; i < turretLists.Count; i++)
        {
            XmlElement lv1 = (XmlElement)turretLists[i].ChildNodes.Item(0);
            XmlElement lv2 = (XmlElement)turretLists[i].ChildNodes.Item(1);
            XmlElement lv3 = (XmlElement)turretLists[i].ChildNodes.Item(2);
            turrets[i].level1 = new TurretData.LevelInfo
            {
                cost = Int32.Parse(lv1.GetAttribute("cost")),
                attackSpeed = Int32.Parse(lv1.GetAttribute("attackSpeed")),
                minRange = Int32.Parse(lv1.GetAttribute("minRange")),
                maxRange = Int32.Parse(lv1.GetAttribute("maxRange"))
            };
            turrets[i].level2 = new TurretData.LevelInfo
            {
                cost = Int32.Parse(lv2.GetAttribute("cost")),
                attackSpeed = Int32.Parse(lv2.GetAttribute("attackSpeed")),
                minRange = Int32.Parse(lv2.GetAttribute("minRange")),
                maxRange = Int32.Parse(lv2.GetAttribute("maxRange"))
            };
            turrets[i].level3 = new TurretData.LevelInfo
            {
                cost = Int32.Parse(lv3.GetAttribute("cost")),
                attackSpeed = Int32.Parse(lv3.GetAttribute("attackSpeed")),
                minRange = Int32.Parse(lv3.GetAttribute("minRange")),
                maxRange = Int32.Parse(lv3.GetAttribute("maxRange"))
            };
        }
    }
}
