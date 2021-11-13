using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RentTileButton : ActionButton
{
    private CommonTile tile = (CommonTile)GroupPlayer.S.ActivePlayer.getTile();
    private Player player = GroupPlayer.S.ActivePlayer;

    public override string Name
    {
        get
        {
            if (!tile.isOwned || tile.isMortgage)
            {
                return "No pay rent";
            }
            else
            {
                return ($"Pay rent: {tile.firmInfo.Rent}$");
            }
        }
    }

    public override void Start()
    {
        base.Start();
        tile = (CommonTile)GroupPlayer.S.ActivePlayer.getTile();
        player = GroupPlayer.S.ActivePlayer;
        if (!tile.isOwned || tile.isMortgage)
        {
            button.interactable = false;
        }
    }

    public override void OnClick()
    {
        if (checkBalane())
        {
            Logs.PrintToLogs($"{player.Name} payed rent({ tile.firmInfo.Rent}$) to the player: {tile.Owner.Name}");
            button.interactable = false;
        }
        else
        {
            Logs.PrintToLogs("Not enough money");
        }
    }

    public bool checkBalane()
    {
        return player.Balance >= tile.firmInfo.Rent ? true : false;
    }
}
