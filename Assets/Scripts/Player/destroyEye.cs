using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEye : MonoBehaviour
{
    private platformSwitcher ps;
    private void Start()
    {
        ps = GameObject.FindGameObjectWithTag("GameManager").GetComponent<platformSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Fire2"))
        {
            ps.turnOn();
        }
    }
}
