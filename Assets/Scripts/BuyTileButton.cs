using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTileButton : ActionButton
{
    private CommonTile tile = (CommonTile)GroupPlayer.S.ActivePlayer.getTile();
    private Player player = GroupPlayer.S.ActivePlayer;
    public override string Name
    {
        get
        {
            return ("Buy Tile: " + tile.firmInfo.Cost +"$");
        }
    }
    public override void Start()
    {
        base.Start();
        tile = (CommonTile)GroupPlayer.S.ActivePlayer.getTile();
        player = GroupPlayer.S.ActivePlayer;
        if (tile.isOwned)
        {
            button.interactable = false;
        }
    }
    public override void OnClick()
    {
        if (checkBalane())
        {
            tile.Owner = player;
            Logs.PrintToLogs($"{player.Name} bought the tile: {tile.firmInfo.name}");
            button.interactable = false;
        } 
        else
        {
            Logs.PrintToLogs("Not enough money");
        }
    }

    public bool checkBalane()
    {
        return player.Balance >= tile.firmInfo.Cost ? true : false;
    }

}
