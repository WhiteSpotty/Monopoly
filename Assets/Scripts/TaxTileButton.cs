using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxTileButton : ActionButton
{
    private int _taxPerFirm = 5000;
    public override void Awake()
    {
        base.Awake();
        if (player.payedTax || player.Property.Count == 0)
        {
            button.interactable = false;
        }
    }

    public override string Name
    {
        get
        {
            if (button.interactable)
            {
                return ($"Need to pay {player.Property.Count * _taxPerFirm}");
            }
            else
            {
                return ("No need pay tax");
            }
        }
    }

    public override void OnClick()
    {
        if (checkBalance(player.Property.Count * _taxPerFirm))
        {
            Logs.PrintToLogs($"{player.Name} payed tax");
            button.interactable = false;
            player.changeBalanceDelegate(-player.Property.Count * _taxPerFirm);
            player.payedTax = true;
        }
        else
        {
            Logs.PrintToLogs("Not enough money");
        }
        base.OnClick();
    }
}
