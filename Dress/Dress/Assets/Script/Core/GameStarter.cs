using UnityEngine;
using System.Collections;

namespace Dress.Core
{
    public class GameStarter : MonoBehaviour
    {
        private Platform platform; 

        void Start()
        {
            LoadContents();
            FileLoader.GetInstance().LoadFiles();
        }

        private void LoadContents()
        {
            Instantiate(Resources.Load("Object/UI/DressUI"));
            DressCreator.Instance.LoadResources();
        }

        void Update()
        {
            InputObserve.Instance.Update(Time.deltaTime);
        }

        public void CreatePlatform()
        {
        }
    }
}
