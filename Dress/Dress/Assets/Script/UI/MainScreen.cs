using System;
using System.Collections.Generic;
using Dress.Core;
using Dress.UI;
using UnityEngine;

public class MainScreen : MonoBehaviour
{
    public DressItemCategory[] dressItemCategories;
    public UIEventDelegate eventDelegate;
    public GameObject helpImage;
    public OpenVariousButtonList variousButtonList;

    private GameObject guideDressItem;
    private DressItemCategory lastItemCategory;
    private List<DressItem> selectedDressItems = new List<DressItem>();
    private bool isOpendItemList;
    private List<DressCategory> duplicateCategories = new List<DressCategory>();

    void Awake()
    {
        
    }

	void Start ()
	{
	    eventDelegate.itemCategoryButtonPressdEvent += PreesedDressItemCategory;
	    eventDelegate.dressListItemButtonPressdEvent += PressedDressListItem;
	    eventDelegate.trashButtonPressdEvent += PressTrashButton;
	    eventDelegate.helpButtonPressdEvent += PressHelpButton;
        eventDelegate.helpImagePressdEvent += PressHelpImage;
        eventDelegate.openVariousButtoPressdEvent += PressOpenVariousButton;
	    eventDelegate.screenShotButtonPressedEvent += PressScreenShotButton;
	    eventDelegate.playButtonPressdEvent += ClearAllItems;
	    eventDelegate.saveButtonPressedEvent += PressSaveButton;
	    

        duplicateCategories.Add(DressCategory.Acc);
        duplicateCategories.Add(DressCategory.Bottom);
	}

    private void PressSaveButton()
    {
        FileWriter.GetInstance().SaveDiaryDress(selectedDressItems);
    }

    private void PressDiaryListItemButton(DiaryListItem listitem)
    {
        ClearAllItems();

        FileLoader.DiaryDataCollection collections = FileLoader.GetInstance().GetDiaryCollection(listitem.listIndex);

        foreach (FileLoader.DiaryData diaryData in collections.GetDatas())
        {
            AttachNewDressItem((DressCategory)diaryData.category, diaryData.dressCode, false);
        }

    }

    private void PressScreenShotButton()
    {

        string fileName = "Dress" + DateTime.Now.ToString("yyMMdd_hhmmss") + ".jpg";
        string path = Platform.Instance().GetSaveScreenShotPath();

       /*byte[] imageByte;
        Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
        tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, true);
        tex.Apply();
        imageByte = tex.EncodeToJPG();
        Destroy(tex);
        File.WriteAllBytes(path + "/" + fileName, imageByte);
        */

        /*byte[] imageByte;
        RenderTexture rt = new RenderTexture(Screen.width, Screen.width, 24);
        Camera.main.targetTexture = rt;
        Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        Camera.main.Render();
        RenderTexture.active = rt;
        tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, true);
        Camera.main.targetTexture = null;
        RenderTexture.active = null;
        imageByte = tex.EncodeToJPG();
        Destroy(rt);
        File.WriteAllBytes(path + "/" + fileName, imageByte);*/


        
        /*amera camera = UICamera.currentCamera;


        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = camera.targetTexture;
        camera.Render();
        Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        tex.Apply();

        RenderTexture.active = currentRT;

        byte[] imageByte;
        imageByte = tex.EncodeToJPG();
        Destroy(tex);
        File.WriteAllBytes(path + "/" + fileName, imageByte);*/
        //File.WriteAllBytes("mnt/sdcard/DCIM/Camera/number_" + Time.time.ToString() + ".png", imageByte);
        //원하는 경로.. 저같은 경우는 저렇게 했습니다. 
        //Debug.Log(path + "/" + "Shot.png");

        /*byte[] captureScreenShot;
        Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
        tex.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0, true);
        tex.Apply();
        captureScreenShot = tex.EncodeToPNG();
        DestroyImmediate(tex);
        File.WriteAllBytes("mnt/sdcard/DCIM/Camera/" + fileName, captureScreenShot);*/

        //string theFileName = "ScreenShot.png";

        //Application.CaptureScreenshot(Application.dataPath + "_" + theFileName);
        //Application.CaptureScreenshot("../../../../DCIM/Camera/pathroot_" + theFileName);
        //Application.CaptureScreenshot("/storage/emulated/0/DCIM/Camera/" + theFileName);
        //Application.CaptureScreenshot("file:///storage/emulated/0/DCIM/Camera/" + theFileName);

        //Debug.Log(path + "/" + fileName);

        //Application.CaptureScreenshot(path + "/" + fileName);
        //System.IO.Directory.GetFiles(Application.persistentDataPath + "/../../../../DCIM/Camera/");

        Application.CaptureScreenshot(fileName);

        string Origin_Path = System.IO.Path.Combine(Application.persistentDataPath, fileName);
        // This is the path of my folder.
        string Path = path + "/" + fileName;


        Debug.Log("Origin_Path : " + Origin_Path);
        Debug.Log("path : " + Path);

        if (System.IO.File.Exists(Origin_Path))
        {
            System.IO.File.Move(Origin_Path, Path);
        }

        //sendBroadcast(new Intent(Intent.ACTION_MEDIA_MOUNTED, Uri.parse("file://" + Environment.getExternalStorageDirectory())));
    }

    private void PressOpenVariousButton()
    {
        ShowVariousButtonList();
    }

    private void ShowVariousButtonList()
    {
        variousButtonList.ToggleList();
    }

    private void PressHelpImage()
    {
        helpImage.gameObject.SetActive(false);
    }

    private void PressHelpButton()
    {
        helpImage.gameObject.SetActive(true);
    }

    private void PressTrashButton()
    {
        ClearAllItems();
    }

    private void ClearAllItems()
    {
        selectedDressItems.ForEach(x => Destroy(x.gameObject));
        selectedDressItems.Clear();
    }

    void Update () {
	}

    public void PreesedDressItemCategory(DressItemCategory dressItemCategory)
    {
        isOpendItemList = !isOpendItemList;

        foreach (DressItemCategory itemCategory in dressItemCategories)
        {
            if (itemCategory == dressItemCategory)
            {
                itemCategory.MoveItem();
                lastItemCategory = itemCategory;
            }
            else 
            {
                itemCategory.gameObject.SetActive(!isOpendItemList);
            }
        }
    }

    private void OpenDressItemList()
    {
        
    }

    public void PressedDressListItem(DressListItem listItem)
    {
        DeleteOldItem(listItem);
        AttachNewDressItem(listItem.dressCategory, listItem.dressCode);
        PreesedDressItemCategory(lastItemCategory);
    }


    public void AttachNewDressItem(DressCategory category, int dressCode, bool isAttachCreatePosition = true)
    {
        GameObject newDressItem = DressCreator.Instance.CloneDressItem(category, dressCode);
        if (newDressItem != null)
        {
            UIDragDropDressItem dragDrop = newDressItem.GetComponent<UIDragDropDressItem>();
            dragDrop.pressItemEvent += ShowGuidDressItem;
            dragDrop.dragEndItemEvent += DeleteOldGuideItem;

            DressItem dressItem = newDressItem.GetComponent<DressItem>();
            selectedDressItems.Add(dressItem);
            newDressItem.transform.parent = transform;
            if (isAttachCreatePosition)
            {
                newDressItem.transform.localPosition = dressItem.createPosition;
            }
            else
            {
                newDressItem.transform.localPosition = dragDrop.attachPosition;
            }
            newDressItem.transform.localScale = Vector3.one;
            newDressItem.GetComponent<UISprite>().depth = (int)dressItem.dressSpriteDepth;
        }
    }

    private void DeleteOldItem(DressListItem newDressItem)
    {
        if (duplicateCategories.Contains(newDressItem.dressCategory))
        {
            return;
        }

        List<DressItem> dressItems = selectedDressItems.FindAll(x => x.dressCategory == newDressItem.dressCategory);
        selectedDressItems.RemoveAll(
            x => x.dressCategory == newDressItem.dressCategory);

        dressItems.ForEach(x => Destroy(x.gameObject));
    }
    private void ShowGuidDressItem(DressItem pressedDressItem)
    {
        GameObject guideDressItem = DressCreator.Instance.CloneDressItem(pressedDressItem.dressCategory, pressedDressItem.dressCode);
        if (guideDressItem != null)
        {
            DressItem dressItem = guideDressItem.GetComponent<DressItem>();
            dressItem.transform.parent = transform;

            UIDragDropDressItem dragDrop = guideDressItem.GetComponent<UIDragDropDressItem>();
            dressItem.transform.localPosition = dragDrop.attachPosition;
            dressItem.transform.localScale = Vector3.one;
            dressItem.GetComponent<UISprite>().alpha = 0.7f;
            dressItem.GetComponent<UISprite>().depth = pressedDressItem.GetComponent<UISprite>().depth - 1;

            this.guideDressItem = guideDressItem;
        }
    }

    private void DeleteOldGuideItem(DressItem pressedDressItem)
    {
        if (guideDressItem != null)
        {
            Destroy(guideDressItem);
            guideDressItem = null;
        }
    }

    public void SetDiaryButtonEvent()
    {
        eventDelegate.diaryListItemButtonPressdEvent += PressDiaryListItemButton;
    }
}
