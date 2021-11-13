using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollDiceButton : ActionButton
{
    private int Dice1;
    private int Dice2;

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
        Player current = GroupPlayer.S.ActivePlayer;
        current.PosIndex += getTotal();
        current.transform.position = Board.S.tilePos[(current.PosLayer, current.PosIndex)].Item2;
        getLastRollString();

        this.gameObject.GetComponent<Button>().interactable = false;
        EndTurnButton.S.button.interactable = true;



        Actions.S.showTilePossibleActions(); //buytile upgradetile morgagetile etc
    }

    public override void Start()
    {
        base.Start();
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
        return 4;
        //return Dice1 + Dice2;
    }
    public void getLastRollString()
    {
        Logs.PrintToLogs($"Roll is Dice1 : {Dice1}, Dice2 : {Dice2}");
    }
}
