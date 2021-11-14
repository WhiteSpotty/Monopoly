using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayerGetBonus : MillionariesLifeCard
{
    private string _story;
    private int _amount;
    public CurrentPlayerGetBonus(string story, int amount)
    {
        _story = story;
        _amount = amount;
    }
    public override void Do()
    {
        Logs.PrintToLogs($"{_story} {_amount}");
        GroupPlayer.S.ActivePlayer.changeBalanceDelegate(_amount);
    }
}
