using UnityEngine;

public class Portal : MonoBehaviour
{
    SpriteRenderer render;
    //[SerializeField] PortalEntered entered;
    [SerializeField] GameObject shieldCharge;
    GameObject obj;
    HazardSpawner spawner;
    Hazard asteroid;
    //PortalColor portal;
    public Sprite portalSprite;
    public Sprite redPortal;
    public Sprite greenPortal;
    public Sprite bluePortal;
    public float colorChangeInterval;
    [SerializeField] float portalSpeed;
    progressScript bar;

    float colorTimer;


    public enum PortalColor
    {
        Red = 1,
        Blue = 2,
        Green = 3,
    }

    public int portalsEntered = 0; //tracks number of portals entered by player

    public void Awake()
    {
        //SetPortalColor();
        render = GetComponent<SpriteRenderer>();
        //render.sprite = portalSprite;

        spawner = FindAnyObjectByType<HazardSpawner>();
        asteroid = FindAnyObjectByType<Hazard>();
        bar = FindAnyObjectByType<progressScript>();
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

    void playRandomTeleportSFX()
    {
        int rand = Random.Range(0, 2);
        switch (rand)
        {
            case 0:
                SoundPlayer.playSound("teleport 1");
                break;
            case 1:
                SoundPlayer.playSound("teleport 2");
                break;
            case 2:
                SoundPlayer.playSound("teleport 3");
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

        transform.position += Vector3.left * portalSpeed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MovementWithNewInput>() != null)
        {
            if (render.sprite == redPortal)
            {
                bar.portalCollision();
                Debug.Log("Red Portal Entered");
                playRandomTeleportSFX();
                SoundPlayer.playSound("shield up");
                portalsEntered += 1;
                spawner.spawnDelay = 3.5f;
                asteroid.setMaxSpeed(300);
                Instantiate(shieldCharge, transform);
                shieldCharge.transform.position = new Vector2(15, 0);

            }
            if (render.sprite == bluePortal)
            {
                bar.portalCollision();
                Debug.Log("Blue Portal Entered");
                portalsEntered += 1;
                playRandomTeleportSFX();
                SoundPlayer.playSound("shield up");
                spawner.setSpawnDelay(6.3f);
                asteroid.setMaxSpeed(100);
                int rand = Random.Range(1, 100);
                if (rand < 60 && rand > 50)
                {
                    Instantiate(shieldCharge, transform);
                    shieldCharge.transform.position = new Vector2(15, 0);
                }
            }

            if (render.sprite == greenPortal)
            {
                bar.portalCollision();
                Debug.Log("Green Portal Entered");
                portalsEntered += 2;
                playRandomTeleportSFX();
                spawner.setSpawnDelay(4.5f);
                asteroid.setMaxSpeed(250);
            }
            //Debug.Log(portalsEntered);
        }

    }
}

