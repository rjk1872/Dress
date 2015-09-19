using System.Collections.Generic;
using UnityEngine;

namespace Dress.UI
{
    public class DressItemList : MonoBehaviour
    {
        public DressCategory dressCagegory;
        public UIEventDelegate clickNotifyTarget;
        public UIAtlas atlas;

        private void Start()
        {
            List<DressItem> dressItems = DressCreator.Instance.GetDressItemsCategory(dressCagegory);
            foreach (DressItem dressItem in dressItems)
            {
                GameObject listItem = Instantiate(Resources.Load("Object/UI/DressListItem")) as GameObject;
                listItem.transform.parent = transform;
                listItem.transform.localPosition = Vector3.zero;
                listItem.transform.localScale = Vector3.one;
                //이미지 설정
                UISprite uiSprite = listItem.GetComponent<UISprite>();
                uiSprite.atlas = atlas;
                uiSprite.spriteName = dressItem.GetComponent<UISprite>().spriteName;
                uiSprite.MakePixelPerfect();

                //동적 이벤트 생성
                UIButton uiButton = listItem.GetComponent<UIButton>();
                EventDelegate eventDelegate = new EventDelegate(clickNotifyTarget, "DressListItemButtonPressed");
                eventDelegate.parameters[0] = new EventDelegate.Parameter();
                eventDelegate.parameters[0].obj = listItem.GetComponent<DressListItem>();
                eventDelegate.parameters[0].expectedType = typeof (DressListItem);
                uiButton.onClick.Add(eventDelegate);

                //category설정
                DressListItem dressItemList = listItem.GetComponent<DressListItem>();
                dressItemList.dressCategory = dressItem.dressCategory;
                dressItemList.dressCode = dressItem.dressCode;
            }

            GetComponent<UIGrid>().Reposition();
        }

        // Update is called once per frame
        private void Update()
        {

        }
    }
}