using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    [SerializeField] GameObject portals;
    //[SerializeField] float spawnTimer = 10f;
    [SerializeField] float portalLife = 10f;
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
        GameObject obj = Instantiate(portals);
        obj.transform.position = GetPortalPosition();
        Destroy(obj.gameObject, portalLife); //Destroys spawned object after 15 seconds (The idea of it despawning off screen)



        /*GameObject obj = Instantiate(portals, transform);
        obj.transform.position = new Vector2(10, 0); //position of where the portal spawns
        Destroy(obj.gameObject, 15);*/ //Destroys spawned object after 15 seconds (The idea of it despawning off screen)
    }

    Vector2 GetPortalPosition()
    {
        // Get screen boundaries
        float screenX = Camera.main.aspect * Camera.main.orthographicSize;
        float screenY = Camera.main.orthographicSize;

        // Spawn portal within screen boundaries
        float randomX = Random.Range(-screenX, screenX);
        float randomY = Random.Range(-screenY, screenY);

        return new Vector2(randomX, randomY);

    }
}