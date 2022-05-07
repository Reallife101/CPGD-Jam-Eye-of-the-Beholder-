using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnPlayer : MonoBehaviour
{
    [SerializeField] Vector3 respawnPoint;

    private platformSwitcher ps;

    private void Start()
    {
        ps = GameObject.FindGameObjectWithTag("GameManager").GetComponent<platformSwitcher>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            respawn(other);
        }
    }
    
    public void respawn(Collider other)
    {
        other.GetComponent<CharacterController>().enabled = false;
        other.transform.position = respawnPoint;
        ps.turnOn();
        other.GetComponent<CharacterController>().enabled = true;
    }
}
