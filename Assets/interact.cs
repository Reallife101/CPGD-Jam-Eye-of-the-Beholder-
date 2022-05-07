using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    [SerializeField] float interactDistance;
    [SerializeField] GameObject camera;
    [SerializeField] LayerMask player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, interactDistance, ~player))
        {
            if (hit.transform.GetComponent<Interactable>())
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<Interactable>().interact();
                }
            }
        }

    }
}
