using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceTile : Tile
{
    [Header("Set in Inspector")]
    public Texture sprite;

    [Header("Set Dynamically")]
    private ChanceDeck _chanceDeck;
    private ECardType _cardtype;

    public override string Name => "Chance";

    public override List<EActions> getListActions()
    {
        List<EActions> res = new List<EActions>();

        res.Add(EActions.chanceTile);

        return res;
    }

    private void Awake()
    {
        GetComponent<Renderer>().material.mainTexture = sprite;
        _cardtype = ECardType.chanceCard;
        _chanceDeck = (ChanceDeck)Board.S.deckByCardType[_cardtype];
    }
}
