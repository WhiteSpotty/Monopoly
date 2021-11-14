using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    protected Tile tile;
    protected Player player;
    protected Button button;

    public virtual void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        tile = GroupPlayer.S.ActivePlayer.getTile();
        player = GroupPlayer.S.ActivePlayer;
    }
    public virtual string Name { get { return "NOT SET"; } }
    public virtual void OnClick() { Actions.S.showPossibleActions(player.possibleActions()); }

    public virtual bool checkBalance(int value)
    {
        return player.Balance >= value ? true : false;
    }
}