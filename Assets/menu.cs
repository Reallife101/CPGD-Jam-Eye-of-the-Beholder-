using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    [SerializeField] GameObject mainmenu;
    [SerializeField] GameObject htp;
    [SerializeField] GameObject credits;

    private void Start()
    {
        mainOn();
    }

    public void htpOn()
    {
        htp.SetActive(true);
        mainmenu.SetActive(false);
        credits.SetActive(false);
    }

    public void mainOn()
    {
        htp.SetActive(false);
        mainmenu.SetActive(true);
        credits.SetActive(false);
    }

    public void creditsOn()
    {
        htp.SetActive(false);
        mainmenu.SetActive(false);
        credits.SetActive(true);
    }

    public void quit()
    {
        Application.Quit();
    }

}
