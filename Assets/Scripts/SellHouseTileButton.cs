using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellHouseTileButton : ActionButton
{
    private CommonTile commonTile;
    public override void Awake()
    {
        base.Awake();
        commonTile = (CommonTile)tile;
        if (commonTile.CurrHouses == 0)
        {
            button.interactable = false;
        }
    }
    public override string Name
    {
        get
        {
            if (commonTile.CurrHouses == 0)
            {
                return ("Nothing to sell");
            }
            else
            {
                return ("Sell House for: " + commonTile.firmInfo.HouseCost + "$");
            }
        }
    }
    public override void OnClick()
    {
        if (commonTile.isOwned && commonTile.Owner == player)
        {
            if (commonTile.CurrHouses > 0)
            {
                commonTile.CurrHouses--;
                player.changeBalanceDelegate(commonTile.firmInfo.HouseCost);
                Logs.PrintToLogs($"{player.Name} sell House at {commonTile.firmInfo.Name}");
            }
        } else {
            Logs.PrintToLogs("Firm not yours");
        }
        base.OnClick();
    }
}
