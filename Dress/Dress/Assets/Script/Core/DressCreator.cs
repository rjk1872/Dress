using System.Collections.Generic;
using UnityEngine;

public class DressCreator  {

    private static DressCreator instance = null;
    private List<DressItem> dressItems = new List<DressItem>();

    private DressCreator()
    {

    }

    public static DressCreator Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DressCreator();
            }

            return instance;
        }
    }

    public void LoadResources()
    {
        Object[] objs = Resources.LoadAll("Object/UI/DressItems/");
        foreach (Object o in objs)
        {
            GameObject obj = o as GameObject;
            dressItems.Add((o as GameObject).GetComponent<DressItem>());
        }
    }

    public GameObject CloneDressItem(DressCategory category, int dressCode)
    {
        DressItem dressItem = dressItems.Find(x => x.dressCategory == category && x.dressCode == dressCode);
        if (dressItem != null)
        {
            GameObject cloneDressItem = Object.Instantiate(dressItem.gameObject);
            return cloneDressItem;    
        }

        return null;
    }

    public List<DressItem> GetDressItemsCategory(DressCategory category)
    {
        return dressItems.FindAll(x => x.dressCategory == category);
    }
}
