using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceTile : Tile
{
    [Header("Set in Inspector")]
    public Texture sprite;

    public override string Name => "Chance";

    public override List<EActions> getListActions()
    {
        List<EActions> res = new List<EActions>();

        return res;
    }

    private void Start()
    {
        GetComponent<Renderer>().material.mainTexture = sprite;
    }
}
