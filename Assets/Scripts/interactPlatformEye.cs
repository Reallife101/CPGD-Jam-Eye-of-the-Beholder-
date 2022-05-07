using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactPlatformEye : Interactable
{
    private eyeballManager em;
    private void Start()
    {
        em = GameObject.FindGameObjectWithTag("GameManager").GetComponent<eyeballManager>();
    }
    public override void interact()
    {
        em.currentEyeball = 1;
    }
}
