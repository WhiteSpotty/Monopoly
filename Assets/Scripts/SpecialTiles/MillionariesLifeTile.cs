using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillionariesLifeTile : Tile
{
    [Header("Set in Inspector")]
    public Texture sprite;

    [Header("Set Dynamically")]
    private MillionariesLifeDeck _millionariesLifeDeck;
    private ECardType _cardtype;

    public override string Name => "Millionarie's Life";

    public override List<EActions> getListActions()
    {
        List<EActions> res = new List<EActions>();

        res.Add(EActions.millionariesLifeTile);

        return res;
    }

    private void Awake()
    {
        GetComponent<Renderer>().material.mainTexture = sprite;
        _cardtype = ECardType.millionariesLifeCard;
        _millionariesLifeDeck = (MillionariesLifeDeck)Board.S.deckByCardType[_cardtype];
    }
}
