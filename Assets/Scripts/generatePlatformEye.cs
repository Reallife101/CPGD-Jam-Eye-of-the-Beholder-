using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatePlatformEye : MonoBehaviour
{
    [SerializeField] List<GameObject> platformEye;

    private void Start()
    {
        platformEye[Random.Range(0, platformEye.Count)].SetActive(true);
    }

}
