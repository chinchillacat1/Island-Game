using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(UniqueID))]
public class ItemPickUp : MonoBehaviour
{
    public float PickUpRadius = 1f;
    public InventoryItemData ItemData;


    [SerializeField] private float _rotationSpeed = 20f;

    private SphereCollider myCollider;

    [SerializeField] private ItemPickUpSaveData itemSaveData;
    private string id;
    
    private void Awake()
    {
       
        SaveLoad.OnLoadGame += LoadGame;
        itemSaveData = new ItemPickUpSaveData(ItemData, transform.position, transform.rotation);

        
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = PickUpRadius;

    }

    private void Start()
    {
        id = GetComponent<UniqueID>().ID;
        SaveGameManager.data.activeItems.Add(id, itemSaveData);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
    }

    private void LoadGame(SaveData data)
    {
        if (data.collectedItems.Contains(id)) Destroy(this.gameObject);

        
    }

    private void OnDestroy()
    {
        if (SaveGameManager.data.activeItems.ContainsKey(id)) SaveGameManager.data.activeItems.Remove(id);
        SaveLoad.OnLoadGame -= LoadGame;
    }

    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.transform.GetComponent<PlayerInventoryHolder>();
        
        if (!inventory) return;

        if (inventory.AddToInventory(ItemData, 1))
        {
            SaveGameManager.data.collectedItems.Add(id);
            Destroy(this.gameObject);
        }



    }

    public Vector3 PickPosition;
    public Vector3 PickRotation;
    private MonoBehaviour item;

    //private void Inventory_ItemUsed(object sender, EventArgs e)
    //{
    //    GameObject goItem = (item as MonoBehaviour).gameObject;
    //    goItem.SetActive(true);

    //    goItem.transform.parent = Hand.transform;
    //    goItem.transform.localPosition = (item as ItemPickUp).PickPosition;
    //    goItem.transform.localEulerAngles = (item as ItemPickUp).PickPosition;

    //}





}

[System.Serializable]
public struct ItemPickUpSaveData
{
    public InventoryItemData ItemData;
    public Vector3 Position;
    public Quaternion Rotation;

    public ItemPickUpSaveData(InventoryItemData _data, Vector3 _position, Quaternion _rotation)
    {
        ItemData = _data;
        Position = _position;
        Rotation = _rotation;
    }
}
