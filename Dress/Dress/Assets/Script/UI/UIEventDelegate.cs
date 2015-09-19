using UnityEngine;
using System.Collections;

namespace Dress.UI
{

    public class UIEventDelegate : MonoBehaviour
    {
    
        public delegate void ButtonPressedEvent();
        public event ButtonPressedEvent playButtonPressdEvent;
        public event ButtonPressedEvent mainButtonPressdEvent;
        public event ButtonPressedEvent trashButtonPressdEvent;
        public event ButtonPressedEvent helpButtonPressdEvent;
        public event ButtonPressedEvent helpImagePressdEvent;
        public event ButtonPressedEvent openVariousButtoPressdEvent;
        public event ButtonPressedEvent screenShotButtonPressedEvent;
        public event ButtonPressedEvent diaryButtonPressedEvent;
        public event ButtonPressedEvent startDiaryWindowEvent;
        public event ButtonPressedEvent saveButtonPressedEvent;

        public delegate void DressCategoryButtonPressedEvent(DressItemCategory categoryButton);
        public event DressCategoryButtonPressedEvent itemCategoryButtonPressdEvent;

        public delegate void DressListItemButtonPressedEvent(DressListItem listItem);
        public event DressListItemButtonPressedEvent dressListItemButtonPressdEvent;

        public delegate void DiaryListItemButtonPressedEvent(DiaryListItem listItem);
        public event DiaryListItemButtonPressedEvent diaryListItemButtonPressdEvent;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PlayButtonPressed()
        {
            if (playButtonPressdEvent != null)
            {
                playButtonPressdEvent();
            }
        }

        public void ItemCategoryButtonPressed(DressItemCategory dressItemCategory)
        {
            if (itemCategoryButtonPressdEvent != null)
            {
                itemCategoryButtonPressdEvent(dressItemCategory);
            }
        }

        public void DressListItemButtonPressed(DressListItem listItem)
        {
            if (dressListItemButtonPressdEvent != null)
            {
                dressListItemButtonPressdEvent(listItem);
            }
        }

        public void DiaryListItemButtonPressed(DiaryListItem listItem)
        {
            if (diaryListItemButtonPressdEvent != null)
            {
                diaryListItemButtonPressdEvent(listItem);
            }
        }

        public void MainButtonPressed()
        {
            if (mainButtonPressdEvent != null)
            {
                mainButtonPressdEvent();
            }
        }

        public void TrashButtonPressed()
        {
            if (trashButtonPressdEvent != null)
            {
                trashButtonPressdEvent();
            }            
        }

        public void HelpButtonPressed()
        {
            if (helpButtonPressdEvent != null)
            {
                helpButtonPressdEvent();
            }
        }

        public void HelpImagePressed()
        {
            if (helpImagePressdEvent != null)
            {
                helpImagePressdEvent();
            }
        }

        public void OpenVariousButtoPressd()
        {
            if (openVariousButtoPressdEvent != null)
            {
                openVariousButtoPressdEvent();
            }
        }

        public void ScreenShotButtonPressed()
        {
            if (screenShotButtonPressedEvent != null)
            {
                screenShotButtonPressedEvent();
            }
        }

        public void DiaryButtonPressed()
        {
            if (diaryButtonPressedEvent!= null)
            {
                diaryButtonPressedEvent();
            }
        }

        public void StartDiaryWindow()
        {
            if (startDiaryWindowEvent != null)
            {
                startDiaryWindowEvent();
            }    
        }

        public void SaveButtonPreesed()
        {
            if (saveButtonPressedEvent != null)
            {
                saveButtonPressedEvent();
            }
        }
    }
}
