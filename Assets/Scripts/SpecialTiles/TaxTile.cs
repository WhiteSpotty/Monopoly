using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxTile : Tile
{
    [Header("Set in Inspector")]
    public Texture sprite;

    public override string Name => "Tax department";

    public override List<EActions> getListActions()
    {
        List<EActions> res = new List<EActions>();

        res.Add(EActions.taxTile);

        return res;
    }

    private void Awake()
    {
        GetComponent<Renderer>().material.mainTexture = sprite;
    }
}
