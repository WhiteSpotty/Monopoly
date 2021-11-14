using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllGetBonus : MillionariesLifeCard
{
    private string _story;
    private int _amount;
    public AllGetBonus(string story, int amount)
    {
        _story = story;
        _amount = amount;
    }
    public override void Do()
    {
        Logs.PrintToLogs($"{_story} {_amount}");
        foreach (Player p in GroupPlayer.S.players)
        {
            p.changeBalanceDelegate(_amount);
        }
    }
}
