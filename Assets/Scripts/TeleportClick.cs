using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportClick : PointerClick
{
    public string TeleportTo;
    public GameObject player;

    public float scaleBy = 0.1f;

    private Vector3 scale;

    private Transform icon;

    private void Start() {
        icon = transform.Find("NodeIcon");

        scale = new Vector3(scaleBy, scaleBy, scaleBy);
    }

    public override void Click()
    {
        SphereSwitcher.SwitchSphere(TeleportTo, player);
    }

    public override void Hover()
    {
        if (icon == null)
            return;

        icon.localScale += scale;
        //transform.localScale = new Vector3(2f, 2f, 2f);

        Debug.Log("Hovered");
    }

    public override void UnHover()
    {
        if (icon == null)
            return;

        icon.localScale -= scale;
        //transform.localScale = new Vector3(1f, 1f, 1f);

        Debug.Log("Un-Hovered");
    }
}
