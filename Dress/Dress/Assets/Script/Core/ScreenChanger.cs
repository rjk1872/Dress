using Dress.UI;
using UnityEngine;

namespace Dress.Core
{
    public class ScreenChanger : MonoBehaviour
    {
        public GameObject mainScreen;
        public GameObject titleScreen;
        public GameObject diaryScreen;

        public UIEventDelegate eventDelegate;
        // Use this for initialization
        void Start()
        {
            eventDelegate.playButtonPressdEvent += ShowMainScreen;
            eventDelegate.mainButtonPressdEvent += ShowTitleScreen;
            eventDelegate.diaryButtonPressedEvent += ShowDiaryScreen;
            eventDelegate.diaryListItemButtonPressdEvent += ShowMainScreenFromDiary;
            eventDelegate.startDiaryWindowEvent += SetEventMainScreen;
            
            mainScreen.SetActive(false);
            titleScreen.SetActive(true);
            diaryScreen.SetActive(false);
        }

        private void SetEventMainScreen()
        {
            mainScreen.GetComponent<MainScreen>().SetDiaryButtonEvent();
        }

        private void ShowMainScreenFromDiary(DiaryListItem listitem)
        {
            mainScreen.SetActive(true);
            diaryScreen.SetActive(false);
        }

        private void ShowDiaryScreen()
        {
            titleScreen.SetActive(false);
            diaryScreen.SetActive(true);
            FileLoader.GetInstance().LoadFiles();
        }

        private void ShowMainScreen()
        {
            titleScreen.SetActive(false);
            mainScreen.SetActive(true);
            //mainScreen.GetComponent<TweenAlpha>().PlayForward();
        }

        private void ShowTitleScreen()
        {
            titleScreen.SetActive(true);
            mainScreen.SetActive(false);
            diaryScreen.SetActive(false);
            //mainScreen.GetComponent<TweenAlpha>().PlayReverse();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
