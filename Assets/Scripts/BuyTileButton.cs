using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTileButton : ActionButton
{
    private CommonTile commonTile;
    
    public override void Awake()
    {
        base.Awake();
        commonTile = (CommonTile)tile;
        if (commonTile.isOwned)
        {
            button.interactable = false;
        }
    }
    public override string Name
    {
        get
        {
            return ("Buy Tile: " + commonTile.firmInfo.Cost + "$");
        }
    }
    public override void OnClick()
    {
        if (checkBalance(commonTile.firmInfo.Cost))
        {
            commonTile.Owner = player;
            player.AddTile(commonTile);
            button.interactable = false;
            player.changeBalanceDelegate(-commonTile.firmInfo.Cost);
            Logs.PrintToLogs($"{player.Name} bought the: {commonTile.firmInfo.Name}");
        }
        else
        {
            Logs.PrintToLogs("Not enough money");
        }
        base.OnClick();
    }
}
