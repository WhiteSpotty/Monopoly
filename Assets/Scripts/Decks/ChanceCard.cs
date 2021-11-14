using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceCard : Card
{
    private string _story;
    private bool _operation;
    private int _amount;

    public ChanceCard(string story, bool operation, int amount)
    {
        _story = story;
        _operation = operation;
        _amount = amount;
    }

    public override string Name => "ChanceCard";

    public override void Do()
    {
        Logs.PrintToLogs(_story + " " + _amount);
        GroupPlayer.S.ActivePlayer.changeBalanceDelegate((_operation ? 1 : -1) *  _amount);
    }
}
