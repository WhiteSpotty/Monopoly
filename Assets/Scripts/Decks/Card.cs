using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECardType
{
    chanceCard,
    millionariesLifeCard,
}


public abstract class Card
{
    public abstract string Name { get; }

    public virtual void Do()
    {
        Logs.PrintToLogs(Name);
    }
}
