using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoClick : PointerClick
{
    public float scaleBy = 0.2f;

    private Vector3 scale;
    private bool contentIsActive = false;

    public Transform icon;
    public GameObject Content;

    private void Start() {
        scale = new Vector3(scaleBy, scaleBy, scaleBy);
    }

    public override void Click()
    {
        contentIsActive = !contentIsActive;
        Content.SetActive(contentIsActive);
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
