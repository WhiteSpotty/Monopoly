using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonTile : Tile
{

    public FirmInfoScriptableObject firmInfo;

    private Player _owner = null;
    private bool _mortgage = false;

    public override string Name
    {
        get { return firmInfo.name; }
    }

    public override List<EActions> getListActions()
    {
        List<EActions> res = new List<EActions>();

        res.Add(EActions.buyTile);

        return res;
    }

    private void Start()
    {
        GetComponent<Renderer>().material.mainTexture = firmInfo.sprite;
    }
    public Player setOwner
    {
        set
        {
            _owner = value;
        }
    }
    public bool isOwned
    {
        get
        {
            return _owner != null ? true : false;
        }
    }
    public bool isMortgage
    {
        get { return _mortgage; }
    }
}
