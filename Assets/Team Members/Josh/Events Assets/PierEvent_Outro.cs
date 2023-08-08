using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.Core.Fader;

public class PierEvent_Outro : MonoBehaviour
{
    [SerializeField] float fadeOutDelay;
    [SerializeField] float fadeDuration;
    [SerializeField] Color fadeColour;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(fadeOutDelay);

        Debug.Log("now I'm fading to white");
        var fader = ScreenFader.Instance;
        fader.FadeTo(fadeColour, fadeDuration);
    }
}
