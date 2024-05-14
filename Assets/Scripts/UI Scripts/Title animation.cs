using UnityEngine;
using TMPro;

public class Titleanimation : MonoBehaviour
{
    [SerializeField] TMP_Text GameTitleText;

    //Tilting method variables
    [SerializeField] float rotZ;
    [SerializeField] int tiltAnimTime; // 50 = 1 second
    int tiltAnimTick = 0;
    bool tiltAnimIn = false;

    //Scaling method variables
    [SerializeField] float animScale;
    [SerializeField] float scalingAnimTime; // 50 = 1 second
    int scalingAnimTick = 0;
    bool scalingAnimIn = false;

    //ColorChange method variables
    Color currentColor;
    [SerializeField] Color colorOne;
    [SerializeField] Color colorTwo;
    [SerializeField] float colorSpeed; // The bigger the number, the slower the speed is!!
    float colorAnimNum;
    public bool colorAnimBack = false;

    // Start is called before the first frame update
    void Start()
    {
        currentColor = colorOne;
    }

    // Updates 50 times per second
    void FixedUpdate() // The whole title animation
    {
        GameTitleText.transform.eulerAngles = new Vector3(GameTitleText.transform.eulerAngles.x, GameTitleText.transform.eulerAngles.y, GameTitleText.transform.eulerAngles.z + rotZ);
        GameTitleText.transform.localScale = new Vector3(GameTitleText.transform.localScale.x + animScale, GameTitleText.transform.localScale.y + animScale, 0);
        GameTitleText.color = currentColor;
        Tilting();
        Scaling();
        ColorChange();
    }

    void Tilting()
    {
        if (tiltAnimTick < tiltAnimTime && !tiltAnimIn)
        {
            if (rotZ < 0)
                rotZ *= -1;
            tiltAnimTick++;
            if (tiltAnimTick == tiltAnimTime - 1)
                tiltAnimIn = true;
        }
        else
        {
            if (tiltAnimIn && rotZ > 0)
                rotZ *= -1;
            else
            {
                tiltAnimTick--;
                if (tiltAnimTick == -tiltAnimTime * 0.80)
                    tiltAnimIn = false;
            }
        }
    }

    void Scaling()
    {
        if(scalingAnimTick < scalingAnimTime && !scalingAnimIn)
        {
            if(animScale < 0)
                animScale *= -1;
            scalingAnimTick++;
            if(scalingAnimTick == scalingAnimTime)
                scalingAnimIn = true;
        }
        else
        {
            if (scalingAnimIn && animScale > 0)
                animScale *= -1;
            else
            {
                scalingAnimTick--;
                if(scalingAnimTick == -scalingAnimTime * 0.80)
                    scalingAnimIn = false;
            }
        }
    }

    void ColorChange()
    {
        colorAnimNum += Time.deltaTime / colorSpeed;

        if(!colorAnimBack)
        {
            currentColor = Color.Lerp(colorOne, colorTwo, colorAnimNum);
            if (colorAnimNum > 1)
            {
                colorAnimNum = 0;
                colorAnimBack = true;
            }
        }
        else
        {
            currentColor = Color.Lerp(colorTwo, colorOne, colorAnimNum);
            if (colorAnimNum > 1)
            {
                colorAnimNum = 0;
                colorAnimBack = false;
            }
        }
    }
}
