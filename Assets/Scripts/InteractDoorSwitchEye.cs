using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoorSwitchEye : Interactable
{
    [SerializeField] Animator door = null;
    [SerializeField] AudioClip ac;


    public override void interact()
    {
        door.SetBool("isOpen", true);
        GetComponent<AudioSource>().PlayOneShot(ac, .9f);
    }
}
