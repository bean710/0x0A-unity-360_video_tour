using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    public GameObject FadeObject;
    public float FadeSpeed = 5f;

    private Renderer FRend;

    // Start is called before the first frame update
    void Start()
    {
        FRend = FadeObject.GetComponent<Renderer>();

        SphereSwitcher.AddFadeHandler(FadeHandler);
    }

    public void FadeHandler(bool toDark)
    {
        Debug.Log("Recieved fade event");

        StartCoroutine(Fade(toDark));
    }

    public IEnumerator Fade(bool toDark)
    {
        Debug.Log("Fade function called");

        float fadeAmount; 
        Color c = FRend.material.color;

        if (toDark == true)
        {
            FadeObject.SetActive(true);

            while (c.a < 1f)
            {
                c = FRend.material.color;
                Debug.Log($"Fade at {c.a}");

                fadeAmount = c.a + (FadeSpeed * Time.deltaTime);
                fadeAmount = fadeAmount > 1f ? 1f : fadeAmount;
                
                FRend.material.color = new Color(c.r, c.g, c.b, fadeAmount);

                yield return null;
            }

            Debug.Log("Done with fading");

            SphereSwitcher.DoneFade();
        }
        else
        {
            while (c.a > 0f)
            {
                c = FRend.material.color;
                Debug.Log($"Fade at {c.a}");

                fadeAmount = c.a - (FadeSpeed * Time.deltaTime);
                fadeAmount = fadeAmount < 0f ? 0f : fadeAmount;

                FRend.material.color = new Color(c.a, c.g, c.b, fadeAmount);

                yield return null;
            }

            FadeObject.SetActive(false);
        }
    }
}
