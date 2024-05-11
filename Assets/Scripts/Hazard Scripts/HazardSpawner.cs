using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    [SerializeField] GameObject asteroid; //placing asteroid prefab
    public float spawnDelay = 0f; //adjustable spawn delay
    float spawnTime;

    public void setSpawnDelay(float delay)
    {
        spawnDelay = delay;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;

        if (spawnTime >= spawnDelay)
        {
            Spawn();
            spawnTime = 0; //resets timer once an asteroid has spawned
        }
    }

    private void Spawn() //spawns hazard  within a random set range
    {
        GameObject obj = Instantiate(asteroid, transform);
        int rand = Random.Range(-20, -25); //the range in which the hazards will spawn within
        obj.transform.position = new Vector2(rand, rand);
        Destroy(obj.gameObject, 20); //destroys object after 20 seconds
    }
}
