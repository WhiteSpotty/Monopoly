using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollDiceButton : ActionButton
{
    private int Dice1;
    private int Dice2;

    public override void Awake()
    {
        base.Awake();
        if (player.isRolled)
        {
            button.interactable = false;
        }
    }

    public override string Name
    {
        get
        {
            return "Roll Dice";
        }
    }

    public override void OnClick()
    {
        roll();
        player.isRolled = true;
        int ind = player.PosIndex + getTotal();
        player.MoveTo(player.PosLayer, ind);
        //player.transform.position = Board.S.tilePos[(player.PosLayer, player.PosIndex)].Item2;
        getLastRollString();

        this.gameObject.GetComponent<Button>().interactable = false;

        base.OnClick();
    }

    public void roll()
    {
        Dice1 = Random.Range(1, 6);
        Dice2 = Random.Range(1, 6);
    }
    public bool checkDouble()
    {
        return Dice1 == Dice2 ? true : false;
    }
    public int getTotal()
    {
        return 1;// Dice1 + Dice2;
    }
    public void getLastRollString()
    {
        Logs.PrintToLogs($"Dice1 : {Dice1}, Dice2 : {Dice2}");
    }
}
