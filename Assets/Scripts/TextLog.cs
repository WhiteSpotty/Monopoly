using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLog : MonoBehaviour
{
    
    public void SetText(string str)
    {
        this.GetComponent<Text>().text = ">"+str;
    }
}
