using Dress.Core;
using UnityEngine;
using System.Collections;
  
public class AlphaChanger : MonoBehaviour
{
    public float changeTime;
    public UISprite image;
    public float alphaChangeSpeed;
    public int changeRepeatCount;
    public bool isInitAlphaZero;

    private EventTimer eventTimer = new EventTimer();
    private bool startChange;
    private float currentAlpha;
    private int checkRepeatCount;
    private bool isChangeAlphaUp;
	
	void Start () {
	    if (!changeTime.Equals(0.0f))
	    {
	        eventTimer.Start(changeTime);
	        eventTimer.endEventHandler += SetAlphaChangeFlag;
	    }

	    if (isInitAlphaZero)
	    {
	        image.alpha = 0;
	        isChangeAlphaUp = true;
	    }
	}
	
	// Update is called once per frame
	void Update () {
        eventTimer.Update(Time.deltaTime);
	    UpdateAlpha();
	}

    void UpdateAlpha()
    {
        if (startChange == false)
        {
            return;
        }


        float changeAlpha = Time.deltaTime*alphaChangeSpeed;
        if (isChangeAlphaUp)
        {
            currentAlpha += changeAlpha;
            if (currentAlpha >= 1.0f)
            {
                isChangeAlphaUp = false;
                ++checkRepeatCount;
            }
        }
        else
        {
            currentAlpha -= changeAlpha;
            if (currentAlpha <= 0.0f)
            {
                isChangeAlphaUp = true;
                ++checkRepeatCount;
            }
        }

        image.alpha = currentAlpha;


        if (checkRepeatCount >= changeRepeatCount)
        {
            checkRepeatCount = 0;
            startChange = false;
            eventTimer.Start(changeTime);
        }
    }

    private void SetAlphaChangeFlag()
    {
        this.startChange = true;
    }
}
