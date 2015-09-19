using UnityEngine;
using System.Collections;

public class ResourceLoader : Singleton<ResourceLoader> {

    private const int DIARY_ITEM_COUNT = 40;

    private ResourceLoader()
    {
        
    }
    public DiaryListItem[] LoadDiaryItems()
    {
        DiaryListItem[] items = new DiaryListItem[DIARY_ITEM_COUNT];

        for (int i = 0; i < DIARY_ITEM_COUNT; ++i)
        {
            GameObject obj = Object.Instantiate(Resources.Load("Object/UI/DiaryListItem") as GameObject);
            items[i] = obj.GetComponent<DiaryListItem>();
        }

        return items;
    }
}
