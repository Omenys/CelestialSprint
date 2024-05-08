using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float cameraSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        // Change position of camera
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);

    }
}
