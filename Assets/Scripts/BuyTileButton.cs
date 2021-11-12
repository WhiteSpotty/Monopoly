using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTileButton : ActionButton
{
    private CommonTile tile;
    private Player player;
    public override string Name
    {
        get
        {
            return ("Buy Tile: " + ((CommonTile)GroupPlayer.S.ActivePlayer.getTile().GetComponent<Tile>()).firmInfo.cost +"$");
        }
    }
    public override void Start()
    {
        base.Start();
        tile = (CommonTile)GroupPlayer.S.ActivePlayer.getTile();
        player = GroupPlayer.S.ActivePlayer;
        if (tile.isOwned)
        {
            Logs.PrintToLogs(GroupPlayer.S.ActivePlayer.Name);
            button.interactable = false;
        }
    }
    public override void OnClick()
    {
        //UpdateVariables();
        if (checkBalane())
        {
            tile.setOwner = player;
            Logs.PrintToLogs($"{player.Name} bought the tile: {tile.firmInfo.name}");
            button.interactable = false;
        } 
        else
        {
            Logs.PrintToLogs("Not enough money");
        }
    }
    //private void  UpdateVariables()
    //{
    //    tile = (CommonTile)GroupPlayer.S.ActivePlayer.getTile().GetComponent<Tile>();
    //    player = GroupPlayer.S.ActivePlayer;
    //}
    public bool checkBalane()
    {
        return player.Balance >= tile.firmInfo.cost ? true : false;
    }

}
