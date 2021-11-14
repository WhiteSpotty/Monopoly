using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankTile : Tile
{
    [Header("Set in Inspector")]
    public Texture sprite;

    public override string Name => "Bank";

    public override List<EActions> getListActions()
    {
        List<EActions> res = new List<EActions>();

        res.Add(EActions.bankTile);

        return res;
    }

    private void Awake()
    {
        GetComponent<Renderer>().material.mainTexture = sprite;
    }
}
