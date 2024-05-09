using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassedPortal : MonoBehaviour
{
    HazardSpawner spawner; //accessing spawner script
    [SerializeField] GameObject obj; //gameobject that will use this script

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Movement>() != null)
        {
            spawner.spawnDelay = 3; //spanws asteroid every 3 seconds
        }
    }
}
