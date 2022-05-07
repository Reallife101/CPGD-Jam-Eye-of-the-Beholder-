using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeballManager : MonoBehaviour
{
    /*
     *-1 - missing eye
     *0 - default eye
     * 1 - platform eye
     */
    [SerializeField] GameObject eyeBleed;

    public int currentEyeball = 0;

    private void Update()
    {
        if (currentEyeball == -1)
        {
            eyeBleed.SetActive(true);
        }
        else if (currentEyeball == 0)
        {
            eyeBleed.SetActive(false);
        }
        else if (currentEyeball == 1)
        {
            eyeBleed.SetActive(false);
        }

    }


}
