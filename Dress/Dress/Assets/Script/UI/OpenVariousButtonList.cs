using System.Threading;
using Dress.Core;
using UnityEngine;

public class OpenVariousButtonList : MonoBehaviour
{
    public GameObject closeButton;
    public GameObject openButton;
    public GameObject listBG;
    public GameObject listGrid;
    public GameObject topBG;

    private EventTimer openVariousListTimer = new EventTimer();
    private bool isClosed;
    private bool doingChange;

    public void ToggleList()
    {
        if (doingChange)
        {
            return;
        }

        if (!isClosed)
        {
            topBG.SetActive(true);
        }

        listBG.GetComponent<TweenPosition>().Toggle();
        listGrid.GetComponent<TweenPosition>().Toggle();
        openVariousListTimer.Start(listGrid.GetComponent<TweenPosition>().duration);

        doingChange = true;
    }

    void Start()
    {
        openVariousListTimer.endEventHandler += () =>
        {
            closeButton.SetActive(isClosed);
            openButton.SetActive(!isClosed);
            if (isClosed)
            {
                topBG.SetActive(false);
            }
            isClosed = !isClosed;
            doingChange = false;
        };
    }

    void Update()
    {
        openVariousListTimer.Update(Time.deltaTime);
    }

}