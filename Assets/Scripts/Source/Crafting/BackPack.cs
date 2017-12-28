using System.Collections;
using System.Collections.Generic;

namespace Scripts.Source.Crafting
{
    public class BackPack
    {
        public Dictionary<Item, int> Inventory { get; private set;}
        public int ItemStackLimit { get; private set;}

        public BackPack(int limit)
        {
            Inventory = new Dictionary<Item, int>();
            ItemStackLimit = limit;
        }

        /*Add a number of value from an Item key or a new key if the key does not appear in the Inventory
            0 = New key of the item was added
            1 = Key already existed and was sucessfully added
            2 = Some was added, but the limit was reached so only up to the limit was added.
        */
        public int AddItem(Item item, int num)
        {
            Item invItem = null;

            foreach (var iItem in Inventory)
            {
                if (Item.ItemCheck(item, iItem.Key) && iItem.Value != ItemStackLimit)
                    invItem = iItem.Key;
            }

            if (invItem != null)
            {
                Inventory[invItem] += num;
                if (Inventory[invItem] > ItemStackLimit)
                {
                    ///TODO: Add overflow stack
                    Inventory[invItem] = ItemStackLimit;
                    return 2;
                }
                return 1;
            }

            Inventory.Add(item, num);
            return 0;
        }
        
        /*Removes a number of value from an Item key*/
        public bool SubtractItem(Item item, int num)
        {
            for(int i = num; i > 0;)
            {
                Item invItem = null;

                foreach (var iItem in Inventory)
                {
                    if (Item.ItemCheck(item, iItem.Key))
                        invItem = iItem.Key;
                }

                if (invItem != null)
                {
                    var oldvalue = Inventory[invItem];
                    Inventory[invItem] -= i;                   
                    i -= oldvalue;
                    CleanInventory(invItem);
                    continue;
                }
                return false;
            }
            return true;
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
    }
}