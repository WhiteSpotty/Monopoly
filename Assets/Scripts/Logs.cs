using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logs : MonoBehaviour
{
    //[Header("Set in Inspector")]
    //public GameObject TextLogPrefab;

    [Header("Set Dynamically")]
    public static GameObject content;

    private void Awake()
    {
        content = this.transform.Find("Viewport/Content").gameObject;
    }

    public static void PrintToLogs(string str)
    {
        GameObject go = (GameObject)Instantiate(Resources.Load("TextLog", typeof(GameObject)));
        go.transform.SetParent(content.transform);
        go.transform.localScale = Vector3.one;
        go.GetComponent<TextLog>().SetText(str);
    }
}
