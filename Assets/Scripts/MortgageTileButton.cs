using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortgageTileButton : ActionButton
{
    public override void Awake()
    {
        base.Awake();
    }

    public override string Name
    {
        get
        {
            return ("Mortgage a tile");
        }
    }

    public override void OnClick()
    {
        GameObject go = (GameObject)Instantiate(Resources.Load("SelectPropertyCanvas", typeof(GameObject)));
        go.GetComponent<SelectProperty>().confirmedDelegate += Confirmed;
        go.GetComponent<SelectProperty>().notMortgagedProperty(player);


        base.OnClick();
    }

    public void Confirmed(Tile selectedTile)
    {
        CommonTile commonTile = (CommonTile)selectedTile;
        commonTile.setMortgage = true;
        player.changeBalanceDelegate(commonTile.firmInfo.PledgedAmount);
        Logs.PrintToLogs($"{player.Name} mortgaged the tile: {commonTile.Name}");
    }
}
