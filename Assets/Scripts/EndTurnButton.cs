using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour
{
    public static EndTurnButton S;
    public Button button; 


    private void Awake()
    {
        S = this;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        Actions.S.Clear();
        GroupPlayer.S.SetNextPlayer(GroupPlayer.S.ActivePlayer);
        GroupPlayer.S.StartTurn();
    }
}
