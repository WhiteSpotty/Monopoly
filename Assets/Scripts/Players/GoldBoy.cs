using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBoy : Player
{
    public override int PosIndex { 
        get => base.PosIndex;
        set
        {
            int N = 1, bonusPassedLayer = 200000;
            switch (PosLayer)
            {
                case ENameLayer.Asia:
                    N = Board.S.asiaTiles.Length;
                    break;
                case ENameLayer.Europe:
                    N = Board.S.europeTiles.Length;
                    break;
                case ENameLayer.America:
                    N = Board.S.americaTiles.Length;
                    break;
            }
            if (value > N) { this.changeBalanceDelegate(bonusPassedLayer); Logs.PrintToLogs($"{this.Name} passed the layer and recieved x4 bonus: {bonusPassedLayer} because GoldBoy"); }
            _posIndex = value % N;
        }
    }
}
