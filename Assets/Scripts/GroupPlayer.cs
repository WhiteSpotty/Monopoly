using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupPlayer : MonoBehaviour
{
    static public GroupPlayer S;

    [Header("Set in Inspector")]
    public Canvas createPlayer;
    public Player[] player;
    public Player defaultPlayer;
    public GameObject playersStatsPanel;
    public PlayerStats playerStatsPrefab;

    [Header("Set Dynamically")]
    public int currPlayers = 0;
    public List<Player> players;
    private List<Color> colors = new List<Color>() { Color.red, Color.yellow, Color.green, Color.blue, Color.cyan, Color.magenta };
    

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
        Time.timeScale = 0;
        if (currPlayers > Monopoly.S.numPlayers-1) { 
            createPlayer.gameObject.SetActive(false); 
            SetNextPlayer(null); //Setting first player turn at the game

            StartTurn();
            Time.timeScale = 1f;
            return; 
        }

        createPlayer.gameObject.SetActive(true);

        currPlayers++;
    }

    public void StartTurn()
    {
        if (ActivePlayer.isDisabled)
        {
            Logs.PrintToLogs($"{ActivePlayer.Name} is disabled remaining for: {ActivePlayer.DisabledAmount}");
            ActivePlayer.DisabledAmount = -1;

            GroupPlayer.S.SetNextPlayer(GroupPlayer.S.ActivePlayer);
            StartTurn();
            return;
        }

        Logs.PrintToLogs("Start turn player is: "+ActivePlayer.Name);
        SetActiveStatusBar();

        EndTurnButton.S.button.interactable = false;
        if (ActivePlayer == null) Logs.PrintToLogs("null");

        Actions.S.showPossibleActions(ActivePlayer.possibleActions());
    }

    public Player SetNextPlayer(Player p)
    {
        if (p == null) { _activePlayer = players[0]; }
        else
        {

            int N = -1, i = 0;
            foreach (Player tmp in players)
            {
                if (tmp == p) N = i;
                i++;
            }
            _activePlayer = players[(N + 1) % players.Count];
        }

        _activePlayer.isRolled = false;
        _activePlayer.payedTax = false;
        _activePlayer.payRent = false;

        return _activePlayer;
    }

    public void SetActiveStatusBar()
    {
        foreach (Player pl in players)
        {
            if (pl==ActivePlayer) { pl.statusPlayer.GetComponent<Image>().color = Color.red; }
            else
            {
                pl.statusPlayer.GetComponent<Image>().color = Color.white;
            }
        }
        
    }

    public void NextButton() 
    {
        PlayerStats stat = Instantiate<PlayerStats>(playerStatsPrefab);
        Dropdown trait = createPlayer.transform.Find("CreatePlayerPanel/TraitDropdown").GetComponent<Dropdown>();
        Player go = null;
        switch (trait.value)
        {
            case 0:
                go = Instantiate<Player>(player[0]) as Runner;
                stat.Trait = "Runner";
                break;
            case 1:
                go = Instantiate<Player>(player[1]) as GoldBoy;
                stat.Trait = "GoldBoy";
                break;
            case 2:
                go = Instantiate<Player>(player[2]) as Speculator;
                stat.Trait = "Speculator";
                break;
            case 3:
                go = Instantiate<Player>(player[3]) as ProfessionalCriminal;
                stat.Trait = "Criminal";
                break;
            default:
                Logs.PrintToLogs("Not found trait");
                break;
        }

        go.transform.SetParent(this.gameObject.transform);
        go.Name = createPlayer.GetComponentInChildren<InputField>().text;
        createPlayer.GetComponentInChildren<InputField>().text = "";

        Dropdown dd = createPlayer.transform.Find("CreatePlayerPanel/ColorDropdown").GetComponent<Dropdown>();
        int colorValue = dd.value;
        go.color = colors[colorValue];

        go.PlaceTo(ENameLayer.Europe, 0);

        
        go.statusPlayer = stat;
        stat.transform.SetParent(playersStatsPanel.transform);
        stat.transform.localScale = Vector3.one;

        stat.Name = go.Name;
        stat.Balance = go.Balance;
        
        stat.Color = dd.options[dd.value].text;

        players.Add(go);
        Logs.PrintToLogs($"Player {go.Name} created");

        CreatePlayers();
    }

    public int AmountPLayersOnTile(ENameLayer layer, int ind)
    {
        int res = 0;
        foreach (Player player in players)
        {
            if (player.PosLayer == layer && player.PosIndex == ind) res++;
        }
        return res;
    }

    public void DeletePlayer()
    {
        Player pl = ActivePlayer;
        SetNextPlayer(pl);
        Destroy(pl.statusPlayer.gameObject);
        foreach (Tile tile in pl._property)
        {
            CommonTile ct = (CommonTile)tile;
            ct.setMortgage = false;
            ct.Owner = null;
            ct.CurrHouses = 0;
        }
        players.Remove(pl);
        Destroy(pl.gameObject);
        StartTurn();
    }

    public void DeletePlayer(Player pl)
    {
        SetNextPlayer(pl);
        Destroy(pl.statusPlayer.gameObject);
        foreach (Tile tile in pl._property)
        {
            CommonTile ct = (CommonTile)tile;
            ct.setMortgage = false;
            ct.Owner = null;
            ct.CurrHouses = 0;
        }
        players.Remove(pl);
        Destroy(pl.gameObject);
        StartTurn();
    }
}
