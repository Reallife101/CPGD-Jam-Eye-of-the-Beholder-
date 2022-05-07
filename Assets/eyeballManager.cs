using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eyeballManager : MonoBehaviour
{
    /*
     *-1 - missing eye
     *0 - default eye
     * 1 - platform eye
     */
    [SerializeField] Camera cam;
    [SerializeField] float transitionTime = 0.2f;
    [SerializeField] float endAlpha = 150f;
    [SerializeField] Animator arm;

    [SerializeField] Image black;
    [SerializeField] AudioSource au;
    [SerializeField] AudioClip eyeRip;

    [SerializeField] GameObject eyeBleed;
    [SerializeField] GameObject platformOverlay;

    public int currentEyeball = 0;

    private int lastEyeball = 0;
    private platformSwitcher ps;

    private void Start()
    {
        ps = GameObject.FindGameObjectWithTag("GameManager").GetComponent<platformSwitcher>();
    }

    private void Update()
    {
        if (currentEyeball == -1 && lastEyeball != currentEyeball)
        {
            StartCoroutine(eyebleed());
        }
        else if (currentEyeball == 0 && lastEyeball != currentEyeball)
        {
            StartCoroutine(deafultEye());
        }
        else if (currentEyeball == 1 && lastEyeball != currentEyeball)
        {
            StartCoroutine(platformEye());
        }
        lastEyeball = currentEyeball;

    }

    IEnumerator eyebleed()
    {
        arm.SetBool("handUp", true);
        float timeElapsed = 0;
        while (timeElapsed < transitionTime)
        {
            black.color = new Color(0f, 0f, 0f, Mathf.Lerp(0, endAlpha, timeElapsed / transitionTime));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        black.color = new Color(0f, 0f, 0f, endAlpha);
        au.PlayOneShot(eyeRip, .8f);
        yield return new WaitForSeconds(.5f);

        eyeBleed.SetActive(true);
        platformOverlay.SetActive(false);
        ps.turnOn();
        cam.fieldOfView = 50f;

        arm.SetBool("handUp", false);
        timeElapsed = 0;
        while (timeElapsed < transitionTime)
        {
            black.color = new Color(0f, 0f, 0f, Mathf.Lerp(endAlpha, 0, timeElapsed / transitionTime));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        black.color = new Color(0f, 0f, 0f, 0f);
    }
    IEnumerator deafultEye()
    {
        float timeElapsed = 0;
        arm.SetBool("handUp", true);
        while (timeElapsed < transitionTime)
        {
            black.color = new Color(0f, 0f, 0f, Mathf.Lerp(0, endAlpha, timeElapsed / transitionTime));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        black.color = new Color(0f, 0f, 0f, endAlpha);

        au.PlayOneShot(eyeRip, .8f);
        yield return new WaitForSeconds(.5f);

        eyeBleed.SetActive(false);
        platformOverlay.SetActive(false);
        ps.turnOn();
        cam.fieldOfView = 50f;

        timeElapsed = 0;
        arm.SetBool("handUp", false);
        while (timeElapsed < transitionTime)
        {
            black.color = new Color(0f, 0f, 0f, Mathf.Lerp(endAlpha, 0, timeElapsed / transitionTime));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        black.color = new Color(0f, 0f, 0f, 0f);
    }

    IEnumerator platformEye()
    {
        float timeElapsed = 0;
        arm.SetBool("handUp", true);
        while (timeElapsed < transitionTime)
        {
            black.color = new Color(0f, 0f, 0f, Mathf.Lerp(0, endAlpha, timeElapsed / transitionTime));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        black.color = new Color(0f, 0f, 0f, endAlpha);

        au.PlayOneShot(eyeRip, .8f);
        yield return new WaitForSeconds(.5f);

        eyeBleed.SetActive(false);
        platformOverlay.SetActive(true);
        ps.turnOff();
        cam.fieldOfView = 60f;

        timeElapsed = 0;
        arm.SetBool("handUp", false);
        while (timeElapsed < transitionTime)
        {
            black.color = new Color(0f, 0f, 0f, Mathf.Lerp(endAlpha, 0, timeElapsed / transitionTime));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        black.color = new Color(0f, 0f, 0f, 0f);
    }

}
