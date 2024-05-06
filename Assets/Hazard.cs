using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] ShieldChargeStat stat; //accessing scriptable
    public float maxSpeed; //asteroid move speed
    public float maxSpin; //asteroid spinning effect
    public Rigidbody2D rb; //rigidbody of asteroid prefab

    private void Start()
    {
        Vector2 move = new Vector2(Random.Range(-maxSpeed, maxSpeed), Random.Range(-maxSpeed, maxSpeed)); //speed

        float spin = Random.Range(-maxSpin, maxSpin); //spin

        rb.AddForce(move);
        rb.AddTorque(spin);
    }
   /* Vector2 movement() //Asteroid movement and spin effect
    {
        Vector2 move = new Vector2(Random.Range(-maxSpeed, maxSpeed), Random.Range(-maxSpeed, maxSpeed)); //speed

        float spin = Random.Range(-maxSpin, maxSpin); //spin

        rb.AddForce(move);
        rb.AddTorque(spin);

        return move;
    }*/
    void Spawning(string portalName, int speed) //Asteroid spawning
    {

    }

    private void OnCollisionEnter(Collision collision) //When player collides with asteroid
    {
        stat.currentShieldCount -= 1;
    }

    void asteroidWall() //Spawns when a player does not enter a portal
    {

    }
}
