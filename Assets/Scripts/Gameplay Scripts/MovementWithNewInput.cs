using UnityEngine;
using UnityEngine.InputSystem;

public class MovementWithNewInput : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Rigidbody2D rb;
    Vector2 direction;
    bool pressed = false;

    // Start is called before the first frame update
    void Start()
    {
        // Get rigid body component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Keyboard.current.upArrowKey.isPressed)
            pressed = true;
        else if(Keyboard.current.downArrowKey.isPressed)
            pressed = true;
        else
            pressed = false;


        // Input from player 
        float directionY = Input.GetAxis("Vertical");

        // Movement in y direction
        direction = new Vector2(0, directionY).normalized;
        rb.velocity = new Vector2(0, direction.y * speed);

    }

    private void FixedUpdate()
    {
        // Move rigid body
        

    }
}
