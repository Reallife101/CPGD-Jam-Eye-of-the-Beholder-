using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEye : MonoBehaviour
{
    private eyeballManager em;
    private void Start()
    {
        em = GameObject.FindGameObjectWithTag("GameManager").GetComponent<eyeballManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Fire2"))
        {
            em.currentEyeball = -1;
        }
    }
}
