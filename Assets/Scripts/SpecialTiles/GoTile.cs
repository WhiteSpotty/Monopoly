using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTile : Tile
{
    [Header("Set in Inspector")]
    public Texture sprite;

    public override string Name => "GO";

    public override List<EActions> getListActions()
    {
        List<EActions> res = new List<EActions>();

        res.Add(EActions.goTile);

        return res;
    }

    private void Awake()
    {
        GetComponent<Renderer>().material.mainTexture = sprite;
    }
}
