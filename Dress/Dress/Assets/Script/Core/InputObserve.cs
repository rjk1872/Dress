using UnityEngine;
using System.Collections;

public class InputObserve
{
    private static InputObserve instance = null;

    public delegate void InputEventPositon(Vector2 position);
    public InputEventPositon buttonDownEvent;

    private InputObserve()
    {

    }

    public static InputObserve Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new InputObserve();
            }

            return instance;
        }
    }

	public void Update (float deltaTime)
	{
	    UpdateMouseInput();
        UpdateTouchInput();
	}

    private void UpdateMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (buttonDownEvent != null)
            {
                buttonDownEvent(Input.mousePosition);    
            }
        }
    }

    private void UpdateTouchInput()
    {
        int touchCount = Input.touchCount;
        if (touchCount == 0)
        {
            return;
        }

        if (touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (buttonDownEvent != null && touch.phase == TouchPhase.Began)
            {
                buttonDownEvent(touch.position);
            }
        }
    }
}
