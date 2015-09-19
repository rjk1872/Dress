using UnityEngine;
using System.Collections;


public enum DressCategory
{
    Hair,
    Face,
    Dress,
    Acc,
    Top,
    Bottom,
    Shoes,
    Bag
}

public enum DressSpriteDepth
{
    Top = 10,
    Bottom,
    Dress,
    Hair,
    Acc,
    Shoes,
    Bag,
}

public class DressListItem : MonoBehaviour
{
    public DressCategory dressCategory;
    public int dressCode;
    public string spriteName;
	// Use this for initialization
	void Start ()
	{
	    spriteName = GetComponentInChildren<UISprite>().spriteName;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
