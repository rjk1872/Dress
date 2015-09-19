using UnityEngine;
using System.Collections;

public class UIDragDropDressItem : UIDragDropItem
{
    public delegate void PressItemEvent(DressItem dressItem);
    public PressItemEvent pressItemEvent;
    public PressItemEvent dragEndItemEvent;

    private float autoFixPositionDistance = 70.0f;
    private bool isFixedPosition;
    public Vector3 attachPosition;
    private Vector2 deltaNotUpdated;

    protected override void OnDragStart()
    {
        base.OnDragStart();
        if (pressItemEvent != null)
        {
            pressItemEvent(GetComponent<DressItem>());
        }
    }

    protected override void OnDragEnd()
    {
        base.OnDragEnd();
        if (dragEndItemEvent != null)
        {
            dragEndItemEvent(GetComponent<DressItem>());
        }
    }

    protected override void OnDragDropMove(Vector2 delta)
    {
        if (Vector3.Distance(attachPosition, mTrans.localPosition) < autoFixPositionDistance)
        {
            if (isFixedPosition)
            {
                deltaNotUpdated += delta;
                if (deltaNotUpdated.magnitude >= autoFixPositionDistance)
                {
                    mTrans.localPosition += (Vector3)deltaNotUpdated;
                    isFixedPosition = false;
                }
            }
            else
            {
                mTrans.localPosition = attachPosition;
                if (mTrans.localPosition.Equals(attachPosition))
                {
                    isFixedPosition = true;
                    deltaNotUpdated = Vector2.zero;
                }    
            }
        }
        else
        {
            if (!isFixedPosition)
            {
                base.OnDragDropMove(delta);    
            }
        }

    }
}
