using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTileButton : ActionButton
{
    private CommonTile commonTile;
    private int discount = 10;

    public override void Awake()
    {
        base.Awake();
        commonTile = (CommonTile)tile;
        if (commonTile.isOwned)
        {
            button.interactable = false;
        }
        if (player is Speculator) discount = 9;
    }
    public override string Name
    {
        get
        {
            return ("Buy Tile: " + commonTile.firmInfo.Cost/10*discount + "$");
        }
    }
    public override void OnClick()
    {
        if (checkBalance(commonTile.firmInfo.Cost/10*discount))
        {
            commonTile.Owner = player;
            player.AddTile(commonTile);
            button.interactable = false;
            player.changeBalanceDelegate(-commonTile.firmInfo.Cost/10*discount);
            Logs.PrintToLogs($"{player.Name} bought the: {commonTile.firmInfo.Name}");
        }
        else
        {
            Logs.PrintToLogs("Not enough money");
        }
        base.OnClick();
    }
}
