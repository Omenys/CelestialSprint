using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MovementWithNewInput : MonoBehaviour
{
    [SerializeField] ShieldChargeStat shield;
    //[SerializeField] PortalEntered entered;
    [SerializeField] float speed = 5f;
    Rigidbody2D rb;
    Vector2 direction;
    float directionY;

    // Start is called before the first frame update
    void Start()
    {
        // Get rigid body component
        rb = GetComponent<Rigidbody2D>();
        shield.currentShieldCount = shield.maxShieldCount;
        //entered.portalsEntered = 0;
    }

    // Update is called once per frame
    void Update()
    {


        // Input from player 
        //directionY = Input.GetAxis("Vertical");

        // Movement in y direction
        direction = new Vector2(0, directionY).normalized;
        

        if (shield.currentShieldCount <= 0)
        {
            SceneManager.LoadSceneAsync("GameOver UI", LoadSceneMode.Additive);
            MusicPlayer.playMusic("game over");
            SceneManager.UnloadSceneAsync("Gameplay");
            SceneManager.UnloadSceneAsync("Gameplay UI");
        }
    }

    private void FixedUpdate()
    {
        // Move rigid body

        rb.velocity = new Vector2(0, direction.y * speed);
    }

    public void OnMovement(InputValue value)
    {
        directionY = value.Get<float>();
    }
}
