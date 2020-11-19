using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportClick : PointerClick
{
    public string TeleportTo;
    public GameObject player;

    public float scaleBy = 0.1f;

    private Vector3 scale;

    public Transform icon;

    private void Start() {
        //icon = transform.Find("NodeIcon");

        scale = new Vector3(scaleBy, scaleBy, scaleBy);
    }

    public override void Click()
    {
        Debug.Log("Clicked me!");
        SphereSwitcher.SwitchSphere(TeleportTo, player);
    }

    public override void Hover()
    {
        Debug.Log("Hovered");

        if (icon == null)
        {
            Debug.Log("Icon is null");
            return;
        }

        icon.localScale += scale;
        //transform.localScale = new Vector3(2f, 2f, 2f);
    }

    public override void UnHover()
    {
        Debug.Log("Un-Hovered");

        if (icon == null)
        {
            Debug.Log("Icon is null");
            return;
        }

        icon.localScale -= scale;
        //transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
