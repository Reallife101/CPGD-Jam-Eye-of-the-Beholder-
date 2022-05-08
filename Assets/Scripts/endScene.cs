using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endScene : MonoBehaviour
{
    [SerializeField] Animator arm;
    [SerializeField] float transitionTime;
    [SerializeField] float endAlpha;
    [SerializeField] Image black;
    [SerializeField] AudioSource au;
    [SerializeField] AudioClip ac;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartCoroutine(jumpEye());
        }
    }

    IEnumerator jumpEye()
    {
        float timeElapsed = 0;
        arm.SetBool("end", true);

        au.PlayOneShot(ac, .6f);
        
        while (timeElapsed < transitionTime)
        {
            black.color = new Color(0f, 0f, 0f, Mathf.Lerp(0, endAlpha, timeElapsed / transitionTime));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        black.color = new Color(0f, 0f, 0f, endAlpha);
        
    }
}
