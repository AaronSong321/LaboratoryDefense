using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    internal int money;
    internal int playerhp;
    public Text moneyText;
    public PerkData perk;

    void Awake ()
    {
        money = 600;
        playerhp = 30;
        moneyText = GameObject.Find("Canvas/Money").GetComponent<Text>();
        moneyText.text = "¥" + money;
    }
	void Start ()
    {

	}
	
	void Update ()
    { 
	}
    public void ChangeMoney(int change)
    {
        money += change;
        moneyText.text = "¥" + money;
    }
}
