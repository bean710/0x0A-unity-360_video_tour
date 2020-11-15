using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public GameObject rConObject;
    public GameObject touchSphere;

    public float maxDist = 100;

    private Transform rConTransform;
    private Transform touchSphereTransform;

    private GameObject contact = null;
    private GameObject lastContact = null;

    // Start is called before the first frame update
    void Start()
    {
        rConTransform = rConObject.transform;
        touchSphereTransform = touchSphere.transform;
    }

    // Update is called once per frame
    void Update()
    {
        /**
        if (Input.GetKeyDown("space") || OVRInput.Get(OVRInput.Touch.One))
            SphereSwitcher.SwitchSphere("Cube", gameObject);
        **/

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (contact != null)
            {
                PointerClick pc = contact.GetComponent<PointerClick>();

                if (pc != null)
                    pc.Click();
            }
        }
    }

    private void FixedUpdate() {
        int layerMask = 1;

        RaycastHit hit;
        
        lastContact = contact;

        if (Physics.Raycast(rConTransform.position,
                    rConTransform.TransformDirection(Vector3.forward),
                    out hit, maxDist))
        {
            touchSphere.SetActive(true);
            touchSphereTransform.position = hit.point;

            contact = hit.transform.gameObject;
        }
        else
        {
            touchSphere.SetActive(false);
            contact = null;
        }

        if (lastContact != contact)
        {
            if (lastContact != null)
                lastContact.GetComponent<PointerClick>().UnHover();

            if (contact != null)
                contact.GetComponent<PointerClick>().Hover();
        }
    }
}
