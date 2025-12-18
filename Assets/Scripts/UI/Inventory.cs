using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject slotPrefab;
    public int maxSlots = 54;
    public List<ItemSlot> slots = new List<ItemSlot>();

    World world;

    private void Start()
    {
        world = GameObject.Find("World").GetComponent<World>();

        for (int i = 0; i < maxSlots; i++)
        {
            GameObject newSlot = Instantiate(slotPrefab, transform);

            ItemSlot slot = new ItemSlot(newSlot.GetComponent<UIItemSlot>());
            slot.isCreative = false;

            slots.Add(slot);
        }
    }

    public void AddItem(byte id, int amount)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].HasItem && slots[i].stack.id == id)
            {
                slots[i].AddAmount(amount);
                return;
            }
        }

        for (int i = 0; i < slots.Count; i++)
        {
            if (!slots[i].HasItem)
            {
                slots[i].InsertStack(new ItemStack(id, amount));
                return;
            }
        }
    }
}

