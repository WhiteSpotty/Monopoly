using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monopoly : MonoBehaviour
{
    static public Monopoly S;

    //[Header("Set in Inspector")]
    

    [Header("Set Dynamically")]
    private int _numPlayers;
    public GroupPlayer players;
    public GameObject selectPropertyCanvas;


    private void Awake()
    {
        S = this;
    }

    private void Start()
    {
        Board.S.CreateBoard();

        NumPlayers = SettingsInfo.numberOfPlayers;
        GroupPlayer.S.CreatePlayers();
    }

    public int NumPlayers
    {
        get { return _numPlayers; }
        set { if (value>=2 && value<=4) _numPlayers = value; }
    }

}
