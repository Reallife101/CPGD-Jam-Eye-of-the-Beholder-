using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactPlatformEye : Interactable
{
    private platformSwitcher ps;
    private eyeballManager em;
    private void Start()
    {
        ps = GameObject.FindGameObjectWithTag("GameManager").GetComponent<platformSwitcher>();
        em = GameObject.FindGameObjectWithTag("GameManager").GetComponent<eyeballManager>();
    }
    public override void interact()
    {
        ps.turnOff();
        em.currentEyeball = 1;
    }
}
