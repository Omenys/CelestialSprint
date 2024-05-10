using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidWall : MonoBehaviour
{
    [SerializeField] ShieldChargeStat stat; //accessing scriptable
    //public Rigidbody2D rb; //rigidbody of asteroid prefab
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Vector2 move = new Vector2(-speed, -1); //speed at which will drop from above

        //rb.AddForce(move);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other) //When player collides with asteroid
    {
        if (other.gameObject.GetComponent<MovementWithNewInput>() != null)
        {
            stat.currentShieldCount -= 1;
        }
    }
}
