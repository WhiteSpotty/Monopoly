using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedeemTileButton : ActionButton
{
    public override void Awake()
    {
        base.Awake();
    }

    public override string Name
    {
        get
        {
            return ("Redeem a tile");
        }
    }

    public override void OnClick()
    {
        GameObject go = (GameObject)Instantiate(Resources.Load("SelectPropertyCanvas", typeof(GameObject)));
        go.GetComponent<SelectProperty>().confirmedDelegate += Confirmed;
        go.GetComponent<SelectProperty>().mortgagedProperty(player);

        base.OnClick();
    }

    public void Confirmed(Tile selectedTile)
    {
        CommonTile commonTile = (CommonTile)selectedTile;
        commonTile.setMortgage = false;
        player.changeBalanceDelegate(-commonTile.firmInfo.UnpledgedAmount);
        Logs.PrintToLogs($"{player.Name} redeemed the tile: {commonTile.Name}");
    }
}
