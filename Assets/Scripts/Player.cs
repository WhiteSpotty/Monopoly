using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private string _name = "defaultName";
    [SerializeField]
    private int _balance = 1000;
    private ENameLayer _posLayer = ENameLayer.Europe;
    private int _posIndex = 0;

    //Properties
    public string Name { get { return _name; } set { _name = value; } }
    public int Balance { get { return _balance; } }
    public ENameLayer PosLayer { get { return _posLayer; }
        set
        {
            _posLayer = value;
        }
        }
    public int PosIndex
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
            _posIndex = value % N;
        }
    }


    //Functions
    public List<EActions> possibleActions()
    {
        List<EActions> res = new List<EActions>();

        res.Add(EActions.rollDice);

        return res;
    }

    public Tile getTile()
    {
        return Board.S.tilePos[(PosLayer, PosIndex)].Item1;
    }
}
