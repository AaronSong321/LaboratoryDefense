using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    private int money;
    private int playerhp;
    public Text moneyText;
    public PerkData perk;
    public int Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
        }

    }
    public int Playerhp
    {
        get
        {
            return playerhp;
        }
        set
        {
            playerhp = value;
        }

    }
    void Awake ()
    {
        Money = 1000;
        Playerhp = 100;
        moneyText = GameObject.Find("Canvas/Money").GetComponent<Text>();
        moneyText.text = "¥" + Money;
    }
	void Start () {
		
	}
	
	void Update () {
        if (Playerhp <= 0)
            GameManager.Instance.Failed();
	}
    public void ChangeMoney(int change)
    {
        Money += change;
        moneyText.text = "¥" + Money;
    }
}
