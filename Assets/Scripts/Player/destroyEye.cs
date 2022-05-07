using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEye : MonoBehaviour
{
    private platformSwitcher ps;
    private eyeballManager em;
    private void Start()
    {
        ps = GameObject.FindGameObjectWithTag("GameManager").GetComponent<platformSwitcher>();
        em = GameObject.FindGameObjectWithTag("GameManager").GetComponent<eyeballManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Fire2"))
        {
            ps.turnOn();
            em.currentEyeball = -1;
        }
    }
}
