using Dress.UI;
using UnityEngine;
using System.Collections;   

public class DiaryItemContainer : MonoBehaviour
{
    public int diaryCapacity;
    public UIEventDelegate clickNotifyTarget;

	// Use this for initialization
	void Start ()
	{
        DiaryListItem[] items = ResourceLoader.GetInstance().LoadDiaryItems();

	    int index = 0;
	    foreach (DiaryListItem diaryListItem in items)
	    {
	        diaryListItem.listIndex = index;
	        diaryListItem.transform.parent = this.transform;
	        diaryListItem.transform.localPosition = Vector3.zero;
	        diaryListItem.transform.localScale = Vector3.one;

            //동적 이벤트 생성
            UIButton uiButton = diaryListItem.GetComponent<UIButton>();
            EventDelegate eventDelegate = new EventDelegate(clickNotifyTarget, "DiaryListItemButtonPressed");
            eventDelegate.parameters[0] = new EventDelegate.Parameter();
            eventDelegate.parameters[0].obj = diaryListItem.GetComponent<DiaryListItem>();
            eventDelegate.parameters[0].expectedType = typeof(DiaryListItem);
            uiButton.onClick.Add(eventDelegate);

	        ++index;
	    }

        GetComponent<UIGrid>().Reposition();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
