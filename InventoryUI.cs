using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.Events;

[System.Serializable]
public class ItemEvent : UnityEvent<Item> { }

public class InventoryUI : MonoBehaviour
{
    public ItemEvent itemSelected; // gets called when a UI ITEM button is clicked

    #region
    public Inventory inventory;  // reference to the inventory list from inventory prefab
    public Transform content;    // the transform parent for the itemUIprefabs
    public ItemUI itemUIPrefab;  // The item UI element
    public bool showPlayerInventory = false;
    #endregion

       

    void Start()
    {
        if (showPlayerInventory)
        {
            //Action<string, >
            Display(Inventory.playerInventory);
        }

        else if (inventory) Display(inventory); // if inventory is added display the items from inventory inside the content Transform
    }




    public virtual void Display(Inventory i)
    {
       if (inventory)
        {
            inventory.onChanged.RemoveListener(Refresh);
        }
        inventory = i;
        inventory.onChanged.AddListener(Refresh);
        Refresh();
    }

    public virtual void Refresh()
    {
        foreach (Transform t in content)
        {
            Destroy(t.gameObject);
        }

        foreach(Item i in inventory.Items)
        {
            ItemUI ui = Instantiate(itemUIPrefab, content);
            ui.onClicked.AddListener(UIClicked);
            ui.Display(i);
        }
        
               
    }
    


    public virtual void UIClicked(ItemUI iui)
    {
        itemSelected.Invoke(iui.item);  // referece to the item linked to the invoked ItemUI

        //Inventory.playerInventory.Add(iui.item);
        //inventory.Remove(iui.item);
        //Destroy(iui.gameObject);
    }
    
    #region UnityEventsResponders

    public void AddToPlayerInventory(Item item)
    {
        Inventory.playerInventory.Add(item);
    }

    public void RemoveFromOwnInventory(Item item)
    {
        inventory.Remove(item);
    }

    public void Use(Item item)
    {
        if (!item.Use())
        {
            RemoveFromOwnInventory(item);
        }
    }


    #endregion

}
