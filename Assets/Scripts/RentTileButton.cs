using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RentTileButton : ActionButton
{
    private CommonTile commonTile;

    public override void Awake()
    {
        base.Awake();
        commonTile = (CommonTile)tile;
        if (!commonTile.isOwned || commonTile.isMortgage)
        {
            button.interactable = false;
        }
    }
    public override string Name
    {
        get
        {
            if (!commonTile.isOwned || commonTile.isMortgage)
            {
                return "No pay rent";
            }
            else
            {
                return ($"Pay rent: {commonTile.firmInfo.Rent}$");
            }
        }
    }

    public override void OnClick()
    {
        if (checkBalance(commonTile.firmInfo.Rent))
        {
            Logs.PrintToLogs($"{player.Name} payed rent({ commonTile.firmInfo.Rent}$) to the player: {commonTile.Owner.Name}");
            button.interactable = false;
            player.changeBalanceDelegate(-commonTile.firmInfo.Rent);
        }
        else
        {
            Logs.PrintToLogs("Not enough money");
        }
    }
}
