using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed;

    [SerializeField] Renderer bgRenderer;

    // Update is called once per frame
    void Update()
    {
        // Infinitely repeat background at speed
        bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
