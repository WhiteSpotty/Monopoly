using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonTile : Tile
{

    public FirmInfoScriptableObject firmInfo;
    public static int maxHouses = 4;

    private Player _owner = null;
    private bool _mortgage = false;
    private int _currHouses = 0;

    public override string Name
    {
        get { return firmInfo.Name; }
    }

    public override List<EActions> getListActions()
    {
        List<EActions> res = new List<EActions>();

        res.Add(EActions.buyTile);
        res.Add(EActions.rentTile);
        res.Add(EActions.buildHouseTile);
        res.Add(EActions.sellHouseTile);

        return res;
    }

    private void Start()
    {
        GetComponent<Renderer>().material.mainTexture = firmInfo.sprite;
    }
    public Player Owner
    {
        get
        {
            return  _owner;
        }
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
    public bool setMortgage
    {
        set { _mortgage = value; }
    }
    public int CurrHouses
    {
        get { return _currHouses; }
        set { _currHouses = value; }
    }
}
