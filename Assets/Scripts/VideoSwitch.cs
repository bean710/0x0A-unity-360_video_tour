using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSwitch : MonoBehaviour
{
    public bool startsOn = false;
    
    private VideoPlayer vidComp;

    // Start is called before the first frame update
    void Start()
    {
        vidComp = GetComponent<VideoPlayer>();

        vidComp.enabled = startsOn;

        SphereSwitcher.AddSphereHandler(SphereChange);
    }

    public void SphereChange(string sphereName)
    {
        
        vidComp.enabled = (sphereName == name);
    }
}
