using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoorSwitchEye : Interactable
{
    private GameObject door;

    void Start()
    {
        //door = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("pressed fire");
            interact();
        }
    }

    public override void interact()
    {
        //door.enabled = false;
    }
}
