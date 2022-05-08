using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactDoubleJump : Interactable
{
    public bool doubleJumpEnabled = false;
    public int numJumps = 1;

    public override void interact()
    {
        doubleJumpEnabled = true;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<eyeballManager>().currentEyeball = 2; ;
    }
}
