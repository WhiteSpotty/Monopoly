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
        if (!commonTile.isOwned || commonTile.Owner== player || commonTile.isMortgage || player.payedTax)
        {
            button.interactable = false;
        }
    }
    public override string Name
    {
        get
        {
            if (!button.interactable)
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
            player.payedTax = true;
            player.changeBalanceDelegate(-commonTile.firmInfo.Rent);
            commonTile.Owner.changeBalanceDelegate(commonTile.firmInfo.Rent);
        }
        else
        {
            Logs.PrintToLogs("Not enough money");
        }
        base.OnClick();
    }
}
