using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    [SerializeField] GameObject portals;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10)
        {
            portalSpawn();
            timer = -30;
        }

    }

    private void portalSpawn()
    {
        GameObject obj = Instantiate(portals, transform);
        obj.transform.position = new Vector2(10, 0); //position of where the portal spawns
        Destroy(obj.gameObject, 15); //Destroys spawned object after 15 seconds (The idea of it despawning off screen)
    }
}
