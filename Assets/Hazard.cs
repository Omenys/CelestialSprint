using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] ShieldChargeStat stat; //accessing scriptable

    Vector2 movement() //Asteroid movement
    {
        return 0; //placeholder
    }
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
