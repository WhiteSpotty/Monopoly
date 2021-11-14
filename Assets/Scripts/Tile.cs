using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Tile : MonoBehaviour
{
    public abstract string Name { get; }

    public abstract List<EActions> getListActions();
    
}
