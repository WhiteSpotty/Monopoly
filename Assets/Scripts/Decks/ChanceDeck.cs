using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceDeck : Deck
{
    public ChanceDeck()
    {
        type = ECardType.chanceCard;
        _cards.Add(new ChanceCard("�������� �������� ����", true, 20000));
        _cards.Add(new ChanceCard("���! ��������", true, 1300));
        _cards.Add(new ChanceCard("�� ��������� � ������", false, 5000));
        _cards.Add(new ChanceCard("�������� ���������� �� �������", false, 15000));
        Shuffle();
    }
}
