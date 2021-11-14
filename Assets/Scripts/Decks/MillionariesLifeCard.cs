using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MillionariesLifeCard : Card
{
    public override string Name => "MillionariesLife";

    public override void Do() { Logs.PrintToLogs("nothing Millionare"); }
}
