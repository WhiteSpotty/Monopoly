using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTile : Tile
{
    [Header("Set in Inspector")]
    public Texture sprite;

    public override string Name => "Transition Tile";

    public override List<EActions> getListActions()
    {
        List<EActions> res = new List<EActions>();

        res.Add(EActions.transitionTile);

        return res;
    }

    protected void Awake()
    {
        GetComponent<Renderer>().material.mainTexture = sprite;
    }
}
