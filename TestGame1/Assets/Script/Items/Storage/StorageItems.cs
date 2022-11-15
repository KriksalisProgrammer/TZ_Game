using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Items.Storage
{
    public class StorageItems:MonoBehaviour
    {
        [SerializeField] protected List<ItemsController> _items;
        [SerializeField] private Transform _pointToMoveItem;


        [SerializeField]protected int _sizeStorageItems = 10;

        protected int _itemCount = 0;

        public ItemsController GiveItem(ItemType itemType)
        {
            if (!IsCanGiveItem(itemType)) return null;

            ItemsController item = _items.Find(x => x.ItemType == itemType);
            _items.Remove(item);

            _itemCount--;

            Offset();

            return item;
        }

        public bool IsCanTakeItem()
        {
            return _itemCount < _sizeStorageItems;
        }


        public void TakeItem(ItemsController item)
        {


            item.SetMove(_pointToMoveItem, this, ItemPositionOffset(_itemCount));

            _itemCount++;

            Offset();
        }

        protected virtual Vector3 ItemPositionOffset(int itemsCount)
        {
            return new Vector3(itemsCount % 5, 0, itemsCount / 5);
        }

        public void MoveToStorage(ItemsController item)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
                Offset();
            }
        }

        private void Offset()
        {
            int count = 0;
            foreach (ItemsController item in _items)
            {
                item.SetMove(_pointToMoveItem, this, ItemPositionOffset(count));
                count++;
            }
        }
        public bool IsCanGiveItem()
        {
            return _items.Count > 0;
        }
        public bool IsCanGiveItem(ItemType itemType)
        {
            return _items.Exists(x => x.ItemType == itemType);
        }

        public ItemsController GiveItem()
        {
            if (!IsCanGiveItem()) return null;


            ItemsController item = _items[_items.Count - 1];
            _items.RemoveAt(_items.Count - 1);

            _itemCount--;

            Offset();

            return item;
        }
    }
}
