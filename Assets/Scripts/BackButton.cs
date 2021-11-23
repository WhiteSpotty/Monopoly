using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public void BackControls()
    {
        GameObject panel = this.transform.root.Find("ControlsPanel").gameObject;
        panel.SetActive(false);
    }

    public void BackSettings()
    {
        GameObject panel = this.transform.root.Find("SettingsPanel").gameObject;
        panel.SetActive(false);
    }
}
