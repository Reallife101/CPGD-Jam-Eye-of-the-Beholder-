using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoorSwitchEye : Interactable
{
    public bool pickedUp = false;


    public override void interact()
    {
        pickedUp = true;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<eyeballManager>().keyEyeAnim(true);
    }
}
