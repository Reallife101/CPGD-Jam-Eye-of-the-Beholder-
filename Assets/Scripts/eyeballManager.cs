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
    [SerializeField] AudioSource au2;
    [SerializeField] AudioClip eyeRip;
    [SerializeField] List<AudioClip> pickupEyes;

    [SerializeField] GameObject eyeBleed;
    [SerializeField] GameObject platformOverlay;
    [SerializeField] GameObject keyHand;
    [SerializeField] GameObject jumpOverlay;
    [SerializeField] interactDoubleJump idj;

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
        else if (currentEyeball == 2 && lastEyeball != currentEyeball)
        {
            StartCoroutine(jumpEye());
        }
        lastEyeball = currentEyeball;

    }

    public void keyEyeAnim(bool t)
    {
        StartCoroutine(keyEye(t));
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
        jumpOverlay.SetActive(false);
        ps.turnOn();
        cam.fieldOfView = 50f;
        if (idj)
        {
            idj.doubleJumpEnabled = false;
        }

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
        jumpOverlay.SetActive(false);
        cam.fieldOfView = 50f;
        if (idj)
        {
            idj.doubleJumpEnabled = false;
        }

        timeElapsed = 0;
        arm.SetBool("handUp", false);
        while (timeElapsed < transitionTime)
        {
            black.color = new Color(0f, 0f, 0f, Mathf.Lerp(endAlpha, 0, timeElapsed / transitionTime));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        black.color = new Color(0f, 0f, 0f, 0f);
        au2.PlayOneShot(pickupEyes[Random.Range(0, pickupEyes.Count)], .8f);
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
        jumpOverlay.SetActive(false);
        platformOverlay.SetActive(true);
        ps.turnOff();
        cam.fieldOfView = 60f;
        if (idj)
        {
            idj.doubleJumpEnabled = false;
        }

        timeElapsed = 0;
        arm.SetBool("handUp", false);
        while (timeElapsed < transitionTime)
        {
            black.color = new Color(0f, 0f, 0f, Mathf.Lerp(endAlpha, 0, timeElapsed / transitionTime));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        black.color = new Color(0f, 0f, 0f, 0f);
        au2.PlayOneShot(pickupEyes[Random.Range(0, pickupEyes.Count)], .8f);
    }

    IEnumerator keyEye(bool t)
    {
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

        keyHand.SetActive(t);
        if (idj)
        {
            idj.doubleJumpEnabled = false;
        }

        timeElapsed = 0;
        while (timeElapsed < transitionTime)
        {
            black.color = new Color(0f, 0f, 0f, Mathf.Lerp(endAlpha, 0, timeElapsed / transitionTime));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        black.color = new Color(0f, 0f, 0f, 0f);
        au2.PlayOneShot(pickupEyes[Random.Range(0, pickupEyes.Count)], .8f);
    }

    IEnumerator jumpEye()
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
        jumpOverlay.SetActive(true);
        platformOverlay.SetActive(false);
        ps.turnOn();
        cam.fieldOfView = 60f;

        if (idj)
        {
            idj.doubleJumpEnabled = true;
        }

        timeElapsed = 0;
        arm.SetBool("handUp", false);
        while (timeElapsed < transitionTime)
        {
            black.color = new Color(0f, 0f, 0f, Mathf.Lerp(endAlpha, 0, timeElapsed / transitionTime));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        black.color = new Color(0f, 0f, 0f, 0f);
        au2.PlayOneShot(pickupEyes[Random.Range(0, pickupEyes.Count)], .8f);
    }

}
