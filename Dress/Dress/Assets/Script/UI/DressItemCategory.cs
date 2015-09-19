using UnityEngine;

public class DressItemCategory : MonoBehaviour
{
    public TweenPosition tweenPosition;
    public TweenPosition itemListTweenPosition;

	void Start () {
	}
	
	void Update () {
	}

    public void MoveItem()
    {
        tweenPosition.Toggle();
        itemListTweenPosition.Toggle();
    }
}
