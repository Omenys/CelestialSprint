using Unity.VisualScripting;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    [SerializeField] GameObject portals;
    [SerializeField] public float spawnTimer = 5f;
    [SerializeField] public float portalLife = 10f;


    public float timer;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnTimer)
        {
            portalSpawn();
            timer = 0;
        }

    }

    private void portalSpawn()
    {
        if(!portals.IsDestroyed())
        {
            GameObject obj = Instantiate(portals);
            obj.transform.position = GetPortalPosition();
            Destroy(obj.gameObject, portalLife); //Destroys spawned object after 15 seconds (The idea of it despawning off screen)
        }

    }

    Vector2 GetPortalPosition()
    {
        // Get screen boundaries
        float screenX = Camera.main.aspect * Camera.main.orthographicSize;
        float screenY = Camera.main.orthographicSize;

        // Adjust spawn heights
        float minX = screenX * 0.5f;
        float minY = -screenY * 0.3f;
        float maxY = 3;

        // Spawn portal within screen boundaries
        float randomX = Random.Range(minX, screenX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);

    }
}
