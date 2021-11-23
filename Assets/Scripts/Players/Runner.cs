using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : Player
{
    public override void MoveTo(ENameLayer layer, int ind)
    {
        ind += 2;
        base.MoveTo(layer, ind);
    }
}
