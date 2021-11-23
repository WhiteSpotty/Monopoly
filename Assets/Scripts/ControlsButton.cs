using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsButton : MonoBehaviour
{
    public GameObject panel;

    public void Controls()
    {
        panel.SetActive(true);
    }
}
