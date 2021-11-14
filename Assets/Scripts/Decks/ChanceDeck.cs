using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceDeck : Deck
{
    public ChanceDeck()
    {
        type = ECardType.chanceCard;
        _cards.Add(new ChanceCard("Получите денежный приз", true, 20000));
        _cards.Add(new ChanceCard("Ура! Зарплата", true, 1300));
        _cards.Add(new ChanceCard("Вы проиграли в казино", false, 5000));
        _cards.Add(new ChanceCard("Погасите адолжность по кредиту", false, 15000));
        Shuffle();
    }
}
