using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDoor : Interactable
{
    [SerializeField] Animator door = null;
    [SerializeField] InteractDoorSwitchEye eye;
    [SerializeField] AudioClip ac;

    void Start()
    {
        he.enabled = false;
    }

    private void Update()
    {
        if (eye.pickedUp)
        {
            he.enabled = true;
        }
    }

    public override void interact()
    {
        if(eye.pickedUp)
        {
            door.SetBool("isOpen", true);
            GetComponent<AudioSource>().PlayOneShot(ac, .9f);
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<eyeballManager>().keyEyeAnim(false);
        }
    }
}
