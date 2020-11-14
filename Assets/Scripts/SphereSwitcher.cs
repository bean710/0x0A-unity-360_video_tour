using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SphereSwitchEvent : UnityEvent<string>
{

}

public static class SphereSwitcher
{
    private static SphereSwitchEvent MSSE = new SphereSwitchEvent();

    public static void AddSphereHandler(UnityAction<string> f)
    {
        MSSE.AddListener(f);
    }

    public static void SwitchSphere(string sphereName)
    {
        if (MSSE != null)
            MSSE.Invoke(sphereName);
    }
}
