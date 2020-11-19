using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void SCB();

[System.Serializable]
public class SphereSwitchEvent : UnityEvent<string, GameObject>
{

}

[System.Serializable]
public class FadeEvent : UnityEvent<bool>
{

}

public static class SphereSwitcher
{
    private static SphereSwitchEvent MSSE = new SphereSwitchEvent();
    private static FadeEvent FE = new FadeEvent();

    private static string toSphereName;
    private static GameObject toPlayer;

    public static void AddSphereHandler(UnityAction<string, GameObject> f)
    {
        MSSE.AddListener(f);
    }

    public static void AddFadeHandler(UnityAction<bool> f)
    {            
        FE.AddListener(f);
    }

    public static void SwitchSphere(string sphereName, GameObject player)
    {
        toSphereName = sphereName;
        toPlayer = player;

        Debug.Log("Starting fade");

        FE.Invoke(true);
    }

    public static void DoneFade()
    {
        Debug.Log("Invoking sphere event");
        MSSE.Invoke(toSphereName, toPlayer);
    }

    public static void DoneSwitch()
    {
        Debug.Log("Un-Fading");
        FE.Invoke(false);
    }

    /**
    public static void SwitchSphere(string sphereName, GameObject player)
    {
        if (FE == null)
            return;
        
        FE.Invoke(() => {
            if (MSSE != null)
                MSSE.Invoke(sphereName, player);
        }, true);
    }
    **/
}
