using Dress.UI;
using UnityEngine;
using System.Collections;

public class DiaryScreen : MonoBehaviour
{
    public UIEventDelegate eventDelegate;

	// Use this for initialization
	void Start ()
	{
	    eventDelegate.StartDiaryWindow();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
