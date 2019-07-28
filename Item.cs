using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Item : MonoBehaviour
{

    public bool consumable = true;

    public bool Use()
    {
        ItemsMixin[] mixins = GetComponents<ItemsMixin>();
        foreach(ItemsMixin mixin in mixins)
        {
            mixin.Use();
        }
        return !consumable;
    }
}
