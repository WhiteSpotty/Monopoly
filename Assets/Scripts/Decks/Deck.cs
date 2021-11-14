using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Deck
{
    public ECardType type;
    protected List<Card> _cards = new List<Card>();
    protected List<Card> _usedcards = new List<Card>();

    public virtual void Shuffle()
    {
        var count = _cards.Count;
        for (var i = 0; i < count; ++i)
        {
            var r = Random.Range(0, count);
            var tmp = _cards[i];
            _cards[i] = _cards[r];
            _cards[r] = tmp;
        }
    }

    public virtual Card TakeLastCard()
    {
        if (_cards.Count==0)
        {
            RenewDeck();
            Shuffle();
        }
        Card res = _cards[_cards.Count - 1];
        _cards.Remove(res);
        _usedcards.Add(res);
        return res;
    }

    public virtual void RenewDeck()
    {
        _cards.AddRange(_usedcards);
        _usedcards.Clear();
    }
}
