using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildHouseTileButton : ActionButton
{
    private CommonTile commonTile;

    public override void Awake()
    {
        base.Awake();
        commonTile = (CommonTile)tile;
        if (!HaveAllFirmByType(commonTile.firmInfo.Type))
        {
            button.interactable = false;
        }
    }
    public override string Name
    {
        get
        {
            return ("Build House for: " + commonTile.firmInfo.HouseCost + "$");
        }
    }
    public override void OnClick()
    {
        if (checkBalance(commonTile.firmInfo.HouseCost)) {
            if (commonTile.CurrHouses < CommonTile.maxHouses)
            {
                commonTile.CurrHouses++;
                player.changeBalanceDelegate(-commonTile.firmInfo.HouseCost);
                Logs.PrintToLogs($"{player.Name} build house to tile: {commonTile.firmInfo.name}");
            }
            else
            {
                Logs.PrintToLogs("You already have the maximum number of houses");
            }
        }
        else
        {
            Logs.PrintToLogs("Not enough money");
        }
        base.OnClick();
    }

    public bool HaveAllFirmByType(EFirmType type)
    {
        foreach (CommonTile tile in Board.S.tileByFirmType[type])
        {
            if (!tile.isOwned || tile.Owner != player) return false;
        }
        return true;
    }
}