using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactNormalEye : Interactable
{
    private eyeballManager em;
    private void Start()
    {
        em = GameObject.FindGameObjectWithTag("GameManager").GetComponent<eyeballManager>();
    }
    public override void interact()
    {
        em.currentEyeball = 0;
    }
}
