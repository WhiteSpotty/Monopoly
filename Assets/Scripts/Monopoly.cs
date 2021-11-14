using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monopoly : MonoBehaviour
{
    static public Monopoly S;

    //[Header("Set in Inspector")]
    

    [Header("Set Dynamically")]
    private static int _numPlayers = 2;
    public GroupPlayer players;
    public GameObject selectPropertyCanvas;


    private void Awake()
    {
        S = this;
    }

    private void Start()
    {
        Board.S.CreateBoard();

        GroupPlayer.S.CreatePlayers();

        
    }

    public int numPlayers
    {
        get { return _numPlayers; }
        set { if (value>2 && value<4) _numPlayers = value; }
    }

}
