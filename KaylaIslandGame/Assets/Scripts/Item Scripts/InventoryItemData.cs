using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Inventory Item")]

public class InventoryItemData : ScriptableObject
{

    public int ID = -1;
    public string DisplayName;
    public bool displayname;
    [TextArea(4, 4)]
    public string Description;
    public Sprite Icon;
    public int MaxStackSize;
    public int GoldValue;
    public GameObject ItemPrefab;




    public virtual void UseItem()
    {

        Debug.Log($"Using {DisplayName}");
        if (DisplayName == "Hatchet")
        {
            
            Debug.Log($"This is a {DisplayName}");


        }
    }



    public void Test()
    {

        Debug.Log("test");

    }

}



