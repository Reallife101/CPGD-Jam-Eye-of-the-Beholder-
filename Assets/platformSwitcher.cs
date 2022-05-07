using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSwitcher : MonoBehaviour
{
    [SerializeField] List<GameObject> onByDefault;
    [SerializeField] List<GameObject> offByDefault;

    public bool on;

    private void Start()
    {
        on = true;
    }

    public void turnOn()
    {
        foreach (GameObject go in onByDefault)
        {
            go.SetActive(true);
        }

        foreach (GameObject go in offByDefault)
        {
            go.SetActive(false);
        }
        on = true;
    }

    public void turnOff()
    {
        foreach (GameObject go in onByDefault)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in offByDefault)
        {
            go.SetActive(true);
        }
        on = false;
    }

    public void flip()
    {
        if (on)
        {
            turnOn();
        }
        else
        {
            turnOff();
        }
    }

}
