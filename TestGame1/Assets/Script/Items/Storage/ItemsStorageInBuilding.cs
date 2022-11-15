using System.Collections.Generic;

namespace Assets.Script.Items.Storage
{
    public class ItemsStorageInBuilding:StorageItems
    {
        public bool IsCompleteMove(List<ItemType> itemTypes)
        {
            foreach (ItemType itemType in itemTypes)
            {
                if (!IsCanGiveItem(itemType))
                    return false;
            }

            return true;
        }
        public void DestroyAllItems()
        {
            foreach (ItemsController item in _items)
            {
                Destroy(item.gameObject);
            }

            _itemCount = 0;
            _items.Clear();
        }
       
    }
}
