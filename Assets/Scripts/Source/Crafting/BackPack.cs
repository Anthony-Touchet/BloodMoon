using System.Collections;
using System.Collections.Generic;

namespace Scripts.Source.Crafting
{
    public class BackPack
    {
        public Dictionary<Item, uint> Inventory { get; private set;}

        public BackPack()
        {
            Inventory = new Dictionary<Item, uint>();
        }

        /*Add a number of value from an Item key or a new key if the key does not appear in the Inventory*/
        public bool AddItem(Item item, uint num)
        {
            var invItem = CheckInventory(item);
            if (invItem != null)
            {
                Inventory[invItem] += num;
                return true;
            }

            Inventory.Add(item, num);
            return true;
        }
        
        /*Removes a number of value from an Item key*/
        public bool SubtractItem(Item item, uint num)
        {
            var invItem = CheckInventory(item);
            if (invItem != null)
            {
                Inventory[invItem] -= num;
                CleanInventory(invItem);
                return true;
            }
            return false;
        }

        /*Removes item entirely from the Inventory*/
        public bool RemoveItem(Item item)
        {
            if (Inventory.ContainsKey(item))
            {
                Inventory.Remove(item);
                return true;
            }
            return false;
        }

        /*This method checks an item has a value of 0. If it does have a value of 0, it is removed*/
        private bool CleanInventory(Item item)
        {
            if (Inventory[item] <= 0)
            {
                Inventory.Remove(item);
                return true;
            }
            return false;
        }

        /*Checks to see if the Item is already in the list*/
        private Item CheckInventory(Item item)
        {
            foreach(var iItem in Inventory)
            {
                if (Item.ItemCheck(item, iItem.Key))
                    return iItem.Key;
            }
            return null;
        }
    }
}