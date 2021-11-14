using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillionariesLifeDeck : Deck
{
    public MillionariesLifeDeck()
    {
        type = ECardType.millionariesLifeCard;
        _cards.Add(new AllGetBonus("All players have successfully invested their money and receive ", 10000));
        _cards.Add(new CurrentPlayerGetBonus("You made it to the list of the richest people get divorced ", 100000));
        _cards.Add(new CurrentPlayerGetBonus("You sold your supercar for ", 50000));
        _cards.Add(new CurrentPlayerGetBonus("Your horse comes first in the race, receive ", 25000));
        Shuffle();
    }
}
