using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Text NameText;
    public Text BalanceText;
    public Text TraitText;
    public Text ColorText;

    private string _name;
    private int _balance;
    private string _trait;
    private string _color; // Color

    private void Awake()
    {
        NameText = transform.Find("StatName").GetComponent<Text>();
        BalanceText = transform.Find("StatBalance").GetComponent<Text>();
        TraitText = transform.Find("StatTrait").GetComponent<Text>();
        ColorText = transform.Find("StatColor").GetComponent<Text>();
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; NameText.text = _name; }
    }

    public int Balance
    {
        get { return _balance; }
        set { _balance = value;
            if (_balance % 1000000 == 0)
            {
                BalanceText.text = (value / 1000000).ToString() + "m";
            } else if (_balance % 1000 == 0)
            {
                BalanceText.text = (value / 1000).ToString() + "k";
            } else
            {
                BalanceText.text = value.ToString();
            }
            }
    }

    public string Trait
    {
        get { return _trait; }
        set { _trait = value; TraitText.text = value; }
    }

    public string Color
    {
        get { return _color; }
        set { _color = value; ColorText.text = value; }
    }
}
