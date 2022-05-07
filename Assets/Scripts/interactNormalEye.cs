using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactNormalEye : Interactable
{
    private platformSwitcher ps;
    private void Start()
    {
        ps = GameObject.FindGameObjectWithTag("GameManager").GetComponent<platformSwitcher>();
    }
    public override void interact()
    {
        ps.turnOn();
    }
}
