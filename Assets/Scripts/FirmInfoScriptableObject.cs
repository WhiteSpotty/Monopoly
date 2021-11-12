using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="FirmInfo", menuName = "", order = 1)]
public class FirmInfoScriptableObject : ScriptableObject
{
    [SerializeField]
    public string type;
    [SerializeField]
    public string name;
    [SerializeField]
    public int cost;
    [SerializeField]
    public Texture sprite;
}
