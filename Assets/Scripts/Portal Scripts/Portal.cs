using UnityEngine;

public class Portal : MonoBehaviour
{
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
        portalSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        SetPortalColor();
    }

    void SetPortalColor()
    {
        int randomColor = UnityEngine.Random.Range(1, 4);
        SetPortalColor((PortalColor)randomColor);
    }


    public void SetPortalColor(PortalColor color)
    {
        switch (color)
        {
            // If RNG is 1 spawn red portal
            case PortalColor.Red:
                portalSprite = redPortal;
                break;
            // If RNG is 2 spawn blue portal
            case PortalColor.Blue:
                portalSprite = bluePortal;
                break;
            // If RNG is 3 spawn green portal
            case PortalColor.Green:
                portalSprite = greenPortal;
                break;
            default:
                break;
        }
    }



    // Update is called once per frame
    void Update()
    {

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
