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

    [Header("Set Dynamically")]
    public bool canEndTurn;

    private void Awake()
    {
        S = this;
    }

    public void showPossibleActions(List<EActions> actions)
    {
        canEndTurn = true;
        Clear();
        foreach (EActions action in actions)
        {
            showAction(action);
        }
        if (canEndTurn) { EndTurnButton.S.button.interactable = true; }
        else { EndTurnButton.S.button.interactable = false; }
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
                if (go.GetComponent<Button>().interactable == true) canEndTurn = false;
                break;
            case EActions.buyTile:
                go.AddComponent<BuyTileButton>();
                text.text = go.GetComponent<BuyTileButton>().Name;
                break;
            case EActions.rentTile:
                go.AddComponent<RentTileButton>();
                text.text = go.GetComponent<RentTileButton>().Name;
                if (go.GetComponent<Button>().interactable == true) canEndTurn = false;
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
            case EActions.goTile:
                getGoBonus(GroupPlayer.S.ActivePlayer);
                Destroy(go);
                break;
            case EActions.chanceTile:
                ChanceCard cd = (ChanceCard)Board.S.deckByCardType[ECardType.chanceCard].TakeLastCard();
                cd.Do();
                Destroy(go);
                break;
            case EActions.millionariesLifeTile:
                MillionariesLifeCard mlc = (MillionariesLifeCard)Board.S.deckByCardType[ECardType.millionariesLifeCard].TakeLastCard();
                mlc.Do();
                Destroy(go);
                break;
            case EActions.transitionTile:
                go.AddComponent<TransitionTileButton>();
                text.text = go.GetComponent<TransitionTileButton>().Name;
                break;
            case EActions.prisonTile:
                setDisabled(GroupPlayer.S.ActivePlayer, 3);
                Destroy(go);
                break;
            case EActions.bankTile:
                Logs.PrintToLogs("At the bank on a tour");
                Destroy(go);
                break;
            case EActions.taxTile:
                go.AddComponent<TaxTileButton>();
                text.text = go.GetComponent<TaxTileButton>().Name;
                if (go.GetComponent<Button>().interactable == true) canEndTurn = false;
                break;
            default:
                Logs.PrintToLogs("Not implemented yet");
                break;
        }
        go.transform.SetParent(actionButtonsPanel.transform);
        go.transform.localScale = Vector3.one;
    }
    private void getGoBonus(Player p)
    {
        int amount = 100000;
        p.changeBalanceDelegate(amount);
        Logs.PrintToLogs($"{p.Name} got GO bonus: {amount}");
    }

    private void setDisabled(Player p, int count)
    {
        p.DisabledAmount = count;
        Logs.PrintToLogs($"{p.Name} remaining disabled for {p.DisabledAmount}");
    }
    public void Clear()
    {
        foreach(Transform child in actionButtonsPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
