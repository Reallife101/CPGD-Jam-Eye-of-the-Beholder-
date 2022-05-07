using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactPlatformEye : Interactable
{
    private platformSwitcher ps;
    private void Start()
    {
        ps = GameObject.FindGameObjectWithTag("GameManager").GetComponent<platformSwitcher>();
    }
    public override void interact()
    {
        Debug.Log("Interacting!");
        ps.turnOff();
    }
}
