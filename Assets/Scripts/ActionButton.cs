using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    public virtual string Name { get { return "NOT SET"; } }
    public virtual void OnClick() { Logs.PrintToLogs("Not assign function"); }

    protected Button button;

    public virtual void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

}