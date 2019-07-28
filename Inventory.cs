using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public static Inventory playerInventory;

    [SerializeField]
    private bool IsPlayerInventory = false;


    public List<Item> Items;

    public UnityEvent onChanged;

    private void Awake()
    {
        if (IsPlayerInventory) playerInventory = this;
    }



    public void Add(Item item)
    {
        Items.Add(item);
        onChanged.Invoke();
    }

    public void Remove(Item item)
    {
        if (!Items.Contains(item)) return;
        Items.Remove(item);
        onChanged.Invoke();

    }

}
