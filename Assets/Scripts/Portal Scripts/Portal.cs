using UnityEngine;

public class Portal : MonoBehaviour
{
    SpriteRenderer render;
    [SerializeField] PortalEntered entered;
    [SerializeField] GameObject shieldCharge;
    GameObject obj;
    HazardSpawner spawner;
    Hazard asteroid;
    PortalColor portal;
    public Sprite portalSprite;
    public Sprite redPortal;
    public Sprite greenPortal;
    public Sprite bluePortal;
    public float colorChangeInterval;

    float colorTimer;


    public enum PortalColor
    {
        Red = 1,
        Blue = 2,
        Green = 3,
    }

    public int portalsEntered = 0; //tracks number of portals entered by player
    int shieldCharges = 0; //tracks amount of shield charges spawned

    public void Awake()
    {
        //SetPortalColor();
        render = GetComponent<SpriteRenderer>();
        //render.sprite = portalSprite;
    }

    void SetPortalColor()
    {
        int randomColor = Random.Range(1, 4);
        SetPortalColor((PortalColor)randomColor);

    }


    public void SetPortalColor(PortalColor color)
    {
        switch (color)
        {
            // If RNG is 1 spawn red portal
            case PortalColor.Red:
                render.sprite = redPortal;
                break;
            // If RNG is 2 spawn blue portal
            case PortalColor.Blue:
                render.sprite = bluePortal;
                break;
            // If RNG is 3 spawn green portal
            case PortalColor.Green:
                render.sprite = greenPortal;
                break;
            default:
                break;
        }
    }



    // Update is called once per frame
    void Update()
    {
        colorTimer += Time.deltaTime;
        if (colorTimer >= colorChangeInterval)
        {
            SetPortalColor();
            colorTimer = 0;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MovementWithNewInput>() != null)
        {
            switch (portal)
            {
                case (PortalColor.Red):
                    spawner.spawnDelay = 3.5f;
                    asteroid.maxSpeed = 300;
                    obj = Instantiate(shieldCharge, transform);
                    obj.transform.position = new Vector2(15, 0);
                    break;

                case (PortalColor.Blue):
                    spawner.spawnDelay = 6.3f;
                    asteroid.maxSpeed = 100;
                    int rand = Random.Range(1, 100);
                    if (rand < 60 && rand > 50)
                    {
                        obj = Instantiate(shieldCharge, transform);
                        obj.transform.position = new Vector2(15, 0);
                    }
                    break;

                case (PortalColor.Green):
                    spawner.spawnDelay = 4.5f;
                    asteroid.maxSpeed = 250;
                    obj.transform.position = new Vector2(15, 0);
                    break;
            }
        }
    }


}
