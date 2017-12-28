namespace Scripts.Source.Crafting
{
    public class Item
    {
        public enum ItemType
        {
            MATERIAL,
            ALLOY,
            CONSUMABLE,
        }

        public string Name { get; private set; }
        public ItemType Type { get; private set; }
        public string Description { get; private set; }

        public Item(string pName, ItemType pType, string pDescr)
        {
            Name = pName;
            Type = pType;
            Description = pDescr;
        }

        /*This function is used to check and see if two instances of an object are the same instance.*/
        public static bool ItemCheck(Item item1, Item item2)
        {
            if (item1.Name == item2.Name && item1.Type == item2.Type && item1.Description == item2.Description)
                return true;
            return false;
        }
    }
}