using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum EActions
{
    rollDice,
    buyTile,
    buildHouseTile,
    sellHouseTile,
    mortgageTile,
    redeemTile
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
       
        switch (action)
        {
            case EActions.rollDice:
                {
                    GameObject go = Instantiate<GameObject>(actionButtonPrefab);
                    go.AddComponent<RollDiceButton>();
                    go.GetComponentInChildren<Text>().text = go.GetComponent<RollDiceButton>().Name;
                    go.transform.SetParent(actionButtonsPanel.transform);
                    go.transform.localScale = Vector3.one;
                    break;
                }
            case EActions.buyTile:
                {
                    GameObject go = Instantiate<GameObject>(actionButtonPrefab);
                    go.AddComponent<BuyTileButton>();
                    go.GetComponentInChildren<Text>().text = go.GetComponent<BuyTileButton>().Name;
                    go.transform.SetParent(actionButtonsPanel.transform);
                    go.transform.localScale = Vector3.one;
                    break;
                }
            default:
                Logs.PrintToLogs("Not implemented yet");
                break;
        }
    }

    public void Clear()
    {
        foreach(Transform child in actionButtonsPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
