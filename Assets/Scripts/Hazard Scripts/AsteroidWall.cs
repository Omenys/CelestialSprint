using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidWall : MonoBehaviour
{
    [SerializeField] ShieldChargeStat stat; //accessing scriptable
    public Rigidbody2D rb; //rigidbody of asteroid prefab

    // Start is called before the first frame update
    void Start()
    {
        Vector2 move = new Vector2(-17, 2).normalized; //speed

        rb.AddForce(move);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other) //When player collides with asteroid
    {
        if (other.gameObject.GetComponent<Movement>() != null)
        {
            stat.currentShieldCount -= 1;
        }
    }
}
