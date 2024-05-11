using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PassedPortal : MonoBehaviour
{
    //HazardSpawner spawner; //accessing spawner script
    [SerializeField] GameObject obj; //gameobject that will use this script
    public float speed;

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Movement>() != null)
        {
            spawner.spawnDelay = 3; //spanws asteroid every 3 seconds
        }
    }*/ // this is for if we are not using asteroid wall

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime); //moves spawner to the left
    }

    public void OnTriggerEnter2D(Collider2D other) //when player collides with trigger
    {
        if (other.gameObject.GetComponent<MovementWithNewInput>() != null)
        {
            Spawn();
        }
    }
    private void Spawn() //Spawns asteroid wall
    {
        GameObject gameObject = Instantiate(obj, transform);

        gameObject.transform.position = new Vector2(13, 0);
    }
}
