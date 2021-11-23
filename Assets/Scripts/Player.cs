using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected string _name = "defaultName";
    protected int _balance = 372000;
    protected Color _color = Color.white;
    protected ENameLayer _posLayer = ENameLayer.Europe;
    protected int _posIndex = 0;
    public HashSet<Tile> _property = new HashSet<Tile>();
    public bool isRolled = false;
    public PlayerStats statusPlayer;
    protected int _disabledAmount = 0;
    protected int bonusPassedLayer = 50000;

    public static Vector3[] pointPos = new Vector3[] { new Vector3(0.25f, 0, 0.25f), new Vector3(0.25f, 0, -0.25f), 
        new Vector3(-0.25f, 0, 0.25f), new Vector3(-0.25f, 0, -0.25f) };
    public bool payedTax = false;
    public bool payRent = false;

    public delegate void PlayerBalanceDelegate(int value);
    public PlayerBalanceDelegate changeBalanceDelegate;

    //Properties
    public string Name { get { return _name; } set { _name = value; } }
    public int Balance { get { return _balance; } }
    public Color color { get { return _color; } 
        set { _color = value; 
            this.transform.GetComponentInChildren<Renderer>().material.color = _color;
        } 
    }
    public ENameLayer PosLayer { get { return _posLayer; }
        set
        {
            _posLayer = value;
        }
        }
    public virtual int PosIndex
    {
        get { return _posIndex; }
        set
        {
            int N=1;
            switch (PosLayer)
            {
                case ENameLayer.Asia:
                    N = Board.S.asiaTiles.Length;
                    break;
                case ENameLayer.Europe:
                    N = Board.S.europeTiles.Length;
                    break;
                case ENameLayer.America:
                    N = Board.S.americaTiles.Length;
                    break;
            }
            if (value > N) { this.changeBalanceDelegate(bonusPassedLayer); Logs.PrintToLogs($"{this.Name} passed the layer and recieved {bonusPassedLayer}"); }
            _posIndex = value % N;
        }
    }
    public HashSet<Tile> Property
    {
        get { return _property; }
    }

    public int DisabledAmount
    {
        get { return _disabledAmount; }
        set { _disabledAmount += value; }
    }
    public bool isDisabled { get { return _disabledAmount > 0 ? true : false; } }

    protected void Awake()
    {

    }

    protected void Start()
    {
        changeBalanceDelegate += ChangeBalance;
    }

    //Functions
    public List<EActions> possibleActions()
    {
        List<EActions> res = new List<EActions>();

        res.Add(EActions.rollDice);
        res.Add(EActions.mortgageTile);
        res.Add(EActions.redeemTile);

        if (isRolled) { possibleTileActions(ref res); }

        return res;
    }
    public void possibleTileActions(ref List<EActions> list)
    {
        List<EActions> tileActions = getTile().getListActions();
        foreach (EActions ea in tileActions)
        {
            list.Add(ea);
        }
    }

    public Tile getTile()
    {
        return Board.S.tilePos[(PosLayer, PosIndex)].Item1;
    }

    public void ChangeBalance (int value)
    {
        _balance += value;
        statusPlayer.Balance = _balance;
    }

    public bool AddTile(Tile tile)
    {
        return _property.Add(tile);
    }

    public bool RemoveTile(Tile tile)
    {
        return _property.Remove(tile);
    }

    public virtual void MoveTo (ENameLayer layer, int ind)
    {
        int cnt = GroupPlayer.S.AmountPLayersOnTile(layer, ind);
        this.PosLayer = layer;
        this.PosIndex = ind;
        this.transform.position = Board.S.tilePos[(PosLayer, PosIndex)].Item2 + pointPos[cnt];
    }

    public void PlaceTo (ENameLayer layer, int ind)
    {
        int cnt = GroupPlayer.S.AmountPLayersOnTile(layer, ind);
        this.PosLayer = layer;
        this.PosIndex = ind;
        this.transform.position = (Board.S.tilePos[(PosLayer, PosIndex)].Item2 + pointPos[cnt]);
    }

    
}
