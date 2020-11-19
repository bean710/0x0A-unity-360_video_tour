using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSwitch : MonoBehaviour
{
    private VideoPlayer vidComp;

    // Start is called before the first frame update
    void Start()
    {
        vidComp = GetComponent<VideoPlayer>();

        SphereSwitcher.AddSphereHandler(SphereChange);
    }

    public void SphereChange(string sphereName, GameObject player)
    {
        if (sphereName == name)
        {
            vidComp.enabled = true;
            player.transform.position = transform.position;
            SphereSwitcher.DoneSwitch();
        }
        else
        {
            vidComp.enabled = false;
        }
    }
}
