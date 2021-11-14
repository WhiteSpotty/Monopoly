using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum EActions
{
    //self-Actions
    rollDice,
    mortgageTile,
    redeemTile,

    //CommonTile Actions
    buyTile,
    rentTile,
    buildHouseTile,
    sellHouseTile,
    //???аукцион???

    //SpecialTile Actions

    //Europe
    goTile,
    chanceTile,
    eventTile,
    transitionTile,
    prisonTile,
    bankTile,
    taxTile,

    //Asia
    harakiriTile,
    chineseTeapotTile,
    everestTile,
    chineseNewYearTile,
    infinityTsukoyomiTile,

    //America
    spinWheelTile,
    tunnelTile,
    millionariesLifeTile,
    energyTile,
    taxiTile,
    coinMachineTile,
    mayanTreasureTile,
    policeOrderTile
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
        Clear();
        foreach (EActions action in actions)
        {
            showAction(action);
        }
    }

    //switch EActions
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
            case EActions.buildHouseTile:
                go.AddComponent<BuildHouseTileButton>();
                text.text = go.GetComponent<BuildHouseTileButton>().Name;
                break;
            case EActions.sellHouseTile:
                go.AddComponent<SellHouseTileButton>();
                text.text = go.GetComponent<SellHouseTileButton>().Name;
                break;
            case EActions.mortgageTile:
                go.AddComponent<MortgageTileButton>();
                text.text = go.GetComponent<MortgageTileButton>().Name;
                break;
            case EActions.redeemTile:
                go.AddComponent<RedeemTileButton>();
                text.text = go.GetComponent<RedeemTileButton>().Name;
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
