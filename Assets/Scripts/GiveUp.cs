using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveUp : MonoBehaviour
{
    public void GiveUpButton()
    {
        GroupPlayer.S.DeletePlayer();
    }
}
