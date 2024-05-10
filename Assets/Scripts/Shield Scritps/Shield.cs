using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] ShieldChargeStat stats; //Accessing ShieldCharge scriptableObject
    [SerializeField] GameObject shield; //To access a shield object

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Movement>() != null)
        {
            Destroy(shield); //Destroys shield objet from scene
            stats.currentShieldCount++; //Adds a charge to the player's current shield count
        }
    }
}
