using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueSliderNumberOfPlayers : MonoBehaviour
{
    public Slider slider;
    private Text _value;

    public void Start()
    {
        _value = this.GetComponent<Text>();
        slider.value = SettingsInfo.numberOfPlayers;
        _value.text = SettingsInfo.numberOfPlayers.ToString();
    }
    public void setValue()
    {
        _value.text = slider.value.ToString();
        SettingsInfo.numberOfPlayers = ((int)slider.value);
    }
}
