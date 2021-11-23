using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTileButton : ActionButton
{
    public override void Awake()
    {
        base.Awake();
    }
    public override string Name
    {
        get
        {
            return "Change the layer";
        }
    }
    public override void OnClick()
    {
        GameObject go = (GameObject)Instantiate(Resources.Load("SelectLayerCanvas", typeof(GameObject)));
        go.GetComponent<SelectLayer>().confirmedDelegate += Confirmed;
        go.GetComponent<SelectLayer>().Create();
        
        base.OnClick();
    }

    public void Confirmed(ENameLayer layer)
    {
        TransitionTile tile = (TransitionTile)player.getTile();
        if (tile is SouthTransitionTile)
        {
            player.MoveTo(Board.S.southTransitions[(int)layer].Item2.Item1, Board.S.southTransitions[(int)layer].Item2.Item2);
        }
        else if (tile is WestTransitionTile)
        {
            player.MoveTo(Board.S.westTransitions[(int)layer].Item2.Item1, Board.S.westTransitions[(int)layer].Item2.Item2);

        }
        else if (tile is NorthTransitionTile)
        {
            player.MoveTo(Board.S.northTransitions[(int)layer].Item2.Item1, Board.S.northTransitions[(int)layer].Item2.Item2);

        }
        else if (tile is EastTransitionTile)
        {
            player.MoveTo(Board.S.eastTransitions[(int)layer].Item2.Item1, Board.S.eastTransitions[(int)layer].Item2.Item2);
        }
        else
        {
            Logs.PrintToLogs("Transition UNsuccessful");
            return;
        }
        Logs.PrintToLogs("Transtion successful");
    }
}
