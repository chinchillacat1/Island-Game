using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Inventory Item/Tools")]
public class ToolsItemData : InventoryItemData
{


    public override void UseItem()
    {

        if (DisplayName == "Hatchet")
        {
            Debug.Log($"HATCHET {DisplayName}");
        }
    
    }




}
