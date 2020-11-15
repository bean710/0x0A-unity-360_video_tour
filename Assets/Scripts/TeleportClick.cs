using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportClick : PointerClick
{
    public string TeleportTo;
    public GameObject player;

    public override void Click()
    {
        SphereSwitcher.SwitchSphere(TeleportTo, player);
    }
}
