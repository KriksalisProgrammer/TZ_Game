using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Items.Storage
{
    public class ItemMoveFrom :ItemsTriger
    {

        [SerializeField] private List<ItemType> _itemTypes;

        public override bool TriggerMove(StorageItems inventory)
    {
        foreach (ItemType itemType in _itemTypes)
        {
            if (_Store.IsCanTakeItem() && inventory.IsCanGiveItem(itemType))
            {
                _Store.TakeItem(inventory.GiveItem(itemType));
                return true;
            }
        }

        return false;
    }
}
}
