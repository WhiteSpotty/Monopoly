using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{

    public GameObject panel;
    public void Settings()
    {
        panel.SetActive(true);
    }
}
