using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.Core.Fader;
using Liminal.SDK.Core;

public class PierEvent_Outro : MonoBehaviour
{
    [SerializeField] float fadeOutDelay;
    [SerializeField] float fadeDuration;
    [SerializeField] Color fadeColour;

    [SerializeField] float sceneEndDelay;
    [SerializeField] float sceneEndDuration;

    [SerializeField] GameObject centerEye;
    [SerializeField] AudioSource musicAudio;
    [SerializeField] AudioSource waterAudio;

    // Start is called before the first frame update
    void Start()
    {
        centerEye.GetComponent<MeshRenderer>().enabled = true;

        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(fadeOutDelay);

        Debug.Log("start outro fade to white");

        var fader = ScreenFader.Instance;
        fader.FadeTo(fadeColour, fadeDuration);

        var elapsedTime = 0f; //instantiate a float with a value of 0 for use as a timer.
        var startingVolume1 = waterAudio.volume;
        var startingVolume2 = musicAudio.volume; 

        while( elapsedTime < fadeDuration )
        {
            elapsedTime += Time.deltaTime; // Count up
            waterAudio.volume = Mathf.Lerp(startingVolume1, 0f, elapsedTime / fadeDuration);
            musicAudio.volume = Mathf.Lerp(startingVolume2, 0f, elapsedTime / fadeDuration);
            yield return new WaitForEndOfFrame(); // Tell the coroutine to wait for a frame to avoid completing this loop in a single frame.
        }

        StartCoroutine(EndExperience());
    }

    IEnumerator EndExperience()
    {
        yield return new WaitForSeconds(sceneEndDelay);

        Debug.Log("start end scene fade to black");
        var fader = ScreenFader.Instance;
        fader.FadeTo(Color.black, sceneEndDuration);

        var elapsedTime = 0f; //instantiate a float with a value of 0 for use as a timer.
        var startingVolume = AudioListener.volume; //this gets the current volume of the audio listener so that we can fade it to 0 over time.

        while( elapsedTime < sceneEndDuration )
        {
            elapsedTime += Time.deltaTime; // Count up
            AudioListener.volume = Mathf.Lerp(startingVolume, 0f, elapsedTime / sceneEndDuration);
            yield return new WaitForEndOfFrame(); // Tell the coroutine to wait for a frame to avoid completing this loop in a single frame.
        }

        // when the while-loop has ended, the audiolistener volume should be 0 and the screen completely black. However, for safety's sake, we should manually set AudioListener volume to 0.
        AudioListener.volume = 0f;
        Debug.Log("audio is 0 now");

        yield return new WaitForSeconds(0.5f);
        Debug.Log("now end scene");
        ExperienceApp.End(); // This tells the platform to exit the experience.
    }
}
