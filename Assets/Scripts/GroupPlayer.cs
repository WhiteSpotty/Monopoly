using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupPlayer : MonoBehaviour
{
    static public GroupPlayer S;

    [Header("Set in Inspector")]
    public Canvas createPlayer;
    public Player player;
    public GameObject playersStatsPanel;
    public PlayerStats playerStatsPrefab;

    [Header("Set Dynamically")]
    public int currPlayers = 0;
    public List<Player> players;
    

    private Player _activePlayer = null;

    public Player ActivePlayer
    {
        get { return _activePlayer; }
    }

    private void Awake()
    {
        S = this;
    }

    public void CreatePlayers()
    {
        if (currPlayers > Monopoly.S.numPlayers-1) { 
            createPlayer.gameObject.SetActive(false); 
            SetNextPlayer(null); //Setting first player turn at the game

            StartTurn();

            return; 
        }

        createPlayer.gameObject.SetActive(true);

        currPlayers++;
    }

    public void StartTurn()
    {
        Logs.PrintToLogs("Start turn player is: "+ActivePlayer.Name);

        EndTurnButton.S.button.interactable = false;
        if (ActivePlayer == null) Logs.PrintToLogs("null");
        List<EActions> actions = ActivePlayer.possibleActions();
        Actions.S.showPossibleActions(actions);

        
    }


    public Player SetNextPlayer(Player p)
    {
        if (p == null) { _activePlayer = players[0]; return players[0]; }

        int N=-1, i=0;
        foreach (Player tmp in players)
        {
            if (tmp == p) N = i;
            i++;
        }

        _activePlayer = players[(N + 1) % players.Count];
        return players[(N + 1) % players.Count];
    }

    public void NextButton() 
    {
        Player go = Instantiate<Player>(player);
        go.transform.SetParent(this.gameObject.transform);
        go.Name = createPlayer.GetComponentInChildren<InputField>().text;
        createPlayer.GetComponentInChildren<InputField>().text ="";

        go.transform.localPosition = Board.S.tilePos[(ENameLayer.Europe, 0)].Item2;

        PlayerStats stat = Instantiate<PlayerStats>(playerStatsPrefab);
        go.statusPlayer = stat;
        stat.transform.SetParent(playersStatsPanel.transform);
        stat.transform.localScale = Vector3.one;


        stat.Name = go.Name;
        stat.Balance = go.Balance;
        stat.Trait = "Evtush";
        stat.Color = "red";

        players.Add(go);
        Logs.PrintToLogs($"Player {go.Name} created");

        CreatePlayers();
    }
}
