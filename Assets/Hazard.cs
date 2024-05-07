using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    //[SerializeField] ShieldChargeStat stat; //accessing scriptable
    public float maxSpeed; //asteroid move speed
    public float maxSpin; //asteroid spinning effect
    public Rigidbody2D rb; //rigidbody of asteroid prefab
    public float screenTop; //screen positions
    public float screenBottom;
    public float screenLeft;
    public float screenRight;

    private void Start()
    {
        Vector2 move = new Vector2(Random.Range(-maxSpeed, maxSpeed), Random.Range(-maxSpeed, maxSpeed)); //speed

        float spin = Random.Range(-maxSpin, maxSpin); //spin

        rb.AddForce(move);
        rb.AddTorque(spin);
    }

    private void FixedUpdate() //Keeping the asteroid from fully going outside of camera perspective
    {
   
        Vector2 newPos = transform.position;
        if (transform.position.y > screenTop)
        {
            newPos.y = screenBottom;
        }
        if (transform.position.y < screenBottom)
        {
            newPos.y = screenTop;
        }
        if (transform.position.x > screenRight)
        {
            newPos.x = screenLeft;
        }
        if (transform.position.x < screenLeft)
        {
            newPos.x = screenRight;
        }
       
        transform.position = newPos;
   
    }
    private void OnCollisionEnter(Collision collision) //When player collides with asteroid
    {
        //stat.currentShieldCount -= 1;
    }

    void asteroidWall() //Spawns when a player does not enter a portal
    {

    }
}
