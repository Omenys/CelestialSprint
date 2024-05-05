using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Constant movement in the +x direction
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Input from player
        float input = Input.GetAxis("Vertical");

        // Movement in y direction
        transform.Translate(Vector2.right * input * speed * Time.deltaTime);

    }
}
