using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatchet : MonoBehaviour
{
    [SerializeField]
    public InventoryItemData itemData;



     public void test(){

        //itemData = (InventoryItemData)ScriptableObject.CreateInstance(typeof(InventoryItemData));

        if (itemData.name == "hatchet")
        {
            Debug.Log("test working");
        }


    }
}