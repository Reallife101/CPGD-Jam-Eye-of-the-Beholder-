using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoorSwitchEye : Interactable
{
    [SerializeField] Animator door = null; 

    void Update()
    {
        
    }

    public override void interact()
    {
        door.SetBool("isOpen", true);
    }
}
