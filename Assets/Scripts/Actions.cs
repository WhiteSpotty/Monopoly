using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum EActions
{
    //self-Actions
    rollDice,

    //CommonTile Actions
    buyTile,
    rentTile,
    buildHouseTile,
    sellHouseTile,
    mortgageTile,
    redeemTile,

    //SpecialTile Actions
    chanceTile,
}

public class Actions : MonoBehaviour
{
    public static Actions S;

    [Header("Set in Inspector")]
    public GameObject actionButtonPrefab;
    public GameObject actionButtonsPanel;

    private void Awake()
    {
        S = this;
    }

    public void showPossibleActions(List<EActions> actions)
    {
        foreach (EActions action in actions)
        {
            showAction(action);
        }
    }


    public void showTilePossibleActions()
    {
        List<EActions> actions = GroupPlayer.S.ActivePlayer.getTile().getListActions();
        Actions.S.showPossibleActions(actions);
    }
    public void showAction(EActions action)
    {
        GameObject go = Instantiate<GameObject>(actionButtonPrefab);
        Text text = go.GetComponentInChildren<Text>();
        switch (action)
        {
            case EActions.rollDice:
                go.AddComponent<RollDiceButton>();
                text.text = go.GetComponent<RollDiceButton>().Name;
                break;
            case EActions.buyTile:
                go.AddComponent<BuyTileButton>();
                text.text = go.GetComponent<BuyTileButton>().Name;
                break;
            case EActions.rentTile:
                go.AddComponent<RentTileButton>();
                text.text = go.GetComponent<RentTileButton>().Name;
                break;
            default:
                Logs.PrintToLogs("Not implemented yet");
                break;
        }
        go.transform.SetParent(actionButtonsPanel.transform);
        go.transform.localScale = Vector3.one;
    }

    
    public void Clear()
    {
        foreach(Transform child in actionButtonsPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
